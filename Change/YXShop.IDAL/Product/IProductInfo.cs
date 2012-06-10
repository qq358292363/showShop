using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Product
{
    /// <summary>
    /// 接口层IProductInfo 的摘要说明。
    /// </summary>
    public interface IProductInfo
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.ProductInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(ShowShop.Model.Product.ProductInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string pro_ID);
        void DeleleById(int pro_ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Product.ProductInfo GetModel(int pro_ID);
        /// <summary>
        /// 所有记录
        /// </summary>
        /// <remarks></remarks>
        ChangeHope.DataBase.DataByPage GetList();
        /// <summary>
        /// 获取部分数据
        /// </summary>
        /// <param name="StrID"></param>
        /// <returns></returns>
        DataTable GetPartData(string StrID);
        /// <summary>
        /// 指字段与条件查询
        /// </summary>
        /// <param name="FieldStr">字段</param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        DataTable GetAppointField(string FieldStr, string Condition);
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        string GetMax();
        //根据条件返回集合  top数
        ChangeHope.DataBase.DataByPage GetListByWhere(string where, int topNumber,int pageSize,string order);


        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
        /// <summary>
        /// 跟据条件返回DataTable
        /// </summary>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        DataTable dtGetListWhere(string Conditions);
        // <summary>
        /// 任意修改字段
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="columnName">修改字段名</param>
        /// <param name="value">修改的值</param>
        /// <returns></returns>
        int Amend(int id, string columnName, Object value);
        #endregion  成员方法
    }
}
