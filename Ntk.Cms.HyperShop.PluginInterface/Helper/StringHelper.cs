using Newtonsoft.Json;
using Ntk.Cms.Share.Interface.FilterEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.Helper
{
    public static class StringHelper
    {
        public static string mKey = "tX@~Fgl!*(_7041B";
        private const int keysize = 128;
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tj84ge£a340d@9ur");

        public static string EncryptString(this string plainText)
        {
            var passPhrase = mKey;
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = memoryStream.ToArray();


                                //return Convert.ToBase64String(cipherTextBytes);
                                return Base64UrlEncode(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string DecryptString(this string cipherText)
        {
            try
            {
                var passPhrase = mKey;
                var cipherTextBytes = Base64UrlDecode(cipherText);
                //var cipherTextBytes = Convert.FromBase64String(cipherText);
                using (var password = new PasswordDeriveBytes(passPhrase, null))
                {
                    var keyBytes = password.GetBytes(keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (var memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (
                                    var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    var plainTextBytes = new byte[cipherTextBytes.Length];
                                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }

            catch
            {
                return "";
            }
        }
        private static string Base64UrlEncode(byte[] bytes)
        {
            var retOut = Convert.ToBase64String(bytes);
            retOut = retOut.TrimEnd('=').Replace('+', '-').Replace('/', '_');
            return retOut;//.Replace("=", "").Replace('+', '-').Replace('/', '_');

        }
        private static string Base64UrlEncode(string str)
        {
            if (str == null || str == "")
            {
                return "";
            }

            byte[] bytesToEncode = System.Text.UTF8Encoding.UTF8.GetBytes(str);
            //String returnVal = System.Convert.ToBase64String(bytesToEncode);

            return Base64UrlEncode(bytesToEncode);
        }
        private static byte[] Base64UrlDecode(string str)
        {
            str = str.Replace('-', '+').Replace('_', '/');
            string padding = new String('=', 3 - (str.Length + 3) % 4);
            str += padding;
            return Convert.FromBase64String(str);
        }

        public static String ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        public static string CreateFilter<T>(this FilterModel model, object columns,string defaultSortCol)
        {
            string ret = "";
            if (model.Filters != null && model.Filters.Count > 0)
            {
                var ctMain = "";
                foreach (var item in model.Filters)
                {
                    var condition = "((?parent?) OR (?child?))";
                    if (!string.IsNullOrEmpty(item.PropertyName))
                    {
                        var co = getCondition<T>(item, columns);
                        if (!string.IsNullOrEmpty(co))
                            condition = condition.Replace("?parent?", co);
                        else
                            condition = condition.Replace("(?parent?) OR", "");
                    }
                    else
                        condition = condition.Replace("(?parent?) OR", "");

                    if (item.Filters != null && item.Filters.Count > 0)
                    {
                        var inner = "(?child?)";
                        var xt = "";
                        foreach (var x in item.Filters)
                        {
                            var co = getCondition<T>(x, columns);
                            if (co != null)
                            {
                                if (!string.IsNullOrEmpty(xt))
                                {
                                    switch (x.ClauseType)
                                    {
                                        case ClauseType.Or:
                                            xt += " OR ";
                                            break;
                                        case ClauseType.And:
                                            xt += " AND ";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                xt = xt + inner.Replace("(?child?)", co);
                            }
                        }
                        condition = condition.Replace("?child?", xt);
                    }
                    else
                        condition = condition.Replace("(?child?)", "");
                    condition = condition.Replace("(?parent?) OR", "").Replace("OR (?child?)", "").Replace("(?parent?)", "").Replace("?child?", "");

                    if (condition.Replace("(", "").Replace(")", "").Replace("OR", "").Trim() != "")
                    {
                        if (!string.IsNullOrEmpty(ctMain))
                        {
                            switch (item.ClauseType)
                            {
                                case ClauseType.Or:
                                    ctMain += " OR ";
                                    break;
                                case ClauseType.And:
                                    ctMain += " AND ";
                                    break;
                                default:
                                    break;
                            }
                        }
                        ctMain += condition;
                    }
                }
                if (!string.IsNullOrEmpty(ctMain))
                {
                    ret += Environment.NewLine+"WHERE "+ctMain;
                }
            }
            ret += Environment.NewLine + "ORDER BY ";
            if (string.IsNullOrEmpty(model.SortColumn))
            {
                if (model.SortType == SortType.Random)
                    ret += " newid()";
                else
                    ret += defaultSortCol;
            }
            else
            {
                if (model.SortType == SortType.Random)
                    ret += " newid()";
                else
                {
                    var prop = model.SortColumn.GetColumnName<T>(columns);
                    if (string.IsNullOrEmpty(prop))
                        ret += defaultSortCol;
                    else
                        ret += prop;
                    switch (model.SortType)
                    {
                        case SortType.Descending:
                            ret += " DESC";
                            break;
                        case SortType.Ascending:
                            ret += " ASC";
                            break;
                        default:
                            break;
                    }
                }
            }
            if (model.RowPerPage > 0)
            {
                ret += Environment.NewLine + "OFFSET " + ((model.RowPerPage * model.CurrentPageNumber)).ToString() + " ROWS FETCH NEXT " + (model.RowPerPage + 1).ToString() + " ROWS ONLY";
            }
            return ret;
        }

        private static string getCondition<T>(FilterDataModel item, object columns)
        {
            if (string.IsNullOrEmpty(item.PropertyName))
                return "";
            var col = item.PropertyName.GetColumnName<T>(columns);
            if (string.IsNullOrEmpty(col))
                return "";
            var val = item.PropertyName.GetColumnValue<T>(item.value);
            if (string.IsNullOrEmpty(val) || val == "''")
                return "";
            switch (item.SearchType)
            {
                case FilterDataModelSearchTypes.Equal:
                    return col + "=" + val;
                case FilterDataModelSearchTypes.NotEqual:
                    return col + "<>" + val;
                case FilterDataModelSearchTypes.LessThan:
                    return col + "<" + val;
                case FilterDataModelSearchTypes.GreaterThan:
                    return col + ">" + val;
                case FilterDataModelSearchTypes.Contains:
                    return col + " LIKE ('%'+" + val + "'%')";
                case FilterDataModelSearchTypes.NotContains:
                    return col + " LIKE ('%'+" + val + "'%')";
                case FilterDataModelSearchTypes.BeginsWith:
                    return col + " LIKE (" + val + "'%')";
                case FilterDataModelSearchTypes.EndsWith:
                    return col + " LIKE ('%'+" + val + ")";
                case FilterDataModelSearchTypes.LessThanOrEqualTo:
                    return col + "<=" + val;
                case FilterDataModelSearchTypes.GreaterThanOrEqualTo:
                    return col + ">=" + val;
                default:
                    return "";
            }
        }


    }
}