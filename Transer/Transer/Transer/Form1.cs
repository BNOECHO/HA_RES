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
        Dictionary<string,List< List<string>>> TDATA;

        string TBOX1S = "";

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
            TBOX1S = "";
            TDATA = new Dictionary<string, List< List<string>>>();
            ReadFile.RemoveAt(0);
            
            foreach (string Line in ReadFile)
            {
                List<string> SPLine =CSVLSpliter(Line);
                string Date = SPLine[5].Replace('-', '/');
                if (!TDATA.Keys.Contains(Date))//如果沒有該日期資料
                {
                    
                    List<List<string>> L = new List<List<string>>();
                    for (int i = 0; i < 24; i++)
                    {
                        L.Add(new List<string>());
                        for (int o = 0; o < 56; o++) L[i].Add("");
                    }
                    TDATA.Add(Date, L);

                }
                for (int i = 0; i < 24; i++)if(SPLine[6 + i]!="nan") TDATA[Date][i][Convert.ToInt32(SPLine[2]) - 1] = SPLine[6 + i];
                backgroundWorker1.ReportProgress(++RPG);
            }
            TBOX1S += "測站,日期,時間,\"類別(ppbC)\",\"Ethane(ppbC)\",\"Ethylene(ppbC)\",\"Propane(ppbC)\",\"Propylene(ppbC)\",\"Isobutane(ppbC)\",\"n-Butane(ppbC)\",\"Acetylene(ppbC)\",\"t-2-Butene(ppbC)\",\"1-Butene(ppbC)\",\"cis-2-Butene(ppbC)\",\"Cyclopentane(ppbC)\",\"Isopentane(ppbC)\",\"n-Pentane(ppbC)\",\"t-2-Pentene(ppbC)\",\"1-Pentene(ppbC)\",\"cis-2-Pentene(ppbC)\",\"2,2-Dimethylbutane(ppbC)\",\"2,3-Dimethylbutane(ppbC)\",\"2-Methylpentane(ppbC)\",\"3-Methylpentane(ppbC)\",\"Isoprene(ppbC)\",\"1-Hexene(ppbC)\",\"n-Hexane(ppbC)\",\"Methylcyclopentane(ppbC)\",\"2,4-Dimethylpentane(ppbC)\",\"Benzene(ppbC)\",\"Cyclohexane(ppbC)\",\"2-Methylhexane(ppbC)\",\"2,3-Dimethylpentane(ppbC)\",\"3-Methylhexane(ppbC)\",\"2,2,4-Trimethylpentane(ppbC)\",\"n-Heptane(ppbC)\",\"Methylcyclohexane(ppbC)\",\"2,3,4-Trimethylpentane(ppbC)\",\"Toluene(ppbC)\",\"2-Methylheptane(ppbC)\",\"3-Methylheptane(ppbC)\",\"n-Octane(ppbC)\",\"Ethylbenzene(ppbC)\",\"m,p-Xylene(ppbC)\",\"Styrene(ppbC)\",\"o-Xylene(ppbC)\",\"n-Nonane(ppbC)\",\"Isopropylbenzene(ppbC)\",\"n-Propylbenzene(ppbC)\",\"m-Ethyltoluene(ppbC)\",\"p-Ethyltoluene(ppbC)\",\"1,3,5-Trimethylbenzene(ppbC)\",\"o-Ethyltoluene(ppbC)\",\"1,2,4-Trimethylbenzene(ppbC)\",\"n-Decane(ppbC)\",\"1,2,3-Trimethylbenzene(ppbC)\",\"m-Diethylbenzene(ppbC)\",\"p-Diethylbenzene(ppbC)\",\"n-Undecane(ppbC)\",\"n-Dodecane(ppbC)\"\n";
            foreach (string Time in TDATA.Keys)
            {
                
                for (int i = 0; i < 24; i++)
                {
                    TBOX1S += "臺西" + ",";
                    TBOX1S += Time + "," + i.ToString()+",QA後";
                    for (int o = 0; o < 56; o++) TBOX1S += "," + TDATA[Time][i][o];
                    TBOX1S += "\n";
                }
            }
            backgroundWorker1.ReportProgress(++RPG);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "選擇CSV檔案";
            ofd.Filter = "CSV Files (.csv)|*.csv|All Files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName; 
                string filename = ofd.FileName;
                Encoding ec = Encoding.GetEncoding("big5");
                ReadFile = File.ReadAllLines(filename, ec).ToList<string>();
                progressBar1.Maximum = ReadFile.Count();
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
                
               
                

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog COFD = new CommonOpenFileDialog();
            COFD.InitialDirectory=@"C:\";
            COFD.IsFolderPicker = true;
            COFD.Title = "選擇儲存路徑";
            if (COFD.ShowDialog() == CommonFileDialogResult.Ok)
            {
               FileStream FS= File.Create(COFD.FileName + @"\TEST1.csv");
                StreamWriter SW = new StreamWriter(FS,  Encoding.GetEncoding("big5"));
                SW.Write(TBOX1S);
                SW.Close();
                MessageBox.Show("輸出已完成", "Transer");
            }


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
        }
    }
}
