/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using Snipping_Tool_Remastered.Class;
using Snipping_Tool_Remastered.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace Snipping_Tool_Remastered
{
    internal partial class Snipping_Tool_Remastered : Form
    {
        Hotkeys hook;
        Boolean snipper_open;

        #region Image

        Bitmap edit_screenshot(Bitmap bmp)
        {
            if (!cls_Settings.edit_screenshot)
                return null;

            var edit = new frm_Edit(bmp);
            edit.ShowDialog();

            return edit.Result;
        }

        private void save_screenshot(Bitmap bmp, String name = null)
        {
            if (!cls_Settings.save_screenshots)
                return;
            if (name == null)
                name = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            try
            {
                bmp.Save(
                    String.Format("{0}/{1}.{2}", cls_Settings.save_folder, name, cls_Settings.save_format),
                    Global_Func.ext_to_imageformat(cls_Settings.save_format)
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot save image.");
                Console.WriteLine(ex.Message);
            }
        }

        private void screen_capture(String type)
        {
            Bitmap bmp = null;
            switch (type)
            {
                case "screen":
                    bmp = Screen_Capture.screen(cls_Settings.show_cursor);
                    break;

                case "window":
                    bmp = Screen_Capture.window(cls_Settings.show_cursor);
                    break;

                default:
                    this.snipper_open = false;
                    if (snipper_open)
                        return;

                    this.snipper_open = true;
                    var rect = frm_Snipper.get_region();

                    if (rect == new Rectangle(0, 0, 0, 0))
                        return;

                    bmp = Screen_Capture.region(rect);
                    this.snipper_open = false;
                    break;
            }
            this.work_image(bmp, true);
        }

        private void work_image(Bitmap bmp, Boolean edit = false)
        {
            Global_Func.play_sound("capture.wav");

            if (edit)
                bmp = edit_screenshot(bmp);

            if (bmp == null)
                return;

            if (cls_Settings.upload_method == "imgur")
                if (!Imgur.upload(bmp))
                {
                    Global_Func.play_sound("error.wav");

                    if (cls_Settings.balloon_messages)
                        this.balloon_tip("Error uploading file!", "Error", 2000, ToolTipIcon.Error);
                }

            this.save_screenshot(bmp);
        }
        #endregion

        #region Invisible Form
        const uint WDA_MONITOR = 1;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        #endregion

        public Snipping_Tool_Remastered()
        {
            InitializeComponent();
            try
            {
                if (Convert.ToInt32(cls_Settings.Read("Snipping Tool", "build")) < cls_Settings.build)
                {
                    File.Delete(cls_Settings.exe_path);
                    cls_Settings.Write("Snipping Tool", "build", cls_Settings.build.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't delete old Snipping Tool Remastered executable.");
                Console.WriteLine(ex.Message);
            }
            Global_Func.app_data_folder_create();
            Global_Func.copy_files();
            if (!File.Exists(cls_Settings.ini_path))
             {
                 DialogResult result = MessageBox.Show(
                     "Do you want to run Snipping Tool Remastered at Windows startup?",
                     "First time run",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1
                 );

                 if (result == DialogResult.Yes)
                     Global_Func.run_at_startup(true);
             }
            this.register_hotkeys();
        }

        private void Snipping_Tool_Remastered_Load(object sender, EventArgs e)
        {
            this.label1.Visible = false;
            this.label1.Text = Settings.Default.LaunchBrowser;
            Imgur.web_client.UploadProgressChanged += upload_progress_changed;
            Imgur.web_client.UploadValuesCompleted += upload_progress_complete;
            cls_Settings.get_settings();
            this.tray_icon.Visible = true;
            Screen_Bounds.load();
        }

        private void exit()
        {
            this.tray_icon.Dispose();
            this.Dispose();
            NovaAPI.gc();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (list_image_links.SelectedItems.Count > 0)
                Process.Start(list_image_links.SelectedItems[0].Text);
            NovaAPI.gc();
        }

        #region Progress Bar
        private void upload_progress_changed(object sender, UploadProgressChangedEventArgs e)
        {
            try
            {
                Int32 percent = Convert.ToInt32(e.BytesSent / e.TotalBytesToSend) * 100;
                this.group_upload_progress.Text = String.Format("Upload Progress - {0}% ({1}kb/{2}kb)", percent, e.BytesSent / 1024, e.TotalBytesToSend / 1024);
                this.progress.Value = percent;
                NovaAPI.gc();
            }
            catch
            {
                NovaAPI.gc();
            }
        }
        private void upload_progress_complete(object sender, UploadValuesCompletedEventArgs e)
        {
            this.group_upload_progress.Text = "Upload Progress";
            this.progress.Value = 0;
            this.label1.Text = Settings.Default.LaunchBrowser;
            this.Refresh();
            String response = Encoding.UTF8.GetString(e.Result);
            String delete_hash = Global_Func.get_text_inbetween(response, "deletehash\":\"", "\",\"link\"").Replace("\\", "").Replace('"',' ').Replace("name","").Replace(" ","").Replace(":","").Replace(",","");
            String link = Global_Func.get_text_inbetween(response, "link\":\"", "\"}").Replace("\\", "");

            this.list_image_links.Items.Add(
                new ListViewItem(new String[] { link, delete_hash })
            );

            this.list_image_links.Items[list_image_links.Items.Count - 1].EnsureVisible();

            if (cls_Settings.copy_links_to_clipboard)
                Clipboard.SetText(link);

            if (cls_Settings.balloon_messages)
                this.balloon_tip(link, "Upload Complete!", 2000);

            if (label1.Text == "true")
            {
                try { Process.Start(link); } catch { }
                NovaAPI.gc();
            }
            Global_Func.play_sound("success.wav");
            NovaAPI.gc();
        }
        #endregion

        private void btn_capture_Click(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 0;
                this.screen_capture("screen");
                this.Opacity = 1;
                NovaAPI.gc();
            } catch { }
        }

        private void btn_capture_selected_area_Click(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 0;
                this.screen_capture("region");
                this.Opacity = 1;
                NovaAPI.gc();
            } catch { }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                work_image(new Bitmap(Image.FromFile(dialog.FileName)));
            }
            NovaAPI.gc();
        }

        private void Snipping_Tool_Remastered_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tray_icon_DoubleClick(sender, e);
            e.Cancel = true;
            NovaAPI.gc();
        }

        void balloon_tip(String text, String title, Int32 duration, ToolTipIcon icon = ToolTipIcon.Info)
        {
            this.tray_icon.BalloonTipText = text;
            this.tray_icon.BalloonTipTitle = title;
            this.tray_icon.BalloonTipIcon = icon;
            this.tray_icon.ShowBalloonTip(duration);
            NovaAPI.gc();
        }

        private void tray_icon_BalloonTipClicked(object sender, EventArgs e)
        {
            try { Process.Start(tray_icon.BalloonTipText); } catch { }
            NovaAPI.gc();
        }

        private void tray_icon_DoubleClick(object sender, EventArgs e)
        {
            this.minimizeToTrayToolStripMenuItem.Text = (minimizeToTrayToolStripMenuItem.Text == "Open Window") ? "Minimize to Tray" : "Open Window";
            this.ShowInTaskbar = !ShowInTaskbar;
            this.Opacity = Opacity < 1 ? 100 : 0;
            NovaAPI.gc();
        }


        #region Hotkeys
        public void register_hotkeys()
        {
            hook = new Hotkeys();
            hook.KeyPressed += hook_KeyPressed;
            try
            {
                this.hook.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Shift, Keys.D3);
                this.hook.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Shift, Keys.D4);
                this.hook.RegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Shift, Keys.D5);
                NovaAPI.gc();
            }
            catch
            {
                MessageBox.Show("Couldn't register hotkeys. Perhaps they are already in use or try running as an Administrator.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NovaAPI.gc();
            }
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            switch (e.Key)
            {
                case Keys.D3:
                    screen_capture("screen");
                    break;

                case Keys.D4:
                    screen_capture("region");
                    break;

                case Keys.D5:
                    screen_capture("window");
                    break;
            }
        }
        #endregion

        private void lbl_instructions_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                work_image(new Bitmap(Image.FromFile(file)));
            }
        }

        private void lbl_instructions_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void hideWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.minimizeToTrayToolStripMenuItem.Text = (minimizeToTrayToolStripMenuItem.Text == "Open Window") ? "Minimize to Tray" : "Open Window";
            this.ShowInTaskbar = !ShowInTaskbar;
            this.Opacity = Opacity < 1 ? 100 : 0;
            NovaAPI.gc();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.exit();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_Preferences().ShowDialog();
            NovaAPI.gc();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_About().ShowDialog();
            NovaAPI.gc();
        }

        private void registerHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.register_hotkeys();
            NovaAPI.gc();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_image_links.SelectedItems.Count > 0)
            Process.Start(list_image_links.SelectedItems[0].Text);
            NovaAPI.gc();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_image_links.SelectedItems.Count > 0)
                Clipboard.SetText(list_image_links.SelectedItems[0].Text);
            NovaAPI.gc();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_image_links.SelectedItems.Count <= 0)
                return;

            if (Imgur.delete(list_image_links.SelectedItems[0].SubItems[1].Text))
                this.list_image_links.SelectedItems[0].Remove();
            else
            {
                Global_Func.play_sound("error.wav");
                if (cls_Settings.balloon_messages)
                    this.balloon_tip("Could not delete file!", "Error", 2000, ToolTipIcon.Error);
            }
            NovaAPI.gc();
        }

        private void minimizeToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.minimizeToTrayToolStripMenuItem.Text = (minimizeToTrayToolStripMenuItem.Text == "Open Window") ? "Minimize to Tray" : "Open Window";
            this.ShowInTaskbar = !ShowInTaskbar;
            this.Opacity = Opacity < 1 ? 100 : 0;
            SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
            NovaAPI.gc();
        }

        private void takeRegionScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btn_capture_selected_area_Click(sender, e);
        }

        private void takeScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btn_capture_Click(sender, e);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.aboutToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.exitToolStripMenuItem_Click(sender, e);
        }

        private void webSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://nyzx.000webhostapp.com/");
        }
    }
}
