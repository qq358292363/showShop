using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Product
{
    public class Product_Auction_Bid
    {
        private readonly IProduct_Auction_Bid dal = DataAccess.CreateProduct_Auction_Bid();
        public Product_Auction_Bid()
        { }

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.Product_Auction_Bid model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.Product.Product_Auction_Bid model)
        {
            return dal.Update(model);
        }

        int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.Product_Auction_Bid GetModel(int id)
        {
            return dal.GetModel(id);
        }
        public ChangeHope.DataBase.DataByPage GetListByPage()
        {
            return dal.GetListByPage();
        }

        public string maxValues(string field, string productid)
        {
            return dal.maxValues(field,productid);
        }

        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            return dal.GetList(orderfield, pagesize, Conditions);
        }
        #endregion  成员方法
    }
}
