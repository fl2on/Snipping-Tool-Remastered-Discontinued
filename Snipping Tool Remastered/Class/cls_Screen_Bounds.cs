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
            bounds = SystemInformation.VirtualScreen;
        }

        public static String reset()
        {
            Rectangle rect = SystemInformation.VirtualScreen;
            return String.Format(System.Globalization.CultureInfo.InvariantCulture,
                "{0},{1},{2},{3}", rect.Left, rect.Top, rect.Width, rect.Height);
        }
    }
}
