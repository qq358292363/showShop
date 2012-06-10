using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Member;
using ShowShop.DALFactory;
using ShowShop.IDAL.Member;
namespace ShowShop.BLL.Member
{
    /// <summary>
    /// 业务逻辑类MemberInfo 的摘要说明。
    /// </summary>
    public class MemberInfo
    {
        private readonly IMemberInfo dal = DataAccess.CreateMemberInfo();
        public MemberInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID)
        {
            return dal.Exists(UID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ShowShop.Model.Member.MemberInfo model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Member.MemberInfo model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int UID)
        {

            dal.Delete(UID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Member.MemberInfo GetModel(int UID)
        {
            return dal.GetModel(UID);
        }
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id, columnName, value);
        }
        public int GetIdByUserId(string userid)
        {
            //return dal.GetIdByUserId(userid);
            return 0;
        }
        #endregion  成员方法
    }
}

