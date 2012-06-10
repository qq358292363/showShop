using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Product
{
    public interface IProductAuction
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.ProductAuction model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Amend(ShowShop.Model.Product.ProductAuction model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string id);
        /// <summary>
        /// 任意修改一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Amend(int id, string columnName, Object value);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Product.ProductAuction GetModelID(int id);
        ShowShop.Model.Product.ProductAuction GetModelProductID(int ProductId);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        

        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
        #endregion  成员方法
    }
}
