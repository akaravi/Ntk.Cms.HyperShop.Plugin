using System;
using System.Collections.Generic;
using Developer.WebApi.Enums;

namespace Developer.WebApi.Models
{
    [Serializable]
    public class HyperShopOrderModel 
    {
        public HyperShopOrderModel()
        {
            Products = new List<HyperShopOrderContentModel>();
        }
        public virtual EnumHyperShopPaymentType PaymentType { get; set; }
        public virtual EnumHyperShopOrderType OrderType { get; set; }
        public long SystemTransactionId { get; set; }
        public long SystemPaymentIsSuccess { get; set; }
        public string SystemMicroServiceOrderId { get; set; }
        public bool SystemMicroServiceAccept { get; set; } = false;
        public string SystemMicroServiceId { get; set; }
        public bool SystemMicroServiceIsSuccess { get; set; }
        public string SystemMicroServiceErrorMessage { get; set; }





        public virtual string Name { get; set; }
        public virtual string Family { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Address { get; set; }
        /// <summary>
        /// مبلغ خالص فاکتور
        /// </summary>
        public virtual decimal AmountPure { get; set; }
        /// <summary>
        /// هزینه حمل و نقل
        /// </summary>
        public virtual decimal FeeTransport { get; set; }
        /// <summary>
        /// هزینه مالیات
        /// </summary>
        public virtual decimal FeeTax { get; set; }

        /// <summary>
        /// مبلغ کل پرداختی
        /// </summary>
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// jamshidi
        /// </summary>
        public virtual bool IsArchived { get; set; }
        public List<HyperShopOrderContentModel> Products { get; set; }
    }
}
