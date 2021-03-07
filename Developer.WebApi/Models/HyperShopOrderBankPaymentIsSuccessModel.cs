namespace Developer.WebApi.Models
{
    public class HyperShopOrderBankPaymentIsSuccessModel
    {
        public long LinkOrderId { get; set; }
        public long TransactionId { get; set; }
        public string SystemMicroServiceId { get; set; }
        public string SystemMicroServiceOrderId { get; set; }
        public decimal AmountPure { get; set; }
        public decimal Amount { get; set; }
    }
}
