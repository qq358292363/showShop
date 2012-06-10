using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Order;
namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        public static ShowShop.IDAL.Order.IShoppingCard CreateShoppingCard()
        {
            return (IShoppingCard)CreateObject("Order.ShoppingCard");
        }

        public static ShowShop.IDAL.Order.IOrders CreateOrders()
        {
            return (IOrders)CreateObject("Order.Orders");
        }

        public static ShowShop.IDAL.Order.ICodeOrderStep CreateCodeOrderStep()
        {
            return (ICodeOrderStep)CreateObject("Order.CodeOrderStep");
        }
        public static ShowShop.IDAL.Order.IOrderProduct CreateOrderProduct()
        {
            return (IOrderProduct)CreateObject("Order.OrderProduct");
        }
        public static ShowShop.IDAL.Order.IRemittanceInfo CreateRemittanceInfo()
        {
            return (IRemittanceInfo)CreateObject("Order.RemittanceInfo");
        }
        public static ShowShop.IDAL.Order.IConsignMent CreateConsignMent()
        {
            return (IConsignMent)CreateObject("Order.ConsignMent");
        }
        public static ShowShop.IDAL.Order.IInvoiceItem CreateInvoiceItem()
        {
            return (IInvoiceItem)CreateObject("Order.InvoiceItem");
        }
        public static ShowShop.IDAL.Order.IOrderLeave CreateOrderLeave()
        {
            return (IOrderLeave)CreateObject("Order.OrderLeave");
        }
        public static ShowShop.IDAL.Order.IOrderTransfer CreateOrderTransfer()
        {
            return (IOrderTransfer)CreateObject("Order.OrderTransfer");
        }
        public static ShowShop.IDAL.Order.IPaymentMoney CreatePaymentMoney()
        {
            return (IPaymentMoney)CreateObject("Order.PaymentMoney");
        }
        public static ShowShop.IDAL.Order.IPrepayMoney CreatePrepayMoney()
        {
            return (IPrepayMoney)CreateObject("Order.PrepayMoney");
        }
        public static ShowShop.IDAL.Order.IRefundMent CreateRefundMent()
        {
            return (IRefundMent)CreateObject("Order.RefundMent");
        }
 

        public static IYXShopProfileProvider CreateYXShopProfileProvider()
        {
            return (IYXShopProfileProvider)CreateObject("Order.YXShopProfileProvider"); 
        }
    }
}
