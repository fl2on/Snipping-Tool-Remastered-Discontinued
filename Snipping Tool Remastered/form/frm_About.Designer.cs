
namespace Snipping_Tool_Remastered
{
    partial class frm_About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_About));
            this.label_build = new System.Windows.Forms.Label();
            this.btn_github = new System.Windows.Forms.Button();
            this.label_motto = new System.Windows.Forms.Label();
            this.label_Snipping_Tool_Remastered = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_build
            // 
            this.label_build.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_build.Location = new System.Drawing.Point(-10, 150);
            this.label_build.Name = "label_build";
            this.label_build.Size = new System.Drawing.Size(88, 26);
            this.label_build.TabIndex = 8;
            this.label_build.Text = "Build: 0";
            this.label_build.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_github
            // 
            this.btn_github.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_github.Location = new System.Drawing.Point(293, 139);
            this.btn_github.Name = "btn_github";
            this.btn_github.Size = new System.Drawing.Size(97, 26);
            this.btn_github.TabIndex = 7;
            this.btn_github.Text = "Github";
            this.btn_github.UseVisualStyleBackColor = true;
            this.btn_github.Click += new System.EventHandler(this.btn_github_Click);
            // 
            // label_motto
            // 
            this.label_motto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_motto.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_motto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_motto.Location = new System.Drawing.Point(12, 104);
            this.label_motto.Name = "label_motto";
            this.label_motto.Size = new System.Drawing.Size(378, 23);
            this.label_motto.TabIndex = 6;
            this.label_motto.Text = "Simple, fast screenshot sharing!";
            this.label_motto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Snipping_Tool_Remastered
            // 
            this.label_Snipping_Tool_Remastered.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_Snipping_Tool_Remastered.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Snipping_Tool_Remastered.Location = new System.Drawing.Point(12, 3);
            this.label_Snipping_Tool_Remastered.Name = "label_Snipping_Tool_Remastered";
            this.label_Snipping_Tool_Remastered.Size = new System.Drawing.Size(378, 86);
            this.label_Snipping_Tool_Remastered.TabIndex = 5;
            this.label_Snipping_Tool_Remastered.Text = "Snipping Tool Remastered";
            this.label_Snipping_Tool_Remastered.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(190, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 173);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_build);
            this.Controls.Add(this.btn_github);
            this.Controls.Add(this.label_motto);
            this.Controls.Add(this.label_Snipping_Tool_Remastered);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frm_About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snipping Tool Remastered";
            this.Load += new System.EventHandler(this.frm_About_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_build;
        private System.Windows.Forms.Button btn_github;
        private System.Windows.Forms.Label label_motto;
        private System.Windows.Forms.Label label_Snipping_Tool_Remastered;
        private System.Windows.Forms.Button button1;
    }
}