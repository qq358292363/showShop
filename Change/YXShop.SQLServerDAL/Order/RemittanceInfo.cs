using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Order;
using System.Collections.Generic;
using System;
using ChangeHope.DataBase;

namespace ShowShop.SQLServerDAL.Order
{
    public class RemittanceInfo:IRemittanceInfo
    {
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// 09.10.20 修改 
        /// 修改人：kevin
        /// </summary>
        public int Add(ShowShop.Model.Order.RemittanceInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [yxs_remittanceinfo](");
            strSql.Append("[orderid],[username],[remittancedate],[remittancemoney],[remintancebank],[presentticket],[remark],[informmode],[notedate],[notename])");
            strSql.Append(" values (");
            strSql.Append("@orderid,@username,@remittancedate,@remittancemoney,@remintancebank,@presentticket,@remark,@informmode,@notedate,@notename) Select scope_IDENTITY() ");
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
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
        public void Amend(ShowShop.Model.Order.RemittanceInfo model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_remittanceinfo set ");
            strSql.Append("orderid=@orderid,");
            strSql.Append("username=@username,");
            strSql.Append("remittancedate=@remittancedate,");
            strSql.Append("remittancemoney=@remittancemoney,");
            strSql.Append("remintancebank=@remintancebank,");
            strSql.Append("presentticket=@presentticket,");
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
            strSql.Append("delete from yxs_remittanceinfo ");
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
            string sequel = "Update [yxs_remittanceinfo] set ";
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
        public ShowShop.Model.Order.RemittanceInfo GetModelByID(int id)
        {
            ShowShop.Model.Order.RemittanceInfo model = new ShowShop.Model.Order.RemittanceInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderid,username,remittancedate,remittancemoney,remintancebank,presentticket,remark,informmode,notedate,notename from yxs_remittanceinfo  ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.RemittanceDate = reader.GetDateTime(3);
                    model.RemittanceMoney = Convert.ToDecimal(reader["remittancemoney"]);
                    model.RemintanceBank = reader.GetInt32(5);
                    model.PresentTicket = Convert.ToDecimal(reader["presentticket"]);
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
        /// 得到一个实体
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ShowShop.Model.Order.RemittanceInfo GetModelByOrderId(string orderId)
        {
            ShowShop.Model.Order.RemittanceInfo model = new ShowShop.Model.Order.RemittanceInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderid,username,remittancedate,remittancemoney,remintancebank,presentticket,remark,informmode,notedate,notename from yxs_remittanceinfo  ");
            strSql.Append(" where [orderid]=@orderid ");
            SqlParameter parameters = new SqlParameter("@orderid", SqlDbType.VarChar, 50);
            parameters.Value = orderId;
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.RemittanceDate = reader.GetDateTime(3);
                    model.RemittanceMoney = Convert.ToDecimal(reader["remittancemoney"]);
                    model.RemintanceBank = reader.GetInt32(5);
                    model.PresentTicket = Convert.ToDecimal(reader["presentticket"]);
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
        public List<ShowShop.Model.Order.RemittanceInfo> GetAll()
        {
            List<ShowShop.Model.Order.RemittanceInfo> list = new List<ShowShop.Model.Order.RemittanceInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderid,username,remittancedate,remittancemoney,remintancebank,presentticket,remark,informmode,notedate,notename from yxs_remittanceinfo  ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Order.RemittanceInfo model = new ShowShop.Model.Order.RemittanceInfo();
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.RemittanceDate = reader.GetDateTime(3);
                    model.RemittanceMoney = Convert.ToDecimal(reader["remittancemoney"]);
                    model.RemintanceBank = reader.GetInt32(5);
                    model.PresentTicket = Convert.ToDecimal(reader["presentticket"]);
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
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Order.RemittanceInfo> GetAll(string strWhere)
        {
            List<ShowShop.Model.Order.RemittanceInfo> list = new List<ShowShop.Model.Order.RemittanceInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,orderid,username,remittancedate,remittancemoney,remintancebank,presentticket,remark,informmode,notedate,notename from yxs_remittanceinfo  ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Order.RemittanceInfo model = new ShowShop.Model.Order.RemittanceInfo();
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.RemittanceDate = reader.GetDateTime(3);
                    model.RemittanceMoney = Convert.ToDecimal(reader["remittancemoney"]);
                    model.RemintanceBank = reader.GetInt32(5);
                    model.PresentTicket = Convert.ToDecimal(reader["presentticket"]);
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
            dataPage.Sql = "[select] * [from] yxs_remittanceinfo [where] " + strWhere + " [order by] id asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new DataByPage();
            dataPage.Sql = "[select] * [from] yxs_remittanceinfo [where] 1=1 [order by] id asc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Order.RemittanceInfo model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderid", SqlDbType.VarChar,50),
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@remittancedate", SqlDbType.DateTime,8),
					new SqlParameter("@remittancemoney", SqlDbType.Float,8),
					new SqlParameter("@remintancebank", SqlDbType.Int,4),
					new SqlParameter("@presentticket", SqlDbType.Float,8),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@informmode", SqlDbType.VarChar,50),
					new SqlParameter("@notedate", SqlDbType.DateTime,8),
					new SqlParameter("@notename", SqlDbType.Char,10)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.RemittanceDate;
            parameters[4].Value = model.RemittanceMoney;
            parameters[5].Value = model.RemintanceBank;
            parameters[6].Value = model.PresentTicket;
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
