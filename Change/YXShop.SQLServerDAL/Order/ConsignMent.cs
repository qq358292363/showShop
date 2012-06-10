using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Order;
using System.Collections.Generic;
using System;

namespace ShowShop.SQLServerDAL.Order
{
    public class ConsignMent:IConsignMent
    {
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Order.ConsignMent model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_consignment(");
            strSql.Append("orderid,username,consignmentdate,expresscompany,expressoddnumbers,consignmentpeople,remark,bosomnote,informmode,notedate,notename,received,consignmenttype)");
            strSql.Append(" values (");
            strSql.Append("@orderid,@username,@consignmentdate,@expresscompany,@expressoddnumbers,@consignmentpeople,@remark,@bosomnote,@informmode,@notedate,@notename,@received,@consignmenttype)");
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
        public void Amend(ShowShop.Model.Order.ConsignMent model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_consignment set ");
            strSql.Append("orderid=@orderid,");
            strSql.Append("username=@username,");
            strSql.Append("consignmentdate=@consignmentdate,");
            strSql.Append("expresscompany=@expresscompany,");
            strSql.Append("expressoddnumbers=@expressoddnumbers,");
            strSql.Append("consignmentpeople=@consignmentpeople,");
            strSql.Append("remark=@remark,");
            strSql.Append("bosomnote=@bosomnote,");
            strSql.Append("informmode=@informmode,");
            strSql.Append("notedate=@notedate,");
            strSql.Append("notename=@notename,");
            strSql.Append("received=@received,");
            strSql.Append("consignmenttype=@consignmenttype");
            strSql.Append(" where id=@id ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_consignment ");
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
            string sequel = "Update [yxs_consignment] set ";
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
        public ShowShop.Model.Order.ConsignMent GetModelByID(int id)
        {
            ShowShop.Model.Order.ConsignMent model = new ShowShop.Model.Order.ConsignMent();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,orderid,username,consignmentdate,expresscompany,expressoddnumbers,consignmentpeople,remark,bosomnote,informmode,notedate,notename,received,consignmenttype from yxs_consignment ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.ConsignMentDate = reader.GetDateTime(3);
                    model.ExpressCompany = reader.GetString(4);
                    model.ExpressOddNumbers = reader.GetString(5);
                    model.ConsignMentPeople = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.BosomNote = reader.GetString(8);
                    model.InformMode = reader.GetString(9);
                    model.NoteDate = reader.GetDateTime(10);
                    model.NoteName = reader.GetString(11);
                    model.Received = reader.GetInt32(12);
                    model.ConsignMentType = reader.GetInt32(13);
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
        public List<ShowShop.Model.Order.ConsignMent> GetAll()
        {
            List<ShowShop.Model.Order.ConsignMent> list = new List<ShowShop.Model.Order.ConsignMent>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderid,username,consignmentdate,expresscompany,expressoddnumbers,consignmentpeople,remark,bosomnote,informmode,notedate,notename,received,consignmenttype from yxs_consignment ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Order.ConsignMent model = new ShowShop.Model.Order.ConsignMent();
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.ConsignMentDate = reader.GetDateTime(3);
                    model.ExpressCompany = reader.GetString(4);
                    model.ExpressOddNumbers = reader.GetString(5);
                    model.ConsignMentPeople = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.BosomNote = reader.GetString(8);
                    model.InformMode = reader.GetString(9);
                    model.NoteDate = reader.GetDateTime(10);
                    model.NoteName = reader.GetString(11);
                    model.Received = reader.GetInt32(12);
                    model.ConsignMentType = reader.GetInt32(13);
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
        public List<ShowShop.Model.Order.ConsignMent> GetAll(string strWhere)
        {
            List<ShowShop.Model.Order.ConsignMent> list = new List<ShowShop.Model.Order.ConsignMent>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,orderid,username,consignmentdate,expresscompany,expressoddnumbers,consignmentpeople,remark,bosomnote,informmode,notedate,notename,received,consignmenttype from yxs_consignment ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Order.ConsignMent model = new ShowShop.Model.Order.ConsignMent();
                    model.ID = reader.GetInt32(0);
                    model.OrderId = reader.GetString(1);
                    model.UserName = reader.GetString(2);
                    model.ConsignMentDate = reader.GetDateTime(3);
                    model.ExpressCompany = reader.GetString(4);
                    model.ExpressOddNumbers = reader.GetString(5);
                    model.ConsignMentPeople = reader.GetString(6);
                    model.Remark = reader.GetString(7);
                    model.BosomNote = reader.GetString(8);
                    model.InformMode = reader.GetString(9);
                    model.NoteDate = reader.GetDateTime(10);
                    model.NoteName = reader.GetString(11);
                    model.Received = reader.GetInt32(12);
                    model.ConsignMentType = reader.GetInt32(13);
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
            dataPage.Sql = "[select] * [from] yxs_consignment [where] " + strWhere + " [order by] id asc";
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
            dataPage.Sql = "[select] * [from] yxs_consignment [where] 1=1 [order by] id asc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Order.ConsignMent model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@orderid", SqlDbType.VarChar,50),
					new SqlParameter("@username", SqlDbType.VarChar,20),
					new SqlParameter("@consignmentdate", SqlDbType.DateTime),
					new SqlParameter("@expresscompany", SqlDbType.VarChar,100),
					new SqlParameter("@expressoddnumbers", SqlDbType.VarChar,50),
					new SqlParameter("@consignmentpeople", SqlDbType.Char,10),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@bosomnote", SqlDbType.VarChar,500),
					new SqlParameter("@informmode", SqlDbType.VarChar,50),
					new SqlParameter("@notedate", SqlDbType.DateTime),
					new SqlParameter("@notename", SqlDbType.VarChar,20),
					new SqlParameter("@received", SqlDbType.Int,4),
					new SqlParameter("@consignmenttype", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.ConsignMentDate;
            parameters[4].Value = model.ExpressCompany;
            parameters[5].Value = model.ExpressOddNumbers;
            parameters[6].Value = model.ConsignMentPeople;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.BosomNote;
            parameters[9].Value = model.InformMode;
            parameters[10].Value = model.NoteDate;
            parameters[11].Value = model.NoteName;
            parameters[12].Value = model.Received;
            parameters[13].Value = model.ConsignMentType;
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
