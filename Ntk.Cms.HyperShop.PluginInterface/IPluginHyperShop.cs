using Ntk.Cms.Share.Interface.CmsDtoModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using Ntk.Cms.Share.Interface.CmsModels.ModelHub;
using Ntk.Cms.Share.Interface.FilterEngine;
using Ntk.Cms.Share.Plugin.Interfaces;

namespace Ntk.Cms.HyperShop.PluginInterface
{
    public interface IPluginHyperShop : IPlugins
    {
        ErrorExceptionResult<CheckStatusActionModel> CheckStatusAction();
        ErrorExceptionResult<UniversalActionModel> UniversalAction(UniversalActionModel model);
        ErrorExceptionResult<HyperShopContentModel> GetDataProductContentGetone(ProductContentDtoModel model);
        ErrorExceptionResult<HyperShopContentModel> GetDataProductContentGetAll(FilterModel model);
        ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetone(ProductCategoryDtoModel model);
        ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetAll(FilterModel model);
        ErrorExceptionResult<HyperShopOrderModel> SetDataOrderAdd(HyperShopOrderModel model);
        ErrorExceptionResult<HyperShopOrderModel> SetDataOrderUpdate(HyperShopOrderModel model);
        ErrorExceptionResult<HyperShopOrderModel> SetDataOrderBankPaymentIsSuccess(HyperShopOrderBankPaymentIsSuccessModel model);
    }
}
