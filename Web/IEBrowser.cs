using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WebWrapper2.Web {

    public class IEBrowser : Browser {
        //================================================================================
        public enum TLMENUF {
            TLEF_RELATIVE_INCLUDE_CURRENT = 0x00000001,
            TLEF_RELATIVE_BACK = 0x00000010,
            TLEF_RELATIVE_FORE = 0x00000020,
            TLEF_INCLUDE_UNINVOKEABLE = 0x00000040,
            TLEF_ABSOLUTE = 0x00000031
        }
        
        //--------------------------------------------------------------------------------
        public static Guid IID_I_TRAVEL_LOG_STG = new Guid("7EBFDD80-AD18-11d3-A4C5-00C04F72D6B8");
        public static Guid STD_S_TRAVEL_LOG_CURSOR = new Guid("7EBFDD80-AD18-11d3-A4C5-00C04F72D6B8");
        public const int H_RESULT_S_OK = 0x00000000;


        //================================================================================
        private WebBrowser                      mControl;


        //================================================================================
        //--------------------------------------------------------------------------------
        public IEBrowser(bool cache) {
            // Browser
            mControl = new WebBrowser();
            mControl.ScriptErrorsSuppressed = true;
        }

        //--------------------------------------------------------------------------------
        public override void Dispose() {
            mControl.Dispose();
        }


        // NAME ================================================================================
        //--------------------------------------------------------------------------------
        public override string Name { get { return "Internet Explorer"; } }


        // CONTROLS ================================================================================
        //--------------------------------------------------------------------------------
        public override Control Control { get { return mControl; } }


        // BROWSER ================================================================================
        //--------------------------------------------------------------------------------
        public override string Address { get { return mControl.Url.AbsolutePath; } }
        public override void Load(string url) { mControl.Navigate(url); }
        public override void Reload() { mControl.Refresh(); }
        public override void Forward() { mControl.GoForward(); }
        public override void Back() { mControl.GoBack(); }

        //--------------------------------------------------------------------------------
        public override bool ExecuteScript(string script, out object result) {
            throw new NotImplementedException();
            // Below would require re-creating the script each time, to avoid an endless amount of them the more this is called
            //HtmlDocument doc = browser.Document;
            //HtmlElement head = doc.GetElementsByTagName("head")[0];
            //HtmlElement s = doc.CreateElement("script");
            //s.SetAttribute("text","function sayTest() { alert('test'); }");
            //head.AppendChild(s);
            //browser.Document.InvokeScript("sayTest");
        }


        // NAVIGATION HISTORY ================================================================================
        //--------------------------------------------------------------------------------
        public override List<HistoryEntry> NavigationHistory {
            get {
                // IE history
                List<HistoryEntry> history = IENavigationHistory((int)TLMENUF.TLEF_ABSOLUTE);
                List<HistoryEntry> historyCurrent = IENavigationHistory((int)TLMENUF.TLEF_RELATIVE_INCLUDE_CURRENT);
                List<HistoryEntry> historyForward = IENavigationHistory((int)TLMENUF.TLEF_RELATIVE_FORE);
                List<HistoryEntry> historyBack = IENavigationHistory((int)TLMENUF.TLEF_RELATIVE_BACK);

                // Current page
                if (historyCurrent.Count == 0 || history.Count == historyBack.Count) // We appear to only need one of these conditions, but let's be safe
                    history.Add(new HistoryEntry(mControl.DocumentTitle, mControl.Url.AbsoluteUri, false));

                // Active page
                if (history.Count > 0)
                    history[history.Count - historyForward.Count - 1].active = true;

                // Return
                mNavigationHistory = history;
                return mNavigationHistory;
            }
        }

        //--------------------------------------------------------------------------------
        private List<HistoryEntry> IENavigationHistory(int travelLogEnumFlags) {
            // Variables
            List<HistoryEntry> history = new List<HistoryEntry>();

            // Interfaces
            SHDocVw.IWebBrowser2 webBrowser2 = (SHDocVw.IWebBrowser2)mControl.ActiveXInstance;
            IServiceProvider serviceProvider = webBrowser2 as IServiceProvider;
            if (serviceProvider == null)
                return history;

            // Query service
            int hResult = serviceProvider.QueryService(ref STD_S_TRAVEL_LOG_CURSOR, ref IID_I_TRAVEL_LOG_STG, out IntPtr oret);
            if (oret == IntPtr.Zero || hResult != H_RESULT_S_OK)
                return history;

            // Travel log
            ITravelLogStg travelLogStg = Marshal.GetObjectForIUnknown(oret) as ITravelLogStg;
            if (travelLogStg != null) {
                // Count
                travelLogStg.GetCount(travelLogEnumFlags, out int historyCount);
                if (historyCount == 0)
                    return history;
                //Debug.WriteLine($"IE History Count {historyCount}");

                // Enumerator
                travelLogStg.EnumEntries(travelLogEnumFlags, out IEnumTravelLogEntry travelLogEnumerator);
                if (travelLogEnumerator == null)
                    return history;

                // Variables
                hResult = 0;
                ITravelLogEntry entry = null;
                int fetched = 0;

                // Fetch
                hResult = travelLogEnumerator.Next(1, out entry, out fetched);
                Marshal.ThrowExceptionForHR(hResult);
                    
                // Entries
                for (int i = 0; hResult == H_RESULT_S_OK; ++i) {
                    if (entry != null) {
                        IntPtr title = IntPtr.Zero;
                        IntPtr url = IntPtr.Zero;
                        entry.GetTitle(out title);
                        entry.GetURL(out url);
                        if (title != IntPtr.Zero || url != IntPtr.Zero)
                            history.Add(new HistoryEntry(title != IntPtr.Zero ? Marshal.PtrToStringUni(title) : "", url != IntPtr.Zero ? Marshal.PtrToStringUni(url) : "", false, entry));
                    }

                    // Next
                    hResult = travelLogEnumerator.Next(1, out entry, out fetched);
                    Marshal.ThrowExceptionForHR(hResult);
                }

                // Release
                Marshal.ReleaseComObject(travelLogEnumerator);
                Marshal.ReleaseComObject(travelLogStg);
            }

            // Return
            return history;
        }


        //================================================================================
        //********************************************************************************
        [ComImport, ComVisible(true)] [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")] [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IServiceProvider {
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int QueryService([In] ref Guid guidService, [In] ref Guid riid, [Out] out IntPtr ppvObject);
        }

        //********************************************************************************
        [ComVisible(true), ComImport()] [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] [GuidAttribute("7EBFDD87-AD18-11d3-A4C5-00C04F72D6B8")]
        public interface ITravelLogEntry {
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int GetTitle([Out] out IntPtr ppszTitle);
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int GetURL([Out] out IntPtr ppszURL);
        }

        //********************************************************************************
        [ComVisible(true), ComImport()] [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] [GuidAttribute("7EBFDD85-AD18-11d3-A4C5-00C04F72D6B8")]
        public interface IEnumTravelLogEntry {
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig]
            int Next([In, MarshalAs(UnmanagedType.U4)] int celt, [Out] out ITravelLogEntry rgelt, [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
            void Reset();
            void Clone([Out] out ITravelLogEntry ppenum);
        }

        //********************************************************************************
        [ComVisible(true), ComImport()] [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] [GuidAttribute("7EBFDD80-AD18-11d3-A4C5-00C04F72D6B8")]
        public interface ITravelLogStg {
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig]
            int CreateEntry([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle,
                            [In] ITravelLogEntry ptleRelativeTo, [In, MarshalAs( UnmanagedType.Bool)] bool fPrepend, [Out] out ITravelLogEntry pptle);

            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int TravelTo([In] ITravelLogEntry ptle);
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int EnumEntries([In] int TLENUMF_flags, [Out] out IEnumTravelLogEntry ppenum);

            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig]
            int FindEntries([In] int TLENUMF_flags, [In, MarshalAs( UnmanagedType.LPWStr)] string pszUrl, [Out] out IEnumTravelLogEntry ppenum);

            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int GetCount([In] int TLENUMF_flags, [Out] out int pcEntries);
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int RemoveEntry([In] ITravelLogEntry ptle);
            [return: MarshalAs(UnmanagedType.I4)] [PreserveSig] int GetRelativeEntry([In] int iOffset, [Out] out ITravelLogEntry ptle);
        }
    }

}
