using System;
using System.Data;
namespace ShowShop.IDAL.SystemInfo
{
    /// <summary>
    /// 接口层IProvinces 的摘要说明。
    /// </summary>
    public interface IProvinces
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.SystemInfo.Provinces model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.SystemInfo.Provinces model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.SystemInfo.Provinces GetModel(int Id);

        ChangeHope.DataBase.DataByPage GetList();

        string GetToolBar(int id);

        int GetChildCount(string id);

        System.Data.SqlClient.SqlDataReader GetChidNode(string parentid);

        DataTable GetChid(string parentid);

        DataTable ProvincesStr(string IdStr);
        #endregion  成员方法
    }
}
