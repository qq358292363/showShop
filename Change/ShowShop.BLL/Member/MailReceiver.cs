using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Member;
using ShowShop.DALFactory;
using ShowShop.IDAL.Member;
namespace ShowShop.BLL.Member
{
    public class MailReceiver
    {
        private readonly IMailReceiver dal = DataAccess.CreateMailReceiver();
        public MailReceiver()
        { }

        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Member.MailReceiver model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.Member.MailReceiver model)
        {
            dal.Amend(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            return dal.Amend(id, columnName, value);
        }
        #endregion

        #region  "Data Load"
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Member.MailReceiver GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MailReceiver> GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MailReceiver> GetAll(string strWhere)
        {
            return dal.GetAll(strWhere);
        }

        /// <summary>
        /// 不同条件得到收件箱
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            return dal.GetList();
        }
        #endregion
    }
}
