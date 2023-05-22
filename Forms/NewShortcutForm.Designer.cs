namespace WebWrapper2.Forms {
    partial class NewShortcutForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewShortcutForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.rdbBrowserChrome = new System.Windows.Forms.RadioButton();
            this.rdbBrowserInternetExplorer = new System.Windows.Forms.RadioButton();
            this.rdbSizeLarge = new System.Windows.Forms.RadioButton();
            this.rdbSizeMedium = new System.Windows.Forms.RadioButton();
            this.rdbSizeSmall = new System.Windows.Forms.RadioButton();
            this.chkMaximise = new System.Windows.Forms.CheckBox();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkCaching = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCreateInStartMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbSizeCustom = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dlgCreateShortcut = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Browser";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Size";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(102, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(483, 20);
            this.txtURL.TabIndex = 8;
            // 
            // rdbBrowserChrome
            // 
            this.rdbBrowserChrome.AutoSize = true;
            this.rdbBrowserChrome.Checked = true;
            this.rdbBrowserChrome.Location = new System.Drawing.Point(3, 1);
            this.rdbBrowserChrome.Name = "rdbBrowserChrome";
            this.rdbBrowserChrome.Size = new System.Drawing.Size(61, 17);
            this.rdbBrowserChrome.TabIndex = 9;
            this.rdbBrowserChrome.TabStop = true;
            this.rdbBrowserChrome.Text = "Chrome";
            this.rdbBrowserChrome.UseVisualStyleBackColor = true;
            // 
            // rdbBrowserInternetExplorer
            // 
            this.rdbBrowserInternetExplorer.AutoSize = true;
            this.rdbBrowserInternetExplorer.Location = new System.Drawing.Point(70, 1);
            this.rdbBrowserInternetExplorer.Name = "rdbBrowserInternetExplorer";
            this.rdbBrowserInternetExplorer.Size = new System.Drawing.Size(102, 17);
            this.rdbBrowserInternetExplorer.TabIndex = 10;
            this.rdbBrowserInternetExplorer.Text = "Internet Explorer";
            this.rdbBrowserInternetExplorer.UseVisualStyleBackColor = true;
            // 
            // rdbSizeLarge
            // 
            this.rdbSizeLarge.AutoSize = true;
            this.rdbSizeLarge.Location = new System.Drawing.Point(3, 1);
            this.rdbSizeLarge.Name = "rdbSizeLarge";
            this.rdbSizeLarge.Size = new System.Drawing.Size(52, 17);
            this.rdbSizeLarge.TabIndex = 11;
            this.rdbSizeLarge.Text = "Large";
            this.rdbSizeLarge.UseVisualStyleBackColor = true;
            this.rdbSizeLarge.CheckedChanged += new System.EventHandler(this.rdbSizeLarge_CheckedChanged);
            // 
            // rdbSizeMedium
            // 
            this.rdbSizeMedium.AutoSize = true;
            this.rdbSizeMedium.Checked = true;
            this.rdbSizeMedium.Location = new System.Drawing.Point(61, 1);
            this.rdbSizeMedium.Name = "rdbSizeMedium";
            this.rdbSizeMedium.Size = new System.Drawing.Size(62, 17);
            this.rdbSizeMedium.TabIndex = 12;
            this.rdbSizeMedium.TabStop = true;
            this.rdbSizeMedium.Text = "Medium";
            this.rdbSizeMedium.UseVisualStyleBackColor = true;
            this.rdbSizeMedium.CheckedChanged += new System.EventHandler(this.rdbSizeMedium_CheckedChanged);
            // 
            // rdbSizeSmall
            // 
            this.rdbSizeSmall.AutoSize = true;
            this.rdbSizeSmall.Location = new System.Drawing.Point(129, 1);
            this.rdbSizeSmall.Name = "rdbSizeSmall";
            this.rdbSizeSmall.Size = new System.Drawing.Size(50, 17);
            this.rdbSizeSmall.TabIndex = 13;
            this.rdbSizeSmall.Text = "Small";
            this.rdbSizeSmall.UseVisualStyleBackColor = true;
            this.rdbSizeSmall.CheckedChanged += new System.EventHandler(this.rdbSizeSmall_CheckedChanged);
            // 
            // chkMaximise
            // 
            this.chkMaximise.AutoSize = true;
            this.chkMaximise.Location = new System.Drawing.Point(102, 111);
            this.chkMaximise.Name = "chkMaximise";
            this.chkMaximise.Size = new System.Drawing.Size(15, 14);
            this.chkMaximise.TabIndex = 14;
            this.chkMaximise.UseVisualStyleBackColor = true;
            // 
            // numHeight
            // 
            this.numHeight.Enabled = false;
            this.numHeight.Location = new System.Drawing.Point(168, 85);
            this.numHeight.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(60, 20);
            this.numHeight.TabIndex = 28;
            this.numHeight.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // numWidth
            // 
            this.numWidth.Enabled = false;
            this.numWidth.Location = new System.Drawing.Point(102, 85);
            this.numWidth.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(60, 20);
            this.numWidth.TabIndex = 27;
            this.numWidth.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Dimensions";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Maximise";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Caching";
            // 
            // chkCaching
            // 
            this.chkCaching.AutoSize = true;
            this.chkCaching.Location = new System.Drawing.Point(58, 19);
            this.chkCaching.Name = "chkCaching";
            this.chkCaching.Size = new System.Drawing.Size(15, 14);
            this.chkCaching.TabIndex = 15;
            this.chkCaching.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(430, 177);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 31;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCreateInStartMenu
            // 
            this.btnCreateInStartMenu.Location = new System.Drawing.Point(296, 177);
            this.btnCreateInStartMenu.Name = "btnCreateInStartMenu";
            this.btnCreateInStartMenu.Size = new System.Drawing.Size(128, 23);
            this.btnCreateInStartMenu.TabIndex = 32;
            this.btnCreateInStartMenu.Text = "Create in Start Menu";
            this.btnCreateInStartMenu.UseVisualStyleBackColor = true;
            this.btnCreateInStartMenu.Visible = false;
            this.btnCreateInStartMenu.Click += new System.EventHandler(this.btnCreateInStartMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(511, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbBrowserChrome);
            this.panel2.Controls.Add(this.rdbBrowserInternetExplorer);
            this.panel2.Location = new System.Drawing.Point(102, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 22);
            this.panel2.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdbSizeCustom);
            this.panel3.Controls.Add(this.rdbSizeLarge);
            this.panel3.Controls.Add(this.rdbSizeMedium);
            this.panel3.Controls.Add(this.rdbSizeSmall);
            this.panel3.Location = new System.Drawing.Point(102, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 22);
            this.panel3.TabIndex = 35;
            // 
            // rdbSizeCustom
            // 
            this.rdbSizeCustom.AutoSize = true;
            this.rdbSizeCustom.Location = new System.Drawing.Point(185, 1);
            this.rdbSizeCustom.Name = "rdbSizeCustom";
            this.rdbSizeCustom.Size = new System.Drawing.Size(60, 17);
            this.rdbSizeCustom.TabIndex = 14;
            this.rdbSizeCustom.Text = "Custom";
            this.rdbSizeCustom.UseVisualStyleBackColor = true;
            this.rdbSizeCustom.CheckedChanged += new System.EventHandler(this.rdbSizeCustom_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCaching);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 40);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced Options";
            // 
            // dlgCreateShortcut
            // 
            this.dlgCreateShortcut.Filter = "Shortcut|*.lnk";
            this.dlgCreateShortcut.Title = "Create Web Wrapper Shortcut";
            // 
            // NewShortcutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateInStartMenu);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkMaximise);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewShortcutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Wrapper - New Shortcut";
            this.Shown += new System.EventHandler(this.NewShortcutForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.RadioButton rdbBrowserChrome;
        private System.Windows.Forms.RadioButton rdbBrowserInternetExplorer;
        private System.Windows.Forms.RadioButton rdbSizeLarge;
        private System.Windows.Forms.RadioButton rdbSizeMedium;
        private System.Windows.Forms.RadioButton rdbSizeSmall;
        private System.Windows.Forms.CheckBox chkMaximise;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkCaching;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCreateInStartMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbSizeCustom;
        private System.Windows.Forms.SaveFileDialog dlgCreateShortcut;
    }
}