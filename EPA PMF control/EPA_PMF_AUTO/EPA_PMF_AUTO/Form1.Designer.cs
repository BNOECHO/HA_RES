
namespace EPA_PMF_AUTO
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.TBCFG = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelC = new System.Windows.Forms.Label();
            this.labelUC = new System.Windows.Forms.Label();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.textBoxUC = new System.Windows.Forms.TextBox();
            this.labelCW = new System.Windows.Forms.Label();
            this.labelUCW = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Warning = new System.Windows.Forms.Label();
            this.TBWorksheetC = new System.Windows.Forms.TextBox();
            this.TBWorksheetUC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CATsetting = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Targetfolder = new System.Windows.Forms.TextBox();
            this.BrowseFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SpawnTitle = new System.Windows.Forms.TextBox();
            this.Warning2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Runtime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FactorBegin = new System.Windows.Forms.TextBox();
            this.FactorEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.R_U_N = new System.Windows.Forms.Button();
            this.ShowStatus = new System.Windows.Forms.Label();
            this.GetEPAPMF = new System.Windows.Forms.Timer(this.components);
            this.Taged = new System.Windows.Forms.CheckBox();
            this.Geted = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "讀取config檔案";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBCFG
            // 
            this.TBCFG.BackColor = System.Drawing.Color.White;
            this.TBCFG.Location = new System.Drawing.Point(135, 13);
            this.TBCFG.Name = "TBCFG";
            this.TBCFG.ReadOnly = true;
            this.TBCFG.Size = new System.Drawing.Size(400, 22);
            this.TBCFG.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "組態檔|*.cfg";
            this.openFileDialog1.Title = "選擇EPA_PMF組態檔";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(11, 44);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(118, 12);
            this.labelC.TabIndex = 2;
            this.labelC.Text = "Concentration Data File:";
            // 
            // labelUC
            // 
            this.labelUC.AutoSize = true;
            this.labelUC.Location = new System.Drawing.Point(23, 72);
            this.labelUC.Name = "labelUC";
            this.labelUC.Size = new System.Drawing.Size(106, 12);
            this.labelUC.TabIndex = 3;
            this.labelUC.Text = "Uncertainty Data File:";
            // 
            // textBoxC
            // 
            this.textBoxC.BackColor = System.Drawing.Color.White;
            this.textBoxC.Location = new System.Drawing.Point(135, 41);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.ReadOnly = true;
            this.textBoxC.Size = new System.Drawing.Size(400, 22);
            this.textBoxC.TabIndex = 4;
            // 
            // textBoxUC
            // 
            this.textBoxUC.BackColor = System.Drawing.Color.White;
            this.textBoxUC.Location = new System.Drawing.Point(135, 69);
            this.textBoxUC.Name = "textBoxUC";
            this.textBoxUC.ReadOnly = true;
            this.textBoxUC.Size = new System.Drawing.Size(400, 22);
            this.textBoxUC.TabIndex = 5;
            // 
            // labelCW
            // 
            this.labelCW.AutoSize = true;
            this.labelCW.Location = new System.Drawing.Point(541, 44);
            this.labelCW.Name = "labelCW";
            this.labelCW.Size = new System.Drawing.Size(58, 12);
            this.labelCW.TabIndex = 6;
            this.labelCW.Text = "Worksheet:";
            // 
            // labelUCW
            // 
            this.labelUCW.AutoSize = true;
            this.labelUCW.Location = new System.Drawing.Point(541, 72);
            this.labelUCW.Name = "labelUCW";
            this.labelUCW.Size = new System.Drawing.Size(58, 12);
            this.labelUCW.TabIndex = 7;
            this.labelUCW.Text = "Worksheet:";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 123);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(707, 78);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Warning
            // 
            this.Warning.AutoSize = true;
            this.Warning.ForeColor = System.Drawing.Color.Red;
            this.Warning.Location = new System.Drawing.Point(133, 99);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(211, 12);
            this.Warning.TabIndex = 13;
            this.Warning.Text = "**目前僅支援2007以後的Excel(*.xlsx)**";
            // 
            // TBWorksheetC
            // 
            this.TBWorksheetC.BackColor = System.Drawing.Color.White;
            this.TBWorksheetC.Location = new System.Drawing.Point(605, 41);
            this.TBWorksheetC.Name = "TBWorksheetC";
            this.TBWorksheetC.ReadOnly = true;
            this.TBWorksheetC.Size = new System.Drawing.Size(100, 22);
            this.TBWorksheetC.TabIndex = 14;
            // 
            // TBWorksheetUC
            // 
            this.TBWorksheetUC.BackColor = System.Drawing.Color.White;
            this.TBWorksheetUC.Location = new System.Drawing.Point(605, 69);
            this.TBWorksheetUC.Name = "TBWorksheetUC";
            this.TBWorksheetUC.ReadOnly = true;
            this.TBWorksheetUC.Size = new System.Drawing.Size(100, 22);
            this.TBWorksheetUC.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "CAT條件";
            // 
            // CATsetting
            // 
            this.CATsetting.Location = new System.Drawing.Point(605, 13);
            this.CATsetting.Name = "CATsetting";
            this.CATsetting.Size = new System.Drawing.Size(100, 22);
            this.CATsetting.TabIndex = 17;
            this.CATsetting.Text = "1;0.5";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(13, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "儲存CAT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Targetfolder
            // 
            this.Targetfolder.Location = new System.Drawing.Point(135, 208);
            this.Targetfolder.Name = "Targetfolder";
            this.Targetfolder.Size = new System.Drawing.Size(400, 22);
            this.Targetfolder.TabIndex = 19;
            // 
            // BrowseFolder
            // 
            this.BrowseFolder.Location = new System.Drawing.Point(13, 208);
            this.BrowseFolder.Name = "BrowseFolder";
            this.BrowseFolder.Size = new System.Drawing.Size(104, 23);
            this.BrowseFolder.TabIndex = 20;
            this.BrowseFolder.Text = "設定目標資料夾";
            this.BrowseFolder.UseVisualStyleBackColor = true;
            this.BrowseFolder.Click += new System.EventHandler(this.BrowseFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "批次標記:";
            // 
            // SpawnTitle
            // 
            this.SpawnTitle.Enabled = false;
            this.SpawnTitle.Location = new System.Drawing.Point(135, 241);
            this.SpawnTitle.Name = "SpawnTitle";
            this.SpawnTitle.Size = new System.Drawing.Size(185, 22);
            this.SpawnTitle.TabIndex = 22;
            this.SpawnTitle.TextChanged += new System.EventHandler(this.SpawnTitle_TextChanged);
            // 
            // Warning2
            // 
            this.Warning2.AutoSize = true;
            this.Warning2.ForeColor = System.Drawing.Color.Red;
            this.Warning2.Location = new System.Drawing.Point(326, 244);
            this.Warning2.Name = "Warning2";
            this.Warning2.Size = new System.Drawing.Size(209, 12);
            this.Warning2.TabIndex = 23;
            this.Warning2.Text = "**生成重複檔案名時會直接覆蓋原檔**";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "Number of Runs:";
            // 
            // Runtime
            // 
            this.Runtime.Location = new System.Drawing.Point(135, 269);
            this.Runtime.Name = "Runtime";
            this.Runtime.Size = new System.Drawing.Size(40, 22);
            this.Runtime.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "Factors:";
            // 
            // FactorBegin
            // 
            this.FactorBegin.Location = new System.Drawing.Point(228, 269);
            this.FactorBegin.Name = "FactorBegin";
            this.FactorBegin.Size = new System.Drawing.Size(52, 22);
            this.FactorBegin.TabIndex = 27;
            // 
            // FactorEnd
            // 
            this.FactorEnd.Location = new System.Drawing.Point(301, 269);
            this.FactorEnd.Name = "FactorEnd";
            this.FactorEnd.Size = new System.Drawing.Size(53, 22);
            this.FactorEnd.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "-";
            // 
            // R_U_N
            // 
            this.R_U_N.Enabled = false;
            this.R_U_N.Location = new System.Drawing.Point(426, 267);
            this.R_U_N.Name = "R_U_N";
            this.R_U_N.Size = new System.Drawing.Size(109, 23);
            this.R_U_N.TabIndex = 30;
            this.R_U_N.Text = "開始批次執行";
            this.R_U_N.UseVisualStyleBackColor = true;
            this.R_U_N.Click += new System.EventHandler(this.R_U_N_Click);
            // 
            // ShowStatus
            // 
            this.ShowStatus.Location = new System.Drawing.Point(12, 303);
            this.ShowStatus.Name = "ShowStatus";
            this.ShowStatus.Size = new System.Drawing.Size(421, 192);
            this.ShowStatus.TabIndex = 31;
            this.ShowStatus.Text = "Status:";
            // 
            // GetEPAPMF
            // 
            this.GetEPAPMF.Enabled = true;
            this.GetEPAPMF.Interval = 300;
            this.GetEPAPMF.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Taged
            // 
            this.Taged.AutoSize = true;
            this.Taged.BackColor = System.Drawing.Color.White;
            this.Taged.Enabled = false;
            this.Taged.Location = new System.Drawing.Point(543, 210);
            this.Taged.Name = "Taged";
            this.Taged.Size = new System.Drawing.Size(108, 16);
            this.Taged.TabIndex = 32;
            this.Taged.Text = "已填寫批次標記";
            this.Taged.UseVisualStyleBackColor = false;
            this.Taged.CheckedChanged += new System.EventHandler(this.Taged_CheckedChanged);
            // 
            // Geted
            // 
            this.Geted.AutoSize = true;
            this.Geted.BackColor = System.Drawing.Color.White;
            this.Geted.Enabled = false;
            this.Geted.Location = new System.Drawing.Point(543, 232);
            this.Geted.Name = "Geted";
            this.Geted.Size = new System.Drawing.Size(108, 16);
            this.Geted.TabIndex = 33;
            this.Geted.Text = "已取得所有目標";
            this.Geted.UseVisualStyleBackColor = false;
            this.Geted.CheckedChanged += new System.EventHandler(this.Geted_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 486);
            this.Controls.Add(this.Geted);
            this.Controls.Add(this.Taged);
            this.Controls.Add(this.ShowStatus);
            this.Controls.Add(this.R_U_N);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FactorEnd);
            this.Controls.Add(this.FactorBegin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Runtime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Warning2);
            this.Controls.Add(this.SpawnTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseFolder);
            this.Controls.Add(this.Targetfolder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CATsetting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBWorksheetUC);
            this.Controls.Add(this.TBWorksheetC);
            this.Controls.Add(this.Warning);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labelUCW);
            this.Controls.Add(this.labelCW);
            this.Controls.Add(this.textBoxUC);
            this.Controls.Add(this.textBoxC);
            this.Controls.Add(this.labelUC);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.TBCFG);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EPA_PMF_AUTORUN By:B";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBCFG;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelUC;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.TextBox textBoxUC;
        private System.Windows.Forms.Label labelCW;
        private System.Windows.Forms.Label labelUCW;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label Warning;
        private System.Windows.Forms.TextBox TBWorksheetC;
        private System.Windows.Forms.TextBox TBWorksheetUC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CATsetting;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Targetfolder;
        private System.Windows.Forms.Button BrowseFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SpawnTitle;
        private System.Windows.Forms.Label Warning2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Runtime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FactorBegin;
        private System.Windows.Forms.TextBox FactorEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button R_U_N;
        private System.Windows.Forms.Label ShowStatus;
        private System.Windows.Forms.Timer GetEPAPMF;
        private System.Windows.Forms.CheckBox Taged;
        private System.Windows.Forms.CheckBox Geted;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

