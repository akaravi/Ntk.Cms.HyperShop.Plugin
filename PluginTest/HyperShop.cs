using Ntk.Cms.HyperShop.PluginInterface;
using Ntk.Cms.HyperShop.PluginInterface.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginTest
{
    public class HyperShop : BasePlugin, IPluginHyperShop
    {
        public HyperShop()
        {
            ConnectionString = "Connection String To Db Here";
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
        }
        public string PluginName => "Test";

        public string CompanyName => "Test";

        public string LogoUrl => "";

        public int Version => 1;

        public string Description => "Test";

        public string Config { get; set; }

        public string ExecuteTest(string model)
        {
            return "Test";
        }
    }
}
