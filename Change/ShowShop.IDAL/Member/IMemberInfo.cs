using System;
using System.Data;
namespace ShowShop.IDAL.Member
{
    /// <summary>
    /// 接口层IMemberInfo 的摘要说明。
    /// </summary>
    public interface IMemberInfo
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int UID);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ShowShop.Model.Member.MemberInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.Member.MemberInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int UID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Member.MemberInfo GetModel(int UID);

        int Amend(int id, string columnName, Object value);
        #endregion  成员方法
    }
}
