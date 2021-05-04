
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
            this.listView2 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.SpawnCsv = new System.Windows.Forms.Button();
            this.bad = new System.Windows.Forms.Button();
            this.weak = new System.Windows.Forms.Button();
            this.strong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCAT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "讀取config檔案";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBCFG
            // 
            this.TBCFG.BackColor = System.Drawing.Color.White;
            this.TBCFG.Location = new System.Drawing.Point(202, 20);
            this.TBCFG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBCFG.Name = "TBCFG";
            this.TBCFG.ReadOnly = true;
            this.TBCFG.Size = new System.Drawing.Size(598, 29);
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
            this.labelC.Location = new System.Drawing.Point(16, 66);
            this.labelC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(179, 18);
            this.labelC.TabIndex = 2;
            this.labelC.Text = "Concentration Data File:";
            // 
            // labelUC
            // 
            this.labelUC.AutoSize = true;
            this.labelUC.Location = new System.Drawing.Point(34, 108);
            this.labelUC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUC.Name = "labelUC";
            this.labelUC.Size = new System.Drawing.Size(164, 18);
            this.labelUC.TabIndex = 3;
            this.labelUC.Text = "Uncertainty Data File:";
            // 
            // textBoxC
            // 
            this.textBoxC.BackColor = System.Drawing.Color.White;
            this.textBoxC.Location = new System.Drawing.Point(202, 62);
            this.textBoxC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.ReadOnly = true;
            this.textBoxC.Size = new System.Drawing.Size(598, 29);
            this.textBoxC.TabIndex = 4;
            // 
            // textBoxUC
            // 
            this.textBoxUC.BackColor = System.Drawing.Color.White;
            this.textBoxUC.Location = new System.Drawing.Point(202, 104);
            this.textBoxUC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUC.Name = "textBoxUC";
            this.textBoxUC.ReadOnly = true;
            this.textBoxUC.Size = new System.Drawing.Size(598, 29);
            this.textBoxUC.TabIndex = 5;
            // 
            // labelCW
            // 
            this.labelCW.AutoSize = true;
            this.labelCW.Location = new System.Drawing.Point(812, 66);
            this.labelCW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCW.Name = "labelCW";
            this.labelCW.Size = new System.Drawing.Size(87, 18);
            this.labelCW.TabIndex = 6;
            this.labelCW.Text = "Worksheet:";
            // 
            // labelUCW
            // 
            this.labelUCW.AutoSize = true;
            this.labelUCW.Location = new System.Drawing.Point(812, 108);
            this.labelUCW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUCW.Name = "labelUCW";
            this.labelUCW.Size = new System.Drawing.Size(87, 18);
            this.labelUCW.TabIndex = 7;
            this.labelUCW.Text = "Worksheet:";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(18, 184);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1058, 115);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Warning
            // 
            this.Warning.AutoSize = true;
            this.Warning.ForeColor = System.Drawing.Color.Red;
            this.Warning.Location = new System.Drawing.Point(200, 148);
            this.Warning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(307, 18);
            this.Warning.TabIndex = 13;
            this.Warning.Text = "**目前僅支援2007以後的Excel(*.xlsx)**";
            // 
            // TBWorksheetC
            // 
            this.TBWorksheetC.BackColor = System.Drawing.Color.White;
            this.TBWorksheetC.Location = new System.Drawing.Point(908, 62);
            this.TBWorksheetC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBWorksheetC.Name = "TBWorksheetC";
            this.TBWorksheetC.ReadOnly = true;
            this.TBWorksheetC.Size = new System.Drawing.Size(148, 29);
            this.TBWorksheetC.TabIndex = 14;
            // 
            // TBWorksheetUC
            // 
            this.TBWorksheetUC.BackColor = System.Drawing.Color.White;
            this.TBWorksheetUC.Location = new System.Drawing.Point(908, 104);
            this.TBWorksheetUC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBWorksheetUC.Name = "TBWorksheetUC";
            this.TBWorksheetUC.ReadOnly = true;
            this.TBWorksheetUC.Size = new System.Drawing.Size(148, 29);
            this.TBWorksheetUC.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(812, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "CAT條件";
            // 
            // CATsetting
            // 
            this.CATsetting.Location = new System.Drawing.Point(908, 20);
            this.CATsetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CATsetting.Name = "CATsetting";
            this.CATsetting.Size = new System.Drawing.Size(148, 29);
            this.CATsetting.TabIndex = 17;
            this.CATsetting.Text = "1;0.5";
            // 
            // Targetfolder
            // 
            this.Targetfolder.Location = new System.Drawing.Point(202, 312);
            this.Targetfolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Targetfolder.Name = "Targetfolder";
            this.Targetfolder.Size = new System.Drawing.Size(598, 29);
            this.Targetfolder.TabIndex = 19;
            // 
            // BrowseFolder
            // 
            this.BrowseFolder.Location = new System.Drawing.Point(20, 312);
            this.BrowseFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrowseFolder.Name = "BrowseFolder";
            this.BrowseFolder.Size = new System.Drawing.Size(156, 34);
            this.BrowseFolder.TabIndex = 20;
            this.BrowseFolder.Text = "設定目標資料夾";
            this.BrowseFolder.UseVisualStyleBackColor = true;
            this.BrowseFolder.Click += new System.EventHandler(this.BrowseFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 366);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "批次標記:";
            // 
            // SpawnTitle
            // 
            this.SpawnTitle.Enabled = false;
            this.SpawnTitle.Location = new System.Drawing.Point(202, 362);
            this.SpawnTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpawnTitle.Name = "SpawnTitle";
            this.SpawnTitle.Size = new System.Drawing.Size(276, 29);
            this.SpawnTitle.TabIndex = 22;
            this.SpawnTitle.TextChanged += new System.EventHandler(this.SpawnTitle_TextChanged);
            // 
            // Warning2
            // 
            this.Warning2.AutoSize = true;
            this.Warning2.ForeColor = System.Drawing.Color.Red;
            this.Warning2.Location = new System.Drawing.Point(489, 366);
            this.Warning2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Warning2.Name = "Warning2";
            this.Warning2.Size = new System.Drawing.Size(310, 18);
            this.Warning2.TabIndex = 23;
            this.Warning2.Text = "**生成重複檔案名時會直接覆蓋原檔**";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 411);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Number of Runs:";
            // 
            // Runtime
            // 
            this.Runtime.Location = new System.Drawing.Point(202, 404);
            this.Runtime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Runtime.Name = "Runtime";
            this.Runtime.Size = new System.Drawing.Size(58, 29);
            this.Runtime.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 411);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Factors:";
            // 
            // FactorBegin
            // 
            this.FactorBegin.Location = new System.Drawing.Point(342, 404);
            this.FactorBegin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FactorBegin.Name = "FactorBegin";
            this.FactorBegin.Size = new System.Drawing.Size(76, 29);
            this.FactorBegin.TabIndex = 27;
            // 
            // FactorEnd
            // 
            this.FactorEnd.Location = new System.Drawing.Point(452, 404);
            this.FactorEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FactorEnd.Name = "FactorEnd";
            this.FactorEnd.Size = new System.Drawing.Size(78, 29);
            this.FactorEnd.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 411);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "-";
            // 
            // R_U_N
            // 
            this.R_U_N.Enabled = false;
            this.R_U_N.Location = new System.Drawing.Point(813, 394);
            this.R_U_N.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.R_U_N.Name = "R_U_N";
            this.R_U_N.Size = new System.Drawing.Size(164, 34);
            this.R_U_N.TabIndex = 30;
            this.R_U_N.Text = "開始批次執行";
            this.R_U_N.UseVisualStyleBackColor = true;
            this.R_U_N.Click += new System.EventHandler(this.R_U_N_Click);
            // 
            // ShowStatus
            // 
            this.ShowStatus.Location = new System.Drawing.Point(18, 454);
            this.ShowStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShowStatus.Name = "ShowStatus";
            this.ShowStatus.Size = new System.Drawing.Size(530, 288);
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
            this.Taged.Location = new System.Drawing.Point(814, 315);
            this.Taged.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Taged.Name = "Taged";
            this.Taged.Size = new System.Drawing.Size(160, 22);
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
            this.Geted.Location = new System.Drawing.Point(814, 348);
            this.Geted.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Geted.Name = "Geted";
            this.Geted.Size = new System.Drawing.Size(160, 22);
            this.Geted.TabIndex = 33;
            this.Geted.Text = "已取得所有目標";
            this.Geted.UseVisualStyleBackColor = false;
            this.Geted.CheckedChanged += new System.EventHandler(this.Geted_CheckedChanged);
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(554, 454);
            this.listView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(523, 115);
            this.listView2.TabIndex = 34;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(554, 582);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "轉折點:";
            // 
            // SpawnCsv
            // 
            this.SpawnCsv.Enabled = false;
            this.SpawnCsv.Location = new System.Drawing.Point(930, 574);
            this.SpawnCsv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpawnCsv.Name = "SpawnCsv";
            this.SpawnCsv.Size = new System.Drawing.Size(148, 34);
            this.SpawnCsv.TabIndex = 36;
            this.SpawnCsv.Text = "產生CSV";
            this.SpawnCsv.UseVisualStyleBackColor = true;
            this.SpawnCsv.Click += new System.EventHandler(this.SpawnCsv_Click);
            // 
            // bad
            // 
            this.bad.Location = new System.Drawing.Point(533, 141);
            this.bad.Name = "bad";
            this.bad.Size = new System.Drawing.Size(75, 34);
            this.bad.TabIndex = 37;
            this.bad.Text = "bad";
            this.bad.UseVisualStyleBackColor = true;
            // 
            // weak
            // 
            this.weak.Location = new System.Drawing.Point(614, 141);
            this.weak.Name = "weak";
            this.weak.Size = new System.Drawing.Size(75, 34);
            this.weak.TabIndex = 38;
            this.weak.Text = "weak";
            this.weak.UseVisualStyleBackColor = true;
            // 
            // strong
            // 
            this.strong.Location = new System.Drawing.Point(695, 141);
            this.strong.Name = "strong";
            this.strong.Size = new System.Drawing.Size(75, 34);
            this.strong.TabIndex = 39;
            this.strong.Text = "strong";
            this.strong.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(778, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 18);
            this.label7.TabIndex = 40;
            this.label7.Text = "**CAT設定將自動套用**";
            // 
            // labelCAT
            // 
            this.labelCAT.AutoSize = true;
            this.labelCAT.Location = new System.Drawing.Point(18, 149);
            this.labelCAT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCAT.Name = "labelCAT";
            this.labelCAT.Size = new System.Drawing.Size(77, 18);
            this.labelCAT.TabIndex = 41;
            this.labelCAT.Text = "CAT設定";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 729);
            this.Controls.Add(this.labelCAT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.strong);
            this.Controls.Add(this.weak);
            this.Controls.Add(this.bad);
            this.Controls.Add(this.SpawnCsv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listView2);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SpawnCsv;
        private System.Windows.Forms.Button bad;
        private System.Windows.Forms.Button weak;
        private System.Windows.Forms.Button strong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCAT;
    }
}

