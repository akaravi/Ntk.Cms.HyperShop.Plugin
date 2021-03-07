//using ExcelDataReader;
//using Developer.WebApi.Config;
//using Developer.WebApi.DBContext;
//using Developer.WebApi.Helper;
//using Ntk.Cms.Share.Interface.Model;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//

//namespace Developer.WebApi.Poco
//{
//    public class DbFileManager
//    {

//        private string fileXlsPath = "";
//        private string fileShopProductContentJsonPath = "";
//        private string fileShopProductCategoryJsonPath = "";
//        private RedisCacheContext redisCacheContext;

//        public List<HyperShopCategoryModel> ShopProductCategoryList { get; set; }
//        public List<HyperShopContentModel> ShopProductContentList { get; set; }
//        public DbFileManager()
//        {
//            fileXlsPath = Path.GetFullPath(Path.Combine(CmsConfigurationHelper.config.AppSettings.FilePath.PathFileDb, "data.xls"));
//            fileShopProductContentJsonPath = Path.GetFullPath(Path.Combine(CmsConfigurationHelper.config.AppSettings.FilePath.PathFileDb, "dataProductContent.json"));
//            fileShopProductCategoryJsonPath = Path.GetFullPath(Path.Combine(CmsConfigurationHelper.config.AppSettings.FilePath.PathFileDb, "dataProductCategory.json"));
//            redisCacheContext = new RedisCacheContext();
//            if (FileHelper.FileExists(fileXlsPath))
//            {
//                #region Impote Data

//                IEnumerable<Dictionary<string, object>> excelContent;
//                using (FileStream fileStream = new FileStream(fileXlsPath, FileMode.Open, FileAccess.Read))
//                {
//                    excelContent = ParseExcel(fileStream);
//                }
//                var ImportExcel = new List<HyperShopImportExcelModel>();
//                foreach (var item in excelContent)
//                {
//                    var newItem = new HyperShopImportExcelModel();
//                    if (item.Keys.Any(x => x == CmsConfigurationHelper.config.AppSettings.ImportExcel.code))
//                        newItem.code = item[CmsConfigurationHelper.config.AppSettings.ImportExcel.code] + "";
//                    if (item.Keys.Any(x => x == CmsConfigurationHelper.config.AppSettings.ImportExcel.cat))
//                        newItem.cat = item[CmsConfigurationHelper.config.AppSettings.ImportExcel.cat] + "";
//                    if (item.Keys.Any(x => x == CmsConfigurationHelper.config.AppSettings.ImportExcel.name))
//                        newItem.name = item[CmsConfigurationHelper.config.AppSettings.ImportExcel.name] + "";
//                    if (item.Keys.Any(x => x == CmsConfigurationHelper.config.AppSettings.ImportExcel.image))
//                        newItem.image = item[CmsConfigurationHelper.config.AppSettings.ImportExcel.image] + "";
//                    if (item.Keys.Any(x => x == CmsConfigurationHelper.config.AppSettings.ImportExcel.memo))
//                        newItem.memo = item[CmsConfigurationHelper.config.AppSettings.ImportExcel.memo] + "";

//                    int count = 0;
//                    if (item.Keys.Any(x => x == CmsConfigurationHelper.config.AppSettings.ImportExcel.count))
//                        int.TryParse(item[CmsConfigurationHelper.config.AppSettings.ImportExcel.count] + "", out count);
//                    newItem.count = count;
//                    decimal price = 0;
//                    if (item.Keys.Any(x => x == CmsConfigurationHelper.config.AppSettings.ImportExcel.price))
//                        decimal.TryParse(item[CmsConfigurationHelper.config.AppSettings.ImportExcel.price] + "", out price);
//                    newItem.price = price;

//                    if (string.IsNullOrEmpty(newItem.image))
//                        newItem.image = newItem.code + "." + CmsConfigurationHelper.config.AppSettings.FileConfig.FileImageDefaultType;
//                    //newItem. count = item.Values[CmsConfigurationHelper.config.AppSettings.ImportExcel.count]
//                    ImportExcel.Add(newItem);


//                }
//                //var ImportExcel = excelContent.ClientJsonHelperSerializeObject().ClientJsonHelperDeserializeObject<List<ImportExcelModel>>();





