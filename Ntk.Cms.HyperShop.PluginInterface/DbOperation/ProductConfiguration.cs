using System;
using System.Collections.Generic;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.DbOperation
{
    public class ProductConfiguration:ConfigurationBase
    {

        internal virtual string ColorsColumn { get; set; }
        /// <summary>
        /// نام ستون رنگ های کالا در ویو یا جدول
        /// [ProductColors]
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Colors(string value)
        {
            ColorsColumn = value;
            return this;
        }

        internal virtual string TagsColumn { get; set; }
        /// <summary>
        /// نام ستون در بانک اطلاعاتی
        /// تگ های مربوط به کالا
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Tags(string value)
        {
            TagsColumn = value;
            return this;
        }

        internal virtual string SaleColumn { get; set; }
        /// <summary>
        /// آیا مجاز به فروش آنلاین است
        /// نام ستون در بانک اطلاعاتی
        /// bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Sale(string value)
        {
            SaleColumn = value;
            return this;
        }

        internal virtual string BrandColumn { get; set; }
        /// <summary>
        /// برند کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Brand(string value)
        {
            BrandColumn = value;
            return this;
        }

        internal virtual string IsNewProColumn { get; set; }
        /// <summary>
        /// آیا کالا جدید است
        /// نام ستون در بانک اطلاعاتی
        /// bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration IsNewPro(string value)
        {
            IsNewProColumn = value;
            return this;
        }

        internal virtual string DescriptionColumn { get; set; }
        /// <summary>
        /// توضیحات کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Description(string value)
        {
            DescriptionColumn = value;
            return this;
        }

        internal virtual string ShortDetailsColumn { get; set; }
        /// <summary>
        /// توضیحات مختصر
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration ShortDetails(string value)
        {
            ShortDetailsColumn = value;
            return this;
        }

        internal virtual string DiscountColumn { get; set; }
        /// <summary>
        /// مبلغ تخفیف داده شده
        /// نام ستون در بانک اطلاعاتی
        /// int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Discount(string value)
        {
            DiscountColumn = value;
            return this;
        }

        internal virtual string CountColumn { get; set; }
        /// <summary>
        /// موجودی کالا
        /// نام ستون در بانک اطلاعاتی
        /// decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Count(string value)
        {
            CountColumn = value;
            return this;
        }

        //internal virtual string MeasurementColumn { get; set; }
        ///// <summary>
        ///// واحد کالا
        ///// نام ستون در بانک اطلاعاتی
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public ProductConfiguration Measurement(string value)
        //{
        //    MeasurementColumn = value;
        //    return this;
        //}

        internal virtual string SalePriceColumn { get; set; }
        /// <summary>
        /// مبلغ فروش فروشگاه
        /// این مبلغ در فاکتور لحاظ می گردد 
        /// نام ستون در بانک اطلاعاتی
        /// decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration SalePrice(string value)
        {
            SalePriceColumn = value;
            return this;
        }

        internal virtual string MemoColumn { get; set; }
        /// <summary>
        /// توضیحات جامع در مورد کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Memo(string value)
        {
            MemoColumn = value;
            return this;
        }

        internal virtual string ImageColumn { get; set; }
        /// <summary>
        /// آدرس یو آر ال کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Image(string value)
        {
            ImageColumn = value;
            return this;
        }

        internal virtual string StatusColumn { get; set; }
        /// <summary>
        /// وضعیت فعال یا غیر فعال بودن کالا
        /// نام ستون در بانک اطلاعاتی
        /// bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Status(string value)
        {
            StatusColumn = value;
            return this;
        }

        internal virtual string CategoryColumn { get; set; }
        /// <summary>
        /// عنوان گروه کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Category(string value)
        {
            CategoryColumn = value;
            return this;
        }

        internal virtual string CategoryCodeColumn { get; set; }
        /// <summary>
        /// کد کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration CategoryCode(string value)
        {
            CategoryCodeColumn = value;
            return this;
        }

        internal virtual string CurrencyColumn { get; set; }
        /// <summary>
        /// واحد پول
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Currency(string value)
        {
            CurrencyColumn = value;
            return this;
        }

        internal virtual string UnitColumn { get; set; }
        /// <summary>
        /// واحد کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Unit(string value)
        {
            UnitColumn = value;
            return this;
        }

        internal virtual string NameColumn { get; set; }
        /// <summary>
        /// عنوان کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Name(string value)
        {
            NameColumn = value;
            return this;
        }

        internal virtual string CodeColumn { get; set; }
        /// <summary>
        /// کد کالا
        /// نام ستون در بانک اطلاعاتی
        /// string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Code(string value)
        {
            CodeColumn = value;
            return this;
        }

        internal virtual string PriceColumn { get; set; }
        /// <summary>
        /// قیمت کالا
        /// نام ستون در بانک اطلاعاتی
        /// decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration Price(string value)
        {
            PriceColumn = value;
            return this;
        }

        internal virtual string RowIdColumn { get; set; }
        /// <summary>
        /// ردیف کالا
        /// نام ستون در بانک اطلاعاتی
        /// int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ProductConfiguration RowId(string value)
        {
            RowIdColumn = value;
            return this;
        }



    }

}
