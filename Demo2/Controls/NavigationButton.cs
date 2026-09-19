using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Demo.UI;

namespace Demo.Controls
{
    public class NavigationButton : Button
    {
        private bool _isActive = false;
        private Color _activeColor = Color.FromArgb(0, 163, 255);
        private Color _activeBgColor = Color.FromArgb(30, 50, 80);
        private Color _normalBgColor = Color.FromArgb(20, 30, 50);
        private Color _hoverBgColor = Color.FromArgb(25, 40, 65);
        private bool _isHovered = false;
        private string _navLabel = "";

        public NavigationButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            ForeColor = Color.FromArgb(148, 163, 184);
            Font = new Font("Segoe UI", 10, FontStyle.Regular);
            Cursor = Cursors.Hand;
            Size = new Size(200, 46);
            TextAlign = ContentAlignment.MiddleLeft;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            ImageAlign = ContentAlignment.MiddleLeft;
            Padding = new Padding(20, 0, 0, 0);
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                ForeColor = value ? Color.White : (_isHovered ? Color.FromArgb(200, 210, 225) : Color.FromArgb(148, 163, 184));
                Font = new Font("Segoe UI", 10, value ? FontStyle.Bold : FontStyle.Regular);
                Invalidate();
            }
        }

        public string NavLabel
        {
            get { return _navLabel; }
            set { _navLabel = value; Invalidate(); }
        }

        public Color ActiveColor
        {
            get { return _activeColor; }
            set { _activeColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Color bgColor = _isActive ? _activeBgColor : (_isHovered ? _hoverBgColor : _normalBgColor);

            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 8;
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(0, Height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                if (_isActive)
                {
                    using (SolidBrush accentBrush = new SolidBrush(_activeColor))
                    {
                        e.Graphics.FillRectangle(accentBrush, 0, 8, 3, Height - 16);
                    }
                }
            }

            int iconSize = 20;
            int iconX = 18;
            int iconY = (Height - iconSize) / 2;

            Color iconColor = _isActive ? _activeColor : (_isHovered ? Color.FromArgb(180, 200, 230) : Color.FromArgb(100, 120, 150));
            using (Pen iconPen = new Pen(iconColor, 2.5f))
            {
                iconPen.StartCap = LineCap.Round;
                iconPen.EndCap = LineCap.Round;
                DrawNavIcon(e.Graphics, iconPen, iconX, iconY, iconSize);
            }

            int textX = iconX + iconSize + 14;
            TextRenderer.DrawText(e.Graphics, Text, Font,
                new Rectangle(textX, 0, Width - textX - 10, Height),
                ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
        }

        private void DrawNavIcon(Graphics g, Pen pen, int x, int y, int size)
        {
            string text = Text.ToLower();
            int cx = x + size / 2;
            int cy = y + size / 2;

            if (text.Contains("dash"))
            {
                g.DrawRectangle(pen, x + 2, y + 4, size - 4, size - 8);
                g.DrawLine(pen, x + 2, cy, x + size - 2, cy);
                g.DrawLine(pen, cx, y + 4, cx, y + size - 4);
                g.DrawRectangle(pen, cx + 2, cy + 2, size / 2 - 4, size / 2 - 4);
            }
            else if (text.Contains("attendance") || text.Contains("clock"))
            {
                g.DrawEllipse(pen, x + 2, y + 2, size - 4, size - 4);
                g.DrawLine(pen, cx, cy, cx, y + 4);
                g.DrawLine(pen, cx, cy, x + size - 6, cy);
                g.FillEllipse(new SolidBrush(pen.Color), cx - 2, cy - 2, 4, 4);
            }
            else if (text.Contains("register"))
            {
                g.DrawEllipse(pen, x + 3, y + 2, size - 6, size - 6);
                g.DrawLine(pen, cx, cy + 2, cx, y + size - 3);
                g.DrawLine(pen, cx - 5, cy + 7, cx + 5, cy + 7);
            }
            else if (text.Contains("history"))
            {
                g.DrawRectangle(pen, x + 2, y + 4, size - 4, size - 8);
                for (int i = 0; i < 3; i++)
                    g.DrawLine(pen, x + 6, y + 8 + i * 5, x + size - 6, y + 8 + i * 5);
            }
            else if (text.Contains("device"))
            {
                g.DrawRectangle(pen, x + 2, y + 3, size - 4, size - 6);
                g.DrawEllipse(pen, cx - 4, cy - 3, 8, 8);
                g.DrawLine(pen, cx, cy + 5, cx, y + size - 4);
            }
            else if (text.Contains("setting"))
            {
                g.DrawEllipse(pen, x + 2, y + 2, size - 4, size - 4);
                g.DrawEllipse(pen, x + 5, y + 5, size - 10, size - 10);
                g.DrawLine(pen, cx, y + 1, cx, y + 5);
                g.DrawLine(pen, cx, y + size - 5, cx, y + size - 1);
            }
            else
            {
                g.DrawRectangle(pen, x + 3, y + 2, size - 6, size - 4);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            if (!_isActive) ForeColor = Color.FromArgb(200, 210, 225);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            if (!_isActive) ForeColor = Color.FromArgb(148, 163, 184);
            Invalidate();
        }
    }
}
