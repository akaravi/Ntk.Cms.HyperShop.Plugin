using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ntk.Cms.HyperShop.Plugin.Test.Comps
{
    public partial class UsrSetPlugin : UserControl
    {
        public UsrSetPlugin()
        {
            InitializeComponent();
        }

        string path = "";

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtAction.Text = "";
            AddToText("شروع جستجو در مسیر");
            path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugin");
            AddToText(path);

        }

        private void AddToText(string txt)
        {
            txtAction.Text += txt + Environment.NewLine;
        }
    }
}
