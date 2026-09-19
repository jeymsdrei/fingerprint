using System;
using System.Drawing;
using System.Windows.Forms;
using Demo.UI;

namespace Demo.Controls
{
    public enum ScannerState
    {
        Idle,
        Scanning,
        Verified,
        Failed
    }

    public class FingerprintPanel : RoundedPanel
    {
        private ScannerState _scannerState = ScannerState.Idle;
        private string _statusText = "Ready";
        private Color _statusColor = Color.FromArgb(148, 163, 184);

        public FingerprintPanel()
        {
            BorderRadius = 14;
            BackColor = Color.FromArgb(30, 41, 59);
            BorderColor = Color.FromArgb(51, 65, 85);
            BorderWidth = 2;
            Size = new Size(320, 380);
        }

        public ScannerState ScannerState
        {
            get { return _scannerState; }
            set
            {
                _scannerState = value;
                UpdateStatusColor();
                Invalidate();
            }
        }

        public string StatusText
        {
            get { return _statusText; }
            set
            {
                _statusText = value;
                Invalidate();
            }
        }

        public Color StatusColor
        {
            get { return _statusColor; }
        }

        private void UpdateStatusColor()
        {
            switch (_scannerState)
            {
                case ScannerState.Scanning:
                    _statusColor = Color.FromArgb(0, 163, 255);
                    break;
                case ScannerState.Verified:
                    _statusColor = Color.FromArgb(0, 230, 118);
                    break;
                case ScannerState.Failed:
                    _statusColor = Color.FromArgb(255, 82, 82);
                    break;
                default:
                    _statusColor = Color.FromArgb(148, 163, 184);
                    break;
            }
        }
    }
}
