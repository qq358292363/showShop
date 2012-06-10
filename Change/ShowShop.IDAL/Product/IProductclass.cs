using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ShowShop.IDAL.Product
{
    public interface IProductclass
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Product.Productclass model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(ShowShop.Model.Product.Productclass model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Product.Productclass GetModelID(int id);

        List<ShowShop.Model.Product.Productclass> GetAll();
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        /// <summary>
        /// 前台标签查询数据
        /// </summary>
        /// <param name="orderfield"></param>
        /// <param name="pagesize"></param>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
        /// <summary>
        /// fatherid查询
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        DataTable GetFatherList(int fatherid);

        DataTable GetClassId(int CID, string ParentPath);
        /// <summary>
        /// 修改某一个字段的值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Amend(int id, string columnName, Object value);
        /// <summary>
        /// 获取多个分类名称
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        DataTable GetMoreThanClassName(string strId);
        /// <summary>
        /// 父级ID模糊查询
        /// </summary>
        /// <param name="ParentPath"></param>
        /// <returns></returns>
        DataTable GetBlurList(string ParentPath);
        #endregion  成员方法
    }
}
