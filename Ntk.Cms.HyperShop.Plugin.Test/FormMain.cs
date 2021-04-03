using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ntk.Cms.HyperShop.Plugin.Test
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSetPlugin_Click(object sender, EventArgs e)
        {

        }

        private void btnSetCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnSetProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnSetBankPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownloadSample_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText("www.google.com");
                MessageBox.Show("لینک در کلیپبورد کپی شد");
            }
            catch 
            {
            }
            try
            {
                System.Diagnostics.Process.Start(Clipboard.GetText());
            }
            catch 
            {
            }
        }
    }
}
