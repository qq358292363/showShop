using System;
using System.Data;
namespace ShowShop.IDAL.SystemInfo
{
    /// <summary>
    /// 接口层ICustomerSetting 的摘要说明。
    /// </summary>
    public interface ICustomerSetting
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.SystemInfo.CustomerSetting model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.SystemInfo.CustomerSetting model);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.SystemInfo.CustomerSetting GetModel();
        #endregion  成员方法
    }
}
