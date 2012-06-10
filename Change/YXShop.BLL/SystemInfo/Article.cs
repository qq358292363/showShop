using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.SystemInfo;
using ShowShop.DALFactory;
using ShowShop.IDAL.SystemInfo;
namespace ShowShop.BLL.SystemInfo
{
    /// <summary>
    /// 业务逻辑类Article 的摘要说明。
    /// </summary>
    public class Article
    {
        private readonly IArticle dal = DataAccess.CreateArticle();
        public Article()
        { }
        #region  成员方法
        /// <summary>
        /// 判断是否有该频道下的文章
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public bool ExistByCid(int channelId)
        {
            return dal.ExistByCid(channelId);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.Article model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.SystemInfo.Article model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.Article GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        public string GetListForTable()
        {
            ChangeHope.WebPage.DataView dataview = new ChangeHope.WebPage.DataView();
            
            dataview.RowHead = "序号/5%,标题/40%,发布人/10%,更新时间/15%,状态/5%,所属频道/10%,操作/20%";
            dataview.RowText = "{0}$@allnum,<a href='article_read.aspx?id={0}'>{1}</a>$id|@sub#Title#30,Users,UpdateTime,<img src='../images/{0}.gif' />$State,ChannelContent,<a href=article_edit.aspx?id={0}>编辑</a> <a href='javascript:void(0)' onclick='Del({0})'>删除</a>$id";
            string view = dataview.GetView(dal.GetList(""));
            dataview = null;
            return view;
        }
        /// <summary>
        /// 根据条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.Article> GetAllByWhere(string strWhere)
        {
            return dal.GetAllByWhere(strWhere);
        }
        /// <summary>
        /// 得到列表的前几条数据
        /// </summary>
        /// <param name="len"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.Article> GetAllByWhere(int len, string strWhere)
        {
            return dal.GetAllByWhere(len, strWhere);
        }
        public ChangeHope.DataBase.DataByPage GetList(string where)
        {
            return dal.GetList(where);
        }
        public ChangeHope.DataBase.DataByPage GetListByWhereAndOrder(string where, int pagesize, string orderfield)
        {
            return dal.GetListByWhereAndOrder(where,pagesize,orderfield);
        }
        public int Amend(int id, string columnName, Object value)
        {
            return dal.Amend(id,columnName,value);
        }
        #endregion  成员方法
    }
}

