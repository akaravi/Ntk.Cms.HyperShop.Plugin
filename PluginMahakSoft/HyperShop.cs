﻿using System;
using Ntk.Cms.HyperShop.PluginInterface;
using Ntk.Cms.HyperShop.PluginInterface.Helper;
using Ntk.Cms.Share.Interface.CmsDtoModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using Ntk.Cms.Share.Interface.CmsModels.ModelHub;
using Ntk.Cms.Share.Interface.FilterEngine;

namespace PluginMahakSoft
{
    public class HyperShop : BasePlugin, IPluginHyperShop
    {
        public string PluginName
        {
            get { return "Piramid"; }
        }

        public string CompanyName
        {
            get { return "Rayan Kara"; }
        }

        public string LogoUrl
        {
            get { return "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"; }
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
