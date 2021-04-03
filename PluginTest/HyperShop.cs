using Ntk.Cms.HyperShop.PluginInterface;
using Ntk.Cms.HyperShop.PluginInterface.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginTest
{
    /// <summary>
    /// پیاده سازی کامل این کلاس ضروری است
    /// پس از پیاده سازی کلاس خروجی دی ال ال را ایجاد کرده و در کنار برنامه تست قرار دهید
    /// برنامه تست به صورت خودکار دی ال ال را فراخوانی کرده و شروع به کار می کند
    /// </summary>
    public class HyperShop : BasePlugin, IPluginHyperShop
    {
        
        public HyperShop()
        {
            // اولین مورد مقداردهی کانکشن به بانک اطلاعاتی می باشد
            ConnectionString = GetConnectionString();
            
            // مشخص کردن ستونهای جدول کالاها در بانک اطلاعاتی شما
            // نام جدول و نام ستونها را به صورت دقیق وارد کنید
            Product.ConfigureColumns((x) =>
            {
                x.SelectFrom("[TblProduct]"); // ViewProduct - Product Inner Join ProductGroup ......
                x.Code("ProductCode");
                x.Name("Name");
                x.Count("Inventory");
                x.Unit("ProductUnit");
                x.Category("Category");
                x.CategoryCode("CategoryCode");
                x.Description("Tozihat");
            });

            // مشخص کردن ستونهای جدول گروه بندی کالاها در بانک اطلاعاتی شما
            // نام جدول و نام ستونها را به صورت دقیق وارد کنید
            ProductCategory.ConfigureColumns((x) =>
            {
                x.SelectFrom("[TblProductGroup]"); // ViewProductGroup - ProductGroup INNER JOIN ParentGroup .....
                x.Code("Code");
                x.Image("");
                x.Memo("Description");
                x.Name("Name");
                x.ParentCode("");
                x.RowId("RowId");
            });

            // زمانی که برنامه سفارش جدیدی را دریافت کند
            Order.OnAdd += Order_OnAdd;
            
            // زمانی که سفارش ویرایش می شود
            Order.OnUpdate += Order_OnUpdate;
            
            //زمانی که عملیات پرداخت در حال انجام است یا به اتمام رسید
            Order.OnBankPaymentSuccess += Order_OnBankPaymentSuccess;
        }

        private static string loadedConnectionString;
        private static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(loadedConnectionString))
            {
                /// کانکشن به بانک اطلاعاتی را در این قسمت قرار دهید
                /// خواندن از فایل - از رجیستری و ....
                loadedConnectionString = "";
            }
            return loadedConnectionString;
        }

        private void Order_OnBankPaymentSuccess(object sender, Ntk.Cms.HyperShop.PluginInterface.Configs.OrderBankPaymentEventArgs e)
        {
            // ایجاد خطا برای خروجی
            //e.ErrorMessage = "در حال حاضر فروش غیر فعال است";
            //e.IsSuccess = false;

            //نوع پرداخت و عملیات مربوط به پرداخت در این فیلد اطلاعاتی قرار دارد
            var payment=e.BankPayment;

            // پس از تغییر پیش فاکتور به فاکتور فروش این مقدار فیلد اطلاعاتی را پر کنید
            e.Order = new Ntk.Cms.Share.Interface.CmsModels.HyperShop.HyperShopOrderModel()
            {

            };
            //عملیات موفقیت آمیز بود
            e.IsSuccess = true;
        }

        private void Order_OnUpdate(object sender, Ntk.Cms.HyperShop.PluginInterface.Configs.OrderEventArgs e)
        {
            // ایجاد خطا برای خروجی
            //e.ErrorMessage = "در حال حاضر فروش غیر فعال است";
            //e.IsSuccess = false;



            // پس از ثبت سفارش به عنوان پیش فاکتور در بانک اطلاعاتی این مقادیر را پر کنید

            // انجاتم موفق عملیات
            e.IsSuccess = true;

        }

        private void Order_OnAdd(object sender, Ntk.Cms.HyperShop.PluginInterface.Configs.OrderEventArgs e)
        {

            // ایجاد خطا برای خروجی
            //e.ErrorMessage = "در حال حاضر فروش غیر فعال است";
            //e.IsSuccess = false;



            // پس از ثبت سفارش به عنوان پیش فاکتور در بانک اطلاعاتی این مقادیر را پر کنید

            // آی دی ردیفی که در بانک اطلاعاتی ثبت کرده اید
            e.Order.SystemMicroServiceOrderId = "DB_ID";
            // انجاتم موفق عملیات
            e.IsSuccess = true;
        }

        /// <summary>
        /// نام پلاگین
        /// بهتر است نام نرم افزار باشد
        /// </summary>
        public string PluginName => "Test";

        /// <summary>
        /// نام شرکت
        /// </summary>
        public string CompanyName => "Test";

        /// <summary>
        /// آدرس لوگوی برنامه
        /// آدرس اینترنتی جهت دانلود
        /// </summary>
        public string LogoUrl => "";

        public int Version => 1;

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description => "Test";

        /// <summary>
        /// در صورتی که کانفیگ خاصی را مد نظر دارید
        /// غیر ضروری
        /// </summary>
        public string Config { get; set; }


    }
}
