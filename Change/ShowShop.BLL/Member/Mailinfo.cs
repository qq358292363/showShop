using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Member;
using ShowShop.DALFactory;
using ShowShop.IDAL.Member;
namespace ShowShop.BLL.Member
{
    public class Mailinfo
    {
        private readonly IMailinfo dal = DataAccess.CreateMailinfo();
        public Mailinfo()
        { }
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Member.MailInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 得到发件人发送的最后一封信件的ID
        /// 也就是作为 收件箱的 mailId
        /// </summary>
        public int GetMaxMailId(string sender)
        {
            return dal.GetMaxMailId(sender);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.Member.MailInfo model)
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
        public ShowShop.Model.Member.MailInfo GetModelByID(int id)
        {
            return dal.GetModelByID(id);
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MailInfo> GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MailInfo> GetAll(string strWhere)
        {
            return dal.GetAll(strWhere);
        }

        /// <summary>
        /// 得到不同用户不用状态的收件列表
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
