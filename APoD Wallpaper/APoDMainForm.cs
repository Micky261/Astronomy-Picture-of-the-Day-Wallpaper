using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APoD_Wallpaper
{
    public partial class APoDMainForm : Form
    {
        public APoDMainForm()
        {
            InitializeComponent();

            tbox_setFilePath.Text = Properties.Settings.Default.FilePath;
            cbox_keepImages.Checked = Properties.Settings.Default.KeepImages;
            cbox_textOnImages.Checked = Properties.Settings.Default.TextOnImages;
        }

        private void trayIcon_DoubleClick(object sender,
                                     System.EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void trayIcon_OpenWindow_Click(object sender,
                                     System.EventArgs e)
        {
            trayIcon_DoubleClick(null, null);
        }

        private void lbll_copyright_imgsAndTxts_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            visitLink(lbll_copyright_imgsAndTxts, "https://apod.nasa.gov/apod/ap_faq.html");
        }

        private void lbll_copyright_program_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            visitLink(lbll_copyright_program, "https://bitbucket.org/Micky261/apod-wallpaper/");
        }

        private void visitLink(LinkLabel ll, string lnk)
        {
            try {
                ll.LinkVisited = true;
                System.Diagnostics.Process.Start(lnk);
            }
            catch (Exception ex) {
                MessageBox.Show("Unable to open link.");
            }
        }

        private void SaveSettings()
        {
            //Save Settings to Config file
        }

        private void cbox_keepImages_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepImages = cbox_keepImages.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbox_textOnImages_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextOnImages = cbox_textOnImages.Checked;
            Properties.Settings.Default.Save();
        }

        private void tbox_setFilePath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FilePath = tbox_setFilePath.Text;
            Properties.Settings.Default.Save();
        }

        private void btn_setFilePath_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = oFile_setFilePath.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = oFile_setFilePath.SelectedPath;
                Properties.Settings.Default.FilePath = folderName;
                tbox_setFilePath.Text = folderName;
            }
        }

        private void openImageFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start(Properties.Settings.Default.FilePath);
        }

        public void changeExplanation(string date, string expl) {
            explanationToolStripMenuItem.ToolTipText = date + ": \r\n" + expl;
        }

        private void updateImageToolStripMenuItem_Click(object sender, EventArgs e) {
            Program.setWallpaper();

        }
    }
}
