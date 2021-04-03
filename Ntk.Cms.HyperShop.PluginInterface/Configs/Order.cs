using Ntk.Cms.Share.Interface.CmsModels.HyperShop;
using Ntk.Cms.Share.Interface.CmsModels.ModelBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ntk.Cms.HyperShop.PluginInterface.Configs
{
    public class Order
    {
        public event EventHandler<OrderEventArgs> OnAdd;
        public event EventHandler<OrderEventArgs> OnUpdate;
        public event EventHandler<OrderBankPaymentEventArgs> OnBankPaymentSuccess;

        internal ErrorExceptionResult<HyperShopOrderModel> RaiseOnBankPayment(HyperShopOrderBankPaymentIsSuccessModel model)
        {
            if (OnBankPaymentSuccess == null)
                return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "ایونت مربوطه مقدار دهی نشده است" + Environment.NewLine + "OnBankPaymentSuccess" };
            var ret = new OrderBankPaymentEventArgs(model) { };
            try
            {
                OnBankPaymentSuccess?.Invoke(this, ret);
                if (ret.IsSuccess)
                {
                    if (ret.Order != null)
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = true, Item = ret.Order };
                    else
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "مقدار بازگشتی سفارش مشخص نشده است" };
                }
                else
                {
                    if (string.IsNullOrEmpty(ret.ErrorMessage))
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "مقدار بازگشتی را در حالت خطا قرار داده اید ولی متن خطا مشخص نشده است" + Environment.NewLine + "IsSuccess=false;ErrorMessage=''" };
                    else
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = ret.ErrorMessage };
                }
            }
            catch (Exception ex)
            {
                return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = ex.ToString() };
            }
        }

        internal ErrorExceptionResult<HyperShopOrderModel> RaiseOnAddOrder(HyperShopOrderModel model)
        {
            if (OnAdd == null)
                return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "ایونت مربوطه مقدار دهی نشده است" + Environment.NewLine + "OnAdd" };
            var ret = new OrderEventArgs(model);
            try
            {
                OnAdd?.Invoke(this, ret);
                if (ret.IsSuccess)
                {
                    if (ret.Order != null)
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = true, Item = ret.Order };
                    else
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "مقدار بازگشتی سفارش مشخص نشده است" };
                }
                else
                {
                    if (string.IsNullOrEmpty(ret.ErrorMessage))
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "مقدار بازگشتی را در حالت خطا قرار داده اید ولی متن خطا مشخص نشده است" + Environment.NewLine + "IsSuccess=false;ErrorMessage=''" };
                    else
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = ret.ErrorMessage };
                }
            }
            catch (Exception ex)
            {
                return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = ex.ToString() };
            }
        }

        internal ErrorExceptionResult<HyperShopOrderModel> RaiseOnEditOrder(HyperShopOrderModel model)
        {
            if (OnUpdate == null)
                return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "ایونت مربوطه مقدار دهی نشده است" + Environment.NewLine + "OnUpdate" };
            var ret = new OrderEventArgs(model);
            try
            {
                OnUpdate?.Invoke(this, ret);
                if (ret.IsSuccess)
                {
                    if (ret.Order != null)
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = true, Item = ret.Order };
                    else
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "مقدار بازگشتی سفارش مشخص نشده است" };
                }
                else
                {
                    if (string.IsNullOrEmpty(ret.ErrorMessage))
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = "مقدار بازگشتی را در حالت خطا قرار داده اید ولی متن خطا مشخص نشده است" + Environment.NewLine + "IsSuccess=false;ErrorMessage=''" };
                    else
                        return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = ret.ErrorMessage };
                }
            }
            catch (Exception ex)
            {
                return new ErrorExceptionResult<HyperShopOrderModel>() { IsSuccess = false, ErrorMessage = ex.ToString() };
            }
        }
    }
    public class OrderEventArgs : EventArgs
    {
        public OrderEventArgs(HyperShopOrderModel model)
        {
            Order = model;
        }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public HyperShopOrderModel Order { get; private set; }
    }

    public class OrderBankPaymentEventArgs : EventArgs
    {
        public OrderBankPaymentEventArgs(HyperShopOrderBankPaymentIsSuccessModel model)
        {
            BankPayment = model;
        }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public HyperShopOrderBankPaymentIsSuccessModel BankPayment { get; private set; }
        public HyperShopOrderModel Order { get; set; }

    }
}
