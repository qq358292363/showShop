using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.SystemInfo;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    /// <summary>
    /// 数据访问类Article。
    /// </summary>
    public class Article : IArticle
    {
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_article");
            strSql.Append(" where Channel=@Channel ");
            SqlParameter[] parameters = {
					new SqlParameter("@Channel", SqlDbType.Int,4)};
            parameters[0].Value = channelId;
            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 任意修改字段
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="columnName">修改字段名</param>
        /// <param name="value">修改的值</param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update [yxs_article] set ";
            sequel = sequel + "[" + columnName + "] =@value ";
            sequel = sequel + " where Id=@Id";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@value", value), new SqlParameter("@Id", id) };
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(sequel, paras);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_Article(");
            strSql.Append("Channel,Title,SubTitle,KeyWord,Content,CopyFrom,LinkUrl,Author,Users,Editor,Hits,Introduction,CreateTime,UpdateTime,IsTop,IsElite,IsPic,IsPageType,State,Area,Property,ImagesAddress,ImagesSoure)");
            strSql.Append(" values (");
            strSql.Append("@Channel,@Title,@SubTitle,@KeyWord,@Content,@CopyFrom,@LinkUrl,@Author,@Users,@Editor,@Hits,@Introduction,@CreateTime,@UpdateTime,@IsTop,@IsElite,@IsPic,@IsPageType,@State,@Area,@Property,@ImagesAddress,@ImagesSoure)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Channel", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@SubTitle", SqlDbType.VarChar,100),
					new SqlParameter("@KeyWord", SqlDbType.VarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@CopyFrom", SqlDbType.VarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@Users", SqlDbType.VarChar,50),
					new SqlParameter("@Editor", SqlDbType.VarChar,50),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Introduction", SqlDbType.NText),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@IsElite", SqlDbType.Bit,1),
					new SqlParameter("@IsPic", SqlDbType.Bit,1),
					new SqlParameter("@IsPageType", SqlDbType.Bit,1),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Area", SqlDbType.VarChar,1000),
                                        new SqlParameter("@Property",SqlDbType.VarChar,50),
                                        new SqlParameter("@ImagesAddress",SqlDbType.VarChar,500),
                                        new SqlParameter("@ImagesSoure",SqlDbType.Int,4)};
            parameters[0].Value = model.Channel;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.KeyWord;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.CopyFrom;
            parameters[6].Value = model.LinkUrl;
            parameters[7].Value = model.Author;
            parameters[8].Value = model.Users;
            parameters[9].Value = model.Editor;
            parameters[10].Value = model.Hits;
            parameters[11].Value = model.Introduction;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.UpdateTime;
            parameters[14].Value = model.IsTop;
            parameters[15].Value = model.IsElite;
            parameters[16].Value = model.IsPic;
            parameters[17].Value = model.IsPageType;
            parameters[18].Value = model.State;
            parameters[19].Value = model.Area;
            parameters[20].Value = model.Property;
            parameters[21].Value = model.ImagesAddress;
            parameters[22].Value = model.ImagesSoure;

            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.SystemInfo.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_Article set ");
            strSql.Append("Channel=@Channel,");
            strSql.Append("Title=@Title,");
            strSql.Append("SubTitle=@SubTitle,");
            strSql.Append("KeyWord=@KeyWord,");
            strSql.Append("Content=@Content,");
            strSql.Append("CopyFrom=@CopyFrom,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("Author=@Author,");
            strSql.Append("Editor=@Editor,");     
            strSql.Append("Introduction=@Introduction,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("IsElite=@IsElite,");
            strSql.Append("IsPic=@IsPic,");
            strSql.Append("IsPageType=@IsPageType,");
            strSql.Append("State=@State,");
            strSql.Append("Area=@Area,");
            strSql.Append("Property=@Property,ImagesAddress=@ImagesAddress,ImagesSoure=@ImagesSoure");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Channel", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@SubTitle", SqlDbType.VarChar,100),
					new SqlParameter("@KeyWord", SqlDbType.VarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@CopyFrom", SqlDbType.VarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,50),
					new SqlParameter("@Users", SqlDbType.VarChar,50),
					new SqlParameter("@Editor", SqlDbType.VarChar,50),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@Introduction", SqlDbType.NText),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@IsElite", SqlDbType.Bit,1),
					new SqlParameter("@IsPic", SqlDbType.Bit,1),
					new SqlParameter("@IsPageType", SqlDbType.Bit,1),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Area", SqlDbType.VarChar,1000),
                                        new SqlParameter("@Property",SqlDbType.VarChar,50),
                                        new SqlParameter("@ImagesAddress",SqlDbType.VarChar,500),
                                        new SqlParameter("@ImagesSoure",SqlDbType.Int,4)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Channel;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.SubTitle;
            parameters[4].Value = model.KeyWord;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.CopyFrom;
            parameters[7].Value = model.LinkUrl;
            parameters[8].Value = model.Author;
            parameters[9].Value = model.Users;
            parameters[10].Value = model.Editor;
            parameters[11].Value = model.Hits;
            parameters[12].Value = model.Introduction;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.IsTop;
            parameters[16].Value = model.IsElite;
            parameters[17].Value = model.IsPic;
            parameters[18].Value = model.IsPageType;
            parameters[19].Value = model.State;
            parameters[20].Value = model.Area;
            parameters[21].Value = model.Property;
            parameters[22].Value = model.ImagesAddress;
            parameters[23].Value = model.ImagesSoure;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_Article ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        public ChangeHope.DataBase.DataByPage GetList(string where)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] *,(select name from yxs_articlechannel where id=yxs_Article.Channel)as ChannelContent [from] yxs_Article [where] 1=1 " + where + " [order by] id desc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        public ChangeHope.DataBase.DataByPage GetListByWhereAndOrder(string where, int pagesize, string orderfield)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_article [where]  "+where+" [order by] "+orderfield+" ";
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.Article GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Channel,Title,SubTitle,KeyWord,Content,CopyFrom,LinkUrl,Author,Users,Editor,Hits,Introduction,CreateTime,UpdateTime,IsTop,IsElite,IsPic,IsPageType,State,Area,Property,ImagesAddress,ImagesSoure,BrowseCount from yxs_Article ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ShowShop.Model.SystemInfo.Article model = new ShowShop.Model.SystemInfo.Article();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Channel = ds.Tables[0].Rows[0]["Channel"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.SubTitle = ds.Tables[0].Rows[0]["SubTitle"].ToString();
                model.KeyWord = ds.Tables[0].Rows[0]["KeyWord"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.CopyFrom = ds.Tables[0].Rows[0]["CopyFrom"].ToString();
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                model.Users = ds.Tables[0].Rows[0]["Users"].ToString();
                model.Editor = ds.Tables[0].Rows[0]["Editor"].ToString();
                if (ds.Tables[0].Rows[0]["Hits"].ToString() != "")
                {
                    model.Hits = int.Parse(ds.Tables[0].Rows[0]["Hits"].ToString());
                }
                model.Introduction = ds.Tables[0].Rows[0]["Introduction"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsTop"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsTop"].ToString().ToLower() == "true"))
                    {
                        model.IsTop = true;
                    }
                    else
                    {
                        model.IsTop = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsElite"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsElite"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsElite"].ToString().ToLower() == "true"))
                    {
                        model.IsElite = true;
                    }
                    else
                    {
                        model.IsElite = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsPic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsPic"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsPic"].ToString().ToLower() == "true"))
                    {
                        model.IsPic = true;
                    }
                    else
                    {
                        model.IsPic = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsPageType"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsPageType"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsPageType"].ToString().ToLower() == "true"))
                    {
                        model.IsPageType = true;
                    }
                    else
                    {
                        model.IsPageType = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                model.Area = ds.Tables[0].Rows[0]["Area"].ToString();
                model.Property = ds.Tables[0].Rows[0]["Property"].ToString();
                model.ImagesAddress = ds.Tables[0].Rows[0]["ImagesAddress"].ToString();
                if (ds.Tables[0].Rows[0]["ImagesSoure"].ToString() != "")
                {
                    model.ImagesSoure = int.Parse(ds.Tables[0].Rows[0]["ImagesSoure"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BrowseCount"].ToString() != "")
                {
                    model.BrowseCount = int.Parse(ds.Tables[0].Rows[0]["BrowseCount"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.Article> GetAllByWhere(string strWhere)
        {
            List<ShowShop.Model.SystemInfo.Article> list = new List<ShowShop.Model.SystemInfo.Article>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Channel,Title,SubTitle,KeyWord,Content,CopyFrom,LinkUrl,Author,Users,Editor,Hits,Introduction,CreateTime,UpdateTime,IsTop,IsElite,IsPic,IsPageType,State,Area,Property,ImagesAddress,ImagesSoure,BrowseCount from yxs_Article  ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }

            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.SystemInfo.Article model = new ShowShop.Model.SystemInfo.Article();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Channel = reader["Channel"].ToString();
                    model.Title = reader["Title"].ToString();
                    model.SubTitle = reader["SubTitle"].ToString();
                    model.KeyWord = reader["KeyWord"].ToString();
                    model.Content = reader["Content"].ToString();
                    model.CopyFrom = reader["CopyFrom"].ToString();
                    model.LinkUrl = reader["LinkUrl"].ToString();
                    model.Author = reader["Author"].ToString();
                    model.Users = reader["Users"].ToString();
                    model.Editor = reader["Editor"].ToString();
                    model.Hits = Convert.ToInt32(reader["Hits"]);
                    model.Introduction = reader["Introduction"].ToString();
                    model.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                    model.UpdateTime = Convert.ToDateTime(reader["UpdateTime"]);
                    model.IsTop = Convert.ToBoolean(reader["IsTop"]);
                    model.IsElite = Convert.ToBoolean(reader["IsElite"]);
                    model.IsPic = Convert.ToBoolean(reader["IsPic"]);
                    model.IsPageType = Convert.ToBoolean(reader["IsPageType"]);
                    model.State = Convert.ToInt32(reader["State"]);
                    model.Area = reader["Area"].ToString();
                    model.Property = reader["Property"].ToString();
                    model.ImagesAddress = reader["ImagesAddress"].ToString();
                    model.ImagesSoure = Convert.ToInt32(reader["ImagesSoure"].ToString());
                    model.BrowseCount = Convert.ToInt32(reader["BrowseCount"].ToString());
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据条件得到列表的前几条数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.Article> GetAllByWhere(int len, string strWhere)
        {
            List<ShowShop.Model.SystemInfo.Article> list = new List<ShowShop.Model.SystemInfo.Article>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + len.ToString() + " Id,Channel,Title,SubTitle,KeyWord,Content,CopyFrom,LinkUrl,Author,Users,Editor,Hits,Introduction,CreateTime,UpdateTime,IsTop,IsElite,IsPic,IsPageType,State,Area,Property,ImagesAddress,ImagesSoure,BrowseCount from yxs_Article  ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }

            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.SystemInfo.Article model = new ShowShop.Model.SystemInfo.Article();
                    model.Id = Convert.ToInt32(reader["Id"]);
                    model.Channel = reader["Channel"].ToString();
                    model.Title = reader["Title"].ToString();
                    model.SubTitle = reader["SubTitle"].ToString();
                    model.KeyWord = reader["KeyWord"].ToString();
                    model.Content = reader["Content"].ToString();
                    model.CopyFrom = reader["CopyFrom"].ToString();
                    model.LinkUrl = reader["LinkUrl"].ToString();
                    model.Author = reader["Author"].ToString();
                    model.Users = reader["Users"].ToString();
                    model.Editor = reader["Editor"].ToString();
                    model.Hits = Convert.ToInt32(reader["Hits"]);
                    model.Introduction = reader["Introduction"].ToString();
                    model.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                    model.UpdateTime = Convert.ToDateTime(reader["UpdateTime"]);
                    model.IsTop = Convert.ToBoolean(reader["IsTop"]);
                    model.IsElite = Convert.ToBoolean(reader["IsElite"]);
                    model.IsPic = Convert.ToBoolean(reader["IsPic"]);
                    model.IsPageType = Convert.ToBoolean(reader["IsPageType"]);
                    model.State = Convert.ToInt32(reader["State"]);
                    model.Area = reader["Area"].ToString();
                    model.Property = reader["Property"].ToString();
                    model.ImagesAddress = reader["ImagesAddress"].ToString();
                    model.ImagesSoure = Convert.ToInt32(reader["ImagesSoure"].ToString());
                    model.BrowseCount = Convert.ToInt32(reader["BrowseCount"].ToString());
                    list.Add(model);
                }
            }
            return list;
        }

        #endregion  成员方法
    }
}

