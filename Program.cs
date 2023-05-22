using CSACore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebWrapper2.Forms;



namespace WebWrapper2 {

    static class Program {
        //================================================================================
        //--------------------------------------------------------------------------------
        [STAThread]
        static void Main(string[] args) {
            // Initialise
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialise - CSA
            try { CSA.Initialise(args, null, "CSA", "Web Wrapper"); }
            catch (Exception e) {
                MessageBox.Show("Failed to initialise: " + e.Message, "Web Wrapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Configuration
            BrowserForm.Config config = new BrowserForm.Config();
            config.url = (CSA.Arguments["-url"] ?? "").ToLower();
            config.name = (CSA.Arguments["-name"] ?? config.url);

            string browser = (CSA.Arguments["-browser"] ?? "").ToLower();
            switch (browser) {
                case "chrome":  config.browser = BrowserForm.BrowserType.CHROME; break;
                case "ie":      config.browser = BrowserForm.BrowserType.INTERNET_EXPLORER; break;
                default:        config.browser = BrowserForm.BrowserType.CHROME; break;
            }

            config.width = int.Parse(CSA.Arguments["-width"] ?? "1024");
            config.height = int.Parse(CSA.Arguments["-height"] ?? "768");
            config.maximise = CSA.Arguments.Contains("-maximise");
            config.cache = CSA.Arguments.Contains("-cache");

            // Run
            try {
                if (!string.IsNullOrWhiteSpace(config.url))
                    Application.Run(new BrowserForm(config));
                else
                    Application.Run(new NewShortcutForm());
            }
            finally {
                // Shutdown
                CSA.Shutdown();
            }
        }
    }
}
