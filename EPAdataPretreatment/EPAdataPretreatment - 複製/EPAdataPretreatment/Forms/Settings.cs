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
using GetEPAdata;

namespace EPAdataPretreatment.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox1.Text = ConfigurationManager.AppSettings["API_KEY"];
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new EPAdataTools().KeyTest(textBox1.Text))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["API_KEY"].Value = textBox1.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 36)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "API KEY 過短";
            }
            else if (new EPAdataTools().KeyTest(textBox1.Text))
            {
                label1.ForeColor = Color.Green;
                label1.Text = "API KEY 正確";
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "API KEY 錯誤";
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://data.epa.gov.tw/api_term");
        }
    }
}
