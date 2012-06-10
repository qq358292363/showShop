using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Product
{
    public class ProductSparepart
    {
        private readonly IProductSparepart dal = DataAccess.CreateProductSparepart();
        public ProductSparepart()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.ProductSparepart model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.Product.ProductSparepart model)
        {
            dal.Amend(model);
        }
        /// <summary>
        /// 任意修改字段
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="columnName">修改字段名</param>
        /// <param name="value">修改的值</param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }
        /// <summary>
        /// 删除单个商品的配件
        /// </summary>
        /// <remarks></remarks>
        public void DeleteProductSparepart(int ProductId)
        {
            dal.DeleteProductSparepart(ProductId);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.ProductSparepart GetModelID(int id)
        {

            return dal.GetModelID(id);
        }

        /// <summary>
        /// 跟据ProductId查询规格
        /// </summary>
        /// <param name="ProductId">商品ID</param>
        /// <returns></returns>
        public List<ShowShop.Model.Product.ProductSparepart> GetSparepart(int ProductId)
        {
            return dal.GetSparepart(ProductId);
        }
        #endregion  成员方法
    }
}
