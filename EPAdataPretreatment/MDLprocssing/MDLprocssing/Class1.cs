using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using BNOECHO_CSV;

namespace MDLprocssing
{

    public class MDLprocssingTools
    {
        [DllImport("user32.dll", SetLastError = true)]private static extern int GetWindowThreadProcessId(IntPtr hwnd,ref int ProcessID);
        private List<string> MDLitem = new List<string> {  "Ethane", "Ethylene", "Propane", "Propylene", "Isobutane", "n-Butane", "Acetylene", "t-2-Butene", "1-Butene", "cis-2-Butene", "Cyclopentane", "Isopentane", "n-Pentane", "t-2-Pentene", "1-Pentene", "cis-2-Pentene", "\"2,2 - Dimethylbutane\"", "\"2,3 - Dimethylbutane\"", "2-Methylpentane", "3-Methylpentane", "Isoprene", "1-Hexene", "n-Hexane", "Methylcyclopentane", "\"2,4 - Dimethylpentane\"", "Benzene", "Cyclohexane", "2-Methylhexane", "\"2,3 - Dimethylpentane\"", "3-Methylhexane", "\"2,2,4 - Trimethylpentane\"", "n-Heptane", "Methylcyclohexane", "\"2,3,4 - Trimethylpentane\"", "Toluene", "2-Methylheptane", "3-Methylheptane", "n-Octane", "Ethylbenzene", "\"m,p - Xylene\"", "Styrene", "o-Xylene", "n-Nonane", "Isopropylbenzene", "n-Propylbenzene", "m-Ethyltoluene", "p-Ethyltoluene", "\"1,3,5 - Trimethylbenzene\"", "o-Ethyltoluene", "\"1,2,4 - Trimethylbenzene\"", "n-Decane", "\"1,2,3 - Trimethylbenzene\"", "m-Diethylbenzene", "p-Diethylbenzene", "n-Undecane"};
        private List<string> header = new List<string> { "Date", "Ethane", "Ethylene", "Propane", "Propylene", "Isobutane", "n-Butane", "Acetylene", "t-2-Butene", "1-Butene", "cis-2-Butene", "Cyclopentane", "Isopentane", "n-Pentane", "t-2-Pentene", "1-Pentene", "cis-2-Pentene", "\"2,2 - Dimethylbutane\"", "\"2,3 - Dimethylbutane\"", "2-Methylpentane", "3-Methylpentane", "Isoprene", "1-Hexene", "n-Hexane", "Methylcyclopentane", "\"2,4 - Dimethylpentane\"", "Benzene", "Cyclohexane", "2-Methylhexane", "\"2,3 - Dimethylpentane\"", "3-Methylhexane", "\"2,2,4 - Trimethylpentane\"", "n-Heptane", "Methylcyclohexane", "\"2,3,4 - Trimethylpentane\"", "Toluene", "2-Methylheptane", "3-Methylheptane", "n-Octane", "Ethylbenzene", "\"m,p - Xylene\"", "Styrene", "o-Xylene", "n-Nonane", "Isopropylbenzene", "n-Propylbenzene", "m-Ethyltoluene", "p-Ethyltoluene", "\"1,3,5 - Trimethylbenzene\"", "o-Ethyltoluene", "\"1,2,4 - Trimethylbenzene\"", "n-Decane", "\"1,2,3 - Trimethylbenzene\"", "m-Diethylbenzene", "p-Diethylbenzene", "n-Undecane", "n-Dodecane", "AMB_TEMP", "CO", "NMHC", "NO", "NO2", "NOx", "O3", "WD_HR", "WS_HR" };
        public CSV DataRemoveNullRow(CSV file)
        {
            CSV result = new CSV();
            for (int i = 1; i < file.table.Count(); i++)
            {
                bool notnull = false;
                for (int o = 1; i < file.table[i].Count(); i++) if (file.table[i][o] != "") notnull = true;
                if(notnull) result.AddRow(file.table[i]);
            }
            return file;
        }
        public Dictionary<string,double> MDLFrequency(CSV file,Dictionary<string,double> MDL)
        {
            Dictionary<string, double> report=new Dictionary<string, double>();
            foreach (string s in MDLitem)
            {
                int MDLcount = 0;
                int index = file.table[0].IndexOf(s);
                if (index == -1) continue;
                double MDLValue = MDL[s];
                for (int i = 1; i < file.table.Count(); i++)
                {
                    double d;
                    if (double.TryParse(file.table[i][index], out d)) if (d > MDLValue) MDLcount++;
                }
                report.Add(s, (double)MDLcount / (double)(file.table.Count() - 1));
            }

            return report;
        }

        public CSV ConcentrationData(CSV file,List<string> RemoveList, Dictionary<string, double> MDL)
        {
            foreach(string item in MDL.Keys)
            {

                int index = file.table[0].IndexOf(item);
                if (index == -1) continue;
                if (RemoveList.Contains(item))
                {
                    Debug.Print("remove" + item+" "+index);
                    file.RemoveColumn(index);
                }
                else
                {
                    double ItemMDLValue = MDL[item]*0.5;
                    double MDLitem = MDL[item];
                    for (int i = 1; i < file.table.Count(); i++)
                    {
                        double d;
                        if (double.TryParse(file.table[i][index], out d))
                        {
                            if (d < MDLitem) file.table[i][index] = ItemMDLValue.ToString();
                        }
                        else
                        {
                            file.table[i][index] = ItemMDLValue.ToString();
                        }
                    }
                }
            }




            return file;
        }
        public CSV UncertaintyData(CSV file, List<string> RemoveList, Dictionary<string, double> MDL)
        {
            foreach (string item in MDL.Keys)
            {
                int index = file.table[0].IndexOf(item);
                if (index == -1) continue;
                if (RemoveList.Contains(item))
                {
                    Debug.Print("UCremove" + item + " " + index);
                    file.RemoveColumn(index);
                }
                else
                {
                    double ItemMDLValue = MDL[item] * 5/6;
                    double MDLitem = MDL[item];
                    for (int i = 1; i < file.table.Count(); i++)
                    {
                        double d;
                        if (double.TryParse(file.table[i][index], out d))
                        {
                            if (d < MDLitem) file.table[i][index] = ItemMDLValue.ToString();
                            else file.table[i][index] = (d*0.15).ToString();
                        }
                        else
                        {
                            file.table[i][index] = ItemMDLValue.ToString();
                        }
                    }
                }
            }


            return file;
        }

        public void SaveFiles(string SAVEfilepath,CSV C,CSV UC)
        {
            SAVEfilepath = SAVEfilepath.Split('.')[SAVEfilepath.Split('.').Length - 2];
            string CSV_Cpath = SAVEfilepath+ "C.csv";
            string CSV_UCpath = SAVEfilepath + "UC.csv";
            C.SaveCSV(CSV_Cpath);
            UC.SaveCSV(CSV_UCpath);
            Excel.Application excel = new Excel.Application();
            Excel.Workbook NFC = excel.Workbooks.Open(CSV_Cpath);
            NFC.SaveAs(SAVEfilepath + "C.xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook);
            Excel.Workbook NFUC = excel.Workbooks.Open(CSV_UCpath);
            NFUC.SaveAs(SAVEfilepath + "UC.xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook);

            NFC.Close(true);
            NFUC.Close(true);
            Marshal.ReleaseComObject(NFC);
            Marshal.ReleaseComObject(NFUC);
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



    }
}
