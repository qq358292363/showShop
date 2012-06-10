using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Product
{
    public class ProductAlbum
    {
        private readonly IProductAlbum dal = DataAccess.CreateProductAlbum();
        public ProductAlbum()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.ProductAlbum model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.Product.ProductAlbum model)
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
        public ShowShop.Model.Product.ProductAlbum GetModelID(int id)
        {

            return dal.GetModelID(id);
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
        /// 删除商品ID的所有图片
        /// </summary>
        /// <param name="strId"></param>
        public void DelAll(string strId)
        {
            dal.DelAll(strId);
        }

        /// <summary>
        /// 查询商品相册
        /// </summary>
        /// <param name="productid"></param>
        public System.Data.DataTable GetProAlbumAll(int productid, int SpecificaticationSignId, int IsSpecialspecificationsSign)
        {
            return dal.GetProAlbumAll(productid, SpecificaticationSignId, IsSpecialspecificationsSign);
        }
        #endregion  成员方法
    }
}
