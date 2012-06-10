using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Order;
using ShowShop.DALFactory;
using ShowShop.IDAL.Order;
namespace ShowShop.BLL.Order
{
    /// <summary>
    /// 业务逻辑类OrderProduct 的摘要说明。
    /// </summary>
    public class OrderProduct
    {
        private readonly IOrderProduct dal = DataAccess.CreateOrderProduct();
        public OrderProduct()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Order.OrderProduct model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Order.OrderProduct model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Order.OrderProduct GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        public ChangeHope.DataBase.DataByPage GetListByPage()
        {
            return dal.GetListByPage();
        }

        public ChangeHope.DataBase.DataByPage GetListByPage(string StrWhere)
        {
            return dal.GetListByPage(StrWhere);
        }

        /// <summary>
        /// 跟据订单号查询
        /// </summary>
        /// <param name="OrderId">订单ID</param>
        /// <returns></returns>
        public DataTable GetListOrderProduct(string OrderId)
        {
            return dal.GetListOrderProduct(OrderId);
        }
        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }
        #endregion  成员方法
    }
}

