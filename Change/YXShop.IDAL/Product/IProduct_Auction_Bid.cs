using System;
using System.Data;
namespace ShowShop.IDAL.Product
{
    /// <summary>
    /// 接口层IProductauctionBid 的摘要说明。
    /// </summary>
    public interface IProduct_Auction_Bid
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.Product_Auction_Bid model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(ShowShop.Model.Product.Product_Auction_Bid model);

        int Amend(int id, string columnName, Object value);
        string maxValues(string field, string productid);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Product.Product_Auction_Bid GetModel(int id);
        ChangeHope.DataBase.DataByPage GetListByPage();
        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
        #endregion  成员方法
    }
}
