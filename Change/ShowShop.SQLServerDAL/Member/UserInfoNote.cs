using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;
using System.Data;
using System.Data.SqlClient;

namespace ShowShop.SQLServerDAL.Member
{
    public class UserInfoNote:IUserInfoNote
    {

        #region Database Opreation 
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Member.UserInfoNote model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [yxs_userinfonote](");
            strSql.Append("userId,ticketCount,causation,bosomNote,noteDate,noteName,noteType,buckleOrAdd,userName)");
            strSql.Append(" values (");
            strSql.Append("@userId,@ticketCount,@causation,@bosomNote,@noteDate,@noteName,@noteType,@buckleOrAdd,@userName);select @@IDENTITY");
            SqlParameter[] parameters = (SqlParameter[])this.ValueParams(model);
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), parameters);
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
        /// 删除
        /// </summary>
        /// <param name="where"></param>
        public void Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_userinfonote ");
            if(where!=""&&where!=null){
                strSql.Append("where "+where+" ");
            }
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }
     
        #endregion


        #region Data Load

        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.Member.UserInfoNote GetModelById(int id)
        {
            ShowShop.Model.Member.UserInfoNote model = new ShowShop.Model.Member.UserInfoNote();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userId,ticketCount,causation,bosomNote,noteDate,noteName,noteType,buckleOrAdd,userName from yxs_userinfonote ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = Convert.ToInt32(reader["Id"]);
                    model.UserID = Convert.ToInt32(reader["userId"]);
                    model.TicketCount = Convert.ToDecimal(reader["ticketCount"]);
                    model.Causation = Convert.ToString(reader["causation"]);
                    model.BosomNote = Convert.ToString(reader["bosomNote"]);
                    model.NoteDate = Convert.ToDateTime(reader["noteDate"]);
                    model.NoteName = Convert.ToString(reader["noteName"]);
                    model.NoteType = Convert.ToInt32(reader["noteType"]);
                    model.BuckleOrAdd = Convert.ToInt32(reader["buckleOrAdd"]);
                    model.Username = (string)(reader["userName"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 根据用户ID及类型查
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetListByIdAndType(int userId, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("[select] * [from] yxs_userinfonote [where] userId=");
            strSql.Append(userId + " and noteType="+type);
            strSql.Append(" [order by] id asc ");
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = strSql.ToString();
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 根据不同条件查
        /// </summary>
        /// 
        public ChangeHope.DataBase.DataByPage GetListByWhere(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("[select] * [from] yxs_userinfonote ");
            if (where != null & where != "")
            {
                strSql.Append(" [where] " + where + " ");
            }
            else
            {
                strSql.Append(" [where] 1=1 ");
            }
            strSql.Append(" [order by] id asc ");
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = strSql.ToString();
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion
     
        #region "Other Faction"
        public IDataParameter[] ValueParams(ShowShop.Model.Member.UserInfoNote model)
        {
            SqlParameter[] parameters = new SqlParameter[10];
            parameters[0] = new SqlParameter("@id",SqlDbType.Int,4);
            parameters[1] = new SqlParameter("@userId",SqlDbType.Int,4);
            parameters[2] = new SqlParameter("@ticketCount",SqlDbType.Float,8);
            parameters[3] = new SqlParameter("@causation",SqlDbType.VarChar,1000);
            parameters[4] = new SqlParameter("@bosomNote",SqlDbType.VarChar,1000);
            parameters[5] = new SqlParameter("@noteDate",SqlDbType.DateTime,8);
            parameters[6] = new SqlParameter("@noteName",SqlDbType.VarChar,50);
            parameters[7] = new SqlParameter("@noteType",SqlDbType.Int,4);
            parameters[8] = new SqlParameter("@buckleOrAdd",SqlDbType.Int,4);
            parameters[9] = new SqlParameter("@userName",SqlDbType.VarChar,50);
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.TicketCount;
            parameters[3].Value = model.Causation;
            parameters[4].Value = model.BosomNote;
            parameters[5].Value = model.NoteDate;
            parameters[6].Value = model.NoteName;
            parameters[7].Value = model.NoteType;
            parameters[8].Value = model.BuckleOrAdd;
            parameters[9].Value = model.Username;
            return parameters;
        }
        #endregion

       
    }
}
