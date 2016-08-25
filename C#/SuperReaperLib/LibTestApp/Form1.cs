using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperReaperLib;

namespace LibTestApp
{
    public partial class Form1 : Form, VersionCheckerCallback
    {
        public VersionChecker vc;
        public Form1()
        {
            InitializeComponent();
            vc = new VersionChecker("https://dl.dropboxusercontent.com/u/123946716/VersionNumber.txt", "1.0.0.0", this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vc.CheckVersion();
            textBox1.Text = vc.GetCurrentVersion();
            textBox2.Text = vc.GetMostRecentVersion();
        }

        public void OnVersionChecked(bool isUpdated)
        {
            if (isUpdated == true)
            {
                MessageBox.Show("Already up to date.");
            }
            else { MessageBox.Show("Outdated Version"); }
            
        }
    }
}
