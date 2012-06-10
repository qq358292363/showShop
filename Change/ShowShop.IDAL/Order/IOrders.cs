using System;
using System.Data;
namespace ShowShop.IDAL.Order
{
    /// <summary>
    /// 接口层IOrders 的摘要说明。
    /// </summary>
    public interface IOrders
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Order.Orders model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.Order.Orders model);
        int Amend(int id, string columnName, Object value);
        /// <summary>
        /// 批量删除
        /// </summary>
        void Delete(string strId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Order.Orders GetModel(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Order.Orders GetModel(string orderId);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        ChangeHope.DataBase.DataByPage GetListByPage(string sqlWhere);
        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);

        
        #endregion  成员方法
    }
}
