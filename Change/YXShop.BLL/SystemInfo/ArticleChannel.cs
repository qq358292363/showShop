using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.SystemInfo;
using ShowShop.DALFactory;
using ShowShop.IDAL.SystemInfo;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace ShowShop.BLL.SystemInfo
{
    /// <summary>
    /// 业务逻辑类ArticleChannel 的摘要说明。
    /// </summary>
    public class ArticleChannel
    {
        private readonly IArticleChannel dal = DataAccess.CreateArticleChannel();
        public ArticleChannel()
        { }
        #region  成员方法
        /// <summary>
        /// 判断该频道下是否有子频道
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HasChild(int id)
        {
            return dal.HasChild(id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ChannelId)
        {
            return dal.Exists(ChannelId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ShowShop.Model.SystemInfo.ArticleChannel model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.SystemInfo.ArticleChannel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ChannelId)
        {

            dal.Delete(ChannelId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.ArticleChannel GetModel(string ChannelId)
        {

            return dal.GetModel(ChannelId);
        }

        /// <summary>
        /// 根据条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.ArticleChannel> GetAllByWhere(string strWhere)
        {
            return dal.GetAllByWhere(strWhere);
        }
        public string GetList()
        {
            return dal.GetList();
        }
        public SortedList GetChannel(string id)
        {
            return dal.GetChannel(id);
        }
        public SortedList GetChildChannel(string id)
        {
            return dal.GetChildChannel(id);
        }
        public string GetMaxId(string parentid)
        {
            return dal.GetMaxId(parentid);
        }
        public SqlDataReader GetAll(string parentid)
        {
            return dal.GetAll(parentid);
        }

        public string GetArticleName(string id)
        {
            return dal.GetArticleName(id);
        }
        
        public void GetDropList(DropDownList ddl, string parentid)
        {
            System.Data.SqlClient.SqlDataReader reader = dal.GetAll(parentid);
            string text = "";
            string value = "";
            int index = 0;
            if (reader != null)
            {
                while (reader.Read())
                {
                    if (reader["id"].ToString() != parentid)
                    {
                    text = "";
                    int len = reader["id"].ToString().Length;
                    len = len / 3;
                    for (int l = 0; l < len; l++)
                    {
                        if (l != 0)
                        {
                            text = text + "┆";
                        }
                    }
                    text = text + "├ " + reader["name"].ToString();
                    value = reader["id"].ToString();
                    ddl.Items.Add(new ListItem(text, value));
                    index++;
                    }
                }
            }
            reader.Close();
            reader.Dispose();
            reader = null;
        }

        public void GetStairList(DropDownList ddl, string parentid)
        {
            System.Data.SqlClient.SqlDataReader reader = dal.GetStairList(parentid);
            string text = "";
            string value = "";
            int deep = 0;
            int index = 0;
            if(reader!=null)
            {
                while(reader.Read())
                {
                    deep = (value.Length - parentid.Length) / 3;
                    text = "";
                    for (int i = 0; i <= deep; i++)
                    {
                        if (i == deep)
                        {
                            text = text + "├";
                        }
                        else
                        {
                            text = text + "┆";
                        }
                    }
                    text = text + "" + reader["name"].ToString();
                    value = reader["id"].ToString();
                    ddl.Items.Add(new ListItem(text, value));
                    index++;
                }
            }
            reader.Close();
            reader.Dispose();
            reader = null;
        }
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            return dal.GetList(orderfield, pagesize, Conditions);
        }
        #endregion  成员方法
    }
}

