using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.Member
{
    public interface IMailinfo
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.Member.MailInfo model);
        /// <summary>
        /// 得到发件人发送的最后一封信件的ID
        /// 也就是作为 收件箱的 mailId
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        int GetMaxMailId(string sender);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Amend(ShowShop.Model.Member.MailInfo model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string id);

        /// <summary>
        /// 任意修改一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Amend(int id, string columnName, Object value);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Member.MailInfo GetModelByID(int id);

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        List<ShowShop.Model.Member.MailInfo> GetAll();

        /// <summary>
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<ShowShop.Model.Member.MailInfo> GetAll(string strWhere);

        /// <summary>
        /// 得到不同条件的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList(string strWhere);
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <returns></returns>
        ChangeHope.DataBase.DataByPage GetList();
    }
}
