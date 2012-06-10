using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Admin;
using ShowShop.DALFactory;
using ShowShop.IDAL.Admin;

namespace ShowShop.BLL.Admin
{
    /// <summary>
    /// 业务逻辑类Administrators 的摘要说明。
    /// </summary>
    public class Administrators
    {
        private readonly IAdministrators dal = DataAccess.CreateAdministrators();

        public Administrators()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string adminName)
        {
            return dal.Exists(adminName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Admin.Administrators model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Admin.Administrators model)
        {
            dal.Update(model);
        }

        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id,columnName,value);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int adminid)
        {

            dal.Delete(adminid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Admin.Administrators GetModel(int adminid)
        {

            return dal.GetModel(adminid);
        }

        /// <summary>
        /// 通过管理员的帐号获取实例
        /// </summary>
        /// <param name="amdinName"></param>
        /// <returns></returns>
        public ShowShop.Model.Admin.Administrators GetModelByAdminName(string amdinName)
        {
            return dal.GetModelByAdminName(amdinName);
        }

        /// <summary>
        /// 生成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Admin.Administrators> GetList(System.Data.DataTable dt)
        {

            return dal.GetList(dt);
        }

        public string GetList()
        {
            return dal.GetList();
        }
        public ChangeHope.DataBase.DataByPage GetListDB()
        {
            return dal.GetListDB();
        }
        #endregion  成员方法
    }
}

