﻿/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal static class Screen_Capture
{
	[StructLayout(LayoutKind.Sequential)]
	struct CURSORINFO { public Int32 cbSize; public Int32 flags; public IntPtr hCursor; public POINTAPI ptScreenPos; }

	[StructLayout(LayoutKind.Sequential)]
	struct POINTAPI { public int x; public int y; }

	[DllImport("user32.dll")]
	static extern bool GetCursorInfo(out CURSORINFO pci);

	[DllImport("user32.dll", SetLastError = true)]
	static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);

	[DllImport("user32.dll")]
	static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll")]
	static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);

	public static Bitmap region(Rectangle area, bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
	{
		Bitmap bmp;

		try { bmp = new Bitmap(area.Width, area.Height, pixel_format); }
		catch { bmp = new Bitmap(100, 100, pixel_format); }

		Graphics g = Graphics.FromImage(bmp);
		g.CopyFromScreen(area.X, area.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

		if (cursor)
		{
			CURSORINFO cursor_info;
			cursor_info.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

			if (GetCursorInfo(out cursor_info))
				if (cursor_info.flags == (Int32)0x0001)
				{
					var hdc = g.GetHdc();
					DrawIconEx(hdc, cursor_info.ptScreenPos.x - area.X, cursor_info.ptScreenPos.y - area.Y, cursor_info.hCursor, 0, 0, 0, IntPtr.Zero, (Int32)0x0003);
					g.ReleaseHdc();
				}
		}

		g.Dispose();
		return bmp;
	}

	public static Bitmap screen(bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
	{
		return region(Screen.PrimaryScreen.Bounds, cursor, pixel_format);
	}

	public static Bitmap window(bool cursor = true, PixelFormat pixel_format = PixelFormat.Format32bppRgb)
	{
		var rect = new Rectangle();
		GetWindowRect(GetForegroundWindow(), ref rect);
		return region(rect, cursor, pixel_format);
	}
}