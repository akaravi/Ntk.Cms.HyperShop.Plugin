using System;

namespace Developer.WebApi.Models
{
    [Serializable]
    public class HyperShopOrderContentModel
    {
        public long LinkOrderId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Memo { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public bool SystemAccept { get; set; }
    }
}
