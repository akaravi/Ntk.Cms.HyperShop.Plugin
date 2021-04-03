using Ntk.Cms.HyperShop.PluginInterface.Configs;
using Ntk.Cms.HyperShop.PluginInterface.DbOperation;
using Ntk.Cms.Share.Interface.CmsDtoModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using Ntk.Cms.Share.Interface.CmsModels.ModelHub;
using Ntk.Cms.Share.Interface.FilterEngine;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.Helper
{
    public class BasePlugin
    {
        public string ConnectionString { get; set; }
        public Product Product { get; set; } = new Product();
        public ProductCategory ProductCategory { get; set; } = new ProductCategory();
        public Order Order { get; private set; } = new Order();

        public ErrorExceptionResult<UniversalActionModel> UniversalAction(UniversalActionModel model)
        {
            return new ErrorExceptionResult<UniversalActionModel>();
        }

        public ErrorExceptionResult<HyperShopContentModel> GetDataProductContentGetone(ProductContentDtoModel model)
        {
            return Product.GetOne(ConnectionString, model);
        }

        public ErrorExceptionResult<HyperShopContentModel> GetDataProductContentGetAll(FilterModel model)
        {
            return Product.GetList(ConnectionString, model);
        }

        public ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetone(ProductCategoryDtoModel model)
        {
            return ProductCategory.GetOne(ConnectionString, model);
        }

        public ErrorExceptionResult<HyperShopCategoryModel> GetDataProductCategoryGetAll(FilterModel model)
        {
            return ProductCategory.GetList(ConnectionString, model);
        }


        public ErrorExceptionResult<HyperShopOrderModel> SetDataOrderBankPaymentIsSuccess(HyperShopOrderBankPaymentIsSuccessModel model)
        {
            var rt = Order.RaiseOnBankPayment(model);
            return rt;
        }

        public ErrorExceptionResult<HyperShopOrderModel> SetDataOrderAdd(HyperShopOrderModel model)
        {
            var rt = Order.RaiseOnAddOrder(model);
            return rt;
        }

        public ErrorExceptionResult<HyperShopOrderModel> SetDataOrderUpdate(HyperShopOrderModel model)
        { 
            var rt = Order.RaiseOnEditOrder(model);
            return rt;
        }

        public virtual ErrorExceptionResult<CheckStatusActionModel> CheckStatusAction()
        {
            if (string.IsNullOrEmpty(ConnectionString))
                return new ErrorExceptionResult<CheckStatusActionModel>() { IsSuccess = false, ErrorMessage = "کانکشن به بانک مقداردهی نشده است" };
            try
            {
                SqlConnection cnn = new SqlConnection(ConnectionString);
                cnn.Open();
                cnn.Close();
                return new ErrorExceptionResult<CheckStatusActionModel>() { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new ErrorExceptionResult<CheckStatusActionModel>() { IsSuccess = false,ErrorMessage=ex.Message };
            }
        }

        public string ExecuteTest(string model)
        {
            return "Test";
        }
    }
}
