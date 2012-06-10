using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Common
{
    public class OrdersStatusEnum
    {
        public enum OrderStatu
        {
            等待处理, 暂停处理, 已经确认, 末确认, 未结清, 已结清, 取消确认, 已经作废
        };
        public enum PaymentStatu
        {
            等待汇款, 已经付清, 未付清, 已收定金
        };
        public enum OgisticsStatus
        {
            配送中, 已发货, 已签收, 未发货, 已退货
        };
        public enum RemitJoinMode
        {
            银行汇款, 虚拟货币, 现金支付
        };
        #region 订单状态 付款情况 物流状态
        /// <summary>
        /// 订单状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string OrderStatus(object obj)
        {
            string reStr = string.Empty;
            Type orderStatu = typeof(OrderStatu);
            bool bl = ChangeHope.Common.ValidateHelper.IsNumber(obj.ToString());
            if (bl)
            {
                reStr = Enum.GetName(orderStatu, obj);
            }
            return reStr;
        }
        /// <summary>
        /// 付款情况
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string PaymentStatus(object obj)
        {
            string reStr = string.Empty;
            Type paymentStatu = typeof(PaymentStatu);
            bool bl = ChangeHope.Common.ValidateHelper.IsNumber(obj.ToString());
            if (bl)
            {
                reStr = Enum.GetName(paymentStatu, obj);
            }
            return reStr;
        }
        /// <summary>
        /// 物流状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string OgisticsStatu(object obj)
        {
            string reStr = string.Empty;
            Type ogisticsStatu = typeof(OgisticsStatus);
            bool bl = ChangeHope.Common.ValidateHelper.IsNumber(obj.ToString());
            if (bl)
            {
                reStr = Enum.GetName(ogisticsStatu, obj);
            }
            return reStr;
        }
        #endregion
    }
}
