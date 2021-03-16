
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(541, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "自動設定cat";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.checkBox1);
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
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

