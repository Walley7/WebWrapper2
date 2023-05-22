using CSACore.Core;
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

    public partial class BrowserForm : Form {
        //================================================================================
        public const int                        DOWNLOAD_ICON_TIMEOUT = 5000;


        //================================================================================
        public enum BrowserType {
            CHROME,
            INTERNET_EXPLORER
        }


        //================================================================================
        private Browser                         mBrowser = null;


        //================================================================================
        //--------------------------------------------------------------------------------
        public BrowserForm(Config config) {
            // Component
            InitializeComponent();

            // Initialise
            Initialise(config);
        }

        //--------------------------------------------------------------------------------
        private void Initialise(Config config) {
            // Title
            Text = config.name;

            // Icon
            IconDownloader iconDownloader = new IconDownloader();
            if (iconDownloader.DownloadIconIfMissing2(config.url, CSA.ApplicationData.ProgramDataPath, DOWNLOAD_ICON_TIMEOUT))
                Icon = new Icon(Path.Combine(CSA.ApplicationData.ProgramDataPath, IconDownloader.IconName(config.url) + ".ico"));

            // Dimensions
            Width = config.width;
            Height = config.height;
            if (config.maximise)
                WindowState = FormWindowState.Maximized;

            // Browser
            CreateBrowser(config.browser, config.url, config.cache);

            // Status
            tlpBase.RowStyles[2].Height = 0;

            // Navigation
            btnBack.ContextMenuStrip = mBrowser.SupportsNavigationHistory ? mnuNavigation : null;
            btnForward.ContextMenuStrip = mBrowser.SupportsNavigationHistory ? mnuNavigation : null;
        }

        //--------------------------------------------------------------------------------
        private void Shutdown() {
            // Browser
            DestroyBrowser();
        }
        

        // FORM ================================================================================
        //--------------------------------------------------------------------------------
        private void BrowserForm_FormClosed(object sender, FormClosedEventArgs e) {
            Shutdown();
        }
        
        //--------------------------------------------------------------------------------
        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e) {
            /*if (mConfig.honan) {
                if (!mBrowser.Address.Contains("Login"))
                    e.Cancel = true;
                object result;
                mBrowser.ExecuteScript("noTimerRunning();", out result);
            }*/
        }


        // BROWSER ================================================================================
        //--------------------------------------------------------------------------------
        private void CreateBrowser(BrowserType browserType, string url = "", bool cache = true) {
            // Create
            if (browserType == BrowserType.CHROME)
                mBrowser = new ChromeBrowser(cache);
            else if (browserType == BrowserType.INTERNET_EXPLORER)
                mBrowser = new IEBrowser(cache);

            // Load
            mBrowser.Load(url);

            // Setup
            if (mBrowser != null) {
                lblBrowser.Text = mBrowser.Name;
                mBrowser.Control.Dock = DockStyle.Fill;
                pnlBrowser.Controls.Add(mBrowser.Control);
            }
            else
                lblBrowser.Text = "";
        }

        //--------------------------------------------------------------------------------
        private void DestroyBrowser() {
            if (mBrowser != null) {
                pnlBrowser.Controls.Remove(mBrowser.Control);
                mBrowser.Dispose();
                mBrowser = null;
            }
        }
        
        //--------------------------------------------------------------------------------
        private void btnRefresh_Click(object sender, EventArgs e) {
            mBrowser?.Reload();
        }
        
        //--------------------------------------------------------------------------------
        private void btnBack_Click(object sender, EventArgs e) {
            mBrowser?.Back();
        }
        
        //--------------------------------------------------------------------------------
        private void btnBackHistory_Click(object sender, EventArgs e) {
            if (mBrowser != null && mBrowser.SupportsNavigationHistory)
                mnuNavigation.Show(new Point(MousePosition.X, MousePosition.Y));
        }
        
        //--------------------------------------------------------------------------------
        private void btnForward_Click(object sender, EventArgs e) {
            mBrowser?.Forward();
        }
        
        //--------------------------------------------------------------------------------
        private void btnForwardHistory_Click(object sender, EventArgs e) {
            if (mBrowser != null && mBrowser.SupportsNavigationHistory)
                mnuNavigation.Show(new Point(MousePosition.X, MousePosition.Y));
        }
        
        //--------------------------------------------------------------------------------
        private void btnNewShortcut_Click(object sender, EventArgs e) {
            NewShortcutForm form = new NewShortcutForm();
            form.ShowDialog();
        }

        
        // NAVIGATION MENU ================================================================================
        //--------------------------------------------------------------------------------
        private void mnuNavigation_Opening(object sender, CancelEventArgs e) {
            // History
            mnuNavigation.Items.Clear();
            List<Browser.HistoryEntry> history = mBrowser.NavigationHistory;
            for (int i = history.Count - 1; i >= 0; --i) {
                mnuNavigation.Items.Add(history[i].ToString(), history[i].active ? WebWrapper2.Properties.Resources.navigation_sphere : null);
            }

            // Uncancel
            if (history.Count > 0)
                e.Cancel = false;
        }
        
        //--------------------------------------------------------------------------------
        private void mnuNavigation_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            int navigationIndex = mnuNavigation.Items.Count - mnuNavigation.Items.IndexOf(e.ClickedItem) - 1;
            mBrowser.GoToNavigationHistory(navigationIndex);
        }


        //================================================================================
        //********************************************************************************
        public class Config {
            public string name = null;
            public BrowserType browser = BrowserType.CHROME;
            public string url = null;
            public int width = 1024;
            public int height = 768;
            public bool maximise = false;
            public bool cache = true;
        }
    }

}
