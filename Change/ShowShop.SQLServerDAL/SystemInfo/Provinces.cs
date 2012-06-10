using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.SystemInfo;
using System.Web;
namespace ShowShop.SQLServerDAL.SystemInfo
{
    /// <summary>
    /// 数据访问类Provinces。
    /// </summary>
    public class Provinces : IProvinces
    {
        public Provinces()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.Provinces model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_Provinces(");
            strSql.Append("CityName,CityEnglishName,ParentId,ParentPath,Depth,OrderID,Child,IsUse,AddDate)");
            strSql.Append(" values (");
            strSql.Append("@CityName,@CityEnglishName,@ParentId,@ParentPath,@Depth,@OrderID,@Child,@IsUse,@AddDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityEnglishName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ParentPath", SqlDbType.VarChar,50),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Child", SqlDbType.Int,4),
					new SqlParameter("@IsUse", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime)};
            parameters[0].Value = model.CityName;
            parameters[1].Value = model.CityEnglishName;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.ParentPath;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.OrderID;
            parameters[6].Value = model.Child;
            parameters[7].Value = model.IsUse;
            parameters[8].Value = model.AddDate;

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
        public void Update(ShowShop.Model.SystemInfo.Provinces model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_Provinces set ");
            strSql.Append("CityName=@CityName,");
            strSql.Append("CityEnglishName=@CityEnglishName,");
            strSql.Append("Child=@Child,");
            strSql.Append("IsUse=@IsUse,");
            strSql.Append("AddDate=@AddDate");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityEnglishName", SqlDbType.NVarChar,50),
					new SqlParameter("@Child", SqlDbType.Int,4),
					new SqlParameter("@IsUse", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.CityName;
            parameters[2].Value = model.CityEnglishName;
            parameters[3].Value = model.Child;
            parameters[4].Value = model.IsUse;
            parameters[5].Value = model.AddDate;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_Provinces ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.Provinces GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CityName,CityEnglishName,ParentId,ParentPath,Depth,OrderID,Child,IsUse,AddDate from yxs_Provinces ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ShowShop.Model.SystemInfo.Provinces model = new ShowShop.Model.SystemInfo.Provinces();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
                model.CityEnglishName = ds.Tables[0].Rows[0]["CityEnglishName"].ToString();
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                model.ParentPath = ds.Tables[0].Rows[0]["ParentPath"].ToString();
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Child"].ToString() != "")
                {
                    model.Child = int.Parse(ds.Tables[0].Rows[0]["Child"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsUse"].ToString() != "")
                {
                    model.IsUse = int.Parse(ds.Tables[0].Rows[0]["IsUse"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_Provinces [where] 1=1 [order by] OrderID asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        public string GetToolBar(int id)
        {
            StringBuilder toolbar = new StringBuilder();
            toolbar.AppendLine("<a href='?w_d_parentid=0'>省、直辖市</a>");
            string sql = "select ParentPath from yxs_Provinces where id='"+id+"'";
            string parentPath = ChangeHope.Common.StringHelper.ToString(ChangeHope.DataBase.SQLServerHelper.GetSingle(sql));
            sql = "select id,cityname from yxs_Provinces where id in('" + (parentPath.Replace(",", "','")) + "') or id='"+id+"' order by Depth";
            System.Data.SqlClient.SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sql);
            while(reader.Read())
            {
                toolbar.AppendFormat(">> <a href='?w_d_parentid={0}'>{1}</a>  ", reader["id"], reader["cityname"]);
            }
            toolbar.Append(" | <a href='area_setting_edit.aspx?parentid="+id+"'>添加同目录城市</a>");
            reader.Close();
            reader.Dispose();
            reader = null;
            return toolbar.ToString();
        }

        public int GetChildCount(string id)
        {
            string sql = "select count(*) from yxs_Provinces where parentid='"+id+"'";
            return ChangeHope.Common.StringHelper.StringToInt(ChangeHope.DataBase.SQLServerHelper.GetSingle(sql).ToString());
        }

        public System.Data.SqlClient.SqlDataReader GetChidNode(string parentid)
        {
            string sql = "select id,cityname from yxs_provinces where ParentId='" + parentid + "'";
            System.Data.SqlClient.SqlDataReader reader= ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sql);
            return reader;
        }

        public DataTable GetChid(string parentid)
        {
            string strSql = "select * from yxs_provinces where ParentId=@ParentId";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@ParentId", SqlDbType.Int, 4);
            paras[0].Value = parentid;
            return ChangeHope.DataBase.SQLServerHelper.Query(strSql, paras).Tables[0];
        }

        public DataTable ProvincesStr(string IdStr)
        {
            string strSql = "select Id,CityName,CityEnglishName,ParentId,ParentPath,Depth,OrderID,Child,IsUse,AddDate from yxs_Provinces where Id in (" + IdStr + ")";
            return ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0];
        }
        
        #endregion  成员方法
    }
}

