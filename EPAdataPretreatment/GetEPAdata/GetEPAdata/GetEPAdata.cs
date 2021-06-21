using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using BNOECHO_CSV;
namespace GetEPAdata
{
    public class EPAdataBase
    {
        private List<string> header = new List<string> { "Date", "Ethane", "Ethylene", "Propane", "Propylene", "Isobutane", "n-Butane", "Acetylene", "t-2-Butene", "1-Butene", "cis-2-Butene", "Cyclopentane", "Isopentane", "n-Pentane", "t-2-Pentene", "1-Pentene", "cis-2-Pentene", "\"2,2 - Dimethylbutane\"", "\"2,3 - Dimethylbutane\"", "2-Methylpentane", "3-Methylpentane", "Isoprene", "1-Hexene", "n-Hexane", "Methylcyclopentane", "\"2,4 - Dimethylpentane\"", "Benzene", "Cyclohexane", "2-Methylhexane", "\"2,3 - Dimethylpentane\"", "3-Methylhexane", "\"2,2,4 - Trimethylpentane\"", "n-Heptane", "Methylcyclohexane", "\"2,3,4 - Trimethylpentane\"", "Toluene", "2-Methylheptane", "3-Methylheptane", "n-Octane", "Ethylbenzene", "\"m,p - Xylene\"", "Styrene", "o-Xylene", "n-Nonane", "Isopropylbenzene", "n-Propylbenzene", "m-Ethyltoluene", "p-Ethyltoluene", "\"1,3,5 - Trimethylbenzene\"", "o-Ethyltoluene", "\"1,2,4 - Trimethylbenzene\"", "n-Decane", "\"1,2,3 - Trimethylbenzene\"", "m-Diethylbenzene", "p-Diethylbenzene", "n-Undecane", "n-Dodecane", "AMB_TEMP", "CO", "NMHC", "NO", "NO2", "NOx", "O3", "WD_HR", "WS_HR" };
        private Dictionary<string, int> C=new Dictionary<string, int> 
        {
            {"Ethane",2},{"Ethylene",2},{"Propane",3},{"Propylene",3},{"Isobutane",4},{"n-Butane",4},{"Acetylene",2},{"t-2-Butene",4},{"1-Butene",4},{"cis-2-Butene",4},{"Cyclopentane",5},{"Isopentane",5},{"n-Pentane",5},{"t-2-Pentene",5},{"1-Pentene",5},{"cis-2-Pentene",5},{"\"2,2 - Dimethylbutane\"",6},{"\"2,3 - Dimethylbutane\"",6},{"2-Methylpentane",6},{"3-Methylpentane",6},{"Isoprene",5},{"1-Hexene",6},{"n-Hexane",6},{"Methylcyclopentane",7},{"\"2,4 - Dimethylpentane\"",6},{"Benzene",6},{"Cyclohexane",7},{"2-Methylhexane",7},{"\"2,3 - Dimethylpentane\"",7},{"3-Methylhexane",8},{"\"2,2,4 - Trimethylpentane\"",7},{"n-Heptane",7},{"Methylcyclohexane",7},{"\"2,3,4 - Trimethylpentane\"",7},{"Toluene",8},{"2-Methylheptane",8},{"3-Methylheptane",8},{"n-Octane",8},{"Ethylbenzene",8},{"\"m,p - Xylene\"",8},{"Styrene",8},{"o-Xylene",9},{"n-Nonane",9},{"Isopropylbenzene",9},{"n-Propylbenzene",9},{"m-Ethyltoluene",9},{"p-Ethyltoluene",9},{"\"1,3,5 - Trimethylbenzene\"",9},{"o-Ethyltoluene",9},{"\"1,2,4 - Trimethylbenzene\"",10},{"n-Decane",9},{"\"1,2,3 - Trimethylbenzene\"",10},{"m-Diethylbenzene",10},{"p-Diethylbenzene",11},{"n-Undecane",12},{"n-Dodecane",12}
        };
        private Dictionary<string, int> M=new Dictionary<string, int>
        {
            {"Ethane",30},{"Ethylene",28},{ "Propane",44},{ "Propylene",42},{ "Isobutane",58},{ "n-Butane",68},{ "Acetylene",26},{ "t-2-Butene",56},{ "1-Butene",56},{ "cis-2-Butene",56},{ "Cyclopentane",70},{ "Isopentane",72},{ "n-Pentane",72},{ "t-2-Pentene",70},{ "1-Pentene",70},{ "cis-2-Pentene",70},{ "\"2,2 - Dimethylbutane\"",86},{ "\"2,3 - Dimethylbutane\"",86},{ "2-Methylpentane",86},{ "3-Methylpentane",86},{ "Isoprene",68},{ "1-Hexene",84},{ "n-Hexane",86},{ "Methylcyclopentane",84},{ "\"2,4 - Dimethylpentane\"",100},{ "Benzene",78},{ "Cyclohexane",84},{ "2-Methylhexane",100},{ "\"2,3 - Dimethylpentane\"",100},{ "3-Methylhexane",100},{ "\"2,2,4 - Trimethylpentane\"",114},{ "n-Heptane",100},{ "Methylcyclohexane",84},{ "\"2,3,4 - Trimethylpentane\"",114},{ "Toluene",92},{ "2-Methylheptane",114},{ "3-Methylheptane",114},{ "n-Octane",114},{ "Ethylbenzene",106},{ "\"m,p - Xylene\"",106},{ "Styrene",104},{ "o-Xylene",106},{ "n-Nonane",128},{ "Isopropylbenzene",120},{ "n-Propylbenzene",120},{ "m-Ethyltoluene",120},{ "p-Ethyltoluene",120},{ "\"1,3,5 - Trimethylbenzene\"",120},{ "o-Ethyltoluene",120},{ "\"1,2,4 - Trimethylbenzene\"",120},{ "n-Decane",142},{ "\"1,2,3 - Trimethylbenzene\"",120},{ "m-Diethylbenzene",134},{ "p-Diethylbenzene",134},{ "n-Undecane",156},{ "n-Dodecane",170}
        };
        public Dictionary<string,SortedDictionary<string,List<string>>> dataDict=new Dictionary<string, SortedDictionary<string, List<string>>>();
        public void ImportData(bool IsActinic, CSV data)
        {
            data.RemoveRow(0);
            if (IsActinic)
            {
                foreach (List<string> ROW in data.table)
                {
                    string site = ROW[1];
                    string date = ROW[5].Split('-')[1].PadLeft(2,'0') + "/" + ROW[5].Split('-')[2].PadLeft(2, '0') + "/" + ROW[5].Split('-')[0];
                    DataDictionExpand(site,date);
                    double d;
                    for (int i = 0; i < 24; i++)if(double.TryParse(ROW[6 + i], out d))dataDict[site][date + " " + i.ToString().PadLeft(2, '0') + ":00"][Convert.ToInt32(ROW[2])] = ROW[6 + i];
                }
            }

            if(!IsActinic)
            {
                foreach (List<string> ROW in data.table)
                {
                    string site = ROW[1];
                    string date = ROW[6].Split('-')[1] + "/" + ROW[6].Split('-')[2] + "/" + ROW[6].Split('-')[0];
                    DataDictionExpand(site,date);
                    int index = header.IndexOf(ROW[4]);
                    double d;
                    if(index!=-1)for (int i = 0; i < 24; i++) if (double.TryParse(ROW[7 + i], out d)) dataDict[site][date + " " + i.ToString().PadLeft(2, '0') + ":00"][index] = ROW[7 + i];
                }
            }
        }
        public void DataDictionExpand(string site, string date)//site->datetime(MM/DD/YYYY hh:mm)
        {
            if (!dataDict.ContainsKey(site)) dataDict.Add(site, new SortedDictionary<string, List<string>>());
            if (!dataDict[site].ContainsKey(date + " 00:00"))for (int t = 0; t < 24; t++)
            {
                List<string> row = new List<string>();
                row.Add(date + " " + t.ToString().PadLeft(2, '0') + ":00");
                int count = 65;while (count-- != 0) row.Add("");//HEAD留空給DATE
                dataDict[site].Add(row[0], row);
            }
            
        }
        public CSV ExportSitePpbcToUgm3(string site)
        {
            CSV Result = new CSV();
            Result.AddRow(header);
            foreach (string TimeTag in dataDict[site].Keys)
            {
                Result.AddRow(dataDict[site][TimeTag]);
            }
            foreach (string Key in C.Keys)
            {
                int index = Result.table[0].IndexOf(Key);
                double d;
                for (int i = 1; i < Result.table.Count(); i++)if(double.TryParse(Result.table[i][index], out d)) Result.table[i][index] = convert(Result.table[i][index], C[Key], M[Key]);
            }
            return Result;
        }

