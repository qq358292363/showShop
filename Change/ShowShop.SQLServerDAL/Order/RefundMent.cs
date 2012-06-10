using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Order;
using System.Collections.Generic;
using System;

namespace ShowShop.SQLServerDAL.Order
{
    public class RefundMent:IRefundMent
    {
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Order.RefundMent model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_refundment(");
            strSql.Append("orderid,username,paymentdate,poundage,refundmentmoney,refundmentmode,remark,informmode,notedate,notename)");
            strSql.Append(" values (");
            strSql.Append("@orderid,@username,@paymentdate,@poundage,@refundmentmoney,@refundmentmode,@remark,@informmode,@notedate,@notename)");
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
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.Order.RefundMent model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_refundment set ");
            strSql.Append("orderid=@orderid,");
            strSql.Append("username=@username,");
            strSql.Append("paymentdate=@paymentdate,");
            strSql.Append("poundage=@poundage,");
            strSql.Append("refundmentmoney=@refundmentmoney,");
            strSql.Append("refundmentmode=@refundmentmode,");
            strSql.Append("remark=@remark,");
            strSql.Append("informmode=@informmode,");
            strSql.Append("notedate=@notedate,");
            strSql.Append("notename=@notename");
            strSql.Append(" where id=@id ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_refundment ");
            strSql.Append(" where [id] in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            string sequel = "Update [yxs_refundment] set ";
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

        #region  "Data Load"
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Order.RefundMent GetModelByID(int id)
        {
            ShowShop.Model.Order.RefundMent model = new ShowShop.Model.Order.RefundMent();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderid,username,paymentdate,poundage,refundmentmoney,refundmentmode,remark,informmode,notedate,notename from yxs_refundment ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.PaymentDate = reader.GetDateTime(3);
                    model.PoundAge = Convert.ToDecimal(reader["poundage"]);
                    model.RefundMentMoney = Convert.ToDecimal(reader["refundmentmoney"]);
                    model.RefundMentMode = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.InformMode = reader.GetString(8);
                    model.NoteDate = reader.GetDateTime(9);
                    model.NoteName = reader.GetString(10);
                }
                else
                {
                    model = null;
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Order.RefundMent> GetAll()
        {
            List<ShowShop.Model.Order.RefundMent> list = new List<ShowShop.Model.Order.RefundMent>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderid,username,paymentdate,poundage,refundmentmoney,refundmentmode,remark,informmode,notedate,notename from yxs_refundment ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Order.RefundMent model = new ShowShop.Model.Order.RefundMent();
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.PaymentDate = reader.GetDateTime(3);
                    model.PoundAge = Convert.ToDecimal(reader["poundage"]);
                    model.RefundMentMoney = Convert.ToDecimal(reader["refundmentmoney"]);
                    model.RefundMentMode = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.InformMode = reader.GetString(8);
                    model.NoteDate = reader.GetDateTime(9);
                    model.NoteName = reader.GetString(10);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到指定条件的所有集合
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Order.RefundMent> GetAll(string strWhere)
        {
            List<ShowShop.Model.Order.RefundMent> list = new List<ShowShop.Model.Order.RefundMent>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderid,username,paymentdate,poundage,refundmentmoney,refundmentmode,remark,informmode,notedate,notename from yxs_refundment ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Order.RefundMent model = new ShowShop.Model.Order.RefundMent();
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.PaymentDate = reader.GetDateTime(3);
                    model.PoundAge = Convert.ToDecimal(reader["poundage"]);
                    model.RefundMentMoney = Convert.ToDecimal(reader["refundmentmoney"]);
                    model.RefundMentMode = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.InformMode = reader.GetString(8);
                    model.NoteDate = reader.GetDateTime(9);
                    model.NoteName = reader.GetString(10);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到不同条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_refundment [where] " + strWhere + " [order by] id asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_refundment [where] 1=1 [order by] id asc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Order.RefundMent model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderid", SqlDbType.VarChar,50),
					new SqlParameter("@username", SqlDbType.VarChar,20),
					new SqlParameter("@paymentdate", SqlDbType.DateTime),
					new SqlParameter("@poundage", SqlDbType.Float,8),
					new SqlParameter("@refundmentmoney", SqlDbType.Float,8),
					new SqlParameter("@refundmentmode", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@informmode", SqlDbType.Char,10),
					new SqlParameter("@notedate", SqlDbType.DateTime),
					new SqlParameter("@notename", SqlDbType.VarChar,20)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.PaymentDate;
            parameters[4].Value = model.PoundAge;
            parameters[5].Value = model.RefundMentMoney;
            parameters[6].Value = model.RefundMentMode;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.InformMode;
            parameters[9].Value = model.NoteDate;
            parameters[10].Value = model.NoteName;
            return parameters;
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
