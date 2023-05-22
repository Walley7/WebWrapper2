namespace WebWrapper2.Forms {
    partial class BrowserForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.tlpBase = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblBrowser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnForwardHistory = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnBackHistory = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNewShortcut = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.mnuNavigation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlpBase.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBase
            // 
            this.tlpBase.ColumnCount = 1;
            this.tlpBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBase.Controls.Add(this.pnlBrowser, 0, 1);
            this.tlpBase.Controls.Add(this.tlpTop, 0, 0);
            this.tlpBase.Controls.Add(this.lblStatus, 0, 2);
            this.tlpBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBase.Location = new System.Drawing.Point(0, 0);
            this.tlpBase.Name = "tlpBase";
            this.tlpBase.RowCount = 3;
            this.tlpBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBase.Size = new System.Drawing.Size(800, 450);
            this.tlpBase.TabIndex = 2;
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowser.Location = new System.Drawing.Point(0, 35);
            this.pnlBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(800, 395);
            this.pnlBrowser.TabIndex = 0;
            // 
            // tlpTop
            // 
            this.tlpTop.ColumnCount = 3;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTop.Controls.Add(this.lblBrowser, 1, 0);
            this.tlpTop.Controls.Add(this.panel1, 0, 0);
            this.tlpTop.Controls.Add(this.btnNewShortcut, 2, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(0, 0);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(800, 35);
            this.tlpTop.TabIndex = 1;
            // 
            // lblBrowser
            // 
            this.lblBrowser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBrowser.ForeColor = System.Drawing.Color.LightGray;
            this.lblBrowser.Location = new System.Drawing.Point(672, 10);
            this.lblBrowser.Name = "lblBrowser";
            this.lblBrowser.Size = new System.Drawing.Size(91, 15);
            this.lblBrowser.TabIndex = 7;
            this.lblBrowser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnForwardHistory);
            this.panel1.Controls.Add(this.btnForward);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnBackHistory);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 35);
            this.panel1.TabIndex = 2;
            // 
            // btnForwardHistory
            // 
            this.btnForwardHistory.BackColor = System.Drawing.SystemColors.Control;
            this.btnForwardHistory.BackgroundImage = global::WebWrapper2.Properties.Resources.navigation_button;
            this.btnForwardHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnForwardHistory.FlatAppearance.BorderSize = 0;
            this.btnForwardHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForwardHistory.Location = new System.Drawing.Point(107, 3);
            this.btnForwardHistory.Name = "btnForwardHistory";
            this.btnForwardHistory.Size = new System.Drawing.Size(10, 28);
            this.btnForwardHistory.TabIndex = 6;
            this.btnForwardHistory.UseVisualStyleBackColor = false;
            this.btnForwardHistory.Click += new System.EventHandler(this.btnForwardHistory_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.SystemColors.Control;
            this.btnForward.BackgroundImage = global::WebWrapper2.Properties.Resources.forward;
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnForward.FlatAppearance.BorderSize = 0;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForward.Location = new System.Drawing.Point(80, 3);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(28, 28);
            this.btnForward.TabIndex = 4;
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.BackgroundImage = global::WebWrapper2.Properties.Resources.back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Location = new System.Drawing.Point(46, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(28, 28);
            this.btnBack.TabIndex = 3;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBackHistory
            // 
            this.btnBackHistory.BackColor = System.Drawing.SystemColors.Control;
            this.btnBackHistory.BackgroundImage = global::WebWrapper2.Properties.Resources.navigation_button;
            this.btnBackHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackHistory.FlatAppearance.BorderSize = 0;
            this.btnBackHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackHistory.Location = new System.Drawing.Point(37, 3);
            this.btnBackHistory.Name = "btnBackHistory";
            this.btnBackHistory.Size = new System.Drawing.Size(10, 28);
            this.btnBackHistory.TabIndex = 7;
            this.btnBackHistory.UseVisualStyleBackColor = false;
            this.btnBackHistory.Click += new System.EventHandler(this.btnBackHistory_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.BackgroundImage = global::WebWrapper2.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 28);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNewShortcut
            // 
            this.btnNewShortcut.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewShortcut.BackgroundImage = global::WebWrapper2.Properties.Resources.add;
            this.btnNewShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewShortcut.FlatAppearance.BorderSize = 0;
            this.btnNewShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewShortcut.Location = new System.Drawing.Point(769, 3);
            this.btnNewShortcut.Name = "btnNewShortcut";
            this.btnNewShortcut.Size = new System.Drawing.Size(28, 28);
            this.btnNewShortcut.TabIndex = 7;
            this.btnNewShortcut.UseVisualStyleBackColor = false;
            this.btnNewShortcut.Click += new System.EventHandler(this.btnNewShortcut_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(1, 434);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(1, 4, 3, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(796, 13);
            this.lblStatus.TabIndex = 2;
            // 
            // mnuNavigation
            // 
            this.mnuNavigation.Name = "mnuNavigation";
            this.mnuNavigation.Size = new System.Drawing.Size(61, 4);
            this.mnuNavigation.Opening += new System.ComponentModel.CancelEventHandler(this.mnuNavigation_Opening);
            this.mnuNavigation.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuNavigation_ItemClicked);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BrowserForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrowserForm_FormClosed);
            this.tlpBase.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpBase;
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.Label lblBrowser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnForwardHistory;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnBackHistory;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNewShortcut;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ContextMenuStrip mnuNavigation;
    }
}