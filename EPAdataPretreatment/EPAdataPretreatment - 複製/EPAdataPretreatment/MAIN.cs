using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BNOECHO_CSV;
using GetEPAdata;
using System.Configuration;

namespace EPAdataPretreatment
{
    public partial class MAIN : Form
    {
        public MAIN()
        {
            InitializeComponent();
        }
        List<Panel> panels = new List<Panel>();
        Form activeForm = null;

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeSubForm( new Forms.FormGetEPAData(this), "下載環保署資料");
        }

        private void ChangeSubForm(Form subform, string text)
        {
            label1.Text = text;
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
                GC.Collect();
            }
            
            activeForm = subform;
            
            subform.TopLevel = false;
            subform.Dock = DockStyle.Fill;
            subform.FormBorderStyle = FormBorderStyle.None;
            SubForm.Controls.Add(subform);
            subform.BringToFront();
            subform.Show();

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public void Lock()
        {
            foreach (Control C in MENU.Controls) if (C is Button) C.Enabled = false;
       
                

        }
        public void UnLock()
        {
            foreach (Control C in MENU.Controls) if (C is Button) C.Enabled = true;
        }





        private void GetActinicData_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeSubForm(new Forms.FormMDLPreTreatMent(), "MDL資料前處理");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeSubForm(new Forms.FormSettings(), "設定");
        }
    }
}
