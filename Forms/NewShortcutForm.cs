using CSACore.Core;
using CSACore.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebWrapper2.Web;



namespace WebWrapper2.Forms {

    public partial class NewShortcutForm : Form {
        //================================================================================
        public const int                        DOWNLOAD_ICON_TIMEOUT = 10000;

        
        //================================================================================
        //--------------------------------------------------------------------------------
        public NewShortcutForm() {
            InitializeComponent();
        }
        

        // FORM ================================================================================
        //--------------------------------------------------------------------------------
        private void NewShortcutForm_Shown(object sender, EventArgs e) {
            // Previous selections
            switch (Properties.Settings.Default.ShortcutBrowser.ToLower()) {
                case "chrome":  rdbBrowserChrome.Checked = true; break;
                case "ie":      rdbBrowserInternetExplorer.Checked = true; break;
                default:        rdbBrowserInternetExplorer.Checked = true; break;
            }

            switch (Properties.Settings.Default.ShortcutSize) {
                case 0:     rdbSizeLarge.Checked = true; break;
                case 1:     rdbSizeMedium.Checked = true; break;
                case 2:     rdbSizeSmall.Checked = true; break;
                default:    rdbSizeCustom.Checked = true; break;
            }

            if (rdbSizeCustom.Checked) {
                numWidth.Value = Properties.Settings.Default.ShortcutWidth;
                numHeight.Value = Properties.Settings.Default.ShortcutHeight;
            }

            chkMaximise.Checked = Properties.Settings.Default.ShortcutMaximise;
            chkCaching.Checked = Properties.Settings.Default.ShortcutCaching;
        }


        // CONTROLS ================================================================================
        //--------------------------------------------------------------------------------
        private void rdbSizeLarge_CheckedChanged(object sender, EventArgs e) {
            if (rdbSizeLarge.Checked) {
                numWidth.Enabled = false;
                numWidth.Value = 1500;
                numHeight.Value = 1000;
            }
        }
        
        //--------------------------------------------------------------------------------
        private void rdbSizeMedium_CheckedChanged(object sender, EventArgs e) {
            if (rdbSizeMedium.Checked) {
                numWidth.Enabled = false;
                numWidth.Value = 1200;
                numHeight.Value = 800;
            }
        }

        //--------------------------------------------------------------------------------
        private void rdbSizeSmall_CheckedChanged(object sender, EventArgs e) {
            if (rdbSizeSmall.Checked) {
                numWidth.Enabled = false;
                numWidth.Value = 900;
                numHeight.Value = 600;
            }
        }
        
        //--------------------------------------------------------------------------------
        private void rdbSizeCustom_CheckedChanged(object sender, EventArgs e) {
            if (rdbSizeSmall.Checked)
                numWidth.Enabled = true;
        }

        //--------------------------------------------------------------------------------
        private void btnCreate_Click(object sender, EventArgs e) {
            CreateShortcut();
        }
        
        //--------------------------------------------------------------------------------
        private void btnCreateInStartMenu_Click(object sender, EventArgs e) {
            CreateShortcut(true);
        }
        
        //--------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }


        // BROWSER ================================================================================
        //--------------------------------------------------------------------------------
        private string BrowserName { get { return rdbBrowserChrome.Checked ? "chrome" : "ie"; } }


        // CREATION ================================================================================
        //--------------------------------------------------------------------------------
        private void CreateShortcut(bool startMenu = false) {
            // Validation
            /*string[] invalidSymbols = new string[] { "<", ">", ":", "\"", "/", "\\", "|", "?", "*" };
            foreach (string s in invalidSymbols) {
                if (txtName.Text.Contains(s)) {
                    MessageBox.Show($"Name contains an invalid character: {s}.", "Web Wrapper", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }*/

            if (txtURL.Text.Length == 0) {
                txtURL.Focus();
                MessageBox.Show("Please enter a URL.", "Web Wrapper", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try { Uri uri = new UriBuilder(txtURL.Text).Uri; }
            catch (UriFormatException) {
                txtURL.Focus();
                MessageBox.Show("Please enter a valid URL.", "Web Wrapper", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Save selections
            Properties.Settings.Default.ShortcutBrowser = rdbBrowserChrome.Checked ? "chrome" : "ie";
            Properties.Settings.Default.ShortcutSize = rdbSizeLarge.Checked ? 0 : (rdbSizeMedium.Checked ? 1 : (rdbSizeSmall.Checked ? 2 : 3));
            Properties.Settings.Default.ShortcutWidth = (int)numWidth.Value;
            Properties.Settings.Default.ShortcutHeight = (int)numHeight.Value;
            Properties.Settings.Default.ShortcutMaximise = chkMaximise.Checked;
            Properties.Settings.Default.ShortcutCaching = chkCaching.Checked;
            Properties.Settings.Default.Save();

            // Application data
            CSA.ApplicationData.CreateProgramDataPath();

            // Icon
            IconDownloader iconDownloader = new IconDownloader();
            if (!iconDownloader.DownloadIcon2(txtURL.Text, CSA.ApplicationData.ProgramDataPath, DOWNLOAD_ICON_TIMEOUT)) {
                // Error
                DialogResult dialogResult = MessageBox.Show($"Icon download failed: {iconDownloader.ErrorString + (!string.IsNullOrEmpty(iconDownloader.ErrorMessage) ? " (" + iconDownloader.ErrorMessage + ")" : "")}.\n" +
                                                            "Continue with default icon?", "Web Wrapper", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult != DialogResult.Yes)
                    return;

                // Copy default icon
                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "default.ico"), Path.Combine(CSA.ApplicationData.ProgramDataPath, IconDownloader.IconName(txtURL.Text) + ".ico"), true);
            }

            // Browse
            dlgCreateShortcut.InitialDirectory = startMenu ? UEnvironment.SHGetFolderPath(UEnvironment.CSIDL_COMMON_PROGRAMS) : "";
            if (dlgCreateShortcut.ShowDialog() != DialogResult.OK)
                return;

            // Shortcut
            CreateShortcut(dlgCreateShortcut.FileName);
            MessageBox.Show("Shortcut created.", "Web Wrapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //--------------------------------------------------------------------------------
        private void CreateShortcut(string shortcutPath) {
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.Description = Path.GetFileNameWithoutExtension(shortcutPath);
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            shortcut.IconLocation = Path.Combine(CSA.ApplicationData.ProgramDataPath, IconDownloader.IconName(txtURL.Text) + ".ico, 0");
            shortcut.Arguments = $"-name \"{shortcut.Description}\" " +
                                 $"-url \"{txtURL.Text}\" " +
                                 $"-browser \"{BrowserName}\" " +
                                 $"-width {numWidth.Value} " +
                                 $"-height {numHeight.Value} " +
                                 (chkMaximise.Checked ? "-maximise " : "") +
                                 (chkCaching.Checked ? "-cache " : "");
            shortcut.Save();
        }
    }

}
