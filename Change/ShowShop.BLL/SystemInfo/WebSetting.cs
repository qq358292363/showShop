using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.SystemInfo;
using ShowShop.DALFactory;
using ShowShop.IDAL.SystemInfo;
namespace ShowShop.BLL.SystemInfo
{
    /// <summary>
    /// 业务逻辑类WebSetting 的摘要说明。
    /// </summary>
    public class WebSetting
    {
        private readonly IWebSetting dal = DataAccess.CreateWebSetting();
        public WebSetting()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.WebSetting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.SystemInfo.WebSetting model)
        {
            dal.Update(model);
        }

        public int Amend(int id, string columnName, object value)
        {
            return dal.Amend(id, columnName, value);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.WebSetting GetModel()
        {

            return dal.GetModel();
        }
        public void AddOrUpdate(ShowShop.Model.SystemInfo.WebSetting model)
        {
            if (model.Id > 0)
            {
                Update(model);
            }
            else
            {
                Add(model);
            }
        }

        #endregion  成员方法
    }
}

