﻿/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using System;
using System.IO;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Microsoft.Win32;


namespace Snipping_Tool_Remastered
{
	internal static class Global_Func
	{
		public static ImageFormat ext_to_imageformat(String ext)
		{
			switch (ext.ToLower())
			{
				case "jpeg":
				case "jpg":
					return ImageFormat.Jpeg;
				case "png":
					return ImageFormat.Png;
				default:
					return ImageFormat.Bmp;
			}
		}

		public static Boolean str_to_bool(String str)
		{
			return str.ToLower() == "true";
		}

		public static String get_text_inbetween(String input, String a, String b)
		{
			return input.Substring(input.IndexOf(a) + a.Length, input.IndexOf(b) - input.IndexOf(a) - a.Length);
		}

		public static String bmp_to_base64(Bitmap bmp, ImageFormat format)
		{
			using (var stream = new MemoryStream())
			{
				bmp.Save(stream, format);
				Byte[] bytes = stream.ToArray();

				return Convert.ToBase64String(bytes);
			}
		}

		readonly public static RegistryKey reg_key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

		public static void run_at_startup(Boolean run)
		{
			app_data_folder_create();

			if (run)
				reg_key.SetValue("Snipping Tool Remastered", cls_Settings.exe_path);
			else
				reg_key.DeleteValue("Snipping Tool Remastered", false);
		}

		public static void app_data_folder_create()
		{
			if (!Directory.Exists(cls_Settings.app_data))
				Directory.CreateDirectory(cls_Settings.app_data);
		}

		public static void copy_files()
		{
			if (!File.Exists(cls_Settings.exe_path))
				File.Copy(
					Application.ExecutablePath,
					cls_Settings.exe_path
				);

			try
			{
				if (!Directory.Exists(cls_Settings.app_data + "\\sounds\\"))
				{
					Directory.CreateDirectory(cls_Settings.app_data + "\\sounds\\");
					foreach (var file in Directory.GetFiles(Environment.CurrentDirectory + "\\sounds"))
						File.Copy(file, cls_Settings.app_data + "\\sounds\\" + Path.GetFileName(file));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Couldn't copy sound files.");
				Console.WriteLine(ex.Message);
			}
		}

		public static void play_sound(String file)
		{
			try
			{

				if (cls_Settings.sound_effects)
					using (var sound_player = new SoundPlayer("sounds\\" + file))
						sound_player.Play();
			}
			catch
			{
				Console.WriteLine("Can't find audio file: " + file);
			}
		}
	}
}
