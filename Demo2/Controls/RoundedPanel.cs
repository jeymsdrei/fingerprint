using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Demo.UI;

namespace Demo.Controls
{
    public class RoundedPanel : Panel
    {
        private int _borderRadius = 12;
        private Color _borderColor = Color.FromArgb(51, 65, 85);
        private int _borderWidth = 1;
        private bool _drawBorder = true;
        private bool _glassEffect = false;
        private bool _glowBorder = false;
        private Color _glowColor = Color.FromArgb(0, 163, 255);
        private float _glowIntensity = 0.3f;

        public RoundedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = ThemeManager.Card;
            Font = new Font("Segoe UI", 9);
        }

        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; Invalidate(); }
        }

        public bool DrawBorder
        {
            get { return _drawBorder; }
            set { _drawBorder = value; Invalidate(); }
        }

        public bool GlassEffect
        {
            get { return _glassEffect; }
            set { _glassEffect = value; Invalidate(); }
        }

        public bool GlowBorder
        {
            get { return _glowBorder; }
            set { _glowBorder = value; Invalidate(); }
        }

        public Color GlowColor
        {
            get { return _glowColor; }
            set { _glowColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (GraphicsPath path = GetRoundedPath(ClientRectangle, _borderRadius))
            {
                Region = new Region(path);

                if (_glassEffect)
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, ThemeManager.GlassBg)))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (SolidBrush highlight = new SolidBrush(Color.FromArgb(30, Color.White)))
                    {
                        Rectangle topHalf = new Rectangle(0, 0, Width, Height / 2);
                        using (GraphicsPath topPath = GetRoundedPath(topHalf, _borderRadius))
                        {
                            e.Graphics.FillPath(highlight, topPath);
                        }
                    }
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                if (_drawBorder && _borderWidth > 0)
                {
                    using (Pen pen = new Pen(_borderColor, _borderWidth))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                if (_glowBorder)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int alpha = (int)(_glowIntensity * 40 - i * 10);
                        if (alpha > 0)
                        {
                            using (Pen glow = new Pen(Color.FromArgb(alpha, _glowColor), 2 + i * 2))
                            {
                                e.Graphics.DrawPath(glow, path);
                            }
                        }
                    }
                }
            }
        }

        protected GraphicsPath GetRoundedPath(Rectangle rect, int radius)
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
    }
}
