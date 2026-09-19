using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo.UI
{
    public class ToastNotification
    {
        public enum ToastType
        {
            Success,
            Error,
            Warning,
            Info
        }

        private Form _owner;
        private Panel _toastPanel;
        private Label _toastLabel;
        private Timer _showTimer;
        private Timer _fadeTimer;
        private float _opacity = 1f;

        public ToastNotification(Form owner)
        {
            _owner = owner;

            _toastPanel = new Panel();
            _toastPanel.Height = 45;
            _toastPanel.BackColor = Color.FromArgb(50, 50, 55);
            _toastPanel.Visible = false;

            _toastLabel = new Label();
            _toastLabel.ForeColor = Color.White;
            _toastLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            _toastLabel.TextAlign = ContentAlignment.MiddleCenter;
            _toastLabel.Dock = DockStyle.Fill;
            _toastPanel.Controls.Add(_toastLabel);

            _showTimer = new Timer();
            _showTimer.Interval = 2500;
            _showTimer.Tick += (s, e) => StartFadeOut();

            _fadeTimer = new Timer();
            _fadeTimer.Interval = 30;
            _fadeTimer.Tick += OnFadeTick;
        }

        public void Show(string message)
        {
            Show(message, ToastType.Info);
        }

        public void Show(string message, ToastType type)
        {
            if (_owner == null || _owner.IsDisposed)
                return;

            Color bgColor;
            switch (type)
            {
                case ToastType.Success:
                    bgColor = Color.FromArgb(40, 180, 100);
                    break;
                case ToastType.Error:
                    bgColor = Color.FromArgb(220, 60, 60);
                    break;
                case ToastType.Warning:
                    bgColor = Color.FromArgb(240, 160, 30);
                    break;
                default:
                    bgColor = Color.FromArgb(50, 50, 55);
                    break;
            }

            _toastPanel.BackColor = bgColor;
            _toastLabel.Text = message;
            _toastPanel.Width = _owner.ClientSize.Width - 80;
            _toastPanel.Left = (_owner.ClientSize.Width - _toastPanel.Width) / 2;
            _toastPanel.Top = 10;
            _toastPanel.Visible = true;
            _toastPanel.BringToFront();
            _opacity = 1f;

            if (!_owner.Controls.Contains(_toastPanel))
            {
                _owner.Controls.Add(_toastPanel);
                _owner.Controls.SetChildIndex(_toastPanel, 0);
            }

            _showTimer.Stop();
            _showTimer.Start();
        }

        private void StartFadeOut()
        {
            _showTimer.Stop();
            _fadeTimer.Start();
        }

        private void OnFadeTick(object sender, EventArgs e)
        {
            _opacity -= 0.05f;
            if (_opacity <= 0f)
            {
                _fadeTimer.Stop();
                _toastPanel.Visible = false;
                _opacity = 1f;
                return;
            }
        }

        public void Dismiss()
        {
            _showTimer.Stop();
            _fadeTimer.Stop();
            _toastPanel.Visible = false;
        }
    }
}
