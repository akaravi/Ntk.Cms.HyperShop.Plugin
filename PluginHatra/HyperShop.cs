using System;
using Ntk.Cms.HyperShop.PluginInterface;
using Ntk.Cms.HyperShop.PluginInterface.Helper;
using Ntk.Cms.Share.Interface.CmsDtoModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using Ntk.Cms.Share.Interface.CmsModels.ModelHub;
using Ntk.Cms.Share.Interface.FilterEngine;

namespace PluginHatra
{
    public class HyperShop : BasePlugin, IPluginHyperShop
    {
        public string PluginName
        {
            get { return "Hatra"; }
        }

        public string CompanyName
        {
            get { return "Hatra"; }
        }

        public string LogoUrl
        {
            get { return "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"; }
        }

        public int Version
        {
            get { return 1; }
        }

        public string Description
        {
            get { return "hyper shop"; }
        }

        public string Config { get; set; } = "Conection=\"localhost\"";


        public string ExecuteTest(string model)
        {
            return model + this.PluginName + DateTime.Now;
        }
        public ErrorExceptionResult<UniversalActionModel> UniversalAction(UniversalActionModel model)
        {
            return new ErrorExceptionResult<UniversalActionModel>();
        }
        public ErrorExceptionResult<HyperShopContentModel> GetDataProductContentGetone(ProductContentDtoModel model)
        {
            var retOut = new ErrorExceptionResult<HyperShopContentModel>();
            retOut.Item=new HyperShopContentModel()
            {
                Category = "1",
                CategoryCode = "1",
                Code = "aaaa",
                Memo = "this is test value",
                Name = "test Product",
                Price = 1000,
                Sale = true,
                Description = "ddd",
                Brand = "Golrang",
                SalePrice = 1000,
                Count = 2,
                Status = true,
                Image = "http://www.iran.ir/image/layout_set_logo"
            };
            return retOut;
        }

        public ErrorExceptionResult<HyperShopContentModel> GetDataProductContentGetAll(FilterModel model)
        {
            var retOut = new ErrorExceptionResult<HyperShopContentModel>();
            retOut.ListItems.Add(new HyperShopContentModel()
            {
                Category = "1",
                CategoryCode = "1",
                Code = "aaaa",
                Memo = "this is test value",
                Name = "test Product",
                Price = 1000,
                Sale = true,
                Description = "ddd",
                Brand = "Golrang",
                SalePrice = 1000,
                Count = 2,
                Status = true,
                Image = "http://www.iran.ir/image/layout_set_logo"
            });
            return retOut;
        }

        public ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetone(ProductCategoryDtoModel model)
        {
            var retOut = new ErrorExceptionResult<HyperShopCategoryModel>();
            retOut.Item = new HyperShopCategoryModel()
            {
                
                Code = "1",
                Memo = "this is test value",
                Name = "test Product",
                Image = "http://www.iran.ir/image/layout_set_logo"
            };
            return retOut;
        }

        public ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetAll(FilterModel model)
        {
            var retOut = new ErrorExceptionResult<HyperShopCategoryModel>();
            retOut.ListItems.Add( new HyperShopCategoryModel()
            {

                Code = "1",
                Memo = "this is test value",
                Name = "test Product",
                Image = "http://www.iran.ir/image/layout_set_logo"
            });
            return retOut;
        }

 

        public ErrorExceptionResult<HyperShopOrderModel> SetDataOrderBankPaymentIsSuccess(HyperShopOrderBankPaymentIsSuccessModel model)
        {
            return new ErrorExceptionResult<HyperShopOrderModel>();
        }

        public ErrorExceptionResult<HyperShopOrderModel> SetDataOrderAdd(HyperShopOrderModel model)
        {
            return new ErrorExceptionResult<HyperShopOrderModel>();
        }

        public ErrorExceptionResult<HyperShopOrderModel> SetDataOrderUpdate(HyperShopOrderModel model)
        {
            return new ErrorExceptionResult<HyperShopOrderModel>();
        }

        public ErrorExceptionResult<CheckStatusActionModel> CheckStatusAction()
        {
            return new ErrorExceptionResult<CheckStatusActionModel>();
        }
    }
}