//                ReadDataBinder(ImportExcel);
//                if (ShopProductContentList == null || ShopProductContentList.Count == 0)
//                {
//                    File.Move(fileXlsPath, fileXlsPath.Replace(".xls", "_used_Error_" + PersianDateMarker() + ".xls"));
//                }
//                else
//                {
//                    File.Move(fileXlsPath, fileXlsPath.Replace(".xls", "_used_OK_" + PersianDateMarker() + ".xls"));
//                }
//                #endregion Import Data
//            }
//            else
//                ReadData();
//            if (ShopProductContentList == null || ShopProductContentList.Count == 0)
//                ReadDataFromFile();
//        }

//        private void ReadDataFromFile()
//        {
//            if (FileHelper.FileExists(fileShopProductContentJsonPath) && FileHelper.FileExists(fileShopProductCategoryJsonPath))
//            {
//                var modelStr = System.IO.File.ReadAllText(fileShopProductContentJsonPath);
//                ShopProductContentList = modelStr.ClientJsonHelperDeserializeObject<List<HyperShopContentModel>>();
//                modelStr = System.IO.File.ReadAllText(fileShopProductCategoryJsonPath);
//                ShopProductCategoryList = modelStr.ClientJsonHelperDeserializeObject<List<HyperShopCategoryModel>>();
//                if (redisCacheContext.RedisCacheRun)
//                {
//                    var retRedis = redisCacheContext.Set("ShopProductContentList", ShopProductContentList.ClientJsonHelperSerializeObject());
//                    if (!retRedis)
//                        CmsConfigurationHelper.config.ApplicationMemory.ShopProductContentList = ShopProductContentList;

//                    retRedis = redisCacheContext.Set("ShopProductCategoryList", ShopProductCategoryList.ClientJsonHelperSerializeObject());
//                    if (!retRedis)
//                        CmsConfigurationHelper.config.ApplicationMemory.ShopProductCategoryList = ShopProductCategoryList;
//                }
//                else
//                {
//                    CmsConfigurationHelper.config.ApplicationMemory.ShopProductContentList = ShopProductContentList;
//                    CmsConfigurationHelper.config.ApplicationMemory.ShopProductCategoryList = ShopProductCategoryList;
//                }
//            }
//        }

//        private void ReadDataBinder(List<HyperShopImportExcelModel> ImportExcel)
//        {
//            ShopProductContentList = new List<HyperShopContentModel>();
//            ShopProductCategoryList = new List<HyperShopCategoryModel>();
//            foreach (var item in ImportExcel)
//            {
//                if (item.status)
//                    ShopProductContentList.Add(new HyperShopContentModel
//                    {
//                        code = item.code,
//                        cat = item.cat,
//                        image = CmsConfigurationHelper.config.AppSettings.FileConfig.FileImageurl + item.image,
//                        name = item.name,
//                        status = item.status,
//                        count = item.count,
//                        price = item.price,
//                        memo = item.memo
//                    });
//                ShopProductCategoryList.Add(new HyperShopCategoryModel
//                {
//                    name = item.cat,
//                    memo = ""
//                });
//            }
//            ShopProductCategoryList = ShopProductCategoryList.GroupBy(x => x.name).Select(y => y.First()).ToList();
//            if (ShopProductContentList != null && ShopProductContentList.Count > 0 && ShopProductCategoryList != null && ShopProductCategoryList.Count > 0)
//            {

//                if (redisCacheContext.RedisCacheRun)
//                {
//                    var retRedis = redisCacheContext.Set("ShopProductContentList", ShopProductContentList.ClientJsonHelperSerializeObject());
//                    if (!retRedis)
//                        CmsConfigurationHelper.config.ApplicationMemory.ShopProductContentList = ShopProductContentList;

//                    retRedis = redisCacheContext.Set("ShopProductCategoryList", ShopProductCategoryList.ClientJsonHelperSerializeObject());
//                    if (!retRedis)
//                        CmsConfigurationHelper.config.ApplicationMemory.ShopProductCategoryList = ShopProductCategoryList;
//                }
//                else
//                {
//                    CmsConfigurationHelper.config.ApplicationMemory.ShopProductContentList = ShopProductContentList;
//                    CmsConfigurationHelper.config.ApplicationMemory.ShopProductCategoryList = ShopProductCategoryList;
//                }


