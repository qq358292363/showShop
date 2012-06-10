using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Member;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Member
{
    public class UserinAndExp:IUserinAndExp
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Member.UserinAndExp model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_userinandexp(");
            strSql.Append("[uid],[adsummoneydate],[adsummoney],[presentcoupons],[remitmode],[remitbank],[remark],[formmode],[bosomnote],[notedate],[notename],[incomeandexpstate],[state],[userid])");
            strSql.Append(" values (");
            strSql.Append("@uid,@adsummoneydate,@adsummoney,@presentcoupons,@remitmode,@remitbank,@remark,@formmode,@bosomnote,@notedate,@notename,@incomeandexpstate,@state,@userid)");
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
        public void Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_userinandexp ");
            strSql.Append(" where [id] in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Member.UserinAndExp model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_userinandexp set ");
            strSql.Append("[uid]=@uid,");
            strSql.Append("[adsummoneydate]=@adsummoneydate,");
            strSql.Append("[adsummoney]=@adsummoney,");
            strSql.Append("[presentcoupons]=@presentcoupons,");
            strSql.Append("[remitmode]=@remitmode,");
            strSql.Append("[remitbank]=@remitbank,");
            strSql.Append("[remark]=@remark,");
            strSql.Append("[formmode]=@formmode,");
            strSql.Append("[bosomnote]=@bosomnote,");
            strSql.Append("[notedate]=@notedate,");
            strSql.Append("[notename]=@notename,");
            strSql.Append("[incomeandexpstate]=@incomeandexpstate,");
            strSql.Append("[state]=@state,");
            strSql.Append("[userid]=@userid");
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
            string sequel = "Update [yxs_userinandexp] set ";
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
        public ShowShop.Model.Member.UserinAndExp GetModelByID(int id)
        {
            ShowShop.Model.Member.UserinAndExp model = new ShowShop.Model.Member.UserinAndExp();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[uid],[adsummoneydate],[adsummoney],[presentcoupons],[remitmode],[remitbank],[remark],[formmode],[bosomnote],[notedate],[notename],[incomeandexpstate],[state],[userid] from yxs_userinandexp ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.AdsumMoneyDate = reader.GetDateTime(2);
                    model.AdsumMoney = Convert.ToDecimal(reader["adsummoney"]);
                    model.PresentCoupons = Convert.ToDecimal(reader["presentcoupons"]);
                    model.RemitMode = reader.GetInt32(5);
                    model.RemitBank = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.FormMode = reader.GetString(8);
                    model.BosomNote = reader.GetString(9);
                    model.NoteDate = reader.GetDateTime(10);
                    model.NoteName = reader.GetString(11);
                    model.InComeandExpState = reader.GetInt32(12);
                    model.State = reader.GetInt32(13);
                    model.UserId = reader.GetString(14);
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.UserinAndExp> GetAll()
        {
            List<ShowShop.Model.Member.UserinAndExp> list = new List<ShowShop.Model.Member.UserinAndExp>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[uid],[adsummoneydate],[adsummoney],[presentcoupons],[remitmode],[remitbank],[remark],[formmode],[bosomnote],[notedate],[notename],[incomeandexpstate],[state],[userid] from yxs_userinandexp ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.UserinAndExp model = new ShowShop.Model.Member.UserinAndExp();
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.AdsumMoneyDate = reader.GetDateTime(2);
                    model.AdsumMoney = Convert.ToDecimal(reader["adsummoney"]);
                    model.PresentCoupons = Convert.ToDecimal(reader["presentcoupons"]);
                    model.RemitMode = reader.GetInt32(5);
                    model.RemitBank = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.FormMode = reader.GetString(8);
                    model.BosomNote = reader.GetString(9);
                    model.NoteDate = reader.GetDateTime(10);
                    model.NoteName = reader.GetString(11);
                    model.InComeandExpState = reader.GetInt32(12);
                    model.State = reader.GetInt32(13);
                    model.UserId = reader.GetString(14);
                    list.Add(model);
                }
            }
            return list;

        }

        /// <summary>
        /// 得到指定条件的所有短消息 不加 where
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.UserinAndExp> GetAll(string strWhere)
        {
            List<ShowShop.Model.Member.UserinAndExp> list = new List<ShowShop.Model.Member.UserinAndExp>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id],[uid],[adsummoneydate],[adsummoney],[presentcoupons],[remitmode],[remitbank],[remark],[formmode],[bosomnote],[notedate],[notename],[incomeandexpstate],[state],[userid] from yxs_userinandexp ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.UserinAndExp model = new ShowShop.Model.Member.UserinAndExp();
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.AdsumMoneyDate = reader.GetDateTime(2);
                    model.AdsumMoney = Convert.ToDecimal(reader["adsummoney"]);
                    model.PresentCoupons = Convert.ToDecimal(reader["presentcoupons"]);
                    model.RemitMode = reader.GetInt32(5);
                    model.RemitBank = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.FormMode = reader.GetString(8);
                    model.BosomNote = reader.GetString(9);
                    model.NoteDate = reader.GetDateTime(10);
                    model.NoteName = reader.GetString(11);
                    model.InComeandExpState = reader.GetInt32(12);
                    model.State = reader.GetInt32(13);
                    model.UserId = reader.GetString(14);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到所有记录
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_userinandexp [where] "+strWhere+" [order by] id desc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Member.UserinAndExp model)
        {
            SqlParameter[] paras = new SqlParameter[15];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@uid", SqlDbType.Int, 4);
            paras[1].Value = model.UID;
            paras[2] = new SqlParameter("@adsummoneydate", SqlDbType.DateTime);
            paras[2].Value = model.AdsumMoneyDate;
            paras[3] = new SqlParameter("@adsummoney", SqlDbType.Float, 8);
            paras[3].Value = model.AdsumMoney;
            paras[4] = new SqlParameter("@presentcoupons", SqlDbType.Float, 8);
            paras[4].Value = model.PresentCoupons;
            paras[5] = new SqlParameter("@remitmode", SqlDbType.Int, 4);
            paras[5].Value = model.RemitMode;
            paras[6] = new SqlParameter("@remitbank", SqlDbType.VarChar, 50);
            paras[6].Value = model.RemitBank;
            paras[7] = new SqlParameter("@remark", SqlDbType.VarChar, 500);
            paras[7].Value = model.Remark;
            paras[8] = new SqlParameter("@formmode", SqlDbType.VarChar, 500);
            paras[8].Value = model.FormMode;
            paras[9] = new SqlParameter("@bosomnote", SqlDbType.VarChar, 50);
            paras[9].Value = model.BosomNote;
            paras[10] = new SqlParameter("@notedate", SqlDbType.DateTime);
            paras[10].Value = model.NoteDate;
            paras[11] = new SqlParameter("@notename", SqlDbType.VarChar, 50);
            paras[11].Value = model.NoteName;
            paras[12] = new SqlParameter("@incomeandexpstate", SqlDbType.Int, 4);
            paras[12].Value = model.InComeandExpState;
            paras[13] = new SqlParameter("@state", SqlDbType.Int, 4);
            paras[13].Value = model.State;
            paras[14] = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            paras[14].Value = model.UserId;
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
