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
using System.Runtime.InteropServices;
using System.IO;

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
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow
           (
               string ClassName,
               string WindowName
           );
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx
            (
                IntPtr FatherWDHandle,
                uint HandleChildAfter,
                string TatgetClass,
                string Targetname
            );
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage
        (
            IntPtr THandle,
            uint SMsg,
            IntPtr wParam,
            string IParam
        );
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern void SetForegroundWindow
        (
            IntPtr Handle
        );
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SendMessage
        (
            IntPtr THandle,
            uint SMsg,
            int wParam,
            int IParam
        );
        int getTBtry = 0;
        string CAT = "";
        double CATweak = 1;
        double CATbad = 0.5;
        String CSV = "";
        Configuration Config = null;
        IntPtr EPA_PMF = new IntPtr(0);
        IntPtr EPA_PMF_TAB = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_1= new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_1_TAB = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_1_TAB_L2 = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_1_TAB_L2_SaveFile = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_2 = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_2_TAB = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_2_TAB_L2 = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run = new IntPtr(0);
        IntPtr EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun = new IntPtr(0);
        private void RenewHwnd()
        {
            EPA_PMF = new IntPtr(0);
            EPA_PMF_TAB = new IntPtr(0);
            EPA_PMF_TAB_L2_1 = new IntPtr(0);
            EPA_PMF_TAB_L2_1_TAB = new IntPtr(0);
            EPA_PMF_TAB_L2_1_TAB_L2 = new IntPtr(0);
            EPA_PMF_TAB_L2_1_TAB_L2_SaveFile = new IntPtr(0);
            EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath = new IntPtr(0);
            EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad = new IntPtr(0);
            EPA_PMF_TAB_L2_2 = new IntPtr(0);
            EPA_PMF_TAB_L2_2_TAB = new IntPtr(0);
            EPA_PMF_TAB_L2_2_TAB_L2 = new IntPtr(0);
            EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun = new IntPtr(0);
            EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run = new IntPtr(0);
            EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun = new IntPtr(0);
            //start Renew
            EPA_PMF = FindWindow(null, "EPA PMF");
            if (EPA_PMF!=IntPtr.Zero)
            {
                EPA_PMF_TAB = FindWindowEx(EPA_PMF, 0, "WindowsForms10.SysTabControl32.app.0.378734a", "");
                if (EPA_PMF_TAB != IntPtr.Zero)
                { 
                    EPA_PMF_TAB_L2_1 = FindWindowEx(EPA_PMF_TAB, 0, "WindowsForms10.Window.8.app.0.378734a", "Model Data");
                    if (EPA_PMF_TAB_L2_1 != IntPtr.Zero)
                    { 
                        EPA_PMF_TAB_L2_1_TAB= FindWindowEx(EPA_PMF_TAB_L2_1, 0, "WindowsForms10.SysTabControl32.app.0.378734a", "");
                        if (EPA_PMF_TAB_L2_1_TAB != IntPtr.Zero)
                        {
                            EPA_PMF_TAB_L2_1_TAB_L2= FindWindowEx(EPA_PMF_TAB_L2_1_TAB, 0, "WindowsForms10.Window.8.app.0.378734a", "Data Files");
                            if (EPA_PMF_TAB_L2_1_TAB_L2 != IntPtr.Zero)
                            {
                                EPA_PMF_TAB_L2_1_TAB_L2_SaveFile = FindWindowEx(EPA_PMF_TAB_L2_1_TAB_L2, 0, "WindowsForms10.Window.8.app.0.378734a", "Save File Locations and Settings in a Configuration File or Load a Previous Configuration File");
                                if (EPA_PMF_TAB_L2_1_TAB_L2_SaveFile != IntPtr.Zero)
                                {
                                    EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath = FindWindowEx(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile, 0, "WindowsForms10.EDIT.app.0.378734a", "");
                                    EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad = FindWindowEx(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile, 0, "WindowsForms10.BUTTON.app.0.378734a", "Load");
                                }
                            }
                        }
                    }
                    EPA_PMF_TAB_L2_2 = FindWindowEx(EPA_PMF_TAB, 0, "WindowsForms10.Window.8.app.0.378734a", "Base Model");
                    if (EPA_PMF_TAB_L2_2 != IntPtr.Zero) 
                    {
                        EPA_PMF_TAB_L2_2_TAB= FindWindowEx(EPA_PMF_TAB_L2_2, 0, "WindowsForms10.SysTabControl32.app.0.378734a", "");
                        if (EPA_PMF_TAB_L2_2_TAB != IntPtr.Zero)
                        { 
                            EPA_PMF_TAB_L2_2_TAB_L2 = FindWindowEx(EPA_PMF_TAB_L2_2_TAB, 0, "WindowsForms10.Window.8.app.0.378734a", "Base Model Runs");
                            if (EPA_PMF_TAB_L2_2_TAB_L2 != IntPtr.Zero)
                            { 
                                EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun= FindWindowEx(EPA_PMF_TAB_L2_2_TAB_L2, 0, "WindowsForms10.Window.8.app.0.378734a", "Base Model Runs");
                                if (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun != IntPtr.Zero)
                                {
                                    EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run= FindWindowEx(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun, 0, "WindowsForms10.BUTTON.app.0.378734a", "Run");
                                    EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun = FindWindowEx(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun, 0, "WindowsForms10.EDIT.app.0.378734a", getTBtry.ToString());
                                    while (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun == IntPtr.Zero)
                                    {
                                        getTBtry++;
                                        EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun = FindWindowEx(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun, 0, "WindowsForms10.EDIT.app.0.378734a", getTBtry.ToString());
                                        if (getTBtry > 100) getTBtry = -1;

                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun == IntPtr.Zero) getTBtry++;
            if (getTBtry > 35) getTBtry = 0;
            ShowStatus.Text = "Status:\n";
            ShowStatus.Text+= "EPA_PMF:"+( EPA_PMF != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB:"+(EPA_PMF_TAB != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_1:"+(EPA_PMF_TAB_L2_1 != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_1_TAB:"+(EPA_PMF_TAB_L2_1_TAB != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_1_TAB_L2 :"+(EPA_PMF_TAB_L2_1_TAB_L2 != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_1_TAB_L2_SaveFile:"+(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath:"+(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad:"+(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_2:"+(EPA_PMF_TAB_L2_2 != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_2_TAB:"+(EPA_PMF_TAB_L2_2_TAB != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_2_TAB_L2:"+(EPA_PMF_TAB_L2_2_TAB_L2 != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun:"+(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text+= "EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run:"+(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run != IntPtr.Zero).ToString()+"\n";
            ShowStatus.Text += "EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun:" + (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun != IntPtr.Zero).ToString() + "\n";






        }
        private bool SetConfigPath(string Path)
        {
            RenewHwnd();
            SetForegroundWindow(EPA_PMF_TAB_L2_1);//
            if (EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath == IntPtr.Zero) return true;
            SetForegroundWindow(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath);
            SendMessage(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath, 0x000C, IntPtr.Zero, Path);
            return false;
        }
        private bool SetNumOfRun(string run)
        {
            RenewHwnd();
            SetForegroundWindow(EPA_PMF_TAB_L2_2);//
            if (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun == IntPtr.Zero) return true;
            SetForegroundWindow(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun);
            SendMessage(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun, 0x000C, IntPtr.Zero, run);
            return false;
        }
        private bool Click_Load()
        {
            RenewHwnd();
            if (EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad == IntPtr.Zero) return true;
            SendMessage(EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad, 0xF5, 0, 0);
            return false;
        }
        private bool Click_Run()
        {
            RenewHwnd();
            if (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run == IntPtr.Zero) return true;
            SendMessage(EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run, 0xF5, 0, 0);
            return false;
        }
        private bool Switch_Tab1(int index)
        {
            RenewHwnd();
            if (EPA_PMF_TAB == IntPtr.Zero) return true;
            SendMessage(EPA_PMF_TAB, 0x1300 + 12, index, 0);
            return false;
        }

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
                    SpawnTitle.Enabled = true;

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
            Config.AppSettings.Settings["categories"].Value = CAT;
            Config.Save();
            MessageBox.Show("在開始執行之前，請先將EPA PMF 5.0 切換至\"model data->data files!\"");
            CSV += FactorBegin.Text + ",";
            GetEPAPMF.Enabled = false;
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
                //MessageBox.Show("Phase" + (Factor + 1 - Convert.ToInt32(FactorBegin.Text)).ToString() + "Start");
                Switch_Tab1(0);//3
                System.Threading.Thread.Sleep(100);
                SetConfigPath(TBCFG.Text);//5
                System.Threading.Thread.Sleep(100);
                Click_Load();//7
                System.Threading.Thread.Sleep(100);
                Switch_Tab1(1);//4
                System.Threading.Thread.Sleep(100);
                SetConfigPath(TBCFG.Text);//5
                System.Threading.Thread.Sleep(100);
                Switch_Tab1(0);//3
                System.Threading.Thread.Sleep(100);
                Click_Run();//8
                System.Threading.Thread.Sleep(100);
                //TEMP
                // MessageBox.Show("Phase" + (Factor + 1 - Convert.ToInt32(FactorBegin.Text)).ToString() + "Complete");

            }
            Config.AppSettings.Settings["outFileQual"].Value = SpawnTitle.Text;
            Config.AppSettings.Settings["outFolder"].Value=TempSaveFolderPath;
            Config.Save();
            GetEPAPMF.Enabled = true;
            listView2.Clear();
            listView2.Columns.Add("Factors");
            ListViewItem Qitem = new ListViewItem("Q(true)/Qexp");
            List<double> MAXQPs = new List<double>();
            for (int i = Convert.ToInt32(FactorBegin.Text); i <= Convert.ToInt32(FactorEnd.Text); i++)
            {
                
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbookC = null;
                object oMissing = System.Reflection.Missing.Value;
                DataTable DT = new DataTable();
                workbookC = excel.Workbooks.Open(Targetfolder.Text+"\\"+SpawnTitle.Text+"\\"+SpawnTitle.Text+"With"+i.ToString()+"Factors_diagnostics.xlsx", oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                Excel.Worksheet Q = (Excel.Worksheet)workbookC.Sheets["Base Runs"];
                listView2.Columns.Add(i.ToString()+"Factors");
                List<double> Qps = new List<double>();
                foreach (Object value in (Q.Range[Q.Cells[10, 7], Q.Cells[10, 7].End[Excel.XlDirection.xlDown]].Value2()))
                {
                    if (value == null) break;
                    Qps.Add((double)value);
                }
                MAXQPs.Add(Qps.Max());
                Qitem.SubItems.Add(Qps.Max().ToString());
                CSV += Qps.Max().ToString() + ",";


                //EXCEL C Close
                Marshal.ReleaseComObject(Q);
                workbookC.Close();
                Marshal.ReleaseComObject(workbookC);
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
            listView2.Items.Add(Qitem);
            List<double> DDMAXQps = new List<double>();
            double Max = 0;
            int MaxIndex = 0;
            for (int i = 1; i < MAXQPs.Count() - 1; i++)
            {
                double T = MAXQPs[i - 1] - MAXQPs[i] * 2 + MAXQPs[i + 1];
                if (Max > T) {
                    MaxIndex = i;
                    Max = T;
                }

            }
            int BestFactor = MaxIndex + Convert.ToInt32(FactorBegin.Text);
            label6.Text = "轉折點:" + (BestFactor).ToString() + "Factors";
            //再重新讀取一次最佳轉折點
            Config.AppSettings.Settings["numBaseFactors"].Value = BestFactor.ToString();
            Config.AppSettings.Settings["outFileQual"].Value = SpawnTitle.Text + "With" + BestFactor.ToString() + "Factors";
            string Bestfactor_names = "Factor 1";
            int BRT = Convert.ToInt32(Runtime.Text);
            for (int i = 1; i <  BestFactor* BRT; i++) Bestfactor_names += "|Factor " + (i % BRT) + 1;
            Config.AppSettings.Settings["factorNames"].Value = Bestfactor_names;
            Config.Save();
            //MessageBox.Show("Phase" + (Factor + 1 - Convert.ToInt32(FactorBegin.Text)).ToString() + "Start");
            Switch_Tab1(0);//3
            System.Threading.Thread.Sleep(100);
            SetConfigPath(TBCFG.Text);//5
            System.Threading.Thread.Sleep(100);
            Click_Load();//7
            System.Threading.Thread.Sleep(100);
            Switch_Tab1(1);//4
            System.Threading.Thread.Sleep(100);
            SetConfigPath(TBCFG.Text);//5
            System.Threading.Thread.Sleep(100);
            Switch_Tab1(0);//3
            System.Threading.Thread.Sleep(100);
            Click_Run();//8
            System.Threading.Thread.Sleep(100);
            //END
            SpawnCsv.Enabled = true;
            if (Convert.ToInt32(FactorEnd.Text) - Convert.ToInt32(FactorBegin.Text) < 2) label6.Text= "轉折點:無法取得"; 
            MessageBox.Show("已完成!");
        }

        private void SpawnTitle_TextChanged(object sender, EventArgs e)
        {
             Taged.Checked = !(SpawnTitle.Text == "");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RenewHwnd();

            Geted.Checked = ((EPA_PMF != IntPtr.Zero) &&
            (EPA_PMF_TAB != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_1 != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_1_TAB != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_1_TAB_L2 != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_1_TAB_L2_SaveFile != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_ConfigPath != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_1_TAB_L2_SaveFile_BUTLoad != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_2 != IntPtr.Zero) &&
             (EPA_PMF_TAB_L2_2_TAB != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_2_TAB_L2 != IntPtr.Zero) &&
             (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun != IntPtr.Zero) &&
            (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_Run != IntPtr.Zero)&&
            (EPA_PMF_TAB_L2_2_TAB_L2_BaseModelRun_NumOfRun!=IntPtr.Zero));

        }



        private void Taged_CheckedChanged(object sender, EventArgs e)
        {
            R_U_N.Enabled = Taged.Checked && Geted.Checked;
        }

        private void Geted_CheckedChanged(object sender, EventArgs e)
        {
            R_U_N.Enabled = Taged.Checked && Geted.Checked;
        }



        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Targetfolder.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void SpawnCsv_Click(object sender, EventArgs e)
        {
            FileStream FS = File.Create( Targetfolder.Text+"\\"+SpawnTitle.Text+"\\Qres.csv");
            StreamWriter SW = new StreamWriter(FS, Encoding.GetEncoding("big5"));
            SW.Write(CSV);

            SW.Close();
        }
    }
}

