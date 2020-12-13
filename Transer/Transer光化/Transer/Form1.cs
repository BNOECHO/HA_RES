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
        Dictionary<string,SortedDictionary<string, List<List<string>>>> TDATA;
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
            TDATA = new Dictionary<string,SortedDictionary<string, List< List<string>>>>();
            foreach (string Line in ReadFile)
            {
                List<string> SPLine =CSVLSpliter(Line);
                if (OPdate == "") OPdate = SPLine[5].Split('-')[0] + SPLine[5].Split('-')[1];
                string Date = SPLine[5].Replace('-', '/');
                if (!TDATA.Keys.Contains(SPLine[1]))
                {
                    TDATA.Add(SPLine[1], new SortedDictionary<string,List<List<string>>>());
                }
                if (!TDATA[SPLine[1]].Keys.Contains(Date))//如果沒有該日期資料
                {
                    
                    List<List<string>> L = new List<List<string>>();
                    for (int i = 0; i < 24; i++)
                    {
                        L.Add(new List<string>());
                        for (int o = 0; o < 56; o++) L[i].Add("");
                    }
                    TDATA[SPLine[1]].Add(Date, L);

                }
                for (int i = 0; i < 24; i++)if(SPLine[6 + i]!="nan") TDATA[SPLine[1]][Date][i][Convert.ToInt32(SPLine[2]) - 1] = SPLine[6 + i];
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
            string File_Head = "測站,日期,時間,\"類別(ppbC)\",\"Ethane(ppbC)\",\"Ethylene(ppbC)\",\"Propane(ppbC)\",\"Propylene(ppbC)\",\"Isobutane(ppbC)\",\"n-Butane(ppbC)\",\"Acetylene(ppbC)\",\"t-2-Butene(ppbC)\",\"1-Butene(ppbC)\",\"cis-2-Butene(ppbC)\",\"Cyclopentane(ppbC)\",\"Isopentane(ppbC)\",\"n-Pentane(ppbC)\",\"t-2-Pentene(ppbC)\",\"1-Pentene(ppbC)\",\"cis-2-Pentene(ppbC)\",\"2,2-Dimethylbutane(ppbC)\",\"2,3-Dimethylbutane(ppbC)\",\"2-Methylpentane(ppbC)\",\"3-Methylpentane(ppbC)\",\"Isoprene(ppbC)\",\"1-Hexene(ppbC)\",\"n-Hexane(ppbC)\",\"Methylcyclopentane(ppbC)\",\"2,4-Dimethylpentane(ppbC)\",\"Benzene(ppbC)\",\"Cyclohexane(ppbC)\",\"2-Methylhexane(ppbC)\",\"2,3-Dimethylpentane(ppbC)\",\"3-Methylhexane(ppbC)\",\"2,2,4-Trimethylpentane(ppbC)\",\"n-Heptane(ppbC)\",\"Methylcyclohexane(ppbC)\",\"2,3,4-Trimethylpentane(ppbC)\",\"Toluene(ppbC)\",\"2-Methylheptane(ppbC)\",\"3-Methylheptane(ppbC)\",\"n-Octane(ppbC)\",\"Ethylbenzene(ppbC)\",\"m,p-Xylene(ppbC)\",\"Styrene(ppbC)\",\"o-Xylene(ppbC)\",\"n-Nonane(ppbC)\",\"Isopropylbenzene(ppbC)\",\"n-Propylbenzene(ppbC)\",\"m-Ethyltoluene(ppbC)\",\"p-Ethyltoluene(ppbC)\",\"1,3,5-Trimethylbenzene(ppbC)\",\"o-Ethyltoluene(ppbC)\",\"1,2,4-Trimethylbenzene(ppbC)\",\"n-Decane(ppbC)\",\"1,2,3-Trimethylbenzene(ppbC)\",\"m-Diethylbenzene(ppbC)\",\"p-Diethylbenzene(ppbC)\",\"n-Undecane(ppbC)\",\"n-Dodecane(ppbC)\"\n";
            Dictionary<string, List<string>> Files = new Dictionary<string, List<string>>();
            foreach (string station in OPstation)
            {
                Files.Add(station, new List<string>());
                Files[station].Add(File_Head);
                foreach (string Time in TDATA[station].Keys)
                {
                    string NewLine = "";
                    for (int i = 0; i < 24; i++)
                    {
                        NewLine += station + ",";
                        NewLine += Time + "," + i.ToString() + ",QA後";
                        for (int o = 0; o < 56; o++) NewLine += "," + TDATA[station][Time][i][o];
                        NewLine += "\n";
                    }
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
            for (int i = 0; i < checkedListBox1.Items.Count; i++) if (checkedListBox1.GetItemChecked(i)) OPstation.Add(checkedListBox1.Items[i].ToString());

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
            foreach (string station in TDATA.Keys) checkedListBox1.Items.Add(station);
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
                    if (Temp[0] != "SiteId,SiteName,ItemId,ItemEngName,ItemUnit,MonitorDate,MonitorValue00,MonitorValue01,MonitorValue02,MonitorValue03,MonitorValue04,MonitorValue05,MonitorValue06,MonitorValue07,MonitorValue08,MonitorValue09,MonitorValue10,MonitorValue11,MonitorValue12,MonitorValue13,MonitorValue14,MonitorValue15,MonitorValue16,MonitorValue17,MonitorValue18,MonitorValue19,MonitorValue20,MonitorValue21,MonitorValue22,MonitorValue23")
                    {
                        MessageBox.Show(IPFname + "標頭不符合規定，故跳過", "Transer");
                        continue;
                    }
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
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, checkBox1.Checked);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
