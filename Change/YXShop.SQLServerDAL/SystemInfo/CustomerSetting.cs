using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.SystemInfo;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    /// <summary>
    /// 数据访问类CustomerSetting。
    /// </summary>
    public class CustomerSetting : ICustomerSetting
    {
        public CustomerSetting()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.CustomerSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_CustomerSetting(");
            strSql.Append("AllowRegister,SameEmailRegister,AdminValidate,EmailValidate,EmailValidateContent,HandselCoupons,HandselCouponsNumber,HandselCouponsBeginTime,HandselCouponsEndTime,HandselPoint,ForbidUserId,AnswerValidate,QuestionFirst,AnswerFirst,QuestionSecond,AnswerSecond,UserDefaultGroup,GetPasswordMethod,LoginPoint,LoginIsNeedCheckCode,AllowOtherLogin,MoneyToCoupons,MoneyToDate,PointToCoupons,PointToDate,CouponsName,CouponsUnits,RegisterRequired,RegisterRequiredOptional)");
            strSql.Append(" values (");
            strSql.Append("@AllowRegister,@SameEmailRegister,@AdminValidate,@EmailValidate,@EmailValidateContent,@HandselCoupons,@HandselCouponsNumber,@HandselCouponsBeginTime,@HandselCouponsEndTime,@HandselPoint,@ForbidUserId,@AnswerValidate,@QuestionFirst,@AnswerFirst,@QuestionSecond,@AnswerSecond,@UserDefaultGroup,@GetPasswordMethod,@LoginPoint,@LoginIsNeedCheckCode,@AllowOtherLogin,@MoneyToCoupons,@MoneyToDate,@PointToCoupons,@PointToDate,@CouponsName,@CouponsUnits,@RegisterRequired,@RegisterRequiredOptional)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AllowRegister", SqlDbType.Char,10),
					new SqlParameter("@SameEmailRegister", SqlDbType.Int,4),
					new SqlParameter("@AdminValidate", SqlDbType.TinyInt,1),
					new SqlParameter("@EmailValidate", SqlDbType.TinyInt,1),
					new SqlParameter("@EmailValidateContent", SqlDbType.NText),
					new SqlParameter("@HandselCoupons", SqlDbType.TinyInt,1),
					new SqlParameter("@HandselCouponsNumber", SqlDbType.Int,4),
					new SqlParameter("@HandselCouponsBeginTime", SqlDbType.DateTime),
					new SqlParameter("@HandselCouponsEndTime", SqlDbType.DateTime),
					new SqlParameter("@HandselPoint", SqlDbType.VarChar,50),
					new SqlParameter("@ForbidUserId", SqlDbType.VarChar,2000),
					new SqlParameter("@AnswerValidate", SqlDbType.Int,4),
					new SqlParameter("@QuestionFirst", SqlDbType.VarChar,50),
					new SqlParameter("@AnswerFirst", SqlDbType.VarChar,50),
					new SqlParameter("@QuestionSecond", SqlDbType.VarChar,50),
					new SqlParameter("@AnswerSecond", SqlDbType.VarChar,50),
					new SqlParameter("@UserDefaultGroup", SqlDbType.VarChar,50),
					new SqlParameter("@GetPasswordMethod", SqlDbType.Int,4),
					new SqlParameter("@LoginPoint", SqlDbType.Float,8),
					new SqlParameter("@LoginIsNeedCheckCode", SqlDbType.Int,4),
					new SqlParameter("@AllowOtherLogin", SqlDbType.Int,4),
					new SqlParameter("@MoneyToCoupons", SqlDbType.VarChar,50),
					new SqlParameter("@MoneyToDate", SqlDbType.VarChar,50),
					new SqlParameter("@PointToCoupons", SqlDbType.VarChar,50),
					new SqlParameter("@PointToDate", SqlDbType.VarChar,50),
					new SqlParameter("@CouponsName", SqlDbType.VarChar,50),
					new SqlParameter("@CouponsUnits", SqlDbType.VarChar,50),
					new SqlParameter("@RegisterRequired", SqlDbType.VarChar,500),
					new SqlParameter("@RegisterRequiredOptional", SqlDbType.VarChar,500)};
            parameters[0].Value = model.AllowRegister;
            parameters[1].Value = model.SameEmailRegister;
            parameters[2].Value = model.AdminValidate;
            parameters[3].Value = model.EmailValidate;
            parameters[4].Value = model.EmailValidateContent;
            parameters[5].Value = model.HandselCoupons;
            parameters[6].Value = model.HandselCouponsNumber;
            parameters[7].Value = model.HandselCouponsBeginTime;
            parameters[8].Value = model.HandselCouponsEndTime;
            parameters[9].Value = model.HandselPoint;
            parameters[10].Value = model.ForbidUserId;
            parameters[11].Value = model.AnswerValidate;
            parameters[12].Value = model.QuestionFirst;
            parameters[13].Value = model.AnswerFirst;
            parameters[14].Value = model.QuestionSecond;
            parameters[15].Value = model.AnswerSecond;
            parameters[16].Value = model.UserDefaultGroup;
            parameters[17].Value = model.GetPasswordMethod;
            parameters[18].Value = model.LoginPoint;
            parameters[19].Value = model.LoginIsNeedCheckCode;
            parameters[20].Value = model.AllowOtherLogin;
            parameters[21].Value = model.MoneyToCoupons;
            parameters[22].Value = model.MoneyToDate;
            parameters[23].Value = model.PointToCoupons;
            parameters[24].Value = model.PointToDate;
            parameters[25].Value = model.CouponsName;
            parameters[26].Value = model.CouponsUnits;
            parameters[27].Value = model.RegisterRequired;
            parameters[28].Value = model.RegisterRequiredOptional;

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
        public void Update(ShowShop.Model.SystemInfo.CustomerSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_CustomerSetting set ");
            strSql.Append("AllowRegister=@AllowRegister,");
            strSql.Append("SameEmailRegister=@SameEmailRegister,");
            strSql.Append("AdminValidate=@AdminValidate,");
            strSql.Append("EmailValidate=@EmailValidate,");
            strSql.Append("EmailValidateContent=@EmailValidateContent,");
            strSql.Append("HandselCoupons=@HandselCoupons,");
            strSql.Append("HandselCouponsNumber=@HandselCouponsNumber,");
            strSql.Append("HandselCouponsBeginTime=@HandselCouponsBeginTime,");
            strSql.Append("HandselCouponsEndTime=@HandselCouponsEndTime,");
            strSql.Append("HandselPoint=@HandselPoint,");
            strSql.Append("ForbidUserId=@ForbidUserId,");
            strSql.Append("AnswerValidate=@AnswerValidate,");
            strSql.Append("QuestionFirst=@QuestionFirst,");
            strSql.Append("AnswerFirst=@AnswerFirst,");
            strSql.Append("QuestionSecond=@QuestionSecond,");
            strSql.Append("AnswerSecond=@AnswerSecond,");
            strSql.Append("UserDefaultGroup=@UserDefaultGroup,");
            strSql.Append("GetPasswordMethod=@GetPasswordMethod,");
            strSql.Append("LoginPoint=@LoginPoint,");
            strSql.Append("LoginIsNeedCheckCode=@LoginIsNeedCheckCode,");
            strSql.Append("AllowOtherLogin=@AllowOtherLogin,");
            strSql.Append("MoneyToCoupons=@MoneyToCoupons,");
            strSql.Append("MoneyToDate=@MoneyToDate,");
            strSql.Append("PointToCoupons=@PointToCoupons,");
            strSql.Append("PointToDate=@PointToDate,");
            strSql.Append("CouponsName=@CouponsName,");
            strSql.Append("CouponsUnits=@CouponsUnits,");
            strSql.Append("RegisterRequired=@RegisterRequired,");
            strSql.Append("RegisterRequiredOptional=@RegisterRequiredOptional");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@AllowRegister", SqlDbType.Char,10),
					new SqlParameter("@SameEmailRegister", SqlDbType.Int,4),
					new SqlParameter("@AdminValidate", SqlDbType.TinyInt,1),
					new SqlParameter("@EmailValidate", SqlDbType.TinyInt,1),
					new SqlParameter("@EmailValidateContent", SqlDbType.NText),
					new SqlParameter("@HandselCoupons", SqlDbType.TinyInt,1),
					new SqlParameter("@HandselCouponsNumber", SqlDbType.Int,4),
					new SqlParameter("@HandselCouponsBeginTime", SqlDbType.DateTime),
					new SqlParameter("@HandselCouponsEndTime", SqlDbType.DateTime),
					new SqlParameter("@HandselPoint", SqlDbType.VarChar,50),
					new SqlParameter("@ForbidUserId", SqlDbType.VarChar,2000),
					new SqlParameter("@AnswerValidate", SqlDbType.Int,4),
					new SqlParameter("@QuestionFirst", SqlDbType.VarChar,50),
					new SqlParameter("@AnswerFirst", SqlDbType.VarChar,50),
					new SqlParameter("@QuestionSecond", SqlDbType.VarChar,50),
					new SqlParameter("@AnswerSecond", SqlDbType.VarChar,50),
					new SqlParameter("@UserDefaultGroup", SqlDbType.VarChar,50),
					new SqlParameter("@GetPasswordMethod", SqlDbType.Int,4),
					new SqlParameter("@LoginPoint", SqlDbType.Float,8),
					new SqlParameter("@LoginIsNeedCheckCode", SqlDbType.Int,4),
					new SqlParameter("@AllowOtherLogin", SqlDbType.Int,4),
					new SqlParameter("@MoneyToCoupons", SqlDbType.VarChar,50),
					new SqlParameter("@MoneyToDate", SqlDbType.VarChar,50),
					new SqlParameter("@PointToCoupons", SqlDbType.VarChar,50),
					new SqlParameter("@PointToDate", SqlDbType.VarChar,50),
					new SqlParameter("@CouponsName", SqlDbType.VarChar,50),
					new SqlParameter("@CouponsUnits", SqlDbType.VarChar,50),
					new SqlParameter("@RegisterRequired", SqlDbType.VarChar,500),
					new SqlParameter("@RegisterRequiredOptional", SqlDbType.VarChar,500)};
            parameters[0].Value = model.SID;
            parameters[1].Value = model.AllowRegister;
            parameters[2].Value = model.SameEmailRegister;
            parameters[3].Value = model.AdminValidate;
            parameters[4].Value = model.EmailValidate;
            parameters[5].Value = model.EmailValidateContent;
            parameters[6].Value = model.HandselCoupons;
            parameters[7].Value = model.HandselCouponsNumber;
            parameters[8].Value = model.HandselCouponsBeginTime;
            parameters[9].Value = model.HandselCouponsEndTime;
            parameters[10].Value = model.HandselPoint;
            parameters[11].Value = model.ForbidUserId;
            parameters[12].Value = model.AnswerValidate;
            parameters[13].Value = model.QuestionFirst;
            parameters[14].Value = model.AnswerFirst;
            parameters[15].Value = model.QuestionSecond;
            parameters[16].Value = model.AnswerSecond;
            parameters[17].Value = model.UserDefaultGroup;
            parameters[18].Value = model.GetPasswordMethod;
            parameters[19].Value = model.LoginPoint;
            parameters[20].Value = model.LoginIsNeedCheckCode;
            parameters[21].Value = model.AllowOtherLogin;
            parameters[22].Value = model.MoneyToCoupons;
            parameters[23].Value = model.MoneyToDate;
            parameters[24].Value = model.PointToCoupons;
            parameters[25].Value = model.PointToDate;
            parameters[26].Value = model.CouponsName;
            parameters[27].Value = model.CouponsUnits;
            parameters[28].Value = model.RegisterRequired;
            parameters[29].Value = model.RegisterRequiredOptional;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.SystemInfo.CustomerSetting GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SID,AllowRegister,SameEmailRegister,AdminValidate,EmailValidate,EmailValidateContent,HandselCoupons,HandselCouponsNumber,HandselCouponsBeginTime,HandselCouponsEndTime,HandselPoint,ForbidUserId,AnswerValidate,QuestionFirst,AnswerFirst,QuestionSecond,AnswerSecond,UserDefaultGroup,GetPasswordMethod,LoginPoint,LoginIsNeedCheckCode,AllowOtherLogin,MoneyToCoupons,MoneyToDate,PointToCoupons,PointToDate,CouponsName,CouponsUnits,RegisterRequired,RegisterRequiredOptional from yxs_CustomerSetting ");


            ShowShop.Model.SystemInfo.CustomerSetting model = new ShowShop.Model.SystemInfo.CustomerSetting();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SID"].ToString() != "")
                {
                    model.SID = int.Parse(ds.Tables[0].Rows[0]["SID"].ToString());
                }
                model.AllowRegister = ds.Tables[0].Rows[0]["AllowRegister"].ToString();
                if (ds.Tables[0].Rows[0]["SameEmailRegister"].ToString() != "")
                {
                    model.SameEmailRegister = int.Parse(ds.Tables[0].Rows[0]["SameEmailRegister"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdminValidate"].ToString() != "")
                {
                    model.AdminValidate = int.Parse(ds.Tables[0].Rows[0]["AdminValidate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EmailValidate"].ToString() != "")
                {
                    model.EmailValidate = int.Parse(ds.Tables[0].Rows[0]["EmailValidate"].ToString());
                }
                model.EmailValidateContent = ds.Tables[0].Rows[0]["EmailValidateContent"].ToString();
                if (ds.Tables[0].Rows[0]["HandselCoupons"].ToString() != "")
                {
                    model.HandselCoupons = int.Parse(ds.Tables[0].Rows[0]["HandselCoupons"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HandselCouponsNumber"].ToString() != "")
                {
                    model.HandselCouponsNumber = int.Parse(ds.Tables[0].Rows[0]["HandselCouponsNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HandselCouponsBeginTime"].ToString() != "")
                {
                    model.HandselCouponsBeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["HandselCouponsBeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HandselCouponsEndTime"].ToString() != "")
                {
                    model.HandselCouponsEndTime = DateTime.Parse(ds.Tables[0].Rows[0]["HandselCouponsEndTime"].ToString());
                }
                model.HandselPoint = ds.Tables[0].Rows[0]["HandselPoint"].ToString();
                model.ForbidUserId = ds.Tables[0].Rows[0]["ForbidUserId"].ToString();
                if (ds.Tables[0].Rows[0]["AnswerValidate"].ToString() != "")
                {
                    model.AnswerValidate = int.Parse(ds.Tables[0].Rows[0]["AnswerValidate"].ToString());
                }
                model.QuestionFirst = ds.Tables[0].Rows[0]["QuestionFirst"].ToString();
                model.AnswerFirst = ds.Tables[0].Rows[0]["AnswerFirst"].ToString();
                model.QuestionSecond = ds.Tables[0].Rows[0]["QuestionSecond"].ToString();
                model.AnswerSecond = ds.Tables[0].Rows[0]["AnswerSecond"].ToString();
                model.UserDefaultGroup = ds.Tables[0].Rows[0]["UserDefaultGroup"].ToString();
                if (ds.Tables[0].Rows[0]["GetPasswordMethod"].ToString() != "")
                {
                    model.GetPasswordMethod = int.Parse(ds.Tables[0].Rows[0]["GetPasswordMethod"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginPoint"].ToString() != "")
                {
                    model.LoginPoint = decimal.Parse(ds.Tables[0].Rows[0]["LoginPoint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginIsNeedCheckCode"].ToString() != "")
                {
                    model.LoginIsNeedCheckCode = int.Parse(ds.Tables[0].Rows[0]["LoginIsNeedCheckCode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllowOtherLogin"].ToString() != "")
                {
                    model.AllowOtherLogin = int.Parse(ds.Tables[0].Rows[0]["AllowOtherLogin"].ToString());
                }
                model.MoneyToCoupons = ds.Tables[0].Rows[0]["MoneyToCoupons"].ToString();
                model.MoneyToDate = ds.Tables[0].Rows[0]["MoneyToDate"].ToString();
                model.PointToCoupons = ds.Tables[0].Rows[0]["PointToCoupons"].ToString();
                model.PointToDate = ds.Tables[0].Rows[0]["PointToDate"].ToString();
                model.CouponsName = ds.Tables[0].Rows[0]["CouponsName"].ToString();
                model.CouponsUnits = ds.Tables[0].Rows[0]["CouponsUnits"].ToString();
                model.RegisterRequired = ds.Tables[0].Rows[0]["RegisterRequired"].ToString();
                model.RegisterRequiredOptional = ds.Tables[0].Rows[0]["RegisterRequiredOptional"].ToString();
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

