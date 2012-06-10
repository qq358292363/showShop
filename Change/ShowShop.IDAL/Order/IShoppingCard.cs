using System;
using System.Data;
namespace ShowShop.IDAL.Order
{
    /// <summary>
    /// 接口层IShoppingCard 的摘要说明。
    /// </summary>
    public interface IShoppingCard
    {
        #region  成员方法
        
        int Amend(int id, string columnName, Object value);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        void Delete(string UserId);
        ChangeHope.DataBase.DataByPage GetCartProduct(string uniqueid);
        ChangeHope.DataBase.DataByPage GetProfilesList(string condition);
        void DeleteCartkey(string cartkey);
        #endregion  成员方法
    }
}
