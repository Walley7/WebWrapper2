using CefSharp;
using CefSharp.Handler;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WebWrapper2.Web {

    public class ChromeBrowser : Browser {
        //================================================================================
        public const string                     APPLICATION_DIRECTORY = "Web Wrapper";

        public const int                        HISTORY_MAXIMUM_WAIT_TIME = 100;

        public const string                     HOST_HANDLE_CLASS_NAME = "Chrome_RenderWidgetHostHWND";


        //================================================================================
        private ChromiumWebBrowser              mControl;

        private ChromeHostMessageHandler        mHostMessageHandler = null;


        //================================================================================
        //--------------------------------------------------------------------------------
        public ChromeBrowser(bool cache) {
            // Initialise
            CefSettings settings = new CefSettings();
            if (cache)
                settings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), APPLICATION_DIRECTORY);
            Cef.Initialize(settings);

            // Browser
            mControl = new ChromiumWebBrowser("");

            // Events
            mControl.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            mControl.RequestHandler = new ChromeRequestHandler();
        }

        //--------------------------------------------------------------------------------
        public override void Dispose() {
            mControl.Dispose();
            Cef.Shutdown();
        }


        // EVENTS ================================================================================
        //--------------------------------------------------------------------------------
        protected void OnIsBrowserInitializedChanged(object sender, EventArgs e) {
            if (mControl.IsBrowserInitialized)
                Task.Run(() => EstablishClickHandling());
        }


        // NAME ================================================================================
        //--------------------------------------------------------------------------------
        public override string Name { get { return "Chrome"; } }


        // CONTROLS ================================================================================
        //--------------------------------------------------------------------------------
        public override Control Control { get { return mControl; } }


        // BROWSER ================================================================================
        //--------------------------------------------------------------------------------
        public override string Address { get { return mControl.Address; } }
        public override void Load(string url) { mControl.Load(url); }
        public override void Reload() { mControl.Reload(); }
        public override void Forward() { mControl.Forward(); }
        public override void Back() { mControl.Back(); }

        //--------------------------------------------------------------------------------
        public override bool ExecuteScript(string script, out object result) {
            JavascriptResponse response = mControl.EvaluateScriptAsync(script).Result;
            result = response.Result;
            return response.Success;
        }


        // NAVIGATION HISTORY ================================================================================
        //--------------------------------------------------------------------------------
        public override List<HistoryEntry> NavigationHistory {
            get {
                // Variables
                mNavigationHistory.Clear();
                NavigationEntryVisitor visitor = new NavigationEntryVisitor(mNavigationHistory);

                // Visit
                mControl.GetBrowserHost().GetNavigationEntries(visitor, false);
                visitor.done.WaitOne(HISTORY_MAXIMUM_WAIT_TIME);
                return mNavigationHistory;
            }
        }


        // CLICK HANDLING ================================================================================
        //--------------------------------------------------------------------------------
        // This is for the purpose of having popup menus close when the browser is
        // clicked - unforunately there's not a built in way to handle this.
        private void EstablishClickHandling() {
            // Variables
            ChromiumWebBrowser control = mControl;
            mHostMessageHandler = null;

            // Click handling
            try {
                while (mHostMessageHandler == null) {
                    control.Invoke((Action)(() => {
                        if (FindHostHandle(control, out IntPtr hostHandle))
                            mHostMessageHandler = new ChromeHostMessageHandler(hostHandle);
                        else
                            Thread.Sleep(10); // Chrome's message-loop window may not be established yet
                    }));
                }
            }
            catch { }
        }

        //--------------------------------------------------------------------------------
        private bool FindHostHandle(ChromiumWebBrowser browser, out IntPtr hostHandle) {
            ChromeHostHandleFinder hostHandleFinder = new ChromeHostHandleFinder();
            hostHandle = hostHandleFinder.Find(browser.Handle);
            return (hostHandle != IntPtr.Zero);
        }
        

        //================================================================================
        //********************************************************************************
        protected class ChromeRequestHandler : RequestHandler {
            protected override bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect) {
                if (request.Url.StartsWith("mailto:")) {
                    Process.Start(request.Url); 
                    return true;
                }
                return false;
            }
        }

        //********************************************************************************
        public class NavigationEntryVisitor : INavigationEntryVisitor {
            public List<HistoryEntry> history;
            public AutoResetEvent done = new AutoResetEvent(false);

            public NavigationEntryVisitor(List<HistoryEntry> history) {
                this.history = history;
            }

            public void Dispose() { }

            public virtual bool Visit(NavigationEntry entry, bool current, int index, int total) {
                this.history.Add(new HistoryEntry(entry.Title, entry.Url, entry.IsCurrent));
                if (index + 1 >= total)
                    done.Set();
                return true;
            }
        }

        //********************************************************************************
        private class ChromeHostMessageHandler : NativeWindow {
            const int WM_MOUSE_ACTIVATE = 0x0021;
            const int WM_NCL_BUTTON_DOWN = 0x00A1;

            public ChromeHostMessageHandler(IntPtr hostHandle) {
                AssignHandle(hostHandle);
            }

            protected override void WndProc(ref Message message) {
                base.WndProc(ref message);
                if (message.Msg == WM_MOUSE_ACTIVATE)
                    PostMessage(message.WParam, WM_NCL_BUTTON_DOWN, IntPtr.Zero, IntPtr.Zero);
            }

            [return: MarshalAs(UnmanagedType.Bool)] [DllImport("user32.dll", SetLastError = true)]
            static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        }
        
        //********************************************************************************
        private class ChromeHostHandleFinder {
            private IntPtr mHostHandle;

            public IntPtr Find(IntPtr browserHandle) {
                mHostHandle = IntPtr.Zero;
                EnumChildWindows(browserHandle, new EnumWindowProc(EnumWindow), IntPtr.Zero);
                return mHostHandle;
            }

            private bool EnumWindow(IntPtr hWnd, IntPtr lParam) {
                StringBuilder builder = new StringBuilder(128);
                GetClassName(hWnd, builder, builder.Capacity);
                if (builder.ToString().Equals(HOST_HANDLE_CLASS_NAME)) {
                    mHostHandle = hWnd;
                    return false;
                }
                return true;
            }

            [DllImport("user32")] [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        }

        //********************************************************************************
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);
    }

}