//                using (var fs = new FileStream(fileShopProductContentJsonPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
//                {
//                    while (!fs.CanWrite)
//                    {

//                    }
//                    byte[] info = new UTF8Encoding(true).GetBytes(ShopProductContentList.ClientJsonHelperSerializeObject());
//                    fs.Write(info, 0, info.Length);
//                    fs.Close();
//                }

//                using (var fs = new FileStream(fileShopProductCategoryJsonPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
//                {
//                    while (!fs.CanWrite)
//                    {

//                    }
//                    byte[] info = new UTF8Encoding(true).GetBytes(ShopProductCategoryList.ClientJsonHelperSerializeObject());
//                    fs.Write(info, 0, info.Length);
//                    fs.Close();
//                }
//            }

//        }

//        private void ReadData()
//        {
//            ShopProductContentList = new List<HyperShopContentModel>();
//            if (redisCacheContext.RedisCacheRun)
//            {
//                var retRedis = redisCacheContext.Get("ShopProductContentList");
//                if (!string.IsNullOrEmpty(retRedis))
//                    ShopProductContentList = retRedis.ClientJsonHelperDeserializeObject<List<HyperShopContentModel>>();

//            }
//            if (ShopProductContentList == null || ShopProductContentList.Count == 0)
//                ShopProductContentList = CmsConfigurationHelper.config.ApplicationMemory.ShopProductContentList;


//            ShopProductCategoryList = new List<HyperShopCategoryModel>();
//            if (redisCacheContext.RedisCacheRun)
//            {
//                var retRedis = redisCacheContext.Get("ShopProductCategoryList");
//                if (!string.IsNullOrEmpty(retRedis))
//                    ShopProductCategoryList = retRedis.ClientJsonHelperDeserializeObject<List<HyperShopCategoryModel>>();

//            }
//            if (ShopProductCategoryList == null || ShopProductCategoryList.Count == 0)
//                ShopProductCategoryList = CmsConfigurationHelper.config.ApplicationMemory.ShopProductCategoryList;
//        }
//        public ErrorExceptionResult<HyperShopContentModel> ShopProductContentSave(List<HyperShopContentModel> model)
//        {
//            var retOut = new ErrorExceptionResult<HyperShopContentModel>();
//            if (redisCacheContext.RedisCacheRun)
//            {
//                var retRedis = redisCacheContext.Set("ShopProductContentList", model.ClientJsonHelperSerializeObject());
//                if (!retRedis)
//                    CmsConfigurationHelper.config.ApplicationMemory.ShopProductContentList = model;
//            }
//            else
//            {
//                CmsConfigurationHelper.config.ApplicationMemory.ShopProductContentList = model;
//            }
//            using (var fs = new FileStream(fileShopProductContentJsonPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
//            {
//                while (!fs.CanWrite)
//                {

//                }
//                byte[] info = new UTF8Encoding(true).GetBytes(ShopProductContentList.ClientJsonHelperSerializeObject());
//                fs.Write(info, 0, info.Length);
//                fs.Close();
//            }
//            return retOut;
//        }

//        private static IEnumerable<Dictionary<string, object>> ParseExcel(Stream document)
//        {
//            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

//            using (var reader = ExcelReaderFactory.CreateReader(document))
//            {
//                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
//                {
//                    UseColumnDataType = true,
//                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
//                    {
//                        UseHeaderRow = true,
//                    }
//                });
//                return MapDatasetData(result.Tables.Cast<DataTable>().First());
//            }
//        }
//        private static IEnumerable<Dictionary<string, object>> MapDatasetData(DataTable dt)
//        {
//            foreach (DataRow dr in dt.Rows)
//            {
//                var row = new Dictionary<string, object>();
//                foreach (DataColumn col in dt.Columns)
//                {
//                    row.Add(col.ColumnName, dr[col]);
//                }
//                yield return row;
//            }
//        }
//        public string PersianDateMarker()
//        {
//            DateTime date = DateTime.Now;
//            PersianCalendar jc = new PersianCalendar();
//            return string.Format("{0:0000}_{1:00}_{2:00}_{3:00}_{4:00}_{5:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date), date.Hour, date.Minute, date.Second);
//        }
//    }
//}
