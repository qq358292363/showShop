using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.SystemInfo;
using ShowShop.DALFactory;
using ShowShop.IDAL.SystemInfo;
namespace ShowShop.BLL.SystemInfo
{
    /// <summary>
    /// 业务逻辑类MailSetting 的摘要说明。
    /// </summary>
    public class MailSetting
    {
        private readonly IMailSetting dal = DataAccess.CreateMailSetting();
        public MailSetting()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.MailSetting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.SystemInfo.MailSetting model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.MailSetting GetModel()
        {

            return dal.GetModel();
        }

        #endregion  成员方法
    }
}

