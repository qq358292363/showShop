using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Member;
using ShowShop.DALFactory;
using ShowShop.IDAL.Member;
namespace ShowShop.BLL.Member
{
    /// <summary>
    /// 业务逻辑类MemberAccount 的摘要说明。
    /// </summary>
    public class MemberAccount
    {
        private readonly IMemberAccount dal = DataAccess.CreateMemberAccount();
        public MemberAccount()
        { }
        #region  成员方法

        /// <summary>
        /// 得到自增ID最大值
        /// </summary>
        /// <returns></returns>
        public int GetMaxID()
        {
            return dal.GetMaxID();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID)
        {
            return dal.Exists(UID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userId)
        {
            return dal.Exists(userId);
        }

        /// <summary>
        /// 是否存在该Email记录
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistEmail(string email)
        {
            return dal.ExistEmail(email);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Member.MemberAccount model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Member.MemberAccount model)
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
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteAll(string ids)
        {
            dal.DeleteAll(ids);
        }
        /// <summary>
        /// 批量解锁与冻结
        /// </summary>
        /// <param name="ids">id集合</param>
        /// <param name="flag">是否冻结为真解锁</param>
        public void LockAddUnLock(string ids, bool flag)
        {
            dal.LockAddUnLock(ids,flag);
        }
        /// <summary>
        /// 更新任意一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            return dal.Amend(id, columnName, value);
        }
        /// <summary>
        /// 更改会员组
        /// </summary>
        /// <param name="oldGroup"></param>
        /// <param name="newGroup"></param>
        /// <returns></returns>
        public int UpdateGroup(string oldGroup, string newGroup)
        {
            return dal.UpdateGroup(oldGroup, newGroup);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Member.MemberAccount GetModel(int UID)
        {

            return dal.GetModel(UID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </
        public ShowShop.Model.Member.MemberAccount GetModel(string UserId)
        {
            return dal.GetModel(UserId);
        }
         /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ShowShop.Model.Member.MemberAccount GetModelByNameAndPassword(string name, string password)
        {
            return dal.GetModelByNameAndPassword(name,password);
        }
         /// <summary>
        /// 查所有 根据条件
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MemberAccount> GetAll(string where)
        {
            return dal.GetAll(where);
        }
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return  dal.GetList();
        }
        public ChangeHope.DataBase.DataByPage GetList(string where)
        {
            return dal.GetList(where);
        }
        #endregion  成员方法
    }
}

