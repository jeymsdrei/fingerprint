using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Demo.Integration
{
    public class HrisPushRecord
    {
        public int fingerprint_id { get; set; }
        public string punch_time { get; set; }
        public string source_key { get; set; }
        public string action { get; set; }
    }

    public class HrisResponse
    {
        public bool Ok { get; set; }
        public int Imported { get; set; }
        public bool Registered { get; set; }
        public int? FingerprintId { get; set; }
        public string Error { get; set; }
    }

    /// <summary>
    /// Minimal REST client for the HRIS biometric device API.
    /// Uses HttpWebRequest (the only option on .NET 3.5). Never logs the
    /// API token or payload secrets.
    /// </summary>
    public class HrisApiClient
    {
        private readonly string _baseUrl;
        private readonly string _token;
        private readonly JavaScriptSerializer _json;

        public HrisApiClient(string baseUrl, string token)
        {
            _baseUrl = (baseUrl ?? string.Empty).TrimEnd('/');
            _token = token ?? string.Empty;
            _json = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
        }

        public bool IsConfigured
        {
            get { return _baseUrl.Length > 0; }
        }

        public bool RegisterAgent(string agentId, string agentName, string computerName, string apiBaseUrl, out string error)
        {
            var body = new Dictionary<string, object>
            {
                { "token", _token },
                { "agent_id", agentId },
                { "name", agentName },
                { "computer_name", computerName },
                { "api_base_url", apiBaseUrl },
            };
            return Post("device/register", body, out error);
        }

        public bool Heartbeat(string agentId, out string error)
        {
            var body = new Dictionary<string, object>
            {
                { "token", _token },
                { "agent_id", agentId },
            };
            return Post("device/heartbeat", body, out error);
        }

        public HrisResponse Push(string agentId, List<HrisPushRecord> records)
        {
            var resp = new HrisResponse();
            try
            {
                var body = new Dictionary<string, object>
                {
                    { "token", _token },
                    { "agent_id", agentId },
                    { "records", records },
                };
                string responseText = Request("device/push", body, "POST");
                var parsed = _json.Deserialize<Dictionary<string, object>>(responseText);
                resp.Ok = true;
                resp.Imported = ConvertToInt(Get(parsed, "imported"));
                return resp;
            }
            catch (WebException ex)
            {
                resp.Ok = false;
                resp.Error = Describe(ex);
                return resp;
            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Error = ex.Message;
                return resp;
            }
        }

        public HrisResponse GetEmployees(out List<Dictionary<string, object>> employees)
        {
            employees = new List<Dictionary<string, object>>();
            var resp = new HrisResponse();
            try
            {
                string responseText = Request("device/employees?token=" + Uri.EscapeDataString(_token), null, "GET");
                var parsed = _json.Deserialize<Dictionary<string, object>>(responseText);
                if (parsed != null && parsed.ContainsKey("employees"))
                {
                    // .NET 3.5 JavaScriptSerializer returns ArrayList (not object[]),
                    // so cast to IList to handle both representations.
                    var list = parsed["employees"] as System.Collections.IList;
                    if (list != null)
                    {
                        foreach (object item in list)
                        {
                            var dict = item as Dictionary<string, object>;
                            if (dict != null) employees.Add(dict);
                        }
                    }
                }
                resp.Ok = true;
                return resp;
            }
            catch (WebException ex)
            {
                resp.Ok = false;
                resp.Error = Describe(ex);
                return resp;
            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Error = ex.Message;
                return resp;
            }
        }

        public HrisResponse AssignFingerprint(string employeeId)
        {
            var resp = new HrisResponse();
            try
            {
                var body = new Dictionary<string, object>
                {
                    { "token", _token },
                    { "employee_id", employeeId },
                };
                string responseText = Request("device/assign-fingerprint", body, "POST");
                var parsed = _json.Deserialize<Dictionary<string, object>>(responseText);
                resp.Ok = ConvertToBool(Get(parsed, "ok"));
                int? fid = GetInt(parsed, "fingerprint_id");
                if (fid.HasValue) resp.FingerprintId = fid;
                if (parsed != null && parsed.ContainsKey("error"))
                    resp.Error = Convert.ToString(Get(parsed, "error"));
                return resp;
            }
            catch (WebException ex)
            {
                resp.Ok = false;
                resp.Error = Describe(ex);
                return resp;
            }
            catch (Exception ex)
            {
                resp.Ok = false;
                resp.Error = ex.Message;
                return resp;
            }
        }

        private bool Post(string endpoint, Dictionary<string, object> body, out string error)
        {
            error = null;
            try
            {
                Request(endpoint, body, "POST");
                return true;
            }
            catch (WebException ex)
            {
                error = Describe(ex);
                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private string Request(string endpoint, Dictionary<string, object> body, string method)
        {
            string url = _baseUrl + "/" + endpoint;
            if (string.IsNullOrEmpty(method)) method = "POST";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = method;
            req.UserAgent = "HrisBiometricAgent/1.0 (.NET 3.5)";
            req.Timeout = 10000;
            req.ReadWriteTimeout = 10000;

            if (method == "POST")
            {
                req.ContentType = "application/json; charset=utf-8";
                string json = _json.Serialize(body);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                req.ContentLength = bytes.Length;
                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                if ((int)resp.StatusCode < 200 || (int)resp.StatusCode >= 300)
                {
                    throw new WebException("HTTP " + (int)resp.StatusCode);
                }
                using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static object Get(Dictionary<string, object> dict, string key)
        {
            if (dict == null) return null;
            object value;
            return dict.TryGetValue(key, out value) ? value : null;
        }

        private static int ConvertToInt(object value)
        {
            if (value == null) return 0;
            try { return Convert.ToInt32(value); }
            catch { return 0; }
        }

        private static bool ConvertToBool(object value)
        {
            if (value == null) return false;
            try { return Convert.ToBoolean(value); }
            catch { return false; }
        }

        private static int? GetInt(Dictionary<string, object> dict, string key)
        {
            object value = Get(dict, key);
            if (value == null) return null;
            try { return Convert.ToInt32(value); }
            catch { return null; }
        }

        private static string Describe(WebException ex)
        {
            if (ex.Response != null)
            {
                using (HttpWebResponse resp = (HttpWebResponse)ex.Response)
                {
                    if ((int)resp.StatusCode == 401) return "Unauthorized (check ApiToken in hris.config)";
                    if ((int)resp.StatusCode == 404) return "Endpoint not found (check ApiBaseUrl)";
                }
            }
            return ex.Message;
        }
    }
}