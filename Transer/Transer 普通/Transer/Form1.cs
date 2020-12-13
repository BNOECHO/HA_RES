using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace Transer
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> ReadFile;
        Dictionary<string, List<List<string>>> TDATA;
        CommonOpenFileDialog COFD = new CommonOpenFileDialog();
        string OPdate = "";
        List<string> OPstation = new List<string>();
        List<string> CSVLSpliter(string s)
        {
            List<string> SA = new List<string>();
            s += "\n";
            string temp = "";
            bool SKIPER = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]=='\n')
                {
                    SA.Add(temp);
                }
                else if (SKIPER)
                {
                    if (s[i] == '\"' && s[i + 1] == ',')
                    {
                        SKIPER = false;
                        SA.Add(temp);
                        temp = "";
                        i++;
                    }
                    else
                    {
                        temp += s[i];
                    }

                }
                else if (s[i] == ',' && s[i + 1] == '\"')
                {
                    SKIPER = true;
                    SA.Add(temp);
                    temp = "";
                    i++;
                }
                else if (s[i] == ',')
                {
                    SA.Add(temp);
                    temp = "";
                }
                else
                {
                    temp += s[i];
                }
            }

            

            return SA;
        }
        
        private void Transer(BackgroundWorker worker,EventArgs e)
        { 
            int RPG = 0;
            TDATA = new Dictionary<string,List< List<string>>>();
            foreach (string Line in ReadFile)
            {
                List<string> SPLine =CSVLSpliter(Line);
                if (OPdate == "") OPdate = SPLine[6].Split('-')[0] + SPLine[6].Split('-')[1];//輸出資料年月標記
                string Date = SPLine[6].Replace('-', '/');
                if (!TDATA.Keys.Contains(SPLine[1]))
                {
                    TDATA.Add(SPLine[1], new List<List<string>>());
                }
                TDATA[SPLine[1]].Add(new List<string>());
                TDATA[SPLine[1]][TDATA[SPLine[1]].Count - 1].Add(Date);
                TDATA[SPLine[1]][TDATA[SPLine[1]].Count - 1].Add(SPLine[1]);
                TDATA[SPLine[1]][TDATA[SPLine[1]].Count - 1].Add(SPLine[4]);
                for (int i = 0; i < 24; i++)
                {
                  if (SPLine[4]== "RAINFALL" && (SPLine[7 + i]=="0"|| SPLine[7 + i] == "0.0"))TDATA[SPLine[1]][TDATA[SPLine[1]].Count - 1].Add("NR");
                 else   TDATA[SPLine[1]][TDATA[SPLine[1]].Count - 1].Add(SPLine[7 + i]);
                }
                    backgroundWorker1.ReportProgress(++RPG);
            }    

        }
        private void button1_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog OPPath = new CommonOpenFileDialog();
            OPPath.InitialDirectory = @"C:\";
            OPPath.IsFolderPicker = true;
            OPPath.Title = "選擇讀取路徑";
            if (OPPath.ShowDialog()==CommonFileDialogResult.Ok)
            {
                DirectoryInfo directory = new DirectoryInfo(OPPath.FileName);
                foreach (FileInfo path in directory.GetFiles("*.csv"))
                {
                   string new_file = path.DirectoryName + "\\" + path.Name;
                   if(!listBox1.Items.Contains(new_file)) listBox1.Items.Add(new_file);
                }
            }

        }
        private void Outputer(BackgroundWorker worker, EventArgs e)
        {
            int RPG = 0;
            string File_Head = "日期,測站,測項,00,01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23\n";
            Dictionary<string, List<string>> Files = new Dictionary<string, List<string>>();
            foreach (string station in OPstation)
            {
                Files.Add(station, new List<string>());
                Files[station].Add(File_Head);
                foreach (List<string> Line in TDATA[station])
                {
                    string NewLine = Line[0];
                    for (int i = 1; i < Line.Count; i++)
                    {
                        NewLine += "," + Line[i];
                    }
                    NewLine += "\n";
                    Files[station].Add(NewLine);
                    backgroundWorker2.ReportProgress(++RPG);
                }
            }
            foreach (string F in Files.Keys)
            {
                FileStream FS = File.Create(COFD.FileName + @"\" + OPdate + "_" + F + ".csv");
                StreamWriter SW = new StreamWriter(FS, Encoding.GetEncoding("big5"));
                foreach(string OP in Files[F]) SW.Write(OP);

                SW.Close();
                backgroundWorker2.ReportProgress(++RPG);
            }   
            OPdate = "";
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            
            COFD.InitialDirectory=@"C:\";
            COFD.IsFolderPicker = true;
            COFD.Title = "選擇儲存路徑";
            OPstation.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++) if (checkedListBox1.GetItemChecked(i))OPstation.Add(checkedListBox1.Items[i].ToString());
                       
            if (COFD.ShowDialog() == CommonFileDialogResult.Ok)
            {  
                int Process = 0;
                foreach (string s in OPstation) Process += TDATA[s].Count;
                progressBar1.Maximum = Process + OPstation.Count;
                progressBar1.Value = 0;
                backgroundWorker2.RunWorkerAsync();
            }
            else MessageBox.Show("輸出已取消", "Transer");
            button2.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker BW = (BackgroundWorker)sender;
            Transer(BW, e);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("轉換完成，已可輸出", "Transer");
            button5.Enabled = true;
            listBox1.Items.Clear();
            button2.Enabled = true;
            checkedListBox1.Items.Clear();
           foreach(string station in TDATA.Keys) checkedListBox1.Items.Add(station);
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker BW = (BackgroundWorker)sender;
            Outputer(BW, e);
        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("輸出已完成", "Transer");
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ReadFile = new List<string>();

            if (listBox1.Items.Count > 0)
            {

                foreach (string IPFname in listBox1.Items)
                {
                    Encoding ec = Encoding.GetEncoding("big5");
                    List<string> Temp = File.ReadAllLines(IPFname, ec).ToList();
                   Temp.RemoveAt(0);
                    ReadFile = ReadFile.Concat(Temp).ToList();
                    
                }

                progressBar1.Maximum = ReadFile.Count();
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
                button5.Enabled = false;
            }
            else MessageBox.Show("輸入檔案為空", "Transer");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "選擇CSV檔案";
            ofd.Filter = "CSV Files (.csv)|*.csv|All Files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!listBox1.Items.Contains(ofd.FileName)) listBox1.Items.Add(ofd.FileName);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0;i<checkedListBox1.Items.Count;i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }

        }

    }
}
