using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Member
{
    /// <summary>
    /// 接口层IMemberAccount 的摘要说明。
    /// </summary>
    public interface IMemberAccount
    {
        #region  成员方法
        /// <summary>
        /// 得到自增ID最大值
        /// </summary>
        /// <returns></returns>
        int GetMaxID();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int UID);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string userId);
        /// <summary>
        /// 是否存在该Email记录
        /// </summary>
        bool ExistEmail(string email);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Member.MemberAccount model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.Member.MemberAccount model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int UID);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeleteAll(string ids);
        /// <summary>
        /// 批量解锁与冻结
        /// </summary>
        /// <param name="ids">id集合</param>
        /// <param name="flag">是否冻结为真解锁</param>
        void LockAddUnLock(string ids, bool flag);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Member.MemberAccount GetModel(int UID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        ShowShop.Model.Member.MemberAccount GetModel(string UserId);
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
        ChangeHope.DataBase.DataByPage GetList(string where);
        /// <summary>
        /// 查所有 可根据条件
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<ShowShop.Model.Member.MemberAccount> GetAll(string where);
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ShowShop.Model.Member.MemberAccount GetModelByNameAndPassword(string name, string password);
        /// <summary>
        /// 任意修改一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Amend(int id, string columnName, Object value);

        /// <summary>
        /// 更改会员组
        /// </summary>
        /// <param name="oldGroup"></param>
        /// <param name="newGroup"></param>
        /// <returns></returns>
        int UpdateGroup(string oldGroup, string newGroup);
        #endregion  成员方法
    }
}
