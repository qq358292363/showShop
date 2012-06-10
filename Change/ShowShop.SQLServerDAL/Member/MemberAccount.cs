using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Member;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Member
{
    /// <summary>
    /// 数据访问类MemberAccount。
    /// </summary>
    public class MemberAccount : IMemberAccount
    {
        public MemberAccount()
        { }
        #region  成员方法

        /// <summary>
        /// 得到自增ID最大值
        /// </summary>
        /// <returns></returns>
        public int GetMaxID()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(UID) from yxs_memberaccount");
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString());
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
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from yxs_memberaccount");
			strSql.Append(" where UID=@UID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)};
			parameters[0].Value = UID;

			return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_memberaccount");
            strSql.Append(" where UserId=@UserId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50)};
            parameters[0].Value = userId;

            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该Email记录
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistEmail(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_memberaccount");
            strSql.Append(" where Email=@Email ");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.VarChar,50)};
            parameters[0].Value = email;
            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ShowShop.Model.Member.MemberAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into yxs_memberaccount(");
			strSql.Append("UserType,UserGroup,UserId,PassWord,Signed,Question,Answer,Email,State,RegisterDate,RegisterIP,LastLoginDate,LastLoginIP,LoginTimes,Capital,Coupons,Points,PeriodOfValidity)");
			strSql.Append(" values (");
			strSql.Append("@UserType,@UserGroup,@UserId,@PassWord,@Signed,@Question,@Answer,@Email,@State,@RegisterDate,@RegisterIP,@LastLoginDate,@LastLoginIP,@LoginTimes,@Capital,@Coupons,@Points,@PeriodOfValidity)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserGroup", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@Signed", SqlDbType.VarChar,5000),
					new SqlParameter("@Question", SqlDbType.NVarChar,50),
					new SqlParameter("@Answer", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@RegisterIP", SqlDbType.VarChar,50),
					new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIP", SqlDbType.VarChar,50),
					new SqlParameter("@LoginTimes", SqlDbType.Int,4),
					new SqlParameter("@Capital", SqlDbType.Float,8),
					new SqlParameter("@Coupons", SqlDbType.Float,8),
					new SqlParameter("@Points", SqlDbType.Float,8),
					new SqlParameter("@PeriodOfValidity", SqlDbType.DateTime)};
			parameters[0].Value = model.UserType;
			parameters[1].Value = model.UserGroup;
			parameters[2].Value = model.UserId;
            parameters[3].Value = ChangeHope.Common.DEncryptHelper.Encrypt(model.PassWord, 1);
			parameters[4].Value = model.Signed;
			parameters[5].Value = model.Question;
			parameters[6].Value = model.Answer;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.State;
			parameters[9].Value = model.RegisterDate;
			parameters[10].Value = model.RegisterIP;
			parameters[11].Value = model.LastLoginDate;
			parameters[12].Value = model.LastLoginIP;
			parameters[13].Value = model.LoginTimes;
			parameters[14].Value = model.Capital;
			parameters[15].Value = model.Coupons;
			parameters[16].Value = model.Points;
			parameters[17].Value = model.PeriodOfValidity;
            int obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
            if (obj >0)
            {
                return obj;
            }
            else
            {
                return 0;
            }
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ShowShop.Model.Member.MemberAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update yxs_memberaccount set ");
			strSql.Append("UserType=@UserType,");
			strSql.Append("UserGroup=@UserGroup,");
			strSql.Append("UserId=@UserId,");
            if (model.PassWord.Length > 0)
            {
                strSql.Append("PassWord=@PassWord,");
            }
			strSql.Append("Signed=@Signed,");
			strSql.Append("Question=@Question,");
			strSql.Append("Answer=@Answer,");
			strSql.Append("Email=@Email,");
			strSql.Append("State=@State,");
            strSql.Append("PeriodOfValidity=@time,");
            strSql.Append("Coupons=@Coupon,");
            strSql.Append("Capital=@Capital,");
            strSql.Append("Points=@Points  ");
			strSql.Append(" where UID=@UID ");
            
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserGroup", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@Signed", SqlDbType.VarChar,5000),
					new SqlParameter("@Question", SqlDbType.NVarChar,50),
					new SqlParameter("@Answer", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@time",SqlDbType.DateTime,8),
                    new SqlParameter("@Coupon",SqlDbType.Float,8),
                    new SqlParameter("@Capital",SqlDbType.Float,8),
                    new SqlParameter("@Points",SqlDbType.Float,8)
					};
			parameters[0].Value = model.UID;
			parameters[1].Value = model.UserType;
			parameters[2].Value = model.UserGroup;
			parameters[3].Value = model.UserId;
			parameters[4].Value = ChangeHope.Common.DEncryptHelper.Encrypt(model.PassWord,1);
			parameters[5].Value = model.Signed;
			parameters[6].Value = model.Question;
			parameters[7].Value = model.Answer;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.State;
            parameters[10].Value=model.PeriodOfValidity;
            parameters[11].Value = model.Coupons;
            parameters[12].Value = model.Capital;
            parameters[13].Value = model.Points;

			ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yxs_memberaccount ");
			strSql.Append(" where UID=@UID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)};
			parameters[0].Value = UID;

			ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteAll(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_memberaccount where UID in(");
            strSql.Append(ids+" )");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 批量解锁与冻结
        /// </summary>
        /// <param name="ids">id集合</param>
        /// <param name="flag">是否冻结为真解锁</param>
        public void LockAddUnLock(string ids,bool flag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_memberaccount set ");
            if (flag == true)
            {  //解锁
                strSql.Append("State=0 ");
            }
            else
            {  //冻结
                strSql.Append("State=1 ");
            }
            strSql.Append(" where UID in(");
            strSql.Append(ids+" )");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
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
            string sequel = "Update [yxs_memberaccount] set ";
            sequel += "[" + columnName + "] =@Value ";
            sequel += "Where [UID] = @id";
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
        /// 更改会员组
        /// </summary>
        /// <param name="oldGroup"></param>
        /// <param name="newGroup"></param>
        /// <returns></returns>
        public int UpdateGroup(string oldGroup, string newGroup)
        {
            string sequel = "Update [yxs_memberaccount] set ";
            sequel += "[UserGroup] =@newGroup ";
            sequel += "Where [UserGroup] = @oldGroup";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@newGroup", newGroup),
                new SqlParameter("@oldGroup", oldGroup) 
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

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ShowShop.Model.Member.MemberAccount GetModel(int UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UID,UserType,UserGroup,UserId,PassWord,Signed,Question,Answer,Email,State,RegisterDate,RegisterIP,LastLoginDate,LastLoginIP,LoginTimes,Capital,Coupons,Points,PeriodOfValidity from yxs_memberaccount ");
			strSql.Append(" where UID=@UID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)};
			parameters[0].Value = UID;

			ShowShop.Model.Member.MemberAccount model=new ShowShop.Model.Member.MemberAccount();
			DataSet ds=ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UID"].ToString()!="")
				{
					model.UID=int.Parse(ds.Tables[0].Rows[0]["UID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserGroup"].ToString()!="")
				{
					model.UserGroup=int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
				}
				model.UserId=ds.Tables[0].Rows[0]["UserId"].ToString();
				model.PassWord=ds.Tables[0].Rows[0]["PassWord"].ToString();
				model.Signed=ds.Tables[0].Rows[0]["Signed"].ToString();
				model.Question=ds.Tables[0].Rows[0]["Question"].ToString();
				model.Answer=ds.Tables[0].Rows[0]["Answer"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegisterDate"].ToString()!="")
				{
					model.RegisterDate=DateTime.Parse(ds.Tables[0].Rows[0]["RegisterDate"].ToString());
				}
				model.RegisterIP=ds.Tables[0].Rows[0]["RegisterIP"].ToString();
				if(ds.Tables[0].Rows[0]["LastLoginDate"].ToString()!="")
				{
					model.LastLoginDate=DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginDate"].ToString());
				}
				model.LastLoginIP=ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
				if(ds.Tables[0].Rows[0]["LoginTimes"].ToString()!="")
				{
					model.LoginTimes=int.Parse(ds.Tables[0].Rows[0]["LoginTimes"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Capital"].ToString()!="")
				{
					model.Capital=decimal.Parse(ds.Tables[0].Rows[0]["Capital"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Coupons"].ToString()!="")
				{
					model.Coupons=decimal.Parse(ds.Tables[0].Rows[0]["Coupons"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Points"].ToString()!="")
				{
					model.Points=decimal.Parse(ds.Tables[0].Rows[0]["Points"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PeriodOfValidity"].ToString()!="")
				{
					model.PeriodOfValidity=DateTime.Parse(ds.Tables[0].Rows[0]["PeriodOfValidity"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public ShowShop.Model.Member.MemberAccount GetModel(string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UID,UserType,UserGroup,UserId,PassWord,Signed,Question,Answer,Email,State,RegisterDate,RegisterIP,LastLoginDate,LastLoginIP,LoginTimes,Capital,Coupons,Points,PeriodOfValidity from yxs_memberaccount ");
            strSql.Append(" where UserId=@UserId ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,50)};
            parameters[0].Value = UserId;

            ShowShop.Model.Member.MemberAccount model = new ShowShop.Model.Member.MemberAccount();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UID"].ToString() != "")
                {
                    model.UID = int.Parse(ds.Tables[0].Rows[0]["UID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserGroup"].ToString() != "")
                {
                    model.UserGroup = int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
                }
                model.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                model.Signed = ds.Tables[0].Rows[0]["Signed"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegisterDate"].ToString() != "")
                {
                    model.RegisterDate = DateTime.Parse(ds.Tables[0].Rows[0]["RegisterDate"].ToString());
                }
                model.RegisterIP = ds.Tables[0].Rows[0]["RegisterIP"].ToString();
                if (ds.Tables[0].Rows[0]["LastLoginDate"].ToString() != "")
                {
                    model.LastLoginDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginDate"].ToString());
                }
                model.LastLoginIP = ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
                if (ds.Tables[0].Rows[0]["LoginTimes"].ToString() != "")
                {
                    model.LoginTimes = int.Parse(ds.Tables[0].Rows[0]["LoginTimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Capital"].ToString() != "")
                {
                    model.Capital = decimal.Parse(ds.Tables[0].Rows[0]["Capital"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Coupons"].ToString() != "")
                {
                    model.Coupons = decimal.Parse(ds.Tables[0].Rows[0]["Coupons"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Points"].ToString() != "")
                {
                    model.Points = decimal.Parse(ds.Tables[0].Rows[0]["Points"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PeriodOfValidity"].ToString() != "")
                {
                    model.PeriodOfValidity = DateTime.Parse(ds.Tables[0].Rows[0]["PeriodOfValidity"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ShowShop.Model.Member.MemberAccount GetModelByNameAndPassword(string name,string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UID,UserType,UserGroup,PassWord,UserId,Signed,Question,Answer,Email,State,RegisterDate,RegisterIP,LastLoginDate,LastLoginIP,LoginTimes,Capital,Coupons,Points,PeriodOfValidity from yxs_memberaccount ");
            strSql.Append(" where UserId=@UserId and PassWord=@PassWord ");
            SqlParameter[] parameters ={
                                           new SqlParameter("@UserId",name),
                                           new SqlParameter("@PassWord",password)
                                      };
            ShowShop.Model.Member.MemberAccount model = null;
            using(SqlDataReader reader=ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(),parameters))
            {
                if(reader.Read())
                {
                    model = new ShowShop.Model.Member.MemberAccount();
                    model.UID = (int)reader["UID"];
                    model.UserType = (int)reader["UserType"];
                    model.UserGroup = Convert.ToInt32(reader["UserGroup"]);
                    model.PassWord = (string)reader["PassWord"];
                    model.UserId = (string)reader["UserId"];
                    model.Signed = reader["Signed"] == null ? string.Empty : Convert.ToString(reader["Signed"]);
                    model.Question = reader["Question"] == null ? string.Empty : reader["Question"].ToString();
                    model.Answer = reader["Answer"] == null ? string.Empty : reader["Answer"].ToString();
                    model.Email = (string)reader["Email"];
                    model.State = Convert.ToInt32(reader["State"]);
                    model.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);
                    model.RegisterIP = (string)reader["RegisterIP"];
                    model.LastLoginDate = Convert.ToDateTime(reader["LastLoginDate"]);
                    model.LastLoginIP = (string)reader["LastLoginIP"];
                    model.LoginTimes = Convert.ToInt32(reader["LoginTimes"]);
                    model.Capital = Convert.ToDecimal(reader["Capital"]);
                    model.Coupons = Convert.ToDecimal(reader["Coupons"]);
                    model.Points = Convert.ToDecimal(reader["Points"]);
                    model.PeriodOfValidity = Convert.ToDateTime(reader["PeriodOfValidity"]);
                }
            }
            return model;

        }
        /// <summary>
        /// 查所有 根据条件
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MemberAccount> GetAll(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UID,UserType,UserGroup,PassWord,UserId,Signed,Question,Answer,Email,State,RegisterDate,RegisterIP,LastLoginDate,LastLoginIP,LoginTimes,Capital,Coupons,Points,PeriodOfValidity from yxs_memberaccount  ");
            if (where != null && where != "")
            {
                strSql.Append("where " + where + " ");
            }
            List<ShowShop.Model.Member.MemberAccount> accountList = new List<ShowShop.Model.Member.MemberAccount>();
            using(SqlDataReader reader=ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while(reader.Read())
                {
                    ShowShop.Model.Member.MemberAccount model= new ShowShop.Model.Member.MemberAccount();
                    model.UID=(int)reader["UID"];
                    model.UserType=(int)reader["UserType"];
                    model.UserGroup=Convert.ToInt32(reader["UserGroup"]);
                    model.PassWord = (string)reader["PassWord"];
                    model.UserId=(string)reader["UserId"];
                    model.Signed=reader["Signed"]==null?string.Empty:Convert.ToString(reader["Signed"]);
                    model.Question = reader["Question"] == null ?string.Empty : reader["Question"].ToString();
                    model.Answer = reader["Answer"] == null ? string.Empty : reader["Answer"].ToString();
                    model.Email=(string)reader["Email"];
                    model.State=Convert.ToInt32(reader["State"]);
                    model.RegisterDate=Convert.ToDateTime(reader["RegisterDate"]);
                    model.RegisterIP=(string)reader["RegisterIP"];
                    model.LastLoginDate=Convert.ToDateTime(reader["LastLoginDate"]);
                    model.LastLoginIP=(string)reader["LastLoginIP"];
                    model.LoginTimes=Convert.ToInt32(reader["LoginTimes"]);
                    model.Capital=Convert.ToDecimal(reader["Capital"]);
                    model.Coupons=Convert.ToDecimal(reader["Coupons"]);
                    model.Points=Convert.ToDecimal(reader["Points"]);
                    model.PeriodOfValidity=Convert.ToDateTime(reader["PeriodOfValidity"]);
                    accountList.Add(model);
                }
            }
            return accountList;

        }

        public ChangeHope.DataBase.DataByPage GetList()
        {
            string sql = "[select] *"
            + ",(select content from yxs_code_usertype where code=yxs_MemberAccount.UserType) as UserTypeContent"
            + " ,(select Name from yxs_memberrank where id=yxs_MemberAccount.UserGroup) as UserGroupContent"
            + " [from] yxs_MemberAccount [where] 1=1 [order by] UID desc";
            ChangeHope.DataBase.DataByPage datapage = new ChangeHope.DataBase.DataByPage();
            datapage.Sql = sql;
            datapage.GetRecordSetByPage();
            return datapage;
        }
        public ChangeHope.DataBase.DataByPage GetList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("[select] *");
            strSql.Append(",(select content from yxs_code_usertype where code=yxs_MemberAccount.UserType) as UserTypeContent");
            strSql.Append(" ,(select Name from yxs_memberrank where id=yxs_MemberAccount.UserGroup) as UserGroupContent");
            strSql.Append(" [from] yxs_MemberAccount [where] 1=1 ");
            if (where!=null&&where!="")
            {
                strSql.Append(where);
            }
            strSql.Append(" [order by] UserId asc ");
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = strSql.ToString();
            dataPage.GetRecordSetByPage();
            return dataPage;         
        }
        #endregion  成员方法
    }
}

