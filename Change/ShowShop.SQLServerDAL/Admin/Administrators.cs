using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using ShowShop.IDAL.Admin;

namespace ShowShop.SQLServerDAL.Admin
{
    /// <summary>
    /// 数据访问类Administrators。
    /// </summary>
    public class Administrators : IAdministrators
    {
        public Administrators()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string adminName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Administrators");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50)};
            parameters[0].Value = adminName;
            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Admin.Administrators model)
        {
            if (!Exists(model.Name))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Administrators(");
                strSql.Append("Name,PassWord,State,ManageBeginTime,ManageEndTime,Power,AllowModifyPassWord,Role)");
                strSql.Append(" values (");
                strSql.Append("@Name,@PassWord,@State,@ManageBeginTime,@ManageEndTime,@Power,@AllowModifyPassWord,@Role)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@ManageBeginTime", SqlDbType.DateTime),
					new SqlParameter("@ManageEndTime", SqlDbType.DateTime),
					new SqlParameter("@Power", SqlDbType.TinyInt,1),
					new SqlParameter("@AllowModifyPassWord", SqlDbType.TinyInt,1),
					new SqlParameter("@Role", SqlDbType.VarChar,50)};
                parameters[0].Value = model.Name;
                parameters[1].Value = ChangeHope.Common.DEncryptHelper.Encrypt(model.PassWord,1);
                parameters[2].Value = model.State;
                parameters[3].Value = model.ManageBeginTime;
                parameters[4].Value = model.ManageEndTime;
                parameters[5].Value = model.Power;
                parameters[6].Value = model.AllowModifyPassWord;
                parameters[7].Value = model.Role;

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
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Admin.Administrators model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Administrators set ");
            strSql.Append("Name=@Name,");
            if (model.PassWord.Length > 0)
            {
                strSql.Append("PassWord=@PassWord,");
            }
            strSql.Append("State=@State,");
            strSql.Append("ManageBeginTime=@ManageBeginTime,");
            strSql.Append("ManageEndTime=@ManageEndTime,");
            strSql.Append("Power=@Power,");
            strSql.Append("AllowModifyPassWord=@AllowModifyPassWord ");
            strSql.Append(" where AdminID=@AdminID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@ManageBeginTime", SqlDbType.DateTime),
					new SqlParameter("@ManageEndTime", SqlDbType.DateTime),
					new SqlParameter("@Power", SqlDbType.TinyInt,1),
					new SqlParameter("@AllowModifyPassWord", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.AdminId;
            parameters[1].Value = model.Name;
            parameters[2].Value = ChangeHope.Common.DEncryptHelper.Encrypt(model.PassWord, 1);
            parameters[3].Value = model.State;
            parameters[4].Value = model.ManageBeginTime;
            parameters[5].Value = model.ManageEndTime;
            parameters[6].Value = model.Power;
            parameters[7].Value = model.AllowModifyPassWord;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update [Administrators] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + "  where AdminID=@AdminID";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@AdminID", id) };
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
        /// 删除一条数据
        /// </summary>
        public void Delete(int adminid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Administrators ");
            strSql.Append(" where AdminID=@AdminID and Name<>'admin'");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4)};
            parameters[0].Value = adminid;
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Admin.Administrators GetModel(int adminId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AdminID,Name,PassWord,State,ManageBeginTime,ManageEndTime,Power,AllowModifyPassWord,Role from Administrators ");
            strSql.Append(" where AdminID=@AdminID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AdminID", SqlDbType.Int,4)};
            parameters[0].Value = adminId;
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Admin.Administrators GetModelByAdminName(string adminName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 AdminID,Name,PassWord,State,ManageBeginTime,ManageEndTime,Power,AllowModifyPassWord,Role from Administrators");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50)};
            parameters[0].Value = adminName;
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Admin.Administrators> GetList(System.Data.DataTable table)
        {
            List<ShowShop.Model.Admin.Administrators> list = new List<ShowShop.Model.Admin.Administrators>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(GetModel(table.Rows[i]));
            }
            return list;
        }
        /// <summary>
        /// 通过DataRow获取一个实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private ShowShop.Model.Admin.Administrators GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Admin.Administrators model = new ShowShop.Model.Admin.Administrators();
            if (row != null)
            {
                if (row["AdminID"].ToString() != "")
                {
                    model.AdminId = int.Parse(row["AdminID"].ToString());
                }
                model.Name = row["Name"].ToString();
                model.PassWord = row["PassWord"].ToString();
                if (row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["ManageBeginTime"].ToString() != "")
                {
                    model.ManageBeginTime = DateTime.Parse(row["ManageBeginTime"].ToString());
                }
                if (row["ManageEndTime"].ToString() != "")
                {
                    model.ManageEndTime = DateTime.Parse(row["ManageEndTime"].ToString());
                }
                if (row["Power"].ToString() != "")
                {
                    model.Power = int.Parse(row["Power"].ToString());
                }
                if (row["AllowModifyPassWord"].ToString() != "")
                {
                    model.AllowModifyPassWord = int.Parse(row["AllowModifyPassWord"].ToString());
                }
                model.Role = row["Role"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        public string GetList()
        {
            ChangeHope.WebPage.DataView dataview = new ChangeHope.WebPage.DataView();
            dataview.Sql = "[select] *,(select top 1 LogininTime from Adminloginlog where AdminName=Administrators.Name order by ID desc)as LoginTime,(select top 1 LoginIP from Adminloginlog where AdminName=Administrators.Name order by ID desc)as LoginIP [from] Administrators [where] 1=1 [order by] AdminID asc";
            dataview.RowHead = "序号/5%,管理员帐号/10%,最后登陆时间/15%,最后登陆IP/10%,是否冻结/10%,开始管理时间/15%,管理过期时间/15%,操作/20%";
            dataview.RowText = "{0}$@AllNum,Name,LoginTime,LoginIP,<script>GetStat('{0}');</script>$State,ManageBeginTime,ManageEndTime,<a href='admin_edit.aspx?adminid={0}'>编辑</a>  <a href='?action=del&adminid={0}' onclick=\"return confirm('是否删除该数据')\">删除</a>$AdminID";
            string view= dataview.GetView();
            dataview = null;
            return view;
        }

        public ChangeHope.DataBase.DataByPage GetListDB()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] *,(select top 1 LogininTime from Adminloginlog where AdminName=Administrators.Name order by ID desc)as LoginTime,(select top 1 LoginIP from Adminloginlog where AdminName=Administrators.Name order by ID desc)as LoginIP [from] Administrators [where] 1=1 [order by] AdminID asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion  成员方法
    }
}

