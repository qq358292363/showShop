using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Product
{
    public interface IProductSparepart
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.ProductSparepart model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Amend(ShowShop.Model.Product.ProductSparepart model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 删除单个商品的配件
        /// </summary>
        /// <remarks></remarks>
        void DeleteProductSparepart(int id);
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
        ShowShop.Model.Product.ProductSparepart GetModelID(int id);
        /// <summary>
        /// 跟据ProductId查询配件
        /// </summary>
        /// <param name="ProductId">商品ID</param>
        /// <returns></returns>
        List<ShowShop.Model.Product.ProductSparepart> GetSparepart(int ProductId);
    }
}
