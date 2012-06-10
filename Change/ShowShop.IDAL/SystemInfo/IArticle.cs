using System;
using System.Data;
using System.Collections.Generic;
namespace ShowShop.IDAL.SystemInfo
{
    /// <summary>
    /// 接口层IArticle 的摘要说明。
    /// </summary>
    public interface IArticle
    {
        #region  成员方法
        /// <summary>
        /// 判断是否有该频道下的文章
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        bool ExistByCid(int channelId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(ShowShop.Model.SystemInfo.Article model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.SystemInfo.Article model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.SystemInfo.Article GetModel(int Id);
        /// <summary>
        /// 根据条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ShowShop.Model.SystemInfo.Article> GetAllByWhere(string strWhere);
        /// <summary>
        /// 根据条件得到列表的前几条数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ShowShop.Model.SystemInfo.Article> GetAllByWhere(int len,string strWhere);
        ChangeHope.DataBase.DataByPage GetList(string where);
        ChangeHope.DataBase.DataByPage GetListByWhereAndOrder(string where, int pagesize, string orderfield);
        int Amend(int id, string columnName, Object value);
        #endregion  成员方法
    }
}
