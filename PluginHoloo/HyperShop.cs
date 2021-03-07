using System;
using Ntk.Cms.HyperShop.PluginInterface;
using Ntk.Cms.Share.Interface.CmsDtoModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using Ntk.Cms.Share.Interface.CmsModels.ModelHub;
using Ntk.Cms.Share.Interface.FilterEngine;

namespace PluginHoloo
{
    public class HyperShop : IPluginHyperShop
    {
        public string PluginName
        {
            get { return "Holoo"; }
        }

        public string CompanyName
        {
            get { return "نرم افزار حسابدای هلو"; }
        }

        public string LogoUrl
        {
            get { return "https://holoo.co.ir/wp-content/uploads/2021/01/Logo-01.png"; }
        }

        public int Version
        {
            get { return 1; }
        }
        public string Config { get; set; } = "Conection=\"localhost\"";
        public string Description
        {
            get { return "hyper shop"; }
        }
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
            return new ErrorExceptionResult<HyperShopContentModel>();
        }

        public ErrorExceptionResult<HyperShopContentModel> GetDataProductContentGetAll(FilterModel model)
        {
            return new ErrorExceptionResult<HyperShopContentModel>();
        }

        public ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetone(ProductCategoryDtoModel model)
        {
            return new ErrorExceptionResult<HyperShopCategoryModel>();
        }

        public ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetAll(FilterModel model)
        {
            return new ErrorExceptionResult<HyperShopCategoryModel>();
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
