using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Member;

namespace ShowShop.SQLServerDAL.Member
{
    /// <summary>
    /// 数据访问类MemberInfo。
    /// </summary>
    public class MemberInfo : IMemberInfo
    {
        public MemberInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_memberinfo");
            strSql.Append(" where UID=@UID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = UID;

            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ShowShop.Model.Member.MemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_memberinfo(");
            strSql.Append("UID,PrivacySettings,TrueName,Title,Photo,Birthday,PapersType,PapersNumber,Origin,Nation,Sex,Marriage,Education,GraduateSchool,Province,City,Borough,Address,Zip,OfficePhone,HomePhone,MobilePhone,HandPhone,Fax,PersonWebSite,QQ,MSN,ICQ,UC,LifeHobbies,CultureHobbies,Entertainment,SportsHobbies,OtherHobbies,IncName,Department,Positions,WorkRange,IncAddress,MonthlyInCome)");
            strSql.Append(" values (");
            strSql.Append("@UID,@PrivacySettings,@TrueName,@Title,@Photo,@Birthday,@PapersType,@PapersNumber,@Origin,@Nation,@Sex,@Marriage,@Education,@GraduateSchool,@Province,@City,@Borough,@Address,@Zip,@OfficePhone,@HomePhone,@MobilePhone,@HandPhone,@Fax,@PersonWebSite,@QQ,@MSN,@ICQ,@UC,@LifeHobbies,@CultureHobbies,@Entertainment,@SportsHobbies,@OtherHobbies,@IncName,@Department,@Positions,@WorkRange,@IncAddress,@MonthlyInCome)");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PrivacySettings", SqlDbType.TinyInt,1),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Photo", SqlDbType.VarChar,200),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@PapersType", SqlDbType.VarChar,20),
					new SqlParameter("@PapersNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Origin", SqlDbType.VarChar,50),
					new SqlParameter("@Nation", SqlDbType.VarChar,30),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Marriage", SqlDbType.TinyInt,1),
					new SqlParameter("@Education", SqlDbType.VarChar,20),
					new SqlParameter("@GraduateSchool", SqlDbType.VarChar,200),
					new SqlParameter("@Province", SqlDbType.VarChar,20),
					new SqlParameter("@City", SqlDbType.VarChar,20),
					new SqlParameter("@Borough", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,200),
					new SqlParameter("@Zip", SqlDbType.VarChar,50),
					new SqlParameter("@OfficePhone", SqlDbType.VarChar,20),
					new SqlParameter("@HomePhone", SqlDbType.VarChar,20),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,20),
					new SqlParameter("@HandPhone", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,20),
					new SqlParameter("@PersonWebSite", SqlDbType.VarChar,200),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,50),
					new SqlParameter("@ICQ", SqlDbType.VarChar,20),
					new SqlParameter("@UC", SqlDbType.VarChar,20),
					new SqlParameter("@LifeHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@CultureHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@Entertainment", SqlDbType.VarChar,2000),
					new SqlParameter("@SportsHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@OtherHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@IncName", SqlDbType.VarChar,100),
					new SqlParameter("@Department", SqlDbType.VarChar,100),
					new SqlParameter("@Positions", SqlDbType.VarChar,100),
					new SqlParameter("@WorkRange", SqlDbType.VarChar,500),
					new SqlParameter("@IncAddress", SqlDbType.VarChar,200),
					new SqlParameter("@MonthlyInCome", SqlDbType.VarChar,200)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.PrivacySettings;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Photo;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.PapersType;
            parameters[7].Value = model.PapersNumber;
            parameters[8].Value = model.Origin;
            parameters[9].Value = model.Nation;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.Marriage;
            parameters[12].Value = model.Education;
            parameters[13].Value = model.GraduateSchool;
            parameters[14].Value = model.Province;
            parameters[15].Value = model.City;
            parameters[16].Value = model.Borough;
            parameters[17].Value = model.Address;
            parameters[18].Value = model.Zip;
            parameters[19].Value = model.OfficePhone;
            parameters[20].Value = model.HomePhone;
            parameters[21].Value = model.MobilePhone;
            parameters[22].Value = model.HandPhone;
            parameters[23].Value = model.Fax;
            parameters[24].Value = model.PersonWebSite;
            parameters[25].Value = model.QQ;
            parameters[26].Value = model.MSN;
            parameters[27].Value = model.ICQ;
            parameters[28].Value = model.UC;
            parameters[29].Value = model.LifeHobbies;
            parameters[30].Value = model.CultureHobbies;
            parameters[31].Value = model.Entertainment;
            parameters[32].Value = model.SportsHobbies;
            parameters[33].Value = model.OtherHobbies;
            parameters[34].Value = model.IncName;
            parameters[35].Value = model.Department;
            parameters[36].Value = model.Positions;
            parameters[37].Value = model.WorkRange;
            parameters[38].Value = model.IncAddress;
            parameters[39].Value = model.MonthlyInCome;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ShowShop.Model.Member.MemberInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_memberinfo set ");
            strSql.Append("PrivacySettings=@PrivacySettings,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("Title=@Title,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("PapersType=@PapersType,");
            strSql.Append("PapersNumber=@PapersNumber,");
            strSql.Append("Origin=@Origin,");
            strSql.Append("Nation=@Nation,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Marriage=@Marriage,");
            strSql.Append("Education=@Education,");
            strSql.Append("GraduateSchool=@GraduateSchool,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("Borough=@Borough,");
            strSql.Append("Address=@Address,");
            strSql.Append("Zip=@Zip,");
            strSql.Append("OfficePhone=@OfficePhone,");
            strSql.Append("HomePhone=@HomePhone,");
            strSql.Append("MobilePhone=@MobilePhone,");
            strSql.Append("HandPhone=@HandPhone,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("PersonWebSite=@PersonWebSite,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("MSN=@MSN,");
            strSql.Append("ICQ=@ICQ,");
            strSql.Append("UC=@UC,");
            strSql.Append("LifeHobbies=@LifeHobbies,");
            strSql.Append("CultureHobbies=@CultureHobbies,");
            strSql.Append("Entertainment=@Entertainment,");
            strSql.Append("SportsHobbies=@SportsHobbies,");
            strSql.Append("OtherHobbies=@OtherHobbies,");
            strSql.Append("IncName=@IncName,");
            strSql.Append("Department=@Department,");
            strSql.Append("Positions=@Positions,");
            strSql.Append("WorkRange=@WorkRange,");
            strSql.Append("IncAddress=@IncAddress,");
            strSql.Append("MonthlyInCome=@MonthlyInCome");
            strSql.Append(" where UID=@UID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PrivacySettings", SqlDbType.TinyInt,1),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Photo", SqlDbType.VarChar,200),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@PapersType", SqlDbType.VarChar,20),
					new SqlParameter("@PapersNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Origin", SqlDbType.VarChar,50),
					new SqlParameter("@Nation", SqlDbType.VarChar,30),
					new SqlParameter("@Sex", SqlDbType.TinyInt,1),
					new SqlParameter("@Marriage", SqlDbType.TinyInt,1),
					new SqlParameter("@Education", SqlDbType.VarChar,20),
					new SqlParameter("@GraduateSchool", SqlDbType.VarChar,200),
					new SqlParameter("@Province", SqlDbType.VarChar,20),
					new SqlParameter("@City", SqlDbType.VarChar,20),
					new SqlParameter("@Borough", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,200),
					new SqlParameter("@Zip", SqlDbType.VarChar,50),
					new SqlParameter("@OfficePhone", SqlDbType.VarChar,20),
					new SqlParameter("@HomePhone", SqlDbType.VarChar,20),
					new SqlParameter("@MobilePhone", SqlDbType.VarChar,20),
					new SqlParameter("@HandPhone", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,20),
					new SqlParameter("@PersonWebSite", SqlDbType.VarChar,200),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,50),
					new SqlParameter("@ICQ", SqlDbType.VarChar,20),
					new SqlParameter("@UC", SqlDbType.VarChar,20),
					new SqlParameter("@LifeHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@CultureHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@Entertainment", SqlDbType.VarChar,2000),
					new SqlParameter("@SportsHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@OtherHobbies", SqlDbType.VarChar,2000),
					new SqlParameter("@IncName", SqlDbType.VarChar,100),
					new SqlParameter("@Department", SqlDbType.VarChar,100),
					new SqlParameter("@Positions", SqlDbType.VarChar,100),
					new SqlParameter("@WorkRange", SqlDbType.VarChar,500),
					new SqlParameter("@IncAddress", SqlDbType.VarChar,200),
					new SqlParameter("@MonthlyInCome", SqlDbType.VarChar,200)};
            parameters[0].Value = model.UID;
            parameters[1].Value = model.PrivacySettings;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.Photo;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.PapersType;
            parameters[7].Value = model.PapersNumber;
            parameters[8].Value = model.Origin;
            parameters[9].Value = model.Nation;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.Marriage;
            parameters[12].Value = model.Education;
            parameters[13].Value = model.GraduateSchool;
            parameters[14].Value = model.Province;
            parameters[15].Value = model.City;
            parameters[16].Value = model.Borough;
            parameters[17].Value = model.Address;
            parameters[18].Value = model.Zip;
            parameters[19].Value = model.OfficePhone;
            parameters[20].Value = model.HomePhone;
            parameters[21].Value = model.MobilePhone;
            parameters[22].Value = model.HandPhone;
            parameters[23].Value = model.Fax;
            parameters[24].Value = model.PersonWebSite;
            parameters[25].Value = model.QQ;
            parameters[26].Value = model.MSN;
            parameters[27].Value = model.ICQ;
            parameters[28].Value = model.UC;
            parameters[29].Value = model.LifeHobbies;
            parameters[30].Value = model.CultureHobbies;
            parameters[31].Value = model.Entertainment;
            parameters[32].Value = model.SportsHobbies;
            parameters[33].Value = model.OtherHobbies;
            parameters[34].Value = model.IncName;
            parameters[35].Value = model.Department;
            parameters[36].Value = model.Positions;
            parameters[37].Value = model.WorkRange;
            parameters[38].Value = model.IncAddress;
            parameters[39].Value = model.MonthlyInCome;

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int UID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_memberinfo ");
            strSql.Append(" where UID=@UID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = UID;

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
            string sequel = "Update [yxs_memberinfo] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + " Where [UID] = @uid"; ;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@uid", id) };
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
        public int GetIdByUserId(string userid)
        {
            string sql = "select UID from yxs_memberaccount where userid='" + userid + "'";
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(sql);
            if (obj != null)
            {
                try
                {
                    return int.Parse(obj.ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Member.MemberInfo GetModel(int UID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UID,PrivacySettings,TrueName,Title,Photo,Birthday,PapersType,PapersNumber,Origin,Nation,Sex,Marriage,Education,GraduateSchool,Province,City,Borough,Address,Zip,OfficePhone,HomePhone,MobilePhone,HandPhone,Fax,PersonWebSite,QQ,MSN,ICQ,UC,LifeHobbies,CultureHobbies,Entertainment,SportsHobbies,OtherHobbies,IncName,Department,Positions,WorkRange,IncAddress,MonthlyInCome from yxs_memberinfo ");
            strSql.Append(" where UID=@UID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)};
            parameters[0].Value = UID;

            ShowShop.Model.Member.MemberInfo model = new ShowShop.Model.Member.MemberInfo();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UID"].ToString() != "")
                {
                    model.UID = int.Parse(ds.Tables[0].Rows[0]["UID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PrivacySettings"].ToString() != "")
                {
                    model.PrivacySettings = int.Parse(ds.Tables[0].Rows[0]["PrivacySettings"].ToString());
                }
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Photo = ds.Tables[0].Rows[0]["Photo"].ToString();
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                model.PapersType = ds.Tables[0].Rows[0]["PapersType"].ToString();
                model.PapersNumber = ds.Tables[0].Rows[0]["PapersNumber"].ToString();
                model.Origin = ds.Tables[0].Rows[0]["Origin"].ToString();
                model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Marriage"].ToString() != "")
                {
                    model.Marriage = int.Parse(ds.Tables[0].Rows[0]["Marriage"].ToString());
                }
                model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                model.GraduateSchool = ds.Tables[0].Rows[0]["GraduateSchool"].ToString();
                model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.Borough = ds.Tables[0].Rows[0]["Borough"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Zip = ds.Tables[0].Rows[0]["Zip"].ToString();
                model.OfficePhone = ds.Tables[0].Rows[0]["OfficePhone"].ToString();
                model.HomePhone = ds.Tables[0].Rows[0]["HomePhone"].ToString();
                model.MobilePhone = ds.Tables[0].Rows[0]["MobilePhone"].ToString();
                model.HandPhone = ds.Tables[0].Rows[0]["HandPhone"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                model.PersonWebSite = ds.Tables[0].Rows[0]["PersonWebSite"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                model.ICQ = ds.Tables[0].Rows[0]["ICQ"].ToString();
                model.UC = ds.Tables[0].Rows[0]["UC"].ToString();
                model.LifeHobbies = ds.Tables[0].Rows[0]["LifeHobbies"].ToString();
                model.CultureHobbies = ds.Tables[0].Rows[0]["CultureHobbies"].ToString();
                model.Entertainment = ds.Tables[0].Rows[0]["Entertainment"].ToString();
                model.SportsHobbies = ds.Tables[0].Rows[0]["SportsHobbies"].ToString();
                model.OtherHobbies = ds.Tables[0].Rows[0]["OtherHobbies"].ToString();
                model.IncName = ds.Tables[0].Rows[0]["IncName"].ToString();
                model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                model.Positions = ds.Tables[0].Rows[0]["Positions"].ToString();
                model.WorkRange = ds.Tables[0].Rows[0]["WorkRange"].ToString();
                model.IncAddress = ds.Tables[0].Rows[0]["IncAddress"].ToString();
                model.MonthlyInCome = ds.Tables[0].Rows[0]["MonthlyInCome"].ToString();
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

