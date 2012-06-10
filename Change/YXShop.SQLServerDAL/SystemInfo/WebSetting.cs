using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.SystemInfo;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    /// <summary>
    /// 数据访问类WebSetting。
    /// </summary>
    public class WebSetting : IWebSetting
    {
        public WebSetting()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.WebSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_websetting(");
            strSql.Append("websitetitle,tel,fax,email,websitepath,logopath,bannerpath,copyright,metekey,meteinfo,publicmethod,closewebsite,closewebsiteinfo,closebbs,closebbsinfo,websitename,closeshop,closestation,websitedomain,usersagreement,loginmothod,staticpagefiletype,tmplatepath,statisticscode,filesize)");
            strSql.Append(" values (");
            strSql.Append("@websitetitle,@tel,@fax,@email,@websitepath,@logopath,@bannerpath,@copyright,@metekey,@meteinfo,@publicmethod,@closewebsite,@closewebsiteinfo,@closebbs,@closebbsinfo,@websitename,@closeshop,@closestation,@websitedomain,@usersagreement,@loginmothod,@staticpagefiletype,@tmplatepath,@statisticscode,@filesize)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@websitetitle", SqlDbType.VarChar,1000),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@fax", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@websitepath", SqlDbType.VarChar,50),
					new SqlParameter("@logopath", SqlDbType.VarChar,50),
					new SqlParameter("@bannerpath", SqlDbType.VarChar,50),
					new SqlParameter("@copyright", SqlDbType.NVarChar,1000),
					new SqlParameter("@metekey", SqlDbType.VarChar,1000),
					new SqlParameter("@meteinfo", SqlDbType.VarChar,1000),
					new SqlParameter("@publicmethod", SqlDbType.Int,4),
					new SqlParameter("@closewebsite", SqlDbType.Int,4),
					new SqlParameter("@closewebsiteinfo", SqlDbType.VarChar,1000),
					new SqlParameter("@closebbs", SqlDbType.Int,4),
					new SqlParameter("@closebbsinfo", SqlDbType.VarChar,1000),
					new SqlParameter("@websitename", SqlDbType.VarChar,1000),
					new SqlParameter("@closeshop", SqlDbType.Int,4),
					new SqlParameter("@closestation", SqlDbType.Int,4),
					new SqlParameter("@websitedomain", SqlDbType.VarChar,200),
					new SqlParameter("@usersagreement", SqlDbType.Text),
					new SqlParameter("@loginmothod", SqlDbType.Int,4),
					new SqlParameter("@staticpagefiletype", SqlDbType.VarChar,20),
					new SqlParameter("@tmplatepath", SqlDbType.VarChar,200),
                    new SqlParameter("@statisticscode", SqlDbType.VarChar,200),//
                    new SqlParameter("@filesize", SqlDbType.Int,4)};//
            parameters[0].Value = model.WebSiteTitle;
            parameters[1].Value = model.Tel;
            parameters[2].Value = model.Fax;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.WebSitePath;
            parameters[5].Value = model.LogoPath;
            parameters[6].Value = model.BannerPath;
            parameters[7].Value = model.CopyRight;
            parameters[8].Value = model.MeteKey;
            parameters[9].Value = model.MeteInfo;
            parameters[10].Value = model.PublicMethod;
            parameters[11].Value = model.CloseWebSite;
            parameters[12].Value = model.CloseWebSiteInfo;
            parameters[13].Value = model.CloseBBS;
            parameters[14].Value = model.CloseBBSInfo;
            parameters[15].Value = model.WebSiteName;
            parameters[16].Value = model.CloseShop;
            parameters[17].Value = model.CloseStation;
            parameters[18].Value = model.WebSiteDomain;
            parameters[19].Value = model.UsersAgreement;
            parameters[20].Value = model.LoginMothod;
            parameters[21].Value = model.StaticPageFileType;
            parameters[22].Value = model.TmplatePath;
            parameters[23].Value = model.Statisticscode;//
            parameters[24].Value = model.Filesize;//

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
        public void Update(ShowShop.Model.SystemInfo.WebSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_websetting set ");
            strSql.Append("websitetitle=@websitetitle,");
            strSql.Append("tel=@tel,");
            strSql.Append("fax=@fax,");
            strSql.Append("email=@email,");
            strSql.Append("websitepath=@websitepath,");
            strSql.Append("logopath=@logopath,");
            strSql.Append("bannerpath=@bannerpath,");
            strSql.Append("copyright=@copyright,");
            strSql.Append("metekey=@metekey,");
            strSql.Append("meteinfo=@meteinfo,");
            strSql.Append("publicmethod=@publicmethod,");
            strSql.Append("closewebsite=@closewebsite,");
            strSql.Append("closewebsiteinfo=@closewebsiteinfo,");
            strSql.Append("closebbs=@closebbs,");
            strSql.Append("closebbsinfo=@closebbsinfo,");
            strSql.Append("websitename=@websitename,");
            strSql.Append("closeshop=@closeshop,");
            strSql.Append("closestation=@closestation,");
            strSql.Append("websitedomain=@websitedomain,");
            strSql.Append("usersagreement=@usersagreement,");
            strSql.Append("loginmothod=@loginmothod,");
            strSql.Append("staticpagefiletype=@staticpagefiletype,");
            strSql.Append("tmplatepath=@tmplatepath,");
            strSql.Append("statisticscode=@statisticscode,");//
            strSql.Append("filesize=@filesize");//
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@websitetitle", SqlDbType.VarChar,1000),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@fax", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@websitepath", SqlDbType.VarChar,50),
					new SqlParameter("@logopath", SqlDbType.VarChar,50),
					new SqlParameter("@bannerpath", SqlDbType.VarChar,50),
					new SqlParameter("@copyright", SqlDbType.NVarChar,1000),
					new SqlParameter("@metekey", SqlDbType.VarChar,1000),
					new SqlParameter("@meteinfo", SqlDbType.VarChar,1000),
					new SqlParameter("@publicmethod", SqlDbType.Int,4),
					new SqlParameter("@closewebsite", SqlDbType.Int,4),
					new SqlParameter("@closewebsiteinfo", SqlDbType.VarChar,1000),
					new SqlParameter("@closebbs", SqlDbType.Int,4),
					new SqlParameter("@closebbsinfo", SqlDbType.VarChar,1000),
					new SqlParameter("@websitename", SqlDbType.VarChar,1000),
					new SqlParameter("@closeshop", SqlDbType.Int,4),
					new SqlParameter("@closestation", SqlDbType.Int,4),
					new SqlParameter("@websitedomain", SqlDbType.VarChar,200),
					new SqlParameter("@usersagreement", SqlDbType.Text),
					new SqlParameter("@loginmothod", SqlDbType.Int,4),
					new SqlParameter("@staticpagefiletype", SqlDbType.VarChar,20),
					new SqlParameter("@tmplatepath", SqlDbType.VarChar,200),
                    new SqlParameter("@statisticscode", SqlDbType.VarChar,200),//
                    new SqlParameter("@filesize", SqlDbType.Int,4)};//
            parameters[0].Value = model.Id;
            parameters[1].Value = model.WebSiteTitle;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Fax;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.WebSitePath;
            parameters[6].Value = model.LogoPath;
            parameters[7].Value = model.BannerPath;
            parameters[8].Value = model.CopyRight;
            parameters[9].Value = model.MeteKey;
            parameters[10].Value = model.MeteInfo;
            parameters[11].Value = model.PublicMethod;
            parameters[12].Value = model.CloseWebSite;
            parameters[13].Value = model.CloseWebSiteInfo;
            parameters[14].Value = model.CloseBBS;
            parameters[15].Value = model.CloseBBSInfo;
            parameters[16].Value = model.WebSiteName;
            parameters[17].Value = model.CloseShop;
            parameters[18].Value = model.CloseStation;
            parameters[19].Value = model.WebSiteDomain;
            parameters[20].Value = model.UsersAgreement;
            parameters[21].Value = model.LoginMothod;
            parameters[22].Value = model.StaticPageFileType;
            parameters[23].Value = model.TmplatePath;
            parameters[24].Value = model.Statisticscode;
            parameters[25].Value = model.Filesize;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
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
            string sequel = "Update yxs_websetting set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + " Where [id] = @id"; ;
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Value", value),
                new SqlParameter("@id", id) 
            };
            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, paras);
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
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_websetting ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.WebSetting GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,websitetitle,tel,fax,email,websitepath,logopath,bannerpath,copyright,metekey,meteinfo,publicmethod,closewebsite,closewebsiteinfo,closebbs,closebbsinfo,websitename,closeshop,closestation,websitedomain,usersagreement,loginmothod,staticpagefiletype,tmplatepath,statisticscode,filesize from yxs_websetting ");
            

            ShowShop.Model.SystemInfo.WebSetting model = new ShowShop.Model.SystemInfo.WebSetting();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.WebSiteTitle = ds.Tables[0].Rows[0]["websitetitle"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["fax"].ToString();
                model.Email = ds.Tables[0].Rows[0]["email"].ToString();
                model.WebSitePath = ds.Tables[0].Rows[0]["websitepath"].ToString();
                model.LogoPath = ds.Tables[0].Rows[0]["logopath"].ToString();
                model.BannerPath = ds.Tables[0].Rows[0]["bannerpath"].ToString();
                model.CopyRight = ds.Tables[0].Rows[0]["copyright"].ToString();
                model.MeteKey = ds.Tables[0].Rows[0]["metekey"].ToString();
                model.MeteInfo = ds.Tables[0].Rows[0]["meteinfo"].ToString();
                model.Statisticscode = ds.Tables[0].Rows[0]["statisticscode"].ToString();//
                if (ds.Tables[0].Rows[0]["filesize"].ToString() != "")//
                {
                    model.Filesize = int.Parse(ds.Tables[0].Rows[0]["filesize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["publicmethod"].ToString() != "")
                {
                    model.PublicMethod = int.Parse(ds.Tables[0].Rows[0]["publicmethod"].ToString());
                }
                if (ds.Tables[0].Rows[0]["closewebsite"].ToString() != "")
                {
                    model.CloseWebSite = int.Parse(ds.Tables[0].Rows[0]["closewebsite"].ToString());
                }
                model.CloseWebSiteInfo = ds.Tables[0].Rows[0]["closewebsiteinfo"].ToString();
                if (ds.Tables[0].Rows[0]["closebbs"].ToString() != "")
                {
                    model.CloseBBS = int.Parse(ds.Tables[0].Rows[0]["closebbs"].ToString());
                }
                model.CloseBBSInfo = ds.Tables[0].Rows[0]["closebbsinfo"].ToString();
                model.WebSiteName = ds.Tables[0].Rows[0]["websitename"].ToString();
                if (ds.Tables[0].Rows[0]["closeshop"].ToString() != "")
                {
                    model.CloseShop = int.Parse(ds.Tables[0].Rows[0]["closeshop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["closestation"].ToString() != "")
                {
                    model.CloseStation = int.Parse(ds.Tables[0].Rows[0]["closestation"].ToString());
                }
                model.WebSiteDomain = ds.Tables[0].Rows[0]["websitedomain"].ToString();
                model.UsersAgreement = ds.Tables[0].Rows[0]["usersagreement"].ToString();
                if (ds.Tables[0].Rows[0]["loginmothod"].ToString() != "")
                {
                    model.LoginMothod = int.Parse(ds.Tables[0].Rows[0]["loginmothod"].ToString());
                }
                model.StaticPageFileType = ds.Tables[0].Rows[0]["staticpagefiletype"].ToString();
                model.TmplatePath = ds.Tables[0].Rows[0]["tmplatepath"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        
        #endregion  成员方法
    }
}

