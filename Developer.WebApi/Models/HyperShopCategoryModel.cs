using System;

namespace Developer.WebApi.Models
{
    [Serializable]
    public class HyperShopCategoryModel
    {
        
        public string ParentCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Memo { get; set; }
        public virtual int rowId { get; set; }
    }
}
