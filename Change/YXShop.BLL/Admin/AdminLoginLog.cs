using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Admin;
using ShowShop.DALFactory;
using ShowShop.IDAL.Admin;
namespace ShowShop.BLL.Admin
{
    /// <summary>
    /// 业务逻辑类AdminLoginLog 的摘要说明。
    /// </summary>
    public class AdminLoginLog
    {
        private readonly IAdminLoginLog dal = DataAccess.CreateAdminLoginLog();
        public AdminLoginLog()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Admin.AdminLoginLog model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        #endregion  成员方法
    }
}

