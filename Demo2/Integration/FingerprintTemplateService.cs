using System;
using System.Collections.Generic;
using libzkfpcsharp;

namespace Demo.Integration
{
    /// <summary>
    /// Template backup/restore against the HRIS server.
    ///
    /// Templates enrolled on the reader are pushed to the server during
    /// capture ("source of truth"). After a reader wipe or a lost local
    /// copy (e.g. a laptop agent was reset), the server-held templates are
    /// re-registered onto the reader so reactivated employees are recognized
    /// again without scanning their finger.
    /// </summary>
    public class FingerprintTemplateService
    {
        private readonly HrisApiClient _api;
        private readonly Data.DatabaseHelper _db;

        public FingerprintTemplateService(HrisApiClient api, Data.DatabaseHelper db)
        {
            _api = api;
            _db = db;
        }

        /// <summary>
        /// Persist an enrolled template to the HRIS server. Employees that are
        /// later deactivated keep their template server-side and are simply not
        /// included in the restore list (lock, not delete).
        /// </summary>
        public bool PushTemplate(Data.FingerprintRecord record, out string error)
        {
            error = null;
            if (record == null || string.IsNullOrEmpty(record.TemplateBase64))
                return true;
            return _api.SaveTemplate(record.FingerprintID, record.TemplateBase64, out error);
        }

        /// <summary>
        /// Re-register every server template that is currently missing from the
        /// reader DB. Only active employees are returned by the server, so
        /// deactivated fingerprints stay locked out. Returns the count restored.
        /// </summary>
        public int RestoreMissingTemplates(IntPtr mDBHandle)
        {
            if (mDBHandle == IntPtr.Zero)
                return 0;

            List<Data.FingerprintRecord> templates = _api.GetTemplates(out string error);
            if (templates == null)
            {
                Data.FingerprintLogger.Warning("Template restore failed: " + (error ?? "no templates returned"));
                return 0;
            }

            int restored = 0;
            foreach (Data.FingerprintRecord rec in templates)
            {
                if (string.IsNullOrEmpty(rec.TemplateBase64))
                    continue;
                if (_db.FindFingerprintByFid(rec.FingerprintID) != null)
                    continue;

                byte[] blob = zkfp2.Base64ToBlob(rec.TemplateBase64);
                if (blob == null || blob.Length == 0)
                    continue;

                if (zkfp.ZKFP_ERR_OK == zkfp2.DBAdd(mDBHandle, rec.FingerprintID, blob))
                {
                    _db.AddFingerprint(rec);
                    restored++;
                }
            }

            if (restored > 0)
                _db.SaveFingerprints();

            return restored;
        }
    }
}