/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Snipping_Tool_Remastered.Class;

namespace Snipping_Tool_Remastered
{
    internal partial class frm_About : Form
    {
        const uint WDA_MONITOR = 1;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);
        public frm_About()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NovaAPI.Decrypt("5Lm9+XWFsKho7hfxHOf3JKgs0amUUoMDCd4uLHbB+O7qUVfRFcJMokX/DOZHGFQPO0RHUAKtbkelKq8JuWDahu/CzPEZZfdu2CtlngmQVkzFAd/YRlZXI+yzRAHTkpdgkwt1M0jpwU/Api4MUR+E5vMh6xHGHFDduqlJUqsAD6m4T1RXqxdtgCYP/3jLmt+RO0RHUAKtbkfMgiUvYyHpONc0Hjn9NqavqoeR/4QJvH5+R+7me0xVQdktwKMCWqpN", true));
        }

        private void frm_About_Load(object sender, EventArgs e)
        {
            this.label_build.Text = "Build: " + cls_Settings.build;
            SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
        }

        private void btn_github_Click(object sender, EventArgs e)
        {
            Process.Start(NovaAPI.Decrypt("JGhznVewz3tnrZ2b7ejj9j6suu9B3rAbgPhO8Gsi5Pw=", true));
            Process.Start(NovaAPI.Decrypt("JGhznVewz3tnrZ2b7ejj9hdAuZHQK/vTksy362nyXhwNGJkX5jB2x/ZlTGS01Luk", true));
        }
    }
}