        string convert(string input, double CValue, double MValue)
        {
            double Result = Convert.ToDouble(input);
            Result = Result / CValue * 12.187 * MValue / 298.15;
            return Result.ToString();
        }
    }


    public class EPAdataTools
    {
        string API_KEY = "";
        private int beginY = 2020;
        private int beginM = 2;
        private int endY = 2020;
        private int endM = 2;
        private bool setTime = false;
        public bool KeyTest(string API_KEY)
        {
            HttpClient Client = new HttpClient();
            string csv = "content here";
            Client.BaseAddress = new Uri("https://data.epa.gov.tw/");
            HttpRequestMessage RequestMessage = new HttpRequestMessage(HttpMethod.Post, "api/v1/aqx_p_25?format=csv&limit=1&year_month=2020_01&api_key=" + API_KEY);
            RequestMessage.Content = new StringContent(csv, Encoding.UTF8, "text/csv");
            var CliRES = Client.SendAsync(RequestMessage).Result;
            return (CliRES.Content.ReadAsStringAsync().Result!= "Api key incorrect");
        }
        public List<CSV> getActinicData()
        {
            List<CSV> Result = new List<CSV>();
            if (!setTime) return new List<CSV>();
            MDtag();
            HttpClient Client = new HttpClient();
            string csv = "content here";
            Client.BaseAddress = new Uri("https://data.epa.gov.tw/");

            foreach (string Tag in MDtag())
            {int offset = 0;
                do
                {
                    
                    HttpRequestMessage RequestMessage = new HttpRequestMessage(HttpMethod.Post, "api/v1/aqx_p_25?format=csv&offset=" + offset.ToString() + "&year_month=" + Tag + "&api_key=" + API_KEY);
                    RequestMessage.Content = new StringContent(csv, Encoding.UTF8, "text/csv");
                    var CliRES = Client.SendAsync(RequestMessage).Result;
                    CSV IPCSV = new CSV();
                    IPCSV.load_String_To_CSV(CliRES.Content.ReadAsStringAsync().Result);
                    if (CliRES.IsSuccessStatusCode) Result.Add(IPCSV);
                    offset += 1000;
                    Debug.Print("已取得資料" + (offset / 1000).ToString());
                } while (Result[Result.Count() - 1].table.Count() >= 1001);
            }
            return Result;

        }
        public List<CSV> getGeneralData()
        {
            List<CSV> Result = new List<CSV>();
            if (!setTime) return new List<CSV>();
            MDtag();
            HttpClient Client = new HttpClient();
            string csv = "content here";
            Client.BaseAddress = new Uri("https://data.epa.gov.tw/");

            foreach (string Tag in MDtag())
            {
                int offset = 0;
                do
                {

                    HttpRequestMessage RequestMessage = new HttpRequestMessage(HttpMethod.Post, "api/v1/aqx_p_13?format=csv&offset=" + offset.ToString() + "&year_month=" + Tag + "&api_key=" + API_KEY);
                    RequestMessage.Content = new StringContent(csv, Encoding.UTF8, "text/csv");
                    var CliRES = Client.SendAsync(RequestMessage).Result;
                    CSV IPCSV = new CSV();
                    IPCSV.load_String_To_CSV(CliRES.Content.ReadAsStringAsync().Result);
                    if (CliRES.IsSuccessStatusCode) Result.Add(IPCSV);
                    offset += 1000;
                    Debug.Print("已取得資料" + (offset / 1000).ToString());
                } while (Result[Result.Count() - 1].table.Count() >= 1001);
            }
            return Result;

        }
        private List<string> MDtag()
        {
            List<string> tag = new List<string>();
            int CureentYear = beginY;
            int CurrentMonth = beginM;
            while (CureentYear <= endY)
            {
                while (CurrentMonth <= 12&&!(CureentYear == endY&&CurrentMonth>endM))
                {
                    tag.Add(CureentYear.ToString() + "_" + CurrentMonth.ToString().PadLeft(2, '0'));
                    CurrentMonth++;
                }
                CurrentMonth = 1;
                CureentYear++;
            }
            return tag;
        }
        public void setBasic(int BY,int BM,int EY,int EM)
        {
            beginY = BY;
            beginM = BM;
            endY=EY;
            endM = EM;
            setTime = true;
        }
        public void SetApiKey(string API)
        {
            API_KEY = API;
        }


    }
}
