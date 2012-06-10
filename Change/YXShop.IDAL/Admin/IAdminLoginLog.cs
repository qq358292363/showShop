using System;
using System.Data;
using ShowShop.Model.Admin;

namespace ShowShop.IDAL.Admin
{
    /// <summary>
    /// 接口层IAdminLoginLog 的摘要说明。
    /// </summary>
    public interface IAdminLoginLog
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(AdminLoginLog model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int id);
        #endregion  成员方法
    }
}
