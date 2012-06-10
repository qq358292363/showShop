using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using ShowShop.DALFactory;
using System.Data;

namespace ShowShop.BLL.Product
{
    public class ProductBrand
    {
        private readonly IProductBrand dal = DataAccess.CreateProductBrand();
        public ProductBrand()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.ProductBrand model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.Product.ProductBrand model)
        {
            return dal.Amend(model);
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
        public ShowShop.Model.Product.ProductBrand GetModelID(int id)
        {
            return dal.GetModelID(id);
        }

        public ShowShop.Model.Product.ProductBrand GetModelName(string BrandName)
        {
            return dal.GetModelName(BrandName);
        }
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 前台标签查询所有数据
        /// </summary>
        /// <param name="orderfield"></param>
        /// <param name="pagesize"></param>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            return dal.GetList(orderfield, pagesize, Conditions);
        }
        /// <summary>
        /// 修改任一字段值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }
        /// <summary>
        /// 跟据商品分类ID查询品牌
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public DataTable GetBrandList(string CID)
        {
            return dal.GetBrandList(CID);
        }

        public List<ShowShop.Model.Product.ProductBrand> GetCommonTypes()
        {
            return dal.GetCommonTypes();
        }

        public List<ShowShop.Model.Product.ProductBrand> GetDTList(string strBrandId)
        {
            return dal.GetDTList(strBrandId);
        }
        #endregion  成员方法
    }
}
