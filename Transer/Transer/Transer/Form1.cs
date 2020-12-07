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
        
        private void Transer()
        {
            TBOX1S = "";
            TDATA = new Dictionary<string, List< List<string>>>();
            ReadFile.RemoveAt(0);
            foreach (string Line in ReadFile)
            {
                List<string> SPLine =CSVLSpliter(Line);
                if (!TDATA.Keys.Contains(SPLine[5]))//如果沒有該日期資料
                {
                    
                    List<List<string>> L = new List<List<string>>();
                    for (int i = 0; i < 24; i++)
                    {
                        L.Add(new List<string>());
                        for (int o = 0; o < 56; o++) L[i].Add("");
                    }
                    TDATA.Add(SPLine[5], L);

                }
                for (int i = 0; i < 24; i++)/*if(SPLine[6 + i]!="nan")*/ TDATA[SPLine[5]][i][Convert.ToInt32(SPLine[2]) - 1] = SPLine[6 + i];
            }

            foreach (string K in TDATA.Keys)
            {
                for (int i = 0; i < 24; i++)
                {
                    TBOX1S += K + "," + i.ToString();
                    for (int o = 0; o < 56; o++) TBOX1S += "," + TDATA[K][i][o];
                    TBOX1S += "\n";
                }


            }


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
                Transer();
               
                

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
                StreamWriter SW = new StreamWriter(FS);
                SW.Write(TBOX1S);
                SW.Close();

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
