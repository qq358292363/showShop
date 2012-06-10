using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Product;
using ShowShop.DALFactory;
using ShowShop.IDAL.Product;
namespace ShowShop.BLL.Product
{
    /// <summary>
    /// 业务逻辑类ProductInfo 的摘要说明。
    /// </summary>
    public class ProductInfo
    {
        private readonly IProductInfo dal = DataAccess.CreateProductInfo();
        public ProductInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.ProductInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ShowShop.Model.Product.ProductInfo model)
        {
            return dal.Update(model);
        }
        // <summary>
        /// 任意修改字段
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="columnName">修改字段名</param>
        /// <param name="value">修改的值</param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id,columnName,value);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        public void Delete(string pro_ID)
        {
            dal.Delete(pro_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="pro_ID"></param>
        public void DeleleById(int pro_ID)
        {
            dal.DeleleById(pro_ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.ProductInfo GetModel(int pro_ID)
        {

            return dal.GetModel(pro_ID);
        }
        /// <summary>
        /// 所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 获取部分数据
        /// </summary>
        /// <param name="StrID"></param>
        /// <returns></returns>
        public DataTable GetPartData(string StrID)
        {
            return dal.GetPartData(StrID);
        }
        /// <summary>
        /// 指字段与条件查询
        /// </summary>
        /// <param name="FieldStr">字段</param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataTable GetAppointField(string FieldStr, string Condition)
        {
            return dal.GetAppointField(FieldStr, Condition);
        }
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public string GetMax()
        {
            return dal.GetMax();
        }
        //根据条件返回集合
        public ChangeHope.DataBase.DataByPage GetListByWhere(string where, int topNumber,int pageSize, string order)
        {
            return dal.GetListByWhere(where,topNumber,pageSize,order);
        }
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            return dal.GetList(orderfield, pagesize, Conditions);
        }
        /// <summary>
        /// 跟据条件返回DataTable
        /// </summary>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public DataTable DTGetListWhere(string Conditions)
        {
            return dal.dtGetListWhere(Conditions);
        }
        #endregion  成员方法
    }
}

