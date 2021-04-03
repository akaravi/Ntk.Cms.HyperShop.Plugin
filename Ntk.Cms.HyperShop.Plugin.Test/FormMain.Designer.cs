
namespace Ntk.Cms.HyperShop.Plugin.Test
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSetProduct = new System.Windows.Forms.Button();
            this.btnSetCategory = new System.Windows.Forms.Button();
            this.btnSetPlugin = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnSetBankPayment = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDownloadSample = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnDownloadSample);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSetBankPayment);
            this.panel1.Controls.Add(this.btnEditOrder);
            this.panel1.Controls.Add(this.btnAddOrder);
            this.panel1.Controls.Add(this.btnSetPlugin);
            this.panel1.Controls.Add(this.btnSetCategory);
            this.panel1.Controls.Add(this.btnSetProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1014, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 784);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 784);
            this.panel2.TabIndex = 1;
            // 
            // btnSetProduct
            // 
            this.btnSetProduct.Location = new System.Drawing.Point(32, 184);
            this.btnSetProduct.Name = "btnSetProduct";
            this.btnSetProduct.Size = new System.Drawing.Size(134, 71);
            this.btnSetProduct.TabIndex = 0;
            this.btnSetProduct.Text = "تست کالا";
            this.btnSetProduct.UseVisualStyleBackColor = true;
            this.btnSetProduct.Click += new System.EventHandler(this.btnSetProduct_Click);
            // 
            // btnSetCategory
            // 
            this.btnSetCategory.Location = new System.Drawing.Point(32, 107);
            this.btnSetCategory.Name = "btnSetCategory";
            this.btnSetCategory.Size = new System.Drawing.Size(134, 71);
            this.btnSetCategory.TabIndex = 1;
            this.btnSetCategory.Text = "تست گروه کالا";
            this.btnSetCategory.UseVisualStyleBackColor = true;
            this.btnSetCategory.Click += new System.EventHandler(this.btnSetCategory_Click);
            // 
            // btnSetPlugin
            // 
            this.btnSetPlugin.Location = new System.Drawing.Point(32, 30);
            this.btnSetPlugin.Name = "btnSetPlugin";
            this.btnSetPlugin.Size = new System.Drawing.Size(134, 71);
            this.btnSetPlugin.TabIndex = 2;
            this.btnSetPlugin.Text = "اتصال به پلاگین";
            this.btnSetPlugin.UseVisualStyleBackColor = true;
            this.btnSetPlugin.Click += new System.EventHandler(this.btnSetPlugin_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(32, 261);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(134, 71);
            this.btnAddOrder.TabIndex = 3;
            this.btnAddOrder.Text = "تست ثبت سفارش";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Location = new System.Drawing.Point(32, 338);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(134, 71);
            this.btnEditOrder.TabIndex = 4;
            this.btnEditOrder.Text = "تست ویرایش سفارش";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnSetBankPayment
            // 
            this.btnSetBankPayment.Location = new System.Drawing.Point(32, 415);
            this.btnSetBankPayment.Name = "btnSetBankPayment";
            this.btnSetBankPayment.Size = new System.Drawing.Size(134, 71);
            this.btnSetBankPayment.TabIndex = 5;
            this.btnSetBankPayment.Text = "تست پرداخت بانکی";
            this.btnSetBankPayment.UseVisualStyleBackColor = true;
            this.btnSetBankPayment.Click += new System.EventHandler(this.btnSetBankPayment_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(32, 492);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(134, 71);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDownloadSample
            // 
            this.btnDownloadSample.Location = new System.Drawing.Point(32, 701);
            this.btnDownloadSample.Name = "btnDownloadSample";
            this.btnDownloadSample.Size = new System.Drawing.Size(134, 71);
            this.btnDownloadSample.TabIndex = 7;
            this.btnDownloadSample.Text = "دانلود مثال";
            this.btnDownloadSample.UseVisualStyleBackColor = true;
            this.btnDownloadSample.Click += new System.EventHandler(this.btnDownloadSample_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 784);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تست پلاگین";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDownloadSample;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSetBankPayment;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnSetPlugin;
        private System.Windows.Forms.Button btnSetCategory;
        private System.Windows.Forms.Button btnSetProduct;
        private System.Windows.Forms.Panel panel2;
    }
}

