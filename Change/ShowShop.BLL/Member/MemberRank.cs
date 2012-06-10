using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Member;
using ShowShop.DALFactory;
using ShowShop.IDAL.Member;
namespace ShowShop.BLL.Member
{
    /// <summary>
    /// 业务逻辑类MemberRank 的摘要说明。
    /// </summary>
    public class MemberRank
    {
        private readonly IMemberRank dal = DataAccess.CreateMemberRank();
        public MemberRank()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            return dal.Exists(name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Member.MemberRank model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Member.MemberRank model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Member.MemberRank GetModel(int id)
        {

            return dal.GetModel(id);
        }
        /// <summary>
        /// 得泛集合 kevin建
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MemberRank> GetAllMemberRank()
        {
            return dal.GetAllMemberRank();
        }
        public string GetView()
        {
            return dal.GetView();
        }
        public DataTable GetList()
        {
            return dal.GetList();
        }
        #endregion  成员方法
    }
}

