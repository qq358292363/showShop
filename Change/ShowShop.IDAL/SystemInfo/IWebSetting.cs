using System;
using System.Data;
namespace ShowShop.IDAL.SystemInfo
{
    /// <summary>
    /// 接口层IWebSetting 的摘要说明。
    /// </summary>
    public interface IWebSetting
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.SystemInfo.WebSetting model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.SystemInfo.WebSetting model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.SystemInfo.WebSetting GetModel();


        int Amend(int id, string columnName, object value);
        #endregion  成员方法
    }
}