using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Demo.UI;

namespace Demo.Controls
{
    public class RoundedButton : Button
    {
        private int _borderRadius = 10;
        private Color _normalColor = Color.FromArgb(0, 163, 255);
        private Color _hoverColor = Color.FromArgb(0, 130, 220);
        private Color _pressColor = Color.FromArgb(0, 90, 180);
        private bool _isHovered = false;
        private bool _isPressed = false;
        private bool _neonGlow = false;

        public RoundedButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Cursor = Cursors.Hand;
            Size = new Size(130, 44);
        }

        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); }
        }

        public Color NormalColor
        {
            get { return _normalColor; }
            set { _normalColor = value; Invalidate(); }
        }

        public Color HoverColor
        {
            get { return _hoverColor; }
            set { _hoverColor = value; Invalidate(); }
        }

        public Color PressColor
        {
            get { return _pressColor; }
            set { _pressColor = value; Invalidate(); }
        }

        public bool NeonGlow
        {
            get { return _neonGlow; }
            set { _neonGlow = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Color bgColor = _isPressed ? _pressColor : (_isHovered ? _hoverColor : _normalColor);

            using (GraphicsPath path = GetRoundedPath(ClientRectangle, _borderRadius))
            {
                Region = new Region(path);

                using (LinearGradientBrush gradient = new LinearGradientBrush(
                    ClientRectangle, bgColor, ControlPaint.Dark(bgColor, 0.15f), LinearGradientMode.Vertical))
                {
                    e.Graphics.FillPath(gradient, path);
                }

                if (_neonGlow && _isHovered)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        using (Pen glow = new Pen(Color.FromArgb(60 - i * 20, ThemeManager.Primary), 3 + i * 2))
                        {
                            e.Graphics.DrawPath(glow, path);
                        }
                    }
                }

                if (_isHovered && !_isPressed)
                {
                    using (SolidBrush highlight = new SolidBrush(Color.FromArgb(40, Color.White)))
                    {
                        e.Graphics.FillPath(highlight, path);
                    }
                }

                Color textColor = Enabled ? ForeColor : Color.FromArgb(100, 100, 100);
                TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);
            rect.Width--; rect.Height--;

            if (r <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Cursor = Cursors.Hand;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            _isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _isPressed = true;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isPressed = false;
            Invalidate();
        }
    }
}
