using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;
using ShowShop.DALFactory;
using System.Data;
namespace ShowShop.BLL.Member
{
    public class Roles_Permissions
    {
        private readonly IRoles_Permissions dal = DataAccess.CreateRoles_Permissions();
        public Roles_Permissions()
        { }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Create(ShowShop.Model.Member.Roles_Permissions model)
        {
            return dal.Create(model);
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
        /// 一字段一值查询
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.Roles_Permissions> GetListByColumn(string Condition)
        {
            return dal.GetListByColumn(Condition);
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.Member.Roles_Permissions GetModelID(int id)
        {
            return dal.GetModelID(id);
        }

        public List<ShowShop.Model.Member.Roles_Permissions> GetAll()
        {
            return dal.GetAll();
        }
        public List<ShowShop.Model.Member.Roles_Permissions> GetListByColumn(string columnName, Object value)
        {
            return dal.GetListByColumn(columnName, value);
        }

        public int Add(List<ShowShop.Model.Member.Roles_Permissions> list)
        {
            return dal.Add(list);
        }
        public int Del(List<ShowShop.Model.Member.Roles_Permissions> list)
        {
            return dal.Del(list);
        }
    }
}
