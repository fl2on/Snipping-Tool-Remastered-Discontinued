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
using System.Threading.Tasks;
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
                return bmp;

            using (var edit = new frm_Edit(bmp))
            {
                edit.ShowDialog();
                return edit.Result;
            }
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
                    if (snipper_open) return;
                    snipper_open = true;
                    try
                    {
                        Screen_Bounds.load();
                        Rectangle rect = frm_Snipper.get_region();
                        if (rect == Rectangle.Empty) return;
                        bmp = Screen_Capture.region(rect, cls_Settings.show_cursor);
                    }
                    finally { snipper_open = false; }
                    break;
            }
            if (bmp != null)
                this.work_image(bmp, true);
        }

        private async void work_image(Bitmap bmp, Boolean edit = false)
        {
            if (bmp == null) return;
            Global_Func.play_sound("capture.wav");
            Bitmap input = bmp;
            if (edit)
            {
                Bitmap edited = edit_screenshot(input);
                if (edited == null)
                {
                    input.Dispose();
                    return;
                }
                if (!Object.ReferenceEquals(edited, input))
                    input.Dispose();
                bmp = edited;
            }

            try
            {
                // Saving is independent of the optional network upload.
                this.save_screenshot(bmp);
                if (cls_Settings.upload_method == "imgur")
                {
                    try
                    {
                        this.group_upload_progress.Text = "Uploading image...";
                        this.progress.Value = 0;
                        Imgur.UploadResult result = await Imgur.UploadAsync(bmp);
                        this.list_image_links.Items.Add(new ListViewItem(new[] { result.Link, result.DeleteHash ?? "" }));
                        this.list_image_links.Items[this.list_image_links.Items.Count - 1].EnsureVisible();
                        if (cls_Settings.copy_links_to_clipboard)
                            Clipboard.SetText(result.Link);
                        if (cls_Settings.balloon_messages)
                            balloon_tip(result.Link, "Upload complete", 2000);
                        if (cls_Settings.launch_browser)
                            Process.Start(result.Link);
                        Global_Func.play_sound("success.wav");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Global_Func.play_sound("error.wav");
                        if (cls_Settings.balloon_messages)
                            balloon_tip("Image upload failed.", "Upload error", 2000, ToolTipIcon.Error);
                    }
                    finally
                    {
                        this.group_upload_progress.Text = "Upload Progress";
                        this.progress.Value = 0;
                    }
                }
            }
            finally { bmp.Dispose(); }
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
            // Never delete an installed executable based on mutable INI settings.
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
            this.Opacity = Opacity < 1 ? 1 : 0;
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
            this.Opacity = Opacity < 1 ? 1 : 0;
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

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_image_links.SelectedItems.Count <= 0)
                return;

            if (await Imgur.DeleteAsync(list_image_links.SelectedItems[0].SubItems[1].Text))
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
            this.Opacity = Opacity < 1 ? 1 : 0;
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
