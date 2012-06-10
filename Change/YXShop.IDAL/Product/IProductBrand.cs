using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChangeHope.WebPage;

namespace ShowShop.IDAL.Product
{
    public interface IProductBrand
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.ProductBrand model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Amend(ShowShop.Model.Product.ProductBrand model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
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
        ShowShop.Model.Product.ProductBrand GetModelID(int id);
        ShowShop.Model.Product.ProductBrand GetModelName(string BrandName);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        /// <summary>
        /// 跟据分类ID查品牌
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        System.Data.DataTable GetBrandList(string CID);
        List<ShowShop.Model.Product.ProductBrand> GetDTList(string strBrandId);
        List<ShowShop.Model.Product.ProductBrand> GetCommonTypes();
        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
        #endregion  成员方法
    }
}
