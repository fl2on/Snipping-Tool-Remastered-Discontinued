﻿
namespace Snipping_Tool_Remastered
{
    partial class Snipping_Tool_Remastered
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snipping_Tool_Remastered));
            this.tray_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.takeRegionScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image_links_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tray_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.group_image_links = new System.Windows.Forms.GroupBox();
            this.list_image_links = new System.Windows.Forms.ListView();
            this.column_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_delete_hash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.group_upload_progress = new System.Windows.Forms.GroupBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.group_screenshot = new System.Windows.Forms.GroupBox();
            this.btn_capture_selected_area = new System.Windows.Forms.Button();
            this.btn_capture = new System.Windows.Forms.Button();
            this.group_upload = new System.Windows.Forms.GroupBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lbl_instructions = new System.Windows.Forms.Label();
            this.tray_menu.SuspendLayout();
            this.main_menu.SuspendLayout();
            this.image_links_menu.SuspendLayout();
            this.group_image_links.SuspendLayout();
            this.group_upload_progress.SuspendLayout();
            this.group_screenshot.SuspendLayout();
            this.group_upload.SuspendLayout();
            this.SuspendLayout();
            // 
            // tray_menu
            // 
            this.tray_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToTrayToolStripMenuItem,
            this.toolStripMenuItem1,
            this.takeRegionScreenshotToolStripMenuItem,
            this.takeScreenshotToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.tray_menu.Name = "tray_menu";
            this.tray_menu.Size = new System.Drawing.Size(199, 120);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.minimizeToTrayToolStripMenuItem.Text = "Minimize to tray";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTrayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // takeRegionScreenshotToolStripMenuItem
            // 
            this.takeRegionScreenshotToolStripMenuItem.Name = "takeRegionScreenshotToolStripMenuItem";
            this.takeRegionScreenshotToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.takeRegionScreenshotToolStripMenuItem.Text = "Take Region Screenshot";
            this.takeRegionScreenshotToolStripMenuItem.Click += new System.EventHandler(this.takeRegionScreenshotToolStripMenuItem_Click);
            // 
            // takeScreenshotToolStripMenuItem
            // 
            this.takeScreenshotToolStripMenuItem.Name = "takeScreenshotToolStripMenuItem";
            this.takeScreenshotToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.takeScreenshotToolStripMenuItem.Text = "Take Screenshot";
            this.takeScreenshotToolStripMenuItem.Click += new System.EventHandler(this.takeScreenshotToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.main_menu.Size = new System.Drawing.Size(355, 24);
            this.main_menu.TabIndex = 2;
            this.main_menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideWindowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // hideWindowToolStripMenuItem
            // 
            this.hideWindowToolStripMenuItem.Name = "hideWindowToolStripMenuItem";
            this.hideWindowToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.hideWindowToolStripMenuItem.Text = "Hide Window";
            this.hideWindowToolStripMenuItem.Click += new System.EventHandler(this.hideWindowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.registerHotkeysToolStripMenuItem,
            this.webSiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // registerHotkeysToolStripMenuItem
            // 
            this.registerHotkeysToolStripMenuItem.Name = "registerHotkeysToolStripMenuItem";
            this.registerHotkeysToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registerHotkeysToolStripMenuItem.Text = "Register Hotkeys";
            this.registerHotkeysToolStripMenuItem.Click += new System.EventHandler(this.registerHotkeysToolStripMenuItem_Click);
            // 
            // webSiteToolStripMenuItem
            // 
            this.webSiteToolStripMenuItem.Name = "webSiteToolStripMenuItem";
            this.webSiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.webSiteToolStripMenuItem.Text = "Dev WebSite";
            this.webSiteToolStripMenuItem.Click += new System.EventHandler(this.webSiteToolStripMenuItem_Click);
            // 
            // image_links_menu
            // 
            this.image_links_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
            this.image_links_menu.Name = "image_links_menu";
            this.image_links_menu.Size = new System.Drawing.Size(108, 76);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tray_icon
            // 
            this.tray_icon.ContextMenuStrip = this.tray_menu;
            this.tray_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("tray_icon.Icon")));
            this.tray_icon.Text = "Snipping Tool Remastered";
            this.tray_icon.Visible = true;
            this.tray_icon.BalloonTipClicked += new System.EventHandler(this.tray_icon_BalloonTipClicked);
            this.tray_icon.DoubleClick += new System.EventHandler(this.tray_icon_DoubleClick);
            // 
            // group_image_links
            // 
            this.group_image_links.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_image_links.Controls.Add(this.list_image_links);
            this.group_image_links.Controls.Add(this.label1);
            this.group_image_links.Location = new System.Drawing.Point(12, 193);
            this.group_image_links.Name = "group_image_links";
            this.group_image_links.Size = new System.Drawing.Size(331, 212);
            this.group_image_links.TabIndex = 8;
            this.group_image_links.TabStop = false;
            this.group_image_links.Text = "Image Links";
            // 
            // list_image_links
            // 
            this.list_image_links.AllowDrop = true;
            this.list_image_links.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_image_links.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_url,
            this.column_delete_hash});
            this.list_image_links.ContextMenuStrip = this.image_links_menu;
            this.list_image_links.FullRowSelect = true;
            this.list_image_links.GridLines = true;
            this.list_image_links.HideSelection = false;
            this.list_image_links.Location = new System.Drawing.Point(6, 19);
            this.list_image_links.MultiSelect = false;
            this.list_image_links.Name = "list_image_links";
            this.list_image_links.Size = new System.Drawing.Size(319, 187);
            this.list_image_links.TabIndex = 0;
            this.list_image_links.UseCompatibleStateImageBehavior = false;
            this.list_image_links.View = System.Windows.Forms.View.Details;
            this.list_image_links.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_instructions_DragDrop);
            this.list_image_links.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbl_instructions_DragEnter);
            this.list_image_links.DoubleClick += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // column_url
            // 
            this.column_url.Text = "Image URL";
            this.column_url.Width = 150;
            // 
            // column_delete_hash
            // 
            this.column_delete_hash.Text = "Delete";
            this.column_delete_hash.Width = 50;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(140, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 34);
            this.label1.TabIndex = 9;
            // 
            // group_upload_progress
            // 
            this.group_upload_progress.Controls.Add(this.progress);
            this.group_upload_progress.Location = new System.Drawing.Point(12, 138);
            this.group_upload_progress.Name = "group_upload_progress";
            this.group_upload_progress.Size = new System.Drawing.Size(331, 49);
            this.group_upload_progress.TabIndex = 7;
            this.group_upload_progress.TabStop = false;
            this.group_upload_progress.Text = "Upload Progress";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(6, 19);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(319, 20);
            this.progress.TabIndex = 0;
            // 
            // group_screenshot
            // 
            this.group_screenshot.Controls.Add(this.btn_capture_selected_area);
            this.group_screenshot.Controls.Add(this.btn_capture);
            this.group_screenshot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.group_screenshot.Location = new System.Drawing.Point(12, 80);
            this.group_screenshot.Name = "group_screenshot";
            this.group_screenshot.Size = new System.Drawing.Size(331, 52);
            this.group_screenshot.TabIndex = 6;
            this.group_screenshot.TabStop = false;
            this.group_screenshot.Text = "Screenshot";
            // 
            // btn_capture_selected_area
            // 
            this.btn_capture_selected_area.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_capture_selected_area.Location = new System.Drawing.Point(174, 19);
            this.btn_capture_selected_area.Name = "btn_capture_selected_area";
            this.btn_capture_selected_area.Size = new System.Drawing.Size(151, 23);
            this.btn_capture_selected_area.TabIndex = 2;
            this.btn_capture_selected_area.Text = "capture region";
            this.btn_capture_selected_area.UseVisualStyleBackColor = true;
            this.btn_capture_selected_area.Click += new System.EventHandler(this.btn_capture_selected_area_Click);
            // 
            // btn_capture
            // 
            this.btn_capture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_capture.Location = new System.Drawing.Point(6, 19);
            this.btn_capture.Name = "btn_capture";
            this.btn_capture.Size = new System.Drawing.Size(162, 23);
            this.btn_capture.TabIndex = 1;
            this.btn_capture.Text = "capture";
            this.btn_capture.UseVisualStyleBackColor = true;
            this.btn_capture.Click += new System.EventHandler(this.btn_capture_Click);
            // 
            // group_upload
            // 
            this.group_upload.Controls.Add(this.btn_browse);
            this.group_upload.Controls.Add(this.lbl_instructions);
            this.group_upload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.group_upload.Location = new System.Drawing.Point(12, 27);
            this.group_upload.Name = "group_upload";
            this.group_upload.Size = new System.Drawing.Size(331, 53);
            this.group_upload.TabIndex = 5;
            this.group_upload.TabStop = false;
            this.group_upload.Text = "Upload Images";
            // 
            // btn_browse
            // 
            this.btn_browse.AllowDrop = true;
            this.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_browse.Location = new System.Drawing.Point(197, 12);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(128, 35);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AllowDrop = true;
            this.lbl_instructions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_instructions.Location = new System.Drawing.Point(6, 17);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(185, 34);
            this.lbl_instructions.TabIndex = 1;
            this.lbl_instructions.Text = "Drag and drop pictures here, or select them by pressing browse";
            this.lbl_instructions.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbl_instructions_DragDrop);
            this.lbl_instructions.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbl_instructions_DragEnter);
            // 
            // Snipping_Tool_Remastered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 417);
            this.Controls.Add(this.group_image_links);
            this.Controls.Add(this.group_upload_progress);
            this.Controls.Add(this.group_screenshot);
            this.Controls.Add(this.group_upload);
            this.Controls.Add(this.main_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Snipping_Tool_Remastered";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snipping Tool Remastered";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Snipping_Tool_Remastered_FormClosing);
            this.Load += new System.EventHandler(this.Snipping_Tool_Remastered_Load);
            this.tray_menu.ResumeLayout(false);
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.image_links_menu.ResumeLayout(false);
            this.group_image_links.ResumeLayout(false);
            this.group_upload_progress.ResumeLayout(false);
            this.group_screenshot.ResumeLayout(false);
            this.group_upload.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip tray_menu;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem takeRegionScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerHotkeysToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip image_links_menu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon tray_icon;
        private System.Windows.Forms.GroupBox group_image_links;
        private System.Windows.Forms.ListView list_image_links;
        private System.Windows.Forms.ColumnHeader column_url;
        private System.Windows.Forms.ColumnHeader column_delete_hash;
        private System.Windows.Forms.GroupBox group_upload_progress;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.GroupBox group_screenshot;
        private System.Windows.Forms.Button btn_capture_selected_area;
        private System.Windows.Forms.Button btn_capture;
        private System.Windows.Forms.GroupBox group_upload;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label lbl_instructions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem webSiteToolStripMenuItem;
    }
}