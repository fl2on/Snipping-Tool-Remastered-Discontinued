/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using Snipping_Tool_Remastered.Properties;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Snipping_Tool_Remastered
{
    internal partial class frm_Preferences : Form
	{
		const uint WDA_MONITOR = 1;

		[DllImport("user32.dll")]
		public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

		public frm_Preferences()
		{
			InitializeComponent();
		}

		private void Frm_PreferencesLoad(object sender, EventArgs e)
		{
			SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
			this.check_save_screenshots.Checked = cls_Settings.save_screenshots;
			this.txt_save_folder.Text = cls_Settings.save_folder;
			this.check_edit_screenshot.Visible = false;
			this.drop_save_format.Text = cls_Settings.save_format;
			this.drop_save_quality.Text = cls_Settings.save_quality.ToString();
			this.drop_upload_method.Text = cls_Settings.upload_method;
			this.drop_upload_format.Text = cls_Settings.upload_format;
			this.check_run_at_startup.Checked = Global_Func.reg_key.GetValue("Snipping Tool Remastered") != null;
			this.check_copy_links.Checked = cls_Settings.copy_links_to_clipboard;
			this.check_sound_effects.Checked = cls_Settings.sound_effects;
			this.check_show_cursor.Checked = cls_Settings.show_cursor;
			this.check_balloon.Checked = cls_Settings.balloon_messages;
			this.check_launch_browser.Checked = cls_Settings.launch_browser;
			this.check_edit_screenshot.Checked = cls_Settings.edit_screenshot;
			this.numeric_top.Minimum = -50000;
			this.numeric_left.Minimum = -50000;
			this.numeric_width.Minimum = -50000;
			this.numeric_height.Minimum = -50000;
			try
			{
				string[] screen_res = cls_Settings.screen_res.Split(',');
				this.numeric_left.Value = Convert.ToDecimal(screen_res[0]);
				this.numeric_top.Value = Convert.ToDecimal(screen_res[1]);
				this.numeric_width.Value = Convert.ToDecimal(screen_res[2]);
				this.numeric_height.Value = Convert.ToDecimal(screen_res[3]);
			}
			catch
			{
				this.btn_reset_screen.PerformClick();
			}
		}

		#region Save & Cancel
		private void Btn_saveClick(object sender, EventArgs e)
		{
			cls_Settings.screen_res = cls_Settings.screen_res = String.Format(
				"{0},{1},{2},{3}",
			this.numeric_left.Value,
			this.numeric_top.Value,
			this.numeric_width.Value,
			this.numeric_height.Value
			);
			Screen_Bounds.load();
			cls_Settings.save_screenshots = check_save_screenshots.Checked;
			cls_Settings.save_folder = txt_save_folder.Text;
			cls_Settings.save_format = drop_save_format.Text;
			cls_Settings.save_quality = Convert.ToInt16(drop_save_quality.Text);
			cls_Settings.upload_method = drop_upload_method.Text;
			cls_Settings.upload_format = drop_upload_format.Text;
			cls_Settings.copy_links_to_clipboard = check_copy_links.Checked;
			cls_Settings.sound_effects = check_sound_effects.Checked;
			cls_Settings.show_cursor = check_show_cursor.Checked;
			cls_Settings.balloon_messages = check_balloon.Checked;
			cls_Settings.launch_browser = check_launch_browser.Checked;
			cls_Settings.edit_screenshot = check_edit_screenshot.Checked;
			cls_Settings.write_settings();
			Global_Func.run_at_startup(check_run_at_startup.Checked);
			this.Dispose();
		}
		private void Btn_cancelClick(object sender, EventArgs e)
		{
			this.Dispose();
		}
		#endregion

		#region General
		private void Check_save_screenshotsCheckedChanged(object sender, EventArgs e)
		{
			this.txt_save_folder.Enabled = check_save_screenshots.Checked;
			this.btn_browse_save_folder.Enabled = check_save_screenshots.Checked;
			this.drop_save_format.Enabled = check_save_screenshots.Checked;
			this.drop_save_quality.Enabled = check_save_screenshots.Checked;
		}
		private void Btn_browse_save_folderClick(object sender, EventArgs e)
		{
			var browse_folder = new FolderBrowserDialog();
			if (browse_folder.ShowDialog() == DialogResult.OK)
				this.txt_save_folder.Text = browse_folder.SelectedPath;
		}
		private void Btn_reset_screenClick(object sender, EventArgs e)
		{
			string[] screen_res = Screen_Bounds.reset().Split(',');
			this.numeric_left.Value = Convert.ToDecimal(screen_res[0]);
			this.numeric_top.Value = Convert.ToDecimal(screen_res[1]);
			this.numeric_width.Value = Convert.ToDecimal(screen_res[2]);
			this.numeric_height.Value = Convert.ToDecimal(screen_res[3]);
		}
		#endregion

        private void check_launch_browser_CheckedChanged(object sender, EventArgs e)
        {
			bool @checked = this.check_launch_browser.Checked;
			if (@checked)
			{
				Settings.Default.LaunchBrowser = "true";
				Settings.Default.Save();
			}
			else
			{
				bool flag = !this.check_launch_browser.Checked;
				if (flag)
				{
					Settings.Default.LaunchBrowser = "false";
					Settings.Default.Save();
				}
			}
		}
    }
}
