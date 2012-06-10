using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Order;
using ShowShop.DALFactory;
using ShowShop.IDAL.Order;
namespace ShowShop.BLL.Order
{
    /// <summary>
    /// 业务逻辑类ShoppingCard 的摘要说明。
    /// </summary>
    public class ShoppingCard
    {
        private readonly IShoppingCard dal = DataAccess.CreateShoppingCard();
        public ShoppingCard()
        { }
        #region  成员方法
       
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }

        public void Delete(string UserId)
        {
            dal.Delete(UserId);
        }



        public ChangeHope.DataBase.DataByPage GetCartProduct(string uniqueid)
        {
            return dal.GetCartProduct(uniqueid);
        }
        public ChangeHope.DataBase.DataByPage GetProfilesList(string condition)
        {
            return dal.GetProfilesList(condition);
        }

        public void DeleteCartkey(string cartkey)
        {
            dal.DeleteCartkey(cartkey);
        }
        #endregion  成员方法
    }
}

