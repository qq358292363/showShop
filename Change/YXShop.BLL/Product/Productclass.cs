using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using ShowShop.DALFactory;
using System.Data;

namespace ShowShop.BLL.Product
{
    public class Productclass
    { 
        private readonly IProductclass dal = DataAccess.CreateProductcalss();
        public Productclass()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.Productclass model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.Product.Productclass model)
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
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.Productclass GetModelID(int id)
        {

            return dal.GetModelID(id);
        }
        public List<ShowShop.Model.Product.Productclass> GetAll()
        {
            return dal.GetAll();
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
        /// fatherid查询
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetFatherList(int fatherid)
        {
            return dal.GetFatherList(fatherid);
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
        /// 获取多个分类名称
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public DataTable GetMoreThanClassName(string strId)
        {
            return dal.GetMoreThanClassName(strId);
        }
        /// <summary>
        /// 父级模糊查询
        /// </summary>
        /// <param name="ParentPath"></param>
        /// <returns></returns>
        public DataTable GetBlurList(string ParentPath)
        {
            return dal.GetBlurList(ParentPath);
        }

        public DataTable GetClassId(int CID, string ParentPath)
        {
            return dal.GetClassId(CID, ParentPath);
        }
        #endregion  成员方法
    }
}
