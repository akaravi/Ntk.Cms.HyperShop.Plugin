using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.Helper
{
    public static class DatabaseHelper
    {
        public static DataTable ExecuteSelect(this string command, string connectionString)
        {
            DataTable ret = new DataTable();
            using (var cnn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(command, cnn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection.Open();
                        da.Fill(ret);
                        cmd.Connection.Close();
                    }
                }

            }
            return ret;
        }

        public static T ConvertDataRowTo<T>(this DataRow row, object columns) where T : class
        {
            var ret = Activator.CreateInstance<T>();
            var props = columns.GetType().GetProperties().Where(x => x.Name.EndsWith("Column")).ToList();
            var retProps = ret.GetType().GetProperties();
            foreach (var x in props)
            {
                try
                {
                    var colVal = x.GetValue(columns);
                    if (colVal == null || string.IsNullOrEmpty(colVal.ToString()))
                        continue;
                    var DbcolName = colVal.ToString().Replace("[", "").Replace("]", "");
                    var val = row[DbcolName];
                    if (val == null || val == DBNull.Value)
                        continue;
                    var pr = retProps.FirstOrDefault(p => p.Name.ToLower() == x.Name.ToLower().Replace("Column", ""));
                    if (pr == null)
                        continue;
                    pr.SetValue(ret,Convert.ChangeType(val, pr.PropertyType));
                }
                catch 
                {
                }
            }
            return ret;
        }

        public static string GetColumnName<T>(this string propertyName, object columns)
        {
            var props = columns.GetType().GetProperties().Where(x => x.Name.EndsWith("Column")).ToList();
            var retprp = typeof(T).GetProperty(propertyName);
            if (retprp == null)
                return "";
            var prp = props.FirstOrDefault(x => x.Name == retprp.Name + "Column");
            if (prp == null)
                return "";
            var val = prp.GetValue(columns);
            if (val == null || String.IsNullOrEmpty(val.ToString()))
                return "";
            return val.ToString();

        }

        public static string GetColumnValue<T>(this string propertyName,string value)
        {
            var rt = GetColumnValue<T>(propertyName, new List<string>() { value });
            if (rt == null || rt.Count == 0)
                return "";
            return rt[0];
        }
        public static List<string> GetColumnValue<T>(this string propertyName, List<string> value)
        {
            var retprp = typeof(T).GetProperty(propertyName);
            if (retprp == null)
                return null;
            List<string> ret = new List<string>();
            foreach (var item in value)
            {
                if (retprp.PropertyType == typeof(DateTime) || retprp.PropertyType == typeof(DateTime?))
                    ret.Add("'" + getSafeItem(item)+"'");
                else if (retprp.PropertyType == typeof(string))
                    ret.Add("'" + getSafeItem(item) + "'");
                else
                    ret.Add(getSafeItem(item));
            }
            return ret;
        }

        private static string getSafeItem(string item)
        {
            return item.Replace("'", "").Replace(";", "");
        }
    }
}
