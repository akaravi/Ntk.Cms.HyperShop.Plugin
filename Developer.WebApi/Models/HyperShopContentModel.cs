using System;

namespace Developer.WebApi.Models
{
    [Serializable]
    public class HyperShopContentModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Currency { get; set; }
        public string CategoryCode { get; set; }
        public string Category { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public string Memo { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Count { get; set; }
        public int Discount { get; set; }
        public string ShortDetails { get; set; }
        public string Description { get; set; }
        public bool IsNewPro { get; set; }
        public string Brand { get; set; }
        public bool Sale { get; set; }
        public string Tags { get; set; }
        public string Colors { get; set; }

        public string measurement { get; set; }
        public int rowId { get; set; }
    }
}
