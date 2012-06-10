using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Product
{
    public interface IProductUnit
    {
        /// <summary>
        /// 是否存在该单位
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool ExistName(string name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.ProductUnit model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(ShowShop.Model.Product.ProductUnit model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        ShowShop.Model.Product.ProductUnit GetModel(System.Data.DataRow row);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Product.ProductUnit GetModelID(int id);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        /// <summary>
        /// 得到指定条件的所有集合
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<ShowShop.Model.Product.ProductUnit> GetAll(string strWhere);
    }
}
