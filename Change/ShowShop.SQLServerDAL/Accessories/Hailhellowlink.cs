using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Accessories;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Accessories
{
    /// <summary>
    /// 友情链接数据访问层
    /// </summary>
    public class Hailhellowlink:IHailhellowlink
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加一条新的友情链接
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.Hailhellowlink model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_hailhellowlink(");
            strSql.Append("[sitename],[siteurl],[sitelogo],[sitelevel],[sitecontent],[sitelinktype],[sitestate],[siteclickcount],[createdate],[updatedate],[putoutid],[putouttyid],[aread])");
            strSql.Append(" values (");
            strSql.Append("@sitename,@siteurl,@sitelogo,@sitelevel,@sitecontent,@sitelinktype,@sitestate,@siteclickcount,@createdate,@updatedate,@putoutid,@putouttyid,@aread)");
            strSql.Append(";select @@IDENTITY");
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), paras);
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
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_hailhellowlink ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        public void DeleteAll(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_hailhellowlink ");
            strSql.Append(" where [id] in("+ids+" )");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.Hailhellowlink model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_hailhellowlink set ");
            strSql.Append("[sitename]=@sitename,");
            strSql.Append("[siteurl]=@siteurl,");
            strSql.Append("[sitelogo]=@sitelogo,");
            strSql.Append("[sitelevel]=@sitelevel,");
            strSql.Append("[sitecontent]=@sitecontent,");
            strSql.Append("[sitelinktype]=@sitelinktype,");
            strSql.Append("[sitestate]=@sitestate,");
            strSql.Append("[siteclickcount]=@siteclickcount,");
            strSql.Append("[createdate]=@createdate,");
            strSql.Append("[updatedate]=@updatedate,");
            strSql.Append("[putoutid]=@putoutid,");
            strSql.Append("[putouttyid]=@putouttyid,");
            strSql.Append("[aread]=@aread");
            //strSql.Append("[siteimages]=@siteimages");//
            strSql.Append(" where [id]=@id ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }


        /// <summary>
        /// 更新任意一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            string sequel = "Update [yxs_hailhellowlink] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Value", value),
                new SqlParameter("@id", id) 
            };
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
        #endregion

        #region "Data Load"
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.Accessories.Hailhellowlink GetModelByID(int id)
        {
            ShowShop.Model.Accessories.Hailhellowlink model = new ShowShop.Model.Accessories.Hailhellowlink();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[sitename],[siteurl],[sitelogo],[sitelevel],[sitecontent],[sitelinktype],[sitestate],[siteclickcount],[createdate],[updatedate],[putoutid],[putouttyid],[aread] from yxs_hailhellowlink ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.SiteName = reader.GetString(1);
                    model.SiteUrl = reader.GetString(2);
                    model.SiteLogo = reader.GetString(3);
                    model.SiteLevel = reader.GetInt32(4);
                    model.SiteContent = reader.GetString(5);
                    model.SiteLinkType = reader.GetInt32(6);
                    model.SiteState = reader.GetInt32(7);
                    model.SiteClickCount = reader.GetInt32(8);
                    model.CreateDate = reader.GetDateTime(9);
                    model.UpdateDate = reader.GetDateTime(10);
                    model.PutoutID = reader.GetInt32(11);
                    model.PutoutTyID = reader.GetInt32(12);
                    model.Aread = reader.GetString(13);
                    //model.SiteImages = reader.GetString(14);//
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.Hailhellowlink> GetAll()
        {
            List<ShowShop.Model.Accessories.Hailhellowlink> list = new List<ShowShop.Model.Accessories.Hailhellowlink>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[sitename],[siteurl],[sitelogo],[sitelevel],[sitecontent],[sitelinktype],[sitestate],[siteclickcount],[createdate],[updatedate],[putoutid],[putouttyid],[aread] from yxs_hailhellowlink ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Accessories.Hailhellowlink model = new ShowShop.Model.Accessories.Hailhellowlink();
                    model.ID = reader.GetInt32(0);
                    model.SiteName = reader.GetString(1);
                    model.SiteUrl = reader.GetString(2);
                    model.SiteLogo = reader.GetString(3);
                    model.SiteLevel = reader.GetInt32(4);
                    model.SiteContent = reader.GetString(5);
                    model.SiteLinkType = reader.GetInt32(6);
                    model.SiteState = reader.GetInt32(7);
                    model.SiteClickCount = reader.GetInt32(8);
                    model.CreateDate = reader.GetDateTime(9);
                    model.UpdateDate = reader.GetDateTime(10);
                    model.PutoutID = reader.GetInt32(11);
                    model.PutoutTyID = reader.GetInt32(12);
                    model.Aread = reader.GetString(13);
                    list.Add(model);
                }
            }
            return list;

        }

        /// <summary>
        /// 得到所有记录
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_hailhellowlink [where] 1=1 [order by] sitelevel desc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 前台标签所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_hailhellowlink [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion

        #region "Other function"

        /// <summary>
        /// 更新条件
        /// </summary>
        protected string UpdateWhereSequel
        {
            get
            {
                return " Where [id] = @id";
            }
        }

        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>
        public IDbDataParameter[] ValueParas(ShowShop.Model.Accessories.Hailhellowlink model)
        {
            SqlParameter[] paras = new SqlParameter[14];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@sitename", SqlDbType.VarChar, 100);
            paras[1].Value = model.SiteName;
            paras[2] = new SqlParameter("@siteurl", SqlDbType.VarChar, 100);
            paras[2].Value = model.SiteUrl;
            paras[3] = new SqlParameter("@sitelogo", SqlDbType.VarChar, 100);
            paras[3].Value = model.SiteLogo;
            paras[4] = new SqlParameter("@sitelevel", SqlDbType.Int, 4);
            paras[4].Value = model.SiteLevel;
            paras[5] = new SqlParameter("@sitecontent", SqlDbType.VarChar, 1000);
            paras[5].Value = model.SiteContent;
            paras[6] = new SqlParameter("@sitelinktype", SqlDbType.Int, 4);
            paras[6].Value = model.SiteLinkType;
            paras[7] = new SqlParameter("@sitestate", SqlDbType.Int, 4);
            paras[7].Value = model.SiteState;
            paras[8] = new SqlParameter("@siteclickcount", SqlDbType.Int, 4);
            paras[8].Value = model.SiteClickCount;
            paras[9] = new SqlParameter("@createdate", SqlDbType.DateTime);
            paras[9].Value = model.CreateDate; ;
            paras[10] = new SqlParameter("@updatedate", SqlDbType.DateTime);
            paras[10].Value = model.UpdateDate;
            paras[11] = new SqlParameter("@putoutid", SqlDbType.Int, 4);
            paras[11].Value = model.PutoutID;
            paras[12] = new SqlParameter("@putouttyid", SqlDbType.Int, 4);
            paras[12].Value = model.PutoutTyID;
            paras[13] = new SqlParameter("@aread", SqlDbType.VarChar, 50);
            paras[13].Value = model.Aread==null?"0":model.Aread;
            //paras[14] = new SqlParameter("@siteimages", SqlDbType.VarChar, 200);//
            //paras[14].Value = model.SiteImages;//
            return paras;
        }

        /// <summary>
        /// 主键参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDbDataParameter[] ValueIDPara(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@id", id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }

        #endregion
    }
}
