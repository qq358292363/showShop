using System;
using System.Data;
namespace ShowShop.IDAL.Order
{
    /// <summary>
    /// 接口层IOrderProduct 的摘要说明。
    /// </summary>
    public interface IOrderProduct
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Order.OrderProduct model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.Order.OrderProduct model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Order.OrderProduct GetModel(int Id);

        ChangeHope.DataBase.DataByPage GetListByPage();

        ChangeHope.DataBase.DataByPage GetListByPage(string StrWhere);
        DataTable GetListOrderProduct(string OrderId);

        int Amend(int id, string columnName, Object value);
        #endregion  成员方法
    }
}
