using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Demo.Controls;

namespace Demo.UI
{
    public enum AppTheme
    {
        Light,
        Dark,
        Cyber
    }

    public static class ThemeManager
    {
        public static AppTheme CurrentTheme { get; private set; }

        public static Color Primary { get; private set; }
        public static Color Secondary { get; private set; }
        public static Color Accent { get; private set; }
        public static Color Bg { get; private set; }
        public static Color Card { get; private set; }
        public static Color CardHover { get; private set; }
        public static Color Success { get; private set; }
        public static Color Warning { get; private set; }
        public static Color Error { get; private set; }
        public static Color TextPrimary { get; private set; }
        public static Color TextSecondary { get; private set; }
        public static Color Border { get; private set; }
        public static Color GlassBg { get; private set; }

        private static List<Color> _semantic = new List<Color>();

        static ThemeManager()
        {
            ApplyPalette(AppTheme.Cyber);
            BuildSemantic(null);
        }

        public static Color HexToColor(string hex)
        {
            int argb = int.Parse(hex.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(argb | unchecked((int)0xFF000000));
        }

        public static void ApplyTheme(Form form, AppTheme theme)
        {
            List<Color> oldSemantic = new List<Color>(_semantic);
            CurrentTheme = theme;
            ApplyPalette(theme);
            BuildSemantic(oldSemantic);

            if (form != null && !form.IsDisposed)
                Recolor(form);
        }

        private static void BuildSemantic(List<Color> previous)
        {
            _semantic = new List<Color>();
            _semantic.Add(Primary);
            _semantic.Add(Secondary);
            _semantic.Add(Accent);
            _semantic.Add(Success);
            _semantic.Add(Warning);
            _semantic.Add(Error);
            if (previous != null)
            {
                foreach (Color c in previous)
                    if (!_semantic.Contains(c)) _semantic.Add(c);
            }
        }

        private static void ApplyPalette(AppTheme theme)
        {
            if (theme == AppTheme.Light)
            {
                Primary = Color.FromArgb(37, 99, 235);
                Secondary = Color.FromArgb(59, 130, 246);
                Accent = Color.FromArgb(14, 116, 144);
                Bg = Color.FromArgb(243, 244, 246);
                Card = Color.White;
                CardHover = Color.FromArgb(241, 245, 249);
                Success = Color.FromArgb(22, 163, 74);
                Warning = Color.FromArgb(217, 119, 6);
                Error = Color.FromArgb(220, 38, 38);
                TextPrimary = Color.FromArgb(17, 24, 39);
                TextSecondary = Color.FromArgb(75, 85, 99);
                Border = Color.FromArgb(229, 231, 235);
                GlassBg = Color.White;
            }
            else if (theme == AppTheme.Dark)
            {
                Primary = Color.FromArgb(88, 166, 255);
                Secondary = Color.FromArgb(110, 180, 255);
                Accent = Color.FromArgb(165, 213, 255);
                Bg = Color.FromArgb(13, 17, 23);
                Card = Color.FromArgb(22, 27, 34);
                CardHover = Color.FromArgb(33, 38, 45);
                Success = Color.FromArgb(63, 185, 80);
                Warning = Color.FromArgb(210, 153, 34);
                Error = Color.FromArgb(248, 81, 73);
                TextPrimary = Color.White;
                TextSecondary = Color.FromArgb(139, 148, 158);
                Border = Color.FromArgb(48, 54, 61);
                GlassBg = Color.FromArgb(22, 27, 34);
            }
            else
            {
                Primary = Color.FromArgb(0, 163, 255);
                Secondary = Color.FromArgb(0, 212, 255);
                Accent = Color.FromArgb(0, 255, 198);
                Bg = Color.FromArgb(15, 23, 42);
                Card = Color.FromArgb(30, 41, 59);
                CardHover = Color.FromArgb(40, 55, 75);
                Success = Color.FromArgb(0, 230, 118);
                Warning = Color.FromArgb(255, 193, 7);
                Error = Color.FromArgb(255, 82, 82);
                TextPrimary = Color.White;
                TextSecondary = Color.FromArgb(203, 213, 225);
                Border = Color.FromArgb(51, 65, 85);
                GlassBg = Color.FromArgb(30, 41, 59);
            }
        }

        public static Color GetCardColor()
        {
            return Card;
        }

        public static Color GetCardHoverColor()
        {
            return CardHover;
        }

        private static Color Darken(Color c, int amount)
        {
            return Color.FromArgb(
                Math.Max(0, c.R - amount),
                Math.Max(0, c.G - amount),
                Math.Max(0, c.B - amount));
        }

        private static bool Same(Color a, Color b)
        {
            return a.R == b.R && a.G == b.G && a.B == b.B;
        }

        private static bool IsSemantic(Color c)
        {
            foreach (Color s in _semantic)
                if (Same(c, s)) return true;
            return false;
        }

        private static void Recolor(Control root)
        {
            Form f = root as Form;
            if (f != null) f.BackColor = Bg;

            foreach (Control c in root.Controls)
                RecolorChild(c);
        }

        private static void RecolorChild(Control c)
        {
            if (c.Name != null && c.Name.ToLower().Contains("toast"))
                return;

            if (c is DataGridView)
            {
                DataGridView g = (DataGridView)c;
                g.BackgroundColor = Card;
                g.GridColor = Border;
                g.ColumnHeadersDefaultCellStyle.BackColor = Card;
                g.ColumnHeadersDefaultCellStyle.ForeColor = TextSecondary;
                g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Card;
                g.DefaultCellStyle.BackColor = Card;
                g.DefaultCellStyle.ForeColor = TextPrimary;
                g.DefaultCellStyle.SelectionBackColor = Primary;
                g.DefaultCellStyle.SelectionForeColor = Color.White;
                g.AlternatingRowsDefaultCellStyle.BackColor = Darken(Card, 8);
                g.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
                g.AlternatingRowsDefaultCellStyle.SelectionBackColor = Primary;
                g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (c is TextBox)
            {
                c.BackColor = Bg;
                c.ForeColor = TextPrimary;
            }
            else if (c is ComboBox)
            {
                c.BackColor = Bg;
                c.ForeColor = TextPrimary;
            }
            else if (c is NavigationButton)
            {
                NavigationButton nb = (NavigationButton)c;
                nb.ForeColor = nb.IsActive ? Primary : TextSecondary;
            }
            else if (c is Label)
            {
                Label l = (Label)c;
                if (!IsSemantic(l.ForeColor))
                    l.ForeColor = TextPrimary;
            }
            else if (c is RoundedPanel)
            {
                RoundedPanel rp = (RoundedPanel)c;
                rp.BackColor = Card;
                rp.BorderColor = Border;
            }
            else if (c is Panel)
            {
                c.BackColor = Bg;
            }

            foreach (Control child in c.Controls)
                RecolorChild(child);
        }
    }
}
