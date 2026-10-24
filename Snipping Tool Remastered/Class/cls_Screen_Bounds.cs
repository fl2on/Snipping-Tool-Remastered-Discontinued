using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snipping_Tool_Remastered
{
    internal class Screen_Bounds
    {
        public static Rectangle bounds;

        public static void load()
        {
            // Refresh the complete virtual desktop, including negative monitor origins.
            // The process manifest enables physical-pixel, per-monitor DPI coordinates.
            Rectangle automatic = SystemInformation.VirtualScreen;
            string[] parts = (cls_Settings.screen_res ?? "").Split(',');
            int x, y, width, height;
            bounds = parts.Length == 4 &&
                int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y) &&
                int.TryParse(parts[2], out width) && int.TryParse(parts[3], out height) &&
                width > 0 && height > 0
                ? new Rectangle(x, y, width, height)
                : automatic;
        }

        public static String reset()
        {
            Rectangle rect = SystemInformation.VirtualScreen;
            return String.Format(System.Globalization.CultureInfo.InvariantCulture,
                "{0},{1},{2},{3}", rect.Left, rect.Top, rect.Width, rect.Height);
        }
    }
}
