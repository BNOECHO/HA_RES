using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using GetEPAdata;
using BNOECHO_CSV;
using System.Configuration;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;

namespace EPAdataPretreatment.Forms
{
    public partial class FormGetEPAData : Form
    {
        public FormGetEPAData(MAIN Father)
        {
            InitializeComponent();
            OWNER = Father;
        }
        MAIN OWNER;
        EPAdataTools EPAdataTools = new EPAdataTools();
        EPAdataBase EPAdataBase = new EPAdataBase();
        List<CSV> ActnicData = new List<CSV>();
        List<CSV> GeneralData = new List<CSV>();
        List<string> NoOutputSite=new List<string>();
        private void button3_Click(object sender, EventArgs e)
        {
            EPAdataTools.setBasic(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker2.Value.Year, dateTimePicker2.Value.Month);
            EPAdataTools.SetApiKey(ConfigurationManager.AppSettings["API_KEY"]);
            button3.Enabled = false;
             OWNER.Lock();
            button3.BackColor = Color.FromArgb(3, 39, 91);
            label7.BackColor = Color.FromArgb(26, 125, 216);
            Phase1.RunWorkerAsync();
            panel2.Visible = false;
            pictureBox1.Visible = true;

            
        }
        private void checkdate()
        {
            if (((dateTimePicker1.Value.Month > dateTimePicker2.Value.Month) && (dateTimePicker1.Value.Year == dateTimePicker2.Value.Year)) || dateTimePicker1.Value.Year > dateTimePicker2.Value.Year)
            {
                label6.Text = "起始時間不得超過結束時間";
                label6.ForeColor = Color.Red;
            }
            else
            {
                label6.Text = "正確";
                label6.ForeColor = Color.Green;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            checkdate();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            checkdate();
        }

        private void PanelDownLoad_Paint(object sender, PaintEventArgs e)
        {
            if (!new EPAdataTools().KeyTest(ConfigurationManager.AppSettings["API_KEY"]))
            {
                button3.Enabled = false;
                button3.ForeColor = Color.Red;
                button3.Text = "API KEY錯誤";
            }
        }

        private void Phase1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            ActnicData = new List<CSV>();
            CSV RF = new CSV();
            RF.load_CSV(@"C:\Users\BNO ECHO\Documents\2020忠明10-12.csv");
            ActnicData.Add(RF);
        }

        private void Phase1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label7.BackColor = Color.FromArgb(3, 39, 91);
            label8.BackColor = Color.FromArgb(26, 125, 216);

            Phase2.RunWorkerAsync();
        }

        private void Phase2_DoWork(object sender, DoWorkEventArgs e)
        {
            GeneralData = new List<CSV>();
        }

        private void Phase3_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (CSV csv in ActnicData) EPAdataBase.ImportData(true, csv);
            //foreach (CSV csv in GeneralData) EPAdataBase.ImportData(false, csv);
        }

        private void Phase2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label8.BackColor = Color.FromArgb(3, 39, 91);
            label9.BackColor = Color.FromArgb(26, 125, 216);
            Phase3.RunWorkerAsync();
        }

        private void Phase3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label9.BackColor = Color.FromArgb(3, 39, 91);
            label11.BackColor = Color.FromArgb(26, 125, 216);
            foreach (string site in EPAdataBase.dataDict.Keys) listBox1.Items.Add(site);
            comboBox1.Items.Clear();
            foreach (string s in listBox1.Items) comboBox1.Items.Add(s);
            panel1.Visible = true;
            pictureBox1.Visible = false;
            button6.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            comboBox1.Items.Clear();
            foreach (string s in listBox1.Items) comboBox1.Items.Add(s);
            button6.Enabled = listBox2.Items.Count > 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            button6.Enabled = listBox2.Items.Count > 0;
            comboBox1.Items.Clear();
            foreach (String s in listBox1.Items) comboBox1.Items.Add(s);
        }







        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.IndexOf(comboBox1.Text) != -1)
            {
                listBox2.Items.Add(comboBox1.Text);
                listBox1.Items.Remove(comboBox1.Text);
            }
            button6.Enabled = listBox2.Items.Count > 0;
            comboBox1.Text = ""; 
            comboBox1.Items.Clear();
            foreach (String s in listBox1.Items) comboBox1.Items.Add(s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OWNER.UnLock();

            this.Close();
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog COFD = new CommonOpenFileDialog();
            COFD.InitialDirectory = ConfigurationManager.AppSettings["SavePath"];
            COFD.IsFolderPicker = true;
            COFD.Title = "選擇讀取路徑";
            if (COFD.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //savepath to config(unFin)
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.AppSettings.Settings["SavePath"].Value = COFD.FileName;
                //config.Save(ConfigurationSaveMode.Modified);
                //ConfigurationManager.RefreshSection("appSettings");
                foreach (string site in listBox2.Items) EPAdataBase.ExportSitePpbcToUgm3(site).SaveCSV(COFD.FileName + "\\" + dateTimePicker1.Value.Year.ToString() + dateTimePicker1.Value.Month.ToString().PadLeft(2, '0') + "_" + dateTimePicker2.Value.Year.ToString() + dateTimePicker2.Value.Month.ToString().PadLeft(2, '0') + "_" + site+".csv");


                MessageBox.Show("輸出已完成");           
                if (listBox2.Items.Count == 1)
                { 
                //接續到MDL
                }
                foreach (string s in listBox2.Items) listBox1.Items.Add(s);
                listBox2.Items.Clear();
                comboBox1.Items.Clear();
                foreach (String s in listBox1.Items) comboBox1.Items.Add(s);

            }






        }
    }
}
