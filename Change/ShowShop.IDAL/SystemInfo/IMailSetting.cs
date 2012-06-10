using System;
using System.Data;
namespace ShowShop.IDAL.SystemInfo
{
    /// <summary>
    /// 接口层IMailSetting 的摘要说明。
    /// </summary>
    public interface IMailSetting
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.SystemInfo.MailSetting model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.SystemInfo.MailSetting model);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.SystemInfo.MailSetting GetModel();
        #endregion  成员方法
    }
}
