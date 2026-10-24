using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;

namespace Snipping_Tool_Remastered
{
internal static class Screen_Capture
{
    [StructLayout(LayoutKind.Sequential)]
    private struct POINT { public int X; public int Y; }
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT { public int Left; public int Top; public int Right; public int Bottom; }
    [StructLayout(LayoutKind.Sequential)]
    private struct CURSORINFO { public int cbSize; public int flags; public IntPtr hCursor; public POINT ptScreenPos; }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorInfo(out CURSORINFO info);
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool DrawIconEx(IntPtr hdc, int x, int y, IntPtr icon, int width, int height, int step, IntPtr brush, int flags);
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowRect(IntPtr hwnd, out RECT bounds);

    public static Bitmap region(Rectangle area, bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
    {
        if (area.Width <= 0 || area.Height <= 0)
            throw new ArgumentOutOfRangeException(nameof(area), "The capture region must have positive dimensions.");

        Bitmap bitmap = new Bitmap(area.Width, area.Height, pixel_format);
        try
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(area.Location, Point.Empty, area.Size, CopyPixelOperation.SourceCopy);
                if (cursor)
                {
                    CURSORINFO info = new CURSORINFO { cbSize = Marshal.SizeOf(typeof(CURSORINFO)) };
                    if (GetCursorInfo(out info) && (info.flags & 1) != 0)
                    {
                        IntPtr hdc = graphics.GetHdc();
                        try
                        {
                            if (!DrawIconEx(hdc, info.ptScreenPos.X - area.X, info.ptScreenPos.Y - area.Y, info.hCursor, 0, 0, 0, IntPtr.Zero, 3))
                                throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                        finally { graphics.ReleaseHdc(hdc); }
                    }
                }
            }
            return bitmap;
        }
        catch
        {
            bitmap.Dispose();
            throw;
        }
    }

    public static Bitmap screen(bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
    {
        return region(Screen.PrimaryScreen.Bounds, cursor, pixel_format);
    }

    public static Bitmap window(bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
    {
        RECT rect;
        IntPtr hwnd = GetForegroundWindow();
        if (hwnd == IntPtr.Zero || !GetWindowRect(hwnd, out rect))
            throw new Win32Exception(Marshal.GetLastWin32Error(), "Unable to read the foreground window bounds.");
        return region(Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom), cursor, pixel_format);
    }
}
}
