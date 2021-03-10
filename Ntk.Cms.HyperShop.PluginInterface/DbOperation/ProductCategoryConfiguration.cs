using System;
using System.Collections.Generic;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.DbOperation
{
   public  class ProductCategoryConfiguration:ConfigurationBase
    {
        internal string ParentCodeColumn { get; set; }
        /// <summary>
        /// در صورت داشتن ساختار درختی پر شود
        /// کد سرگروه
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductCategoryConfiguration ParentCode(string value)
        {
            ParentCodeColumn = value;
            return this;
        }

        internal string CodeColumn { get; set; }

        /// <summary>
        /// کد گروه کالا
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductCategoryConfiguration Code(string value)
        {
            CodeColumn = value;
            return this;
        }

        internal string NameColumn { get; set; }
        /// <summary>
        /// نام گروه
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductCategoryConfiguration Name(string value)
        {
            NameColumn = value;
            return this;
        }

        internal string ImageColumn { get; set; }
        /// <summary>
        /// آدرس یوآر ال تصویر
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductCategoryConfiguration Image(string value)
        {
            ImageColumn = value;
            return this;
        }

        internal string MemoColumn { get; set; }
        /// <summary>
        /// توضیحات
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductCategoryConfiguration Memo(string value)
        {
            MemoColumn = value;
            return this;
        }

        internal string RowIdColumn { get; set; }
        /// <summary>
        /// ردیف 
        /// int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductCategoryConfiguration RowId(string value)
        {
            RowIdColumn = value;
            return this;
        }

    }
}
