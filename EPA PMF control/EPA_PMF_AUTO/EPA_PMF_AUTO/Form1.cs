using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Excel= Microsoft.Office.Interop.Excel;
using System.Data;
using System.Runtime.InteropServices;

namespace EPA_PMF_AUTO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId
        (
            IntPtr hwnd,
            ref int ProcessID
        );
        string CAT = "";
        double CATweak = 1;
        double CATbad = 0.5;
        Configuration Config = null;
        private void GetDataGrid()
        {
            button2.Enabled = true;
            CAT = "";
            listView1.Clear();
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbookC = null;
            Excel.Workbook workbookUC = null;
            object oMissing = System.Reflection.Missing.Value;
            DataTable DT = new DataTable();
            workbookC = excel.Workbooks.Open(textBoxC.Text, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
            if (textBoxC.Text == textBoxUC.Text) workbookUC = workbookC;
            else workbookUC = excel.Workbooks.Open(textBoxUC.Text, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

            Excel.Worksheet C = (Excel.Worksheet)workbookC.Sheets[TBWorksheetC.Text];
            Excel.Worksheet UC = (Excel.Worksheet)workbookUC.Sheets[TBWorksheetUC.Text];
            int itemcount = 2;
            listView1.Columns.Add("項目");
            List<double> SNRatio = new List<double>();
            while (true)
            {
                string TempTitle=null;
                if (C.Cells[1, itemcount].Value!=null) TempTitle = C.Cells[1, itemcount].Value2().ToString();
                if (TempTitle != null)
                {
                    listView1.Columns.Add(TempTitle);
                    double SNR = 0;
                    List<double> Cvalue2 = new List<double>();
                    foreach (double value in (C.Range[C.Cells[2, itemcount], C.Cells[2, itemcount].End[Excel.XlDirection.xlDown]].Value2()))
                    {
                        Cvalue2.Add(value);
                    }
                    List<double> UCvalue2 = new List<double>();
                    foreach (double value in (UC.Range[UC.Cells[2, itemcount], UC.Cells[2, itemcount].End[Excel.XlDirection.xlDown]].Value2()))
                    {
                        UCvalue2.Add(value);
                    }
                    for(int i=0;i<Cvalue2.Count();i++)if (UCvalue2[i] <= Cvalue2[i]) SNR += (Cvalue2[i] - UCvalue2[i]) / UCvalue2[i];
                    SNRatio.Add(SNR/ Cvalue2.Count());
                }
                else { break; }
                itemcount++;
            }
            ListViewItem listItem = new ListViewItem("S/N值");
            ListViewItem CATitem = new ListViewItem("CAT");
            foreach (double sn in SNRatio)
            {
                int CATtype = 0;
                string CATString = "Strong";
                listItem.SubItems.Add(sn.ToString());
                if (sn < CATbad) { CATtype = 2; CATString = "Bad"; }
                else if (sn < CATweak) {CATtype = 1;CATString = "Weak"; }
                CAT += CATtype.ToString();
                CATitem.SubItems.Add(CATString);

            }
            listView1.Items.Add(listItem);
            listView1.Items.Add(CATitem);

            //EXCEL C Close
            Marshal.ReleaseComObject(C);
            Marshal.ReleaseComObject(UC);
            workbookC.Close(true);
            if(textBoxC.Text!= textBoxUC.Text)workbookUC.Close(true);
            Marshal.ReleaseComObject(workbookC);
            Marshal.ReleaseComObject(workbookUC);
            excel.Workbooks.Close();
            excel.Quit();
            if (excel != null)
            {
                int EXCproID = -1;
                GetWindowThreadProcessId(new IntPtr(excel.Hwnd), ref EXCproID);
                System.Diagnostics.Process EXprocess = System.Diagnostics.Process.GetProcessById(EXCproID);
                if (EXprocess != null)
                {
                    EXprocess.Kill();
                }
            }
            Marshal.ReleaseComObject(excel);
            GC.Collect();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CATweak = Convert.ToDouble(CATsetting.Text.Split(';')[0]);
            CATbad = Convert.ToDouble(CATsetting.Text.Split(';')[1]);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExeConfigurationFileMap ExConfig = new ExeConfigurationFileMap();
                ExConfig.ExeConfigFilename = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                TBCFG.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                
                try
                {
                    Config = ConfigurationManager.OpenMappedExeConfiguration(ExConfig, ConfigurationUserLevel.None);
                    textBoxC.Text = Config.AppSettings.Settings["concFile"].Value.ToString();
                    textBoxUC.Text = Config.AppSettings.Settings["uncFile"].Value.ToString();
                    TBWorksheetC.Text =  Config.AppSettings.Settings["concSheet"].Value.ToString();
                    TBWorksheetUC.Text = Config.AppSettings.Settings["uncSheet"].Value.ToString();
                    Targetfolder.Text = Config.AppSettings.Settings["outFolder"].Value.ToString();
                    GetDataGrid();
                    Config.AppSettings.Settings["configFile"].Value = TBCFG.Text;
                    Config.AppSettings.Settings["chkOverwriteWarning"].Value = 0.ToString() ;
                    Runtime.Text = Config.AppSettings.Settings["numBaseRuns"].Value.ToString();
                    FactorBegin.Text = Config.AppSettings.Settings["numBaseFactors"].Value.ToString();
                    FactorEnd.Text = Config.AppSettings.Settings["numBaseFactors"].Value.ToString();
                    Config.Save();

                }
                catch
                {
                    MessageBox.Show("錯誤的組態檔", "EPA_PMF_AUTORUN");
                    
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Config.AppSettings.Settings["categories"].Value = CAT;
            Config.Save();
        }

        private void R_U_N_Click(object sender, EventArgs e)
        {
            string TempSaveFolderPath = Targetfolder.Text;
            Config.AppSettings.Settings["outFolder"].Value = TempSaveFolderPath + "\\" + SpawnTitle.Text;
            Config.AppSettings.Settings["numBaseRuns"].Value = Runtime.Text;
            for (int Factor = Convert.ToInt32(FactorBegin.Text); Factor <= Convert.ToInt32(FactorEnd.Text); Factor++)
            {
                Config.AppSettings.Settings["numBaseFactors"].Value=Factor.ToString();
                Config.AppSettings.Settings["outFileQual"].Value = SpawnTitle.Text +"With"+ Factor.ToString() + "Factors";
                string factor_names = "Factor 1";
                int RT = Convert.ToInt32(Runtime.Text);
                for (int i = 1; i < Factor * RT; i++) factor_names += "|Factor " + (i % RT) + 1;
                Config.AppSettings.Settings["factorNames"].Value = factor_names;
                Config.Save();
//TEMP
                MessageBox.Show("Phase" + (Factor + 1 - Convert.ToInt32(FactorBegin.Text)).ToString() + "Complete");

            }
            Config.AppSettings.Settings["outFileQual"].Value = SpawnTitle.Text;
            Config.AppSettings.Settings["outFolder"].Value=TempSaveFolderPath;
            Config.Save();
        }

        private void SpawnTitle_TextChanged(object sender, EventArgs e)
        {
             R_U_N.Enabled = !(SpawnTitle.Text == "");
        }

    }
}
