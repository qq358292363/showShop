using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.SystemInfo;
using System.Collections;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    /// <summary>
    /// 数据访问类ArticleChannel。
    /// </summary>
    public class ArticleChannel : IArticleChannel
    {
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_articlechannel");
            strSql.Append(" where Id like +'" + id.ToString() + "'+'_%' ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_articlechannel");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,50)};
            parameters[0].Value = Id;

            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }
        public string GetMaxId(string parentid)
        {
            if (parentid.Length % 3 != 0)
            {
                parentid = "";
            }
            string sql = "select max(id+1) from yxs_articlechannel where id like '" + parentid + "%' and len(id)=" + (parentid.Length + 3);
            string  maxid = ChangeHope.Common.StringHelper.ToString(ChangeHope.DataBase.SQLServerHelper.GetSingle(sql));
            if (maxid.Length<=0)
            {
                maxid = parentid + "100";
            }
            return maxid;
        }
        public SortedList GetChannel(string id)
        {
            SortedList chanel = new SortedList();
            chanel.Add("", "资讯频道");
            string sql = "select * from yxs_articlechannel where 1=0 ";
            if (id.Length > 0 && id.Length % 3 == 0)
            {
                for (int i = 0; i < id.Length/3;i++ )
                {
                    sql += " or Id ='"+ChangeHope.Common.StringHelper.SubString(id,(i+1)*3)+"'";
                }
            }
            sql += " order by id";
            System.Data.SqlClient.SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sql);
            if (reader!=null)
            {
                while(reader.Read())
                {
                    chanel.Add(reader["id"].ToString(), reader["name"].ToString());
                }
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            return chanel;
        }
        public SortedList GetChildChannel(string id)
        {
            SortedList chanel = new SortedList();
            string sql = "select * from yxs_articlechannel where id like '"+id+"%' and len(id)="+(id.Length+3);
            sql += " order by id";
            System.Data.SqlClient.SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sql);
            if (reader != null)
            {
                while (reader.Read())
                {
                    chanel.Add(reader["id"].ToString(), reader["name"].ToString());
                }
            }
            reader.Close();
            reader.Dispose();
            reader = null;
            return chanel;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ShowShop.Model.SystemInfo.ArticleChannel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_articlechannel(");
            strSql.Append("Id,Name,Shop,Users,Description,Type,ProjectName,ProjectUtil,Target,ExternalLink,MeteKey,MeteDescription,Power,[DefaultTemplate], [ListTemplate], [ContentTemplate])");
            strSql.Append(" values (");
            strSql.Append("@Id,@Name,@Shop,@Users,@Description,@Type,@ProjectName,@ProjectUtil,@Target,@ExternalLink,@MeteKey,@MeteDescription,@Power,@DefaultTemplate, @ListTemplate, @ContentTemplate)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.VarChar,500),
                    new SqlParameter("@Name", SqlDbType.VarChar,500),
                    new SqlParameter("@Shop", SqlDbType.VarChar,50),
                    new SqlParameter("@Users", SqlDbType.VarChar,50),
                    new SqlParameter("@Description", SqlDbType.VarChar,5000),
                    new SqlParameter("@Type", SqlDbType.VarChar,50),
                    new SqlParameter("@ProjectName", SqlDbType.VarChar,50),
                    new SqlParameter("@ProjectUtil", SqlDbType.VarChar,50),
                    new SqlParameter("@Target", SqlDbType.VarChar,50),
                    new SqlParameter("@ExternalLink", SqlDbType.VarChar,500),
                    new SqlParameter("@MeteKey", SqlDbType.VarChar,500),
                    new SqlParameter("@MeteDescription", SqlDbType.VarChar,5000),
                    new SqlParameter("@Power", SqlDbType.VarChar,50),
            new SqlParameter("@DefaultTemplate", SqlDbType.VarChar,100),
            new SqlParameter("@ListTemplate", SqlDbType.VarChar,100),
            new SqlParameter("@ContentTemplate", SqlDbType.VarChar,100)
                                        };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Shop;
            parameters[3].Value = model.Users;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.ProjectName;
            parameters[7].Value = model.ProjectUtil;
            parameters[8].Value = model.Target;
            parameters[9].Value = model.ExternalLink;
            parameters[10].Value = model.MeteKey;
            parameters[11].Value = model.MeteDescription;
            parameters[12].Value = model.Power;
            parameters[13].Value = model.DefaultTemplate;
            parameters[14].Value = model.ListTemplate;
            parameters[15].Value = model.ContentTemplate;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.SystemInfo.ArticleChannel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_articlechannel set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Shop=@Shop,");
            strSql.Append("Users=@Users,");
            strSql.Append("Description=@Description,");
            strSql.Append("Type=@Type,");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("ProjectUtil=@ProjectUtil,");
            strSql.Append("Target=@Target,");
            strSql.Append("ExternalLink=@ExternalLink,");
            strSql.Append("MeteKey=@MeteKey,");
            strSql.Append("MeteDescription=@MeteDescription,");
            strSql.Append("Power=@Power,");
            strSql.Append("DefaultTemplate=@DefaultTemplate,");
            strSql.Append("ListTemplate=@ListTemplate,");
            strSql.Append("ContentTemplate=@ContentTemplate");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,500),
					new SqlParameter("@Name", SqlDbType.VarChar,500),
					new SqlParameter("@Shop", SqlDbType.VarChar,50),
					new SqlParameter("@Users", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,5000),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectUtil", SqlDbType.VarChar,50),
					new SqlParameter("@Target", SqlDbType.VarChar,50),
					new SqlParameter("@ExternalLink", SqlDbType.VarChar,500),
					new SqlParameter("@MeteKey", SqlDbType.VarChar,500),
					new SqlParameter("@MeteDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@Power", SqlDbType.VarChar,50),
                                        new SqlParameter("@DefaultTemplate", SqlDbType.VarChar,100),
                                        new SqlParameter("@ListTemplate", SqlDbType.VarChar,100),
                                        new SqlParameter("@ContentTemplate", SqlDbType.VarChar,100)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Shop;
            parameters[3].Value = model.Users;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.ProjectName;
            parameters[7].Value = model.ProjectUtil;
            parameters[8].Value = model.Target;
            parameters[9].Value = model.ExternalLink;
            parameters[10].Value = model.MeteKey;
            parameters[11].Value = model.MeteDescription;
            parameters[12].Value = model.Power;
            parameters[13].Value = model.DefaultTemplate;
            parameters[14].Value = model.ListTemplate;
            parameters[15].Value = model.ContentTemplate;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_articlechannel ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,50)};
            parameters[0].Value = Id;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.ArticleChannel GetModel(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Shop,Users,Description,Type,ProjectName,ProjectUtil,Target,ExternalLink,MeteKey,MeteDescription,Power,[DefaultTemplate], [ListTemplate], [ContentTemplate] from yxs_articlechannel ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,50)};
            parameters[0].Value = Id;

            ShowShop.Model.SystemInfo.ArticleChannel model = new ShowShop.Model.SystemInfo.ArticleChannel();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Shop = ds.Tables[0].Rows[0]["Shop"].ToString();
                model.Users = ds.Tables[0].Rows[0]["Users"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                model.ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                model.ProjectUtil = ds.Tables[0].Rows[0]["ProjectUtil"].ToString();
                model.Target = ds.Tables[0].Rows[0]["Target"].ToString();
                model.ExternalLink = ds.Tables[0].Rows[0]["ExternalLink"].ToString();
                model.MeteKey = ds.Tables[0].Rows[0]["MeteKey"].ToString();
                model.MeteDescription = ds.Tables[0].Rows[0]["MeteDescription"].ToString();
                model.Power = ds.Tables[0].Rows[0]["Power"].ToString();
                model.DefaultTemplate = ds.Tables[0].Rows[0]["DefaultTemplate"].ToString();
                model.ListTemplate = ds.Tables[0].Rows[0]["ListTemplate"].ToString();
                model.ContentTemplate = ds.Tables[0].Rows[0]["ContentTemplate"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///  暂时屏蔽删除
        ///  <a href='javascript:void(0)' onclick='Del({0})'>删除</a>
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            string chanelid = ChangeHope.WebPage.PageRequest.GetString("q_chanelid");
            ChangeHope.WebPage.DataView dataview = new ChangeHope.WebPage.DataView();
            dataview.RowHead = "序号/5%,频道名称/10%,描述/45%,是否系统频道/15%,操作/25%";
            dataview.Sql = "[select] * [from] yxs_ArticleChannel [where] Id like '" + chanelid + "%' and LEN(Id) =" + (chanelid.Length + 3) + " [order by] Id asc";
            dataview.RowText = "{0}$@allnum,<a href=?q_chanelid={1}>{0}</a>$Name|Id,Description,Shop,<a href='articlechannel_edit.aspx?id={0}'>编辑</a> <a href='javascript:void(0)' onclick='Del({0})'>删除</a> $Id";
            string view = dataview.GetView();
            dataview = null;
            return view;
        }

        /// <summary>
        /// 根据条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.ArticleChannel> GetAllByWhere(string strWhere)
        {
            List<ShowShop.Model.SystemInfo.ArticleChannel> list = new List<ShowShop.Model.SystemInfo.ArticleChannel>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,Shop,Users,Description,Type,ProjectName,ProjectUtil,Target,ExternalLink,MeteKey,MeteDescription,Power from yxs_articlechannel  ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }

            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.SystemInfo.ArticleChannel model = new ShowShop.Model.SystemInfo.ArticleChannel();
                    model.Id = reader["Id"].ToString();
                    model.Name = reader["Name"].ToString();
                    model.Shop = reader["Shop"].ToString();
                    model.Users = reader["Users"].ToString();
                    model.Description = reader["Description"].ToString();
                    model.Type = reader["Type"].ToString();
                    model.ProjectName = reader["ProjectName"].ToString();
                    model.ProjectUtil = reader["ProjectUtil"].ToString();
                    model.Target = reader["Target"].ToString();
                    model.ExternalLink = reader["ExternalLink"].ToString();
                    model.MeteKey = reader["MeteKey"].ToString();
                    model.MeteDescription = reader["MeteDescription"].ToString();
                    model.Power = reader["Power"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据ID查询资讯名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetArticleName(string id)
        { 
            string strSql = "select Name from yxs_articlechannel  where Id ='"+id+"'";
            SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString());
            string Name = "";
            while (reader.Read())
            {
               Name = reader["Name"].ToString();
            }
            return Name;
        }


        public SqlDataReader GetAll(string parentid)
        {
            string sql = "select * from yxs_articlechannel  where id like '"+parentid+"%' order by id";
            return ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sql);
        }
        /// <summary>
        /// 排序所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_articlechannel [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        public SqlDataReader GetStairList(string parentid)
        {
            string sql = "select * from yxs_articlechannel where id like '"+parentid+"%' and LEN(Id)< "+(parentid.Length+3)+" order by id";
            return ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sql);
        }
        #endregion  成员方法

        #region Other Faction
        public IDataParameter[] ValueParams(ShowShop.Model.SystemInfo.ArticleChannel model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.VarChar,500),
					new SqlParameter("@Name", SqlDbType.VarChar,500),
					new SqlParameter("@Shop", SqlDbType.VarChar,50),
					new SqlParameter("@Users", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,5000),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectName", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectUtil", SqlDbType.VarChar,50),
					new SqlParameter("@Target", SqlDbType.VarChar,50),
					new SqlParameter("@ExternalLink", SqlDbType.VarChar,500),
					new SqlParameter("@MeteKey", SqlDbType.VarChar,500),
					new SqlParameter("@MeteDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@Power", SqlDbType.VarChar,50),

                    new SqlParameter("@DefaultTemplate",SqlDbType.VarChar,100),
                    new SqlParameter("@ListTemplate",SqlDbType.VarChar,100),
                    new SqlParameter("@ContentTemplate",SqlDbType.VarChar,100),
                    //new SqlParameter("@Topnavigation",SqlDbType.Int,4),
                    //new SqlParameter("@Channelpower",SqlDbType.Int,4),
                    //new SqlParameter("@Custom",SqlDbType.VarChar,1000)
                                        };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Shop;
            parameters[3].Value = model.Users;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.ProjectName;
            parameters[7].Value = model.ProjectUtil;
            parameters[8].Value = model.Target;
            parameters[9].Value = model.ExternalLink;
            parameters[10].Value = model.MeteKey;
            parameters[11].Value = model.MeteDescription;
            parameters[12].Value = model.Power;

            parameters[13].Value = model.DefaultTemplate;
            parameters[14].Value = model.ListTemplate;
            parameters[15].Value = model.ContentTemplate;
            //parameters[16].Value = model.Topnavigation;
            //parameters[17].Value = model.Channelpower;
            //parameters[18].Value = model.Custom;

            return parameters;
        }
        #endregion
    }
}

