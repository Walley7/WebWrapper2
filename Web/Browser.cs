using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WebWrapper2.Web {

    public abstract class Browser {
        //================================================================================
        protected List<HistoryEntry>            mNavigationHistory = new List<HistoryEntry>();


        //================================================================================
        //--------------------------------------------------------------------------------
        public abstract void Dispose();


        // NAME ================================================================================
        //--------------------------------------------------------------------------------
        public virtual string Name { get; }


        // CONTROLS ================================================================================
        //--------------------------------------------------------------------------------
        public abstract Control Control { get; }


        // BROWSER ================================================================================
        //--------------------------------------------------------------------------------
        public abstract string Address { get; }
        public abstract void Load(string url);
        public abstract void Reload();
        public abstract void Forward();
        public abstract void Back();
        public abstract bool ExecuteScript(string script, out object result);


        // NAVIGATION HISTORY ================================================================================
        //--------------------------------------------------------------------------------
        public virtual void GoToNavigationHistory(int index) {
            // Checks
            if ((index < 0) || (index >= mNavigationHistory.Count) || mNavigationHistory[index].active)
                return;

            // Active index
            int activeIndex = -1;
            for (int i = 0; i < mNavigationHistory.Count; ++i) {
                if (mNavigationHistory[i].active) {
                    activeIndex = i;
                    break;
                }
            }

            // Navigate
            if (index > activeIndex) {
                while (--index >= activeIndex) {
                    Forward();
                }
            }
            else if (index < activeIndex) {
                while (++index <= activeIndex) {
                    Back();
                }
            }  
        }
        
        //--------------------------------------------------------------------------------
        public abstract List<HistoryEntry> NavigationHistory { get; }
        public virtual bool SupportsNavigationHistory { get { return true; } }


        //================================================================================
        //********************************************************************************
        public class HistoryEntry {
            public string title;
            public string url;
            public bool active;
            public object data;

            public HistoryEntry(string title, string url, bool active, object data = null) {
                this.title = title;
                this.url = url;
                this.active = active;
                this.data = data;
            }

            public override string ToString() { return (title != null ? title : url); }
        }
    }

}
