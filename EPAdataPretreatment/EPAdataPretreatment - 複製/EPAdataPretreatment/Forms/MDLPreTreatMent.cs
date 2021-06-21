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
using MDLprocssing;
using BNOECHO_CSV;
using System.Configuration;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace EPAdataPretreatment.Forms
{
    public partial class FormMDLPreTreatMent : Form
    {
        public FormMDLPreTreatMent()
        {
            InitializeComponent();
        }
        CSV file = new CSV();
        MDLprocssingTools MDLTools = new MDLprocssingTools();
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string s in MDLitem) listBox4.Items.Add(s);
            listBox4.SelectedIndex = 0;
            groupBox5.Text = "輸入MDL值:" + listBox4.Items[0];
            groupBox3.Visible = false;
            button3.BackColor = Color.FromArgb(3, 39, 91);
            label7.BackColor = Color.FromArgb(26, 125, 216);
            panel2.Visible = true;
            
        }
        string filename = "";
        List<string> MDLitem = new List<string> { "Ethane", "Ethylene", "Propane", "Propylene", "Isobutane", "n-Butane", "Acetylene", "t-2-Butene", "1-Butene", "cis-2-Butene", "Cyclopentane", "Isopentane", "n-Pentane", "t-2-Pentene", "1-Pentene", "cis-2-Pentene", "\"2,2 - Dimethylbutane\"", "\"2,3 - Dimethylbutane\"", "2-Methylpentane", "3-Methylpentane", "Isoprene", "1-Hexene", "n-Hexane", "Methylcyclopentane", "\"2,4 - Dimethylpentane\"", "Benzene", "Cyclohexane", "2-Methylhexane", "\"2,3 - Dimethylpentane\"", "3-Methylhexane", "\"2,2,4 - Trimethylpentane\"", "n-Heptane", "Methylcyclohexane", "\"2,3,4 - Trimethylpentane\"", "Toluene", "2-Methylheptane", "3-Methylheptane", "n-Octane", "Ethylbenzene", "\"m,p - Xylene\"", "Styrene", "o-Xylene", "n-Nonane", "Isopropylbenzene", "n-Propylbenzene", "m-Ethyltoluene", "p-Ethyltoluene", "\"1,3,5 - Trimethylbenzene\"", "o-Ethyltoluene", "\"1,2,4 - Trimethylbenzene\"", "n-Decane", "\"1,2,3 - Trimethylbenzene\"", "m-Diethylbenzene", "p-Diethylbenzene", "n-Undecane" };
        Dictionary<string, double> MDLValue=new Dictionary<string, double>();
        Dictionary<string, double> MDLFrequency = new Dictionary<string, double>();
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "選擇CSV檔案";
            ofd.Filter = "CSV Files (.csv)|*.csv|All Files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text= ofd.FileName;
                file.load_CSV(textBox1.Text);
                file = MDLTools.DataRemoveNullRow(file);
                button3.Enabled = true;
                filename = textBox1.Text.Split('.')[textBox1.Text.Split('.').Length- 2];
                filename = textBox1.Text.Split('\\')[textBox1.Text.Split('\\').Length - 1];
                Debug.Print(filename);
            }
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MDLValue = new Dictionary<string, double>();
            foreach (string item in listBox3.Items)
            {
                string[] split = item.Split(new string[] { "---" }, StringSplitOptions.None);
                MDLValue.Add(split[1], Convert.ToDouble(split[0]));
            }
            panel2.Visible = false;
            pictureBox1.Visible = true;
            label7.BackColor = Color.FromArgb(3, 39, 91);
            label8.BackColor = Color.FromArgb(26, 125, 216);
            Phase1.RunWorkerAsync();

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            groupBox5.Text = "輸入MDL值:" + listBox4.SelectedItem;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add(textBox2.Text + "---" + listBox4.SelectedItem);
            listBox4.Items.Remove(listBox4.SelectedItem);
            if (listBox4.Items.Count != 0) listBox4.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double d;
            button5.Enabled = double.TryParse(textBox2.Text, out d);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                listBox4.Items.Insert(0, listBox3.SelectedItem.ToString().Split(new string[] { "---" }, StringSplitOptions.None)[1]);
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CSV IPfile = file;
            MDLFrequency = MDLTools.MDLFrequency(IPfile,MDLValue);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            panel1.Visible = true;
            foreach (string s in MDLFrequency.Keys)
            {
                listBox1.Items.Add(MDLFrequency[s].ToString("0.000%").PadLeft(5) + "---" + s);
            }
            label8.BackColor = Color.FromArgb(3, 39, 91);
            label11.BackColor = Color.FromArgb(26, 125, 216);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex!= -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
        List<string> RemoveClo = new List<string>();
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
                config.AppSettings.Settings["SavePath"].Value = COFD.FileName;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                foreach (string item in listBox2.Items)
                {
                    RemoveClo.Add(item.Split(new string[] { "---" }, StringSplitOptions.None)[1]);
                }
                CSV IPfile = file;
                CSV C = MDLTools.ConcentrationData(IPfile, RemoveClo, MDLValue);
                IPfile = file;
                CSV UC = MDLTools.UncertaintyData(IPfile, RemoveClo, MDLValue);

                MDLTools.SaveFiles(COFD.FileName + @"\" + filename, C,UC );
                MessageBox.Show("輸出已完成");

            }


        }

        private void button9_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double d;
                if(double.TryParse(textBox2.Text, out d)&&listBox4.SelectedIndex!=-1)
                {
                    listBox3.Items.Add(textBox2.Text + "---" + listBox4.SelectedItem);
                    listBox4.Items.Remove(listBox4.SelectedItem);
                   if(listBox4.Items.Count!=0) listBox4.SelectedIndex = 0;
                }

            }

        }

    }
}
