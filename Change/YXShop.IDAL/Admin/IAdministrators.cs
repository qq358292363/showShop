using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Admin
{
    /// <summary>
    /// 接口层IAdministrators 的摘要说明。
    /// </summary>
    public interface IAdministrators
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string adminName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Admin.Administrators model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.Admin.Administrators model);

        int Amend(int id, string columnName, Object value);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int adminid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Admin.Administrators GetModel(int adminid);
        ShowShop.Model.Admin.Administrators GetModelByAdminName(string amdinName);
        List<ShowShop.Model.Admin.Administrators> GetList(System.Data.DataTable table);
        string GetList();
        ChangeHope.DataBase.DataByPage GetListDB();
        #endregion  成员方法
    }
}
