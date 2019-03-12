using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ActiveButtons.Utils
{
    internal static class ColorHelper
    {
        public static Color ChangeLightness(this Color color, float lightness)
        {
            return Color.FromArgb(
                (byte)255,
                (byte)(Math.Max(0, Math.Min(color.R * lightness, 255))),
                (byte)(Math.Max(0, Math.Min(color.G * lightness, 255))),
                (byte)(Math.Max(0, Math.Min(color.B * lightness, 255))));
        }
        public static Color Lerp(this Color color, Color to, float amount)
        {
            return Color.FromArgb(
                (byte)(color.R + (to.R - color.R) * amount),
                (byte)(color.G + (to.G - color.G) * amount),
                (byte)(color.B + (to.B - color.B) * amount));
        }
    }
}
