using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Member
{
    /// <summary>
    /// 接口层IMemberRank 的摘要说明。
    /// </summary>
    public interface IMemberRank
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Member.MemberRank model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.Member.MemberRank model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Member.MemberRank GetModel(int id);
        /// <summary>
        /// 得集合 kevin建
        /// </summary>
        /// <returns></returns>
        List<ShowShop.Model.Member.MemberRank> GetAllMemberRank();
        string GetView();
        DataTable GetList();
        #endregion  成员方法
    }
}
