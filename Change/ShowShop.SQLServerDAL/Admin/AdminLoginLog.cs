using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Admin;

namespace ShowShop.SQLServerDAL.Admin
{
    /// <summary>
    /// 数据访问类AdminLoginLog。
    /// </summary>
    public class AdminLoginLog : IAdminLoginLog
    {
        public AdminLoginLog()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Admin.AdminLoginLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Adminloginlog(");
            strSql.Append("AdminName,PassWord,LogininTime,LoginoutTime,LoginIP,HostComputerName,OperateNote)");
            strSql.Append(" values (");
            strSql.Append("@AdminName,@PassWord,@LogininTime,@LoginoutTime,@LoginIP,@HostComputerName,@OperateNote)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@LogininTime", SqlDbType.DateTime),
					new SqlParameter("@LoginoutTime", SqlDbType.DateTime),
					new SqlParameter("@LoginIP", SqlDbType.VarChar,50),
					new SqlParameter("@HostComputerName", SqlDbType.VarChar,50),
					new SqlParameter("@OperateNote", SqlDbType.VarChar,4000)};
            parameters[0].Value = model.AdminName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.LoginInTime;
            parameters[3].Value = model.LoginOutTime;
            parameters[4].Value = model.LoginIp;
            parameters[5].Value = model.HostComputerName;
            parameters[6].Value = model.OperateNote;

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
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Adminloginlog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion  成员方法
    }
}

