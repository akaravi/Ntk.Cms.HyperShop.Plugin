using Ntk.Cms.HyperShop.PluginInterface.DbOperation;
using Ntk.Cms.HyperShop.PluginInterface.Helper;
using Ntk.Cms.Share.Interface.CmsDtoModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using Ntk.Cms.Share.Interface.FilterEngine;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.Configs
{
    public class Product
    {
        internal static ProductConfiguration ColumnConfiguration;
        public void ConfigureColumns(Action<ProductConfiguration> action)
        {
            ColumnConfiguration = new ProductConfiguration();
            action.Invoke(ColumnConfiguration);
        }

        internal ErrorExceptionResult<HyperShopContentModel> GetOne(string connectionString, ProductContentDtoModel model)
        {
            ErrorExceptionResult<HyperShopContentModel> ret = new ErrorExceptionResult<HyperShopContentModel>();
            var str = ColumnConfiguration.GetSelectBody(ColumnConfiguration);
            str = str + " where " + ColumnConfiguration.CodeColumn + " = " + model.code;
            try
            {
                var dt = str.ExecuteSelect(connectionString);
                if (dt.Rows.Count == 0)
                {
                    ret.IsSuccess = false;
                    ret.ErrorMessage = "کالا یافت نشد";
                }
                ret.Item = dt.Rows[0].ConvertDataRowTo<HyperShopContentModel>(ColumnConfiguration);
            }
            catch (Exception ex)
            {
                ret.IsSuccess = false;
                ret.ErrorMessage = ex.Message;
            }
            return ret;

        }

        internal ErrorExceptionResult<HyperShopContentModel> GetList(string connectionString, FilterModel model)
        {
            ErrorExceptionResult<HyperShopContentModel> ret = new ErrorExceptionResult<HyperShopContentModel>();
            var str = ColumnConfiguration.GetSelectBody(ColumnConfiguration);
            str = str + model.CreateFilter<HyperShopContentModel>(ColumnConfiguration,ColumnConfiguration.NameColumn);// + model.code;
            try
            {
                var dt = str.ExecuteSelect(connectionString);
                List<HyperShopContentModel> lst = new List<HyperShopContentModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                    lst.Add(dt.Rows[i].ConvertDataRowTo<HyperShopContentModel>(ColumnConfiguration));
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
