using Ntk.Cms.HyperShop.PluginInterface.DbOperation;
using Ntk.Cms.HyperShop.PluginInterface.Helper;
using Ntk.Cms.Share.Interface.CmsDtoModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using Ntk.Cms.Share.Interface.FilterEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.Configs
{
    public class ProductCategory
    {
        internal static ProductCategoryConfiguration ColumnConfiguration;
        public void ConfigureColumns(Action<ProductCategoryConfiguration> action)
        {
            ColumnConfiguration = new ProductCategoryConfiguration();
            action.Invoke(ColumnConfiguration);
        }

        internal ErrorExceptionResult<HyperShopCategoryModel> GetOne(string connectionString, ProductCategoryDtoModel model)
        {
            ErrorExceptionResult<HyperShopCategoryModel> ret = new ErrorExceptionResult<HyperShopCategoryModel>();
            var str = ColumnConfiguration.GetSelectBody(ColumnConfiguration);
            str = str + " where " + ColumnConfiguration.CodeColumn + " = " + model.code;
            try
            {
                var dt = str.ExecuteSelect(connectionString);
                if (dt.Rows.Count == 0)
                {
                    ret.IsSuccess = false;
                    ret.ErrorMessage = "گروه کالا یافت نشد";
                }
                ret.Item = dt.Rows[0].ConvertDataRowTo<HyperShopCategoryModel>(ColumnConfiguration);
            }
            catch (Exception ex)
            {
                ret.IsSuccess = false;
                ret.ErrorMessage = ex.Message;
            }
            return ret;
        }

        internal ErrorExceptionResult<HyperShopCategoryModel> GetList(string connectionString, FilterModel model)
        {
            ErrorExceptionResult<HyperShopCategoryModel> ret = new ErrorExceptionResult<HyperShopCategoryModel>();
            var str = ColumnConfiguration.GetSelectBody(ColumnConfiguration);
            str = str+ model.CreateFilter<HyperShopCategoryModel>(ColumnConfiguration, ColumnConfiguration.NameColumn);
            try
            {
                var dt = str.ExecuteSelect(connectionString);
                List<HyperShopCategoryModel> lst = new List<HyperShopCategoryModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                    lst.Add(dt.Rows[i].ConvertDataRowTo<HyperShopCategoryModel>(ColumnConfiguration));
                ret.ListItems = lst;
            }
            catch (Exception ex)
            {
                ret.IsSuccess = false;
                ret.ErrorMessage = ex.Message;
            }
            return ret;
        }
    }
}
