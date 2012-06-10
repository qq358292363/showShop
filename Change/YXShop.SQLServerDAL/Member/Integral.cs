using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;
using System.Data.SqlClient;
using System.Data;

namespace ShowShop.SQLServerDAL.Member
{
    public class Integral:IIntegral
    {
        #region DataBase Operation

        public int Add(ShowShop.Model.Member.Integral model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [yxs_integral](");
            strSql.Append("userId,orderid,integralClass,origin,integral,gainDate,noteDate,noteName,remark,integralStatus) ");
            strSql.Append("values(");
            strSql.Append("@userId,@orderid,@integralClass,@origin,@integral,@gainDate,@noteDate,@noteName,@remark,@integralStatus )");
            SqlParameter[] parameters = (SqlParameter[])this.ValueParams(model);
            int count = 0;
            count = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
            return count;
        }

        #endregion

        #region Data Load

        /// <summary>
        /// 根据UID得到积分总和
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetInteSumByUid(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(integral) from yxs_integral ");
            strSql.Append(" where [userId] =@userId ");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@userId", SqlDbType.Int, 4)
            };
            parms[0].Value = uid;
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), parms);
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
        /// 根据uid和积分来源类别得到积分总和
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetInteSumByUid(int uid, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(integral) from yxs_integral ");
            strSql.Append(" where [userId] =@userId ");
            strSql.Append(" and integralClass=@integralClass ");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@userId", SqlDbType.Int, 4),
                new SqlParameter("@integralClass", SqlDbType.Int, 4)
            };
            parms[0].Value = uid;
            parms[1].Value = type;
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), parms);
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
        /// 根据条件查集合 按获得积分时间排序
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.Integral> GetListByWhere(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [yxs_integral] ");
            if(where!=null&&where!=""){
                strSql.Append(" where "+where+" ");
            }
            strSql.Append(" order by GainDate Desc");
            List<ShowShop.Model.Member.Integral> lists = new List<ShowShop.Model.Member.Integral>();
            using(SqlDataReader reader=ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while(reader.Read())
                {
                    ShowShop.Model.Member.Integral model = new ShowShop.Model.Member.Integral();
                    model.Id=(int)reader["id"];
                    model.Userid = (int)reader["userId"];
                    model.OrderId =(string)reader["orderid"];
                    model.IntegralClass = (int)reader["integralClass"];
                    model.Origin = (string)reader["origin"];
                    model.IntegralNum = Convert.ToDecimal(reader["integral"]);
                    model.GainDate = Convert.ToDateTime(reader["gainDate"]);
                    model.NoteDate = Convert.ToDateTime(reader["noteDate"]);
                    model.NoteName = (string)reader["noteName"];
                    model.Remark = (string)reader["remark"];
                    model.IntegralStatus = (int)reader["integralStatus"];
                    lists.Add(model);
                }
            }
            return lists;
        }

        /// <summary>
        /// 根据条件得到分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_integral [where] " + strWhere + " [order by] id desc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion

        #region Other Faction
        public IDataParameter[] ValueParams(ShowShop.Model.Member.Integral model)
        {
            SqlParameter[] parameters=new SqlParameter[11];
            parameters[0] = new SqlParameter("@id",SqlDbType.Int,4);
            parameters[1] = new SqlParameter("@userId",SqlDbType.Int,4);
            parameters[2] = new SqlParameter("@orderid", SqlDbType.VarChar, 50);
            parameters[3] = new SqlParameter("@integralClass",SqlDbType.Int,4);
            parameters[4] = new SqlParameter("@origin",SqlDbType.VarChar,50);
            parameters[5] = new SqlParameter("@integral",SqlDbType.Float,8);
            parameters[6] = new SqlParameter("@gainDate",SqlDbType.DateTime,8);
            parameters[7] = new SqlParameter("@noteDate",SqlDbType.DateTime,8);
            parameters[8] = new SqlParameter("@noteName",SqlDbType.VarChar,50);
            parameters[9] = new SqlParameter("@remark",SqlDbType.VarChar,500);
            parameters[10] = new SqlParameter("@integralStatus",SqlDbType.Int,4);
            parameters[0].Value=model.Id;
            parameters[1].Value=model.Userid;
            parameters[2].Value = model.OrderId;
            parameters[3].Value=model.IntegralClass;
            parameters[4].Value=model.Origin;
            parameters[5].Value=model.IntegralNum;
            parameters[6].Value=model.GainDate;
            parameters[7].Value=model.NoteDate;
            parameters[8].Value=model.NoteName;
            parameters[9].Value=model.Remark;
            parameters[10].Value=model.IntegralStatus;
            return parameters;
        }
        #endregion
    }
}
