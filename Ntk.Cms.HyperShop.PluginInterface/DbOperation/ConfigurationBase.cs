using Ntk.Cms.Share.Interface.FilterEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.DbOperation
{
    public class ConfigurationBase
    {
        internal string SelectTable { get; set; }
        /// <summary>
        /// نام ویو یا جدول بانک در این قسمت مشخص می شود
        /// [View_Product] or [Tbl_Product]
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        public void SelectFrom(string select)
        {
            SelectTable = select;
        }

        internal virtual String GetOne(int id)
        {
            return "";
        }
        
        internal virtual String GetList(FilterModel model)
        {
            return "";
        }

        public string GetSelectBody<T>(T item)where T:ConfigurationBase
        {
            string ret = "Select ";
            string cols = "";
            var props = item.GetType().GetProperties().Where(x => x.Name.EndsWith("Column")).ToList();
            foreach (var p in props)
            {
                var val = p.GetValue(item);
                if (val == null || string.IsNullOrEmpty(val.ToString()))
                    continue;
                if (!string.IsNullOrEmpty(cols))
                    cols += ", ";
                cols += val.ToString();
            }
            return ret + SelectTable + " " + cols;

        }
    }
}
