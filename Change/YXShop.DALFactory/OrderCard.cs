using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.OrderCard;

namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        /// <summary>
        /// 标签管理
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.OrderCard.IOrderCardInfo CreateOrderCardInfo()
        {
            return (IOrderCardInfo)CreateObject("OrderCard.OrderCardInfo");
        }
    }
}
