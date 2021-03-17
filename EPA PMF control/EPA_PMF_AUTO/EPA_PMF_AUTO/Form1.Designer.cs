
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxCFGLabel = new System.Windows.Forms.TextBox();
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
            // textBoxCFGLabel
            // 
            this.textBoxCFGLabel.BackColor = System.Drawing.Color.White;
            this.textBoxCFGLabel.Location = new System.Drawing.Point(135, 13);
            this.textBoxCFGLabel.Name = "textBoxCFGLabel";
            this.textBoxCFGLabel.ReadOnly = true;
            this.textBoxCFGLabel.Size = new System.Drawing.Size(400, 22);
            this.textBoxCFGLabel.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "組態檔|*.cfg";
            this.openFileDialog1.Title = "選擇EPA_PMF組態檔";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(11, 53);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(118, 12);
            this.labelC.TabIndex = 2;
            this.labelC.Text = "Concentration Data File:";
            // 
            // labelUC
            // 
            this.labelUC.AutoSize = true;
            this.labelUC.Location = new System.Drawing.Point(23, 81);
            this.labelUC.Name = "labelUC";
            this.labelUC.Size = new System.Drawing.Size(106, 12);
            this.labelUC.TabIndex = 3;
            this.labelUC.Text = "Uncertainty Data File:";
            // 
            // textBoxC
            // 
            this.textBoxC.BackColor = System.Drawing.Color.White;
            this.textBoxC.Location = new System.Drawing.Point(135, 50);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.ReadOnly = true;
            this.textBoxC.Size = new System.Drawing.Size(400, 22);
            this.textBoxC.TabIndex = 4;
            // 
            // textBoxUC
            // 
            this.textBoxUC.BackColor = System.Drawing.Color.White;
            this.textBoxUC.Location = new System.Drawing.Point(135, 78);
            this.textBoxUC.Name = "textBoxUC";
            this.textBoxUC.ReadOnly = true;
            this.textBoxUC.Size = new System.Drawing.Size(400, 22);
            this.textBoxUC.TabIndex = 5;
            // 
            // labelCW
            // 
            this.labelCW.AutoSize = true;
            this.labelCW.Location = new System.Drawing.Point(541, 53);
            this.labelCW.Name = "labelCW";
            this.labelCW.Size = new System.Drawing.Size(58, 12);
            this.labelCW.TabIndex = 6;
            this.labelCW.Text = "Worksheet:";
            // 
            // labelUCW
            // 
            this.labelUCW.AutoSize = true;
            this.labelUCW.Location = new System.Drawing.Point(541, 81);
            this.labelUCW.Name = "labelUCW";
            this.labelUCW.Size = new System.Drawing.Size(58, 12);
            this.labelUCW.TabIndex = 7;
            this.labelUCW.Text = "Worksheet:";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 132);
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
            this.Warning.Location = new System.Drawing.Point(133, 114);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(211, 12);
            this.Warning.TabIndex = 13;
            this.Warning.Text = "**目前僅支援2007以後的Excel(*.xlsx)**";
            // 
            // TBWorksheetC
            // 
            this.TBWorksheetC.BackColor = System.Drawing.Color.White;
            this.TBWorksheetC.Location = new System.Drawing.Point(605, 50);
            this.TBWorksheetC.Name = "TBWorksheetC";
            this.TBWorksheetC.ReadOnly = true;
            this.TBWorksheetC.Size = new System.Drawing.Size(100, 22);
            this.TBWorksheetC.TabIndex = 14;
            // 
            // TBWorksheetUC
            // 
            this.TBWorksheetUC.BackColor = System.Drawing.Color.White;
            this.TBWorksheetUC.Location = new System.Drawing.Point(605, 78);
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
            this.button2.Location = new System.Drawing.Point(13, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "儲存CAT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 450);
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
            this.Controls.Add(this.textBoxCFGLabel);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "EPA_PMF_AUTORUN By:B";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxCFGLabel;
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
    }
}

