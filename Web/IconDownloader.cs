using CSACore.Utility;
using FaviconFetcher;
using FreeImageAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebWrapper2.Web {

    public class IconDownloader {
        //================================================================================
        public const int                        ERROR_NONE = 0;
        public const int                        ERROR_INVALID_URL = 1;
        public const int                        ERROR_TIMED_OUT = 2;
        public const int                        ERROR_NOT_FOUND = 3;
        public const int                        ERROR_FAILED = 4;


        //================================================================================
        private volatile int                    mError = ERROR_NONE;
        private volatile string                 mErrorMessage = "";

        private volatile string                 mDownloadIconURL = null;
        private volatile string                 mDownloadIconPath = null;
        private volatile bool                   mDownloadIconCompleted = false;


        //================================================================================
        //--------------------------------------------------------------------------------
        public IconDownloader() { }


        // ICONS ================================================================================
        //--------------------------------------------------------------------------------
        public bool DownloadIcon(string url, string path, int timeout) {
            // URL
            if (url.Length == 0) {
                mError = ERROR_INVALID_URL;
                return false;
            }

            Uri uri;
            try { uri = new UriBuilder(url).Uri; }
            catch (UriFormatException) {
                mError = ERROR_INVALID_URL;
                return false;
            }

            // Protocols
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.DefaultConnectionLimit = 9999;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Fixes an SSL error when downloading icons on Windows 7, for example from https://www.pdffiller.com/en/forms/dashboard
            //ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;

            // Download
            mDownloadIconURL = url;
            mDownloadIconPath = path;
            mDownloadIconCompleted = false;
            mError = ERROR_NONE;
            mErrorMessage = "";
            Favicon icon = new Favicon();
            icon.GetFromUrlAsyncCompleted += DownloadIcon_OnDownloaded;
            icon.GetFromUrlAsync(uri, timeout);

            // Wait
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (!mDownloadIconCompleted) {
                if (stopwatch.ElapsedMilliseconds > timeout) {
                    mError = ERROR_TIMED_OUT;
                    break;
                }
            }

            // Result
            return (mError == ERROR_NONE);
        }

        //--------------------------------------------------------------------------------
        // Uses favicon fetcher library.
        public bool DownloadIcon2(string url, string path, int timeout) {
            // URL
            if (url.Length == 0) {
                mError = ERROR_INVALID_URL;
                return false;
            }

            Uri uri;
            try { uri = new UriBuilder(url).Uri; }
            catch (UriFormatException) {
                mError = ERROR_INVALID_URL;
                return false;
            }
            
            // Protocols
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Download
            mDownloadIconURL = url;
            mDownloadIconPath = path;
            Fetcher fetcher = new Fetcher();
            Image icon = null;
            try { icon = fetcher.FetchClosest(uri, new Size(32, 32)); }
            catch (Exception e) {
                mError = ERROR_NOT_FOUND;
                mErrorMessage = e.Message;
                return false;
            }

            // Not found
            if (icon == null) {
                mError = ERROR_NOT_FOUND;
                return false;
            }

            // Save
            SaveIcon(icon);
            return true;
        }
        
        //--------------------------------------------------------------------------------
        private void DownloadIcon_OnDownloaded(object sender, EventArgs e) {
            // Icon
            Favicon icon = (Favicon)sender;
            if (icon.Icon == null) {
                mError = ERROR_NOT_FOUND;
                if (((AsyncCompletedEventArgs)e).Error != null)
                    mErrorMessage = ((AsyncCompletedEventArgs)e).Error.Message;
                mDownloadIconCompleted = true;
                return;
            }

            // Save
            SaveIcon(icon.Icon);
        }

        //--------------------------------------------------------------------------------
        private void SaveIcon(Image icon) {
            // Filename
            string filename = IconName(mDownloadIconURL);

            // Save
            string path = Path.Combine(mDownloadIconPath, filename + ".ico");
            FreeImageBitmap bitmap = new FreeImageBitmap(icon);
            bitmap.Rescale(48, 48, FREE_IMAGE_FILTER.FILTER_BICUBIC);
            bitmap.Save(path);
            bitmap.Rescale(32, 32, FREE_IMAGE_FILTER.FILTER_BICUBIC);
            bitmap.SaveAdd(path);
            bitmap.Rescale(16, 16, FREE_IMAGE_FILTER.FILTER_BICUBIC);
            bitmap.SaveAdd(path);
            mDownloadIconCompleted = true;
        }

        //--------------------------------------------------------------------------------
        public bool DownloadIconIfMissing(string url, string path, int timeout) {
            if (File.Exists(Path.Combine(path, IconName(url) + ".ico")))
                return true;
            else {
                Directory.CreateDirectory(path);
                return DownloadIcon(url, path, timeout);
            }
        }

        //--------------------------------------------------------------------------------
        public bool DownloadIconIfMissing2(string url, string path, int timeout) {
            if (File.Exists(Path.Combine(path, IconName(url) + ".ico")))
                return true;
            else {
                Directory.CreateDirectory(path);
                return DownloadIcon2(url, path, timeout);
            }
        }

        //--------------------------------------------------------------------------------
        public static string IconName(string url) {
            string name = UWeb.BaseURL(url, 200);
            name = name.Replace('<', '_');
            name = name.Replace('>', '_');
            name = name.Replace(':', '_');
            name = name.Replace('"', '_');
            name = name.Replace('/', '_');
            name = name.Replace('\\', '_');
            name = name.Replace('|', '_');
            name = name.Replace('?', '_');
            name = name.Replace('*', '_');
            return name;
        }


        // ERRORS ================================================================================
        //--------------------------------------------------------------------------------
        public int Error { get { return mError; } }

        //--------------------------------------------------------------------------------
        public string ErrorString {
            get {
                switch (mError) {
                    case ERROR_NONE:        return "";
                    case ERROR_INVALID_URL: return "Invalid url";
                    case ERROR_TIMED_OUT:   return "Timed out";
                    case ERROR_NOT_FOUND:   return "Not found";
                    case ERROR_FAILED:      return "Failed";
                    default:                return mError.ToString();
                }
            }
        }
        
        //--------------------------------------------------------------------------------
        public string ErrorMessage { get { return mErrorMessage; } }
    }

}
