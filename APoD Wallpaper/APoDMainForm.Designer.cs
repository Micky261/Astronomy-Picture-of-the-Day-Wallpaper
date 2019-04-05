using System.Windows.Forms;

namespace APoD_Wallpaper
{
    partial class APoDMainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APoDMainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_setFilePath = new System.Windows.Forms.Label();
            this.tbox_setFilePath = new System.Windows.Forms.TextBox();
            this.btn_setFilePath = new System.Windows.Forms.Button();
            this.cbox_keepImages = new System.Windows.Forms.CheckBox();
            this.lbl_setFilePath_expl = new System.Windows.Forms.Label();
            this.lbl_copyright_program = new System.Windows.Forms.Label();
            this.lbll_copyright_imgsAndTxts = new System.Windows.Forms.LinkLabel();
            this.lbl_copyright_imgsAndTxts = new System.Windows.Forms.Label();
            this.cbox_textOnImages = new System.Windows.Forms.CheckBox();
            this.lbll_copyright_program = new System.Windows.Forms.LinkLabel();
            this.oFile_setFilePath = new System.Windows.Forms.FolderBrowserDialog();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "APoD Wallpaper";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.updateImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(149, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.ToolTipText = "Open Settings-Window";
            // 
            // updateImageToolStripMenuItem
            // 
            this.updateImageToolStripMenuItem.Name = "updateImageToolStripMenuItem";
            this.updateImageToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.updateImageToolStripMenuItem.Text = "Update image";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Will";
            // 
            // lbl_setFilePath
            // 
            this.lbl_setFilePath.AutoSize = true;
            this.lbl_setFilePath.Location = new System.Drawing.Point(15, 15);
            this.lbl_setFilePath.Name = "lbl_setFilePath";
            this.lbl_setFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_setFilePath.Size = new System.Drawing.Size(66, 13);
            this.lbl_setFilePath.TabIndex = 1;
            this.lbl_setFilePath.Text = "Set file path:";
            // 
            // tbox_setFilePath
            // 
            this.tbox_setFilePath.Location = new System.Drawing.Point(87, 12);
            this.tbox_setFilePath.Name = "tbox_setFilePath";
            this.tbox_setFilePath.Size = new System.Drawing.Size(200, 20);
            this.tbox_setFilePath.TabIndex = 2;
            this.tbox_setFilePath.TextChanged += new System.EventHandler(this.tbox_setFilePath_TextChanged);
            // 
            // btn_setFilePath
            // 
            this.btn_setFilePath.Location = new System.Drawing.Point(293, 10);
            this.btn_setFilePath.Name = "btn_setFilePath";
            this.btn_setFilePath.Size = new System.Drawing.Size(113, 23);
            this.btn_setFilePath.TabIndex = 3;
            this.btn_setFilePath.Text = "Choose Path";
            this.btn_setFilePath.UseVisualStyleBackColor = true;
            this.btn_setFilePath.Click += new System.EventHandler(this.btn_setFilePath_Click);
            // 
            // cbox_keepImages
            // 
            this.cbox_keepImages.AutoSize = true;
            this.cbox_keepImages.Location = new System.Drawing.Point(18, 77);
            this.cbox_keepImages.Name = "cbox_keepImages";
            this.cbox_keepImages.Size = new System.Drawing.Size(388, 17);
            this.cbox_keepImages.TabIndex = 4;
            this.cbox_keepImages.Text = "Keep downloaded images (if unchecked they will be deleted on the next day)";
            this.cbox_keepImages.UseVisualStyleBackColor = true;
            this.cbox_keepImages.CheckedChanged += new System.EventHandler(this.cbox_keepImages_CheckedChanged);
            // 
            // lbl_setFilePath_expl
            // 
            this.lbl_setFilePath_expl.AutoSize = true;
            this.lbl_setFilePath_expl.Location = new System.Drawing.Point(15, 35);
            this.lbl_setFilePath_expl.Name = "lbl_setFilePath_expl";
            this.lbl_setFilePath_expl.Size = new System.Drawing.Size(285, 13);
            this.lbl_setFilePath_expl.TabIndex = 5;
            this.lbl_setFilePath_expl.Text = "This is where the daily image should be put after download.";
            // 
            // lbl_copyright_program
            // 
            this.lbl_copyright_program.AutoSize = true;
            this.lbl_copyright_program.Location = new System.Drawing.Point(12, 375);
            this.lbl_copyright_program.Name = "lbl_copyright_program";
            this.lbl_copyright_program.Size = new System.Drawing.Size(325, 39);
            this.lbl_copyright_program.TabIndex = 6;
            this.lbl_copyright_program.Text = "The program is provided as-is without any warranty.\r\nUsage is only allowed for no" +
    "n-commercial, non-public, personal use.\r\nCopyright Frank Nelles";
            // 
            // lbll_copyright_imgsAndTxts
            // 
            this.lbll_copyright_imgsAndTxts.AutoSize = true;
            this.lbll_copyright_imgsAndTxts.Location = new System.Drawing.Point(12, 350);
            this.lbll_copyright_imgsAndTxts.Name = "lbll_copyright_imgsAndTxts";
            this.lbll_copyright_imgsAndTxts.Size = new System.Drawing.Size(125, 13);
            this.lbll_copyright_imgsAndTxts.TabIndex = 7;
            this.lbll_copyright_imgsAndTxts.TabStop = true;
            this.lbll_copyright_imgsAndTxts.Text = "APoD - FAQ / Copyrights";
            this.lbll_copyright_imgsAndTxts.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbll_copyright_imgsAndTxts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbll_copyright_imgsAndTxts_LinkClicked);
            // 
            // lbl_copyright_imgsAndTxts
            // 
            this.lbl_copyright_imgsAndTxts.AutoSize = true;
            this.lbl_copyright_imgsAndTxts.Location = new System.Drawing.Point(12, 324);
            this.lbl_copyright_imgsAndTxts.Name = "lbl_copyright_imgsAndTxts";
            this.lbl_copyright_imgsAndTxts.Size = new System.Drawing.Size(319, 26);
            this.lbl_copyright_imgsAndTxts.TabIndex = 8;
            this.lbl_copyright_imgsAndTxts.Text = "Usage of the images (and texts) according to the APoD-Website is\r\nonly allowed fo" +
    "r non-commercial, non-public, personal use.";
            // 
            // cbox_textOnImages
            // 
            this.cbox_textOnImages.AutoSize = true;
            this.cbox_textOnImages.Location = new System.Drawing.Point(18, 100);
            this.cbox_textOnImages.Name = "cbox_textOnImages";
            this.cbox_textOnImages.Size = new System.Drawing.Size(298, 17);
            this.cbox_textOnImages.TabIndex = 9;
            this.cbox_textOnImages.Text = "Show info texts on images (Images will be saved with text)";
            this.cbox_textOnImages.UseVisualStyleBackColor = true;
            this.cbox_textOnImages.CheckedChanged += new System.EventHandler(this.cbox_textOnImages_CheckedChanged);
            // 
            // lbll_copyright_program
            // 
            this.lbll_copyright_program.Location = new System.Drawing.Point(12, 414);
            this.lbll_copyright_program.Name = "lbll_copyright_program";
            this.lbll_copyright_program.Size = new System.Drawing.Size(241, 23);
            this.lbll_copyright_program.TabIndex = 10;
            this.lbll_copyright_program.TabStop = true;
            this.lbll_copyright_program.Text = "Help and Source Code is available on BitBucket";
            this.lbll_copyright_program.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // APoDMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 450);
            this.Controls.Add(this.lbll_copyright_program);
            this.Controls.Add(this.cbox_textOnImages);
            this.Controls.Add(this.lbl_copyright_imgsAndTxts);
            this.Controls.Add(this.lbll_copyright_imgsAndTxts);
            this.Controls.Add(this.lbl_copyright_program);
            this.Controls.Add(this.lbl_setFilePath_expl);
            this.Controls.Add(this.cbox_keepImages);
            this.Controls.Add(this.btn_setFilePath);
            this.Controls.Add(this.tbox_setFilePath);
            this.Controls.Add(this.lbl_setFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "APoDMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Astronomy Picture of the Day - Wallpaper Settings";
            this.Resize += new System.EventHandler(this.APoDMainForm_Resize);
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;


        private void APoDMainForm_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private ContextMenuStrip trayContextMenu;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem updateImageToolStripMenuItem;
        private Label lbl_setFilePath;
        private TextBox tbox_setFilePath;
        private Button btn_setFilePath;
        private CheckBox cbox_keepImages;
        private Label lbl_setFilePath_expl;
        private Label lbl_copyright_program;
        private LinkLabel lbll_copyright_imgsAndTxts;
        private Label lbl_copyright_imgsAndTxts;
        private CheckBox cbox_textOnImages;
        private LinkLabel lbll_copyright_program;
        private FolderBrowserDialog oFile_setFilePath;
    }
}

