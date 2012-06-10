using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;
using ShowShop.DALFactory;
using System.Data;


namespace ShowShop.BLL.Member
{
    public class Role
    {
        private readonly IRole dal = DataAccess.CreateRole();
        public Role()
        { }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Create(ShowShop.Model.Member.Role model)
        {
            return dal.Create(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Amend(ShowShop.Model.Member.Role model)
        {
            return dal.Amend(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 一字段一值查询值
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataTable GetListByColumn(string columnName, Object value)
        {
            return dal.GetListByColumn(columnName, value);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }

        public ShowShop.Model.Member.Role GetModelID(int id)
        {
            return dal.GetModelID(id);
        }
    }
}
