using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Product
{
    public interface IProductAlbum
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.ProductAlbum model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Amend(ShowShop.Model.Product.ProductAlbum model);
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
        ShowShop.Model.Product.ProductAlbum GetModelID(int id);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        /// <summary>
        /// 删除商品ID的所有图片
        /// </summary>
        /// <param name="strId"></param>
        void DelAll(string strId);

        /// <summary>
        /// 查询商品相册
        /// </summary>
        /// <param name="productid"></param>
        System.Data.DataTable GetProAlbumAll(int productid, int SpecificaticationSignId, int IsSpecialspecificationsSign);
    }
}
