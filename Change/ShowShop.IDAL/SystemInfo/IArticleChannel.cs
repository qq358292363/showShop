using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace ShowShop.IDAL.SystemInfo
{
    /// <summary>
    /// 接口层IArticleChannel 的摘要说明。
    /// </summary>
    public interface IArticleChannel
    {
        #region  成员方法
        /// <summary>
        /// 判断该频道下是否有子频道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool HasChild(int id);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ChannelId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(ShowShop.Model.SystemInfo.ArticleChannel model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(ShowShop.Model.SystemInfo.ArticleChannel model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string ChannelId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.SystemInfo.ArticleChannel GetModel(string ChannelId);
        /// <summary>
        /// 根据条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<ShowShop.Model.SystemInfo.ArticleChannel> GetAllByWhere(string strWhere);

        string GetList();
        SortedList GetChannel(string id);
        string GetMaxId(string parentid);
        SqlDataReader GetAll(string parentid);
        SqlDataReader GetStairList(string parentid);
         SortedList GetChildChannel(string id);

         ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions);
        #endregion  成员方法

         string GetArticleName(string id);
    }
}
