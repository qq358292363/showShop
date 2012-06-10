using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.SystemInfo;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    /// <summary>
    /// 数据访问类MailSetting。
    /// </summary>
    public class MailSetting : IMailSetting
    {
        public MailSetting()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.MailSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_MailSetting(");
            strSql.Append("SmtpServerIP,SmtpServerPort,MailId,MailPassword)");
            strSql.Append(" values (");
            strSql.Append("@SmtpServerIP,@SmtpServerPort,@MailId,@MailPassword)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SmtpServerIP", SqlDbType.VarChar,50),
					new SqlParameter("@SmtpServerPort", SqlDbType.Int,4),
					new SqlParameter("@MailId", SqlDbType.VarChar,50),
					new SqlParameter("@MailPassword", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SmtpServerIP;
            parameters[1].Value = model.SmtpServerPort;
            parameters[2].Value = model.MailId;
            parameters[3].Value = model.MailPassword;

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
        public void Update(ShowShop.Model.SystemInfo.MailSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_MailSetting set ");
            strSql.Append("SmtpServerIP=@SmtpServerIP,");
            strSql.Append("SmtpServerPort=@SmtpServerPort,");
            strSql.Append("MailId=@MailId,");
            strSql.Append("MailPassword=@MailPassword");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@SmtpServerIP", SqlDbType.VarChar,50),
					new SqlParameter("@SmtpServerPort", SqlDbType.Int,4),
					new SqlParameter("@MailId", SqlDbType.VarChar,50),
					new SqlParameter("@MailPassword", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.SmtpServerIP;
            parameters[2].Value = model.SmtpServerPort;
            parameters[3].Value = model.MailId;
            parameters[4].Value = model.MailPassword;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.MailSetting GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,SmtpServerIP,SmtpServerPort,MailId,MailPassword from yxs_MailSetting ");

            ShowShop.Model.SystemInfo.MailSetting model = new ShowShop.Model.SystemInfo.MailSetting();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.SmtpServerIP = ds.Tables[0].Rows[0]["SmtpServerIP"].ToString();
                if (ds.Tables[0].Rows[0]["SmtpServerPort"].ToString() != "")
                {
                    model.SmtpServerPort = int.Parse(ds.Tables[0].Rows[0]["SmtpServerPort"].ToString());
                }
                model.MailId = ds.Tables[0].Rows[0]["MailId"].ToString();
                model.MailPassword = ds.Tables[0].Rows[0]["MailPassword"].ToString();
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

