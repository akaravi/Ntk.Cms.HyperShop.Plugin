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
            ConnectionString = "Connectionstring To Db Here";
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
        }
        public string PluginName => "Test";

        public string CompanyName => "Test";

        public string LogoUrl => "";

        public int Version => 1;

        public string Description => "Test";

        public string Config { get; set; }


    }
}
