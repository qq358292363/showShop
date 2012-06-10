using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using ShowShop.DALFactory;

namespace ShowShop.BLL.Product
{
    public class ProductUnit
    {
        private readonly IProductUnit dal = DataAccess.CreateProductUnit();
        public ProductUnit()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该单位
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistName(string name)
        {
            return dal.ExistName(name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.ProductUnit model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.Product.ProductUnit model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ShowShop.Model.Product.ProductUnit GetModel(System.Data.DataRow row)
        {
            return dal.GetModel(row);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.ProductUnit GetModelID(int id)
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
        /// 得到指定条件的所有集合
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Product.ProductUnit> GetAll(string strWhere)
        {
            return dal.GetAll(strWhere);
        }
        #endregion  成员方法
    }
}
