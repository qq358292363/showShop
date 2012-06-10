using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Order;
using ShowShop.DALFactory;
using ShowShop.IDAL.Order;
namespace ShowShop.BLL.Order
{
    /// <summary>
    /// 业务逻辑类Orders 的摘要说明。
    /// </summary>
    public class Orders
    {
        private readonly IOrders dal = DataAccess.CreateOrders();
        public Orders()
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
        public int Add(ShowShop.Model.Order.Orders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Order.Orders model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public void Delete(string strId)
        {
            dal.Delete(strId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Order.Orders GetModel(int Id)
        {

            return dal.GetModel(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ShowShop.Model.Order.Orders GetModel(string orderId)
        {
            return dal.GetModel(orderId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public ChangeHope.DataBase.DataByPage GetListByPage(string sqlWhere)
        {
            return dal.GetListByPage(sqlWhere);
        }
        /// <summary>
        /// 前台分页
        /// </summary>
        /// <param name="orderfield"></param>
        /// <param name="pagesize"></param>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            return dal.GetList(orderfield,pagesize,Conditions);
        }
        
        #endregion  成员方法
    }
}

