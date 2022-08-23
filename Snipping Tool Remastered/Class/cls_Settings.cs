/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using System;
using System.Runtime.InteropServices;
using System.Text;
namespace Snipping_Tool_Remastered
{
    internal static class cls_Settings
	{
		public static Int32 build = 1;
		public static string app_data = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Snipping Tool Remastered\";
		public static string exe_path = app_data + @"Snipping Tool Remastered.exe";
		public static string ini_path = app_data + @"Snipping Tool Remastered.ini";

		[DllImport("kernel32")]
		static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
		[DllImport("kernel32")]
		static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, Int32 size, string filePath);

		public static string Write(string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, ini_path);
			return value;
		}

		public static string Read(string section, string key)
		{
			var temp = new StringBuilder(255);
			int i = GetPrivateProfileString(section, key, "", temp, 255, ini_path);
			return temp.ToString();
		}

		public static string Exists(string section, string key, string value)
		{
			string str = Read(section, key);
			return (str.Length > 0) ? Read(section, key) : Write(section, key, value);
		}

		public static string settings_build;
		public static string imgur_client_id;
		public static Boolean save_screenshots;
		public static string save_folder;
		public static string save_format;
		public static Int16 save_quality;
		public static string upload_method;
		public static string upload_format;
		public static Boolean run_at_system_startup;
		public static Boolean copy_links_to_clipboard;
		public static Boolean show_cursor;
		public static Boolean sound_effects;
		public static Boolean balloon_messages;
		public static Boolean launch_browser;
		public static Boolean edit_screenshot;
		public static Boolean auto_detect_screen_res;
		public static string screen_res;

		public static void get_settings()
		{
			Global_Func.app_data_folder_create();
			settings_build = Exists("Snipping Tool Remastered", "build", Convert.ToString(build));
			imgur_client_id = Exists("upload", "imgur_client_id", "84c55d06b4c9686");
			save_screenshots = Global_Func.str_to_bool(Exists("general", "save_screenshots", "false"));
			save_folder = Exists("general", "save_folder", Environment.CurrentDirectory + "\\captures\\");
			save_format = Exists("general", "save_format", "png");
			save_quality = Convert.ToInt16(Exists("general", "save_quality", "100"));
			upload_method = Exists("upload", "upload_method", "imgur");
			upload_format = Exists("upload", "upload_format", "png");
			copy_links_to_clipboard = Global_Func.str_to_bool(Exists("behavior", "copy_links_to_clipboard", "true"));
			show_cursor = Global_Func.str_to_bool(Exists("behavior", "show_cursor", "false"));
			sound_effects = Global_Func.str_to_bool(Exists("behavior", "sound_effects", "true"));
			balloon_messages = Global_Func.str_to_bool(Exists("behavior", "balloon_messages", "true"));
			launch_browser = Global_Func.str_to_bool(Exists("behavior", "launch_browser", "false"));
			edit_screenshot = Global_Func.str_to_bool(Exists("behavior", "edit_screenshot", "true"));
			screen_res = Exists("screen", "screen_res", Screen_Bounds.reset());
		}

		public static void write_settings()
		{
			Write("upload", "imgur_client_id", imgur_client_id);
			Write("general", "save_screenshots", save_screenshots.ToString());
			Write("general", "save_folder", save_folder);
			Write("general", "save_format", save_format);
			Write("general", "save_quality", save_quality.ToString());
			Write("behavior", "copy_links_to_clipboard", copy_links_to_clipboard.ToString());
			Write("behavior", "show_cursor", show_cursor.ToString());
			Write("behavior", "sound_effects", sound_effects.ToString());
			Write("behavior", "balloon_messages", balloon_messages.ToString());
			Write("behavior", "launch_browser", launch_browser.ToString());
			Write("behavior", "edit_screenshot", edit_screenshot.ToString());
			Write("screen", "screen_res", screen_res);
		}
	}
}
