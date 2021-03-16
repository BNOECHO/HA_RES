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

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExeConfigurationFileMap ExConfig = new ExeConfigurationFileMap();
                ExConfig.ExeConfigFilename = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                textBoxCFGLabel.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                try
                {
                    Configuration Config = ConfigurationManager.OpenMappedExeConfiguration(ExConfig, ConfigurationUserLevel.None);
                    textBoxC.Text = Config.AppSettings.Settings["concFile"].Value.ToString();
                    textBoxUC.Text = Config.AppSettings.Settings["uncFile"].Value.ToString();
                    labelCW.Text = "Worksheet:" + Config.AppSettings.Settings["concSheet"].Value.ToString();
                    labelUCW.Text = "Worksheet:" + Config.AppSettings.Settings["uncSheet"].Value.ToString();
                    dataGridView1.Columns.Add(new DataGridViewColumn());
                    dataGridView1.Columns[0].HeaderText = "  ";
                }
                catch
                {
                    MessageBox.Show("錯誤的組態檔", "EPA_PMF_AUTORUN");
                }
            
            }
        }
    }
}
