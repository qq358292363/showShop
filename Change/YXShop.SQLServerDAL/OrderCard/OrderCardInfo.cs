using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ShowShop.IDAL.OrderCard;

namespace ShowShop.SQLServerDAL.OrderCard
{
    public class OrderCardInfo : IOrderCardInfo
    {
        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.OrderCard.OrderCardInfo model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into [yxs_ordercard](";
            sequel = sequel + "[productid], [iswebsitersale], [type], [cardnumber], [password], [facevalue], [point], [unit], [expirationdate], [businessagent], [createdate], [appearance], [price], [whetherRelease], [updatedate], [username], [fullmoneydate])";
            sequel = sequel + "Values(";
            sequel = sequel + "@productid, @iswebsitersale,@type,@cardnumber,@password,@facevalue,@point,@unit,@expirationdate,@businessagent,@createdate,@appearance,@price,@whetherRelease,@updatedate,@username,@fullmoneydate) Select scope_IDENTITY() ";
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
        /// 删除数据
        /// </summary>
        /// <remarks></remarks>
        public void Delete(int id)
        {
            string sequel = "Delete From [yxs_ordercard]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Amend(ShowShop.Model.OrderCard.OrderCardInfo model)
        {
            string sequel = "Update [yxs_ordercard] set  ";
            sequel = sequel + "[productid] =@productid ,[iswebsitersale] =@iswebsitersale ,[type]=@type ,[cardnumber] =@cardnumber ,[password] =@password ,[facevalue] =@facevalue ,[point] =@point,[unit] =@unit,[expirationdate] =@expirationdate,[businessagent] =@businessagent,[createdate] =@createdate,[appearance] =@appearance,[price] =@price,[whetherRelease] =@whetherRelease,[updatedate] =@updatedate,[username] =@username,[fullmoneydate] =@fullmoneydate";
            sequel = sequel + UpdateWhereSequel;
            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, (SqlParameter[])this.ValueParas(model));
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
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update [yxs_ordercard] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@id", id) };
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
        /// 返回数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ShowShop.Model.OrderCard.OrderCardInfo GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.OrderCard.OrderCardInfo model = new ShowShop.Model.OrderCard.OrderCardInfo();
            if (row != null)
            {
                model.ID = int.Parse(row["id"].ToString());
                model.ProductID = int.Parse(row["productid"].ToString());
                model.IsWhetherSale = int.Parse(row["iswebsitersale"].ToString());
                model.Type = row["type"].ToString();
                model.CardNumber = row["cardnumber"].ToString();
                model.Password = row["password"].ToString();
                model.FaceValue = decimal.Parse(row["facevalue"].ToString());
                model.Point = row["point"].ToString();
                model.Unit = row["unit"].ToString();
                model.ExpirationDate = Convert.ToDateTime(row["expirationdate"].ToString());
                model.BusinessAgent = row["businessagent"].ToString();
                model.CreateDate = Convert.ToDateTime(row["createdate"].ToString());
                model.Appearance = int.Parse(row["appearance"].ToString());
                model.Price = decimal.Parse(row["price"].ToString());
                model.WhetherRelease = int.Parse(row["whetherRelease"].ToString());
                model.UserName = row["username"].ToString();
                model.UpdateDate = Convert.ToDateTime(row["updatedate"].ToString());
                model.FullMoneyDate = Convert.ToDateTime(row["fullmoneydate"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据卡号查询
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public ShowShop.Model.OrderCard.OrderCardInfo GetModelByCardNumber(string cardNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,password,expirationdate,point,unit,whetherRelease from yxs_ordercard  where cardnumber=@cardnumber");
            SqlParameter[] parameters ={
                                          new SqlParameter("@cardnumber",SqlDbType.VarChar,50)
                                      };
            parameters[0].Value = cardNumber;
            ShowShop.Model.OrderCard.OrderCardInfo model = null;
            using(SqlDataReader reader=ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(),parameters)){
                if(reader.Read())
                {
                    model = new ShowShop.Model.OrderCard.OrderCardInfo();
                    model.ID = (int)reader["id"];
                    model.Password = (string)reader["password"];
                    model.ExpirationDate = Convert.ToDateTime(reader["expirationdate"]);
                    model.Point = (string)reader["point"];
                    model.Unit = (string)reader["unit"];
                    model.WhetherRelease = Convert.ToInt32(reader["whetherRelease"]);                 
                }
            }
            return model;
            
        }
        /// <summary>
        /// ID查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.OrderCard.OrderCardInfo GetModelID(int id)
        {
            string sequel = SelectSequel + UpdateWhereSequel;
            SqlParameter[] paras = (SqlParameter[])this.ValueIDPara(id);
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(sequel, paras);
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
        /// ProductID查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.OrderCard.OrderCardInfo GetModelProductID(int ProductId)
        {
            string sequel = SelectSequel + " Where [productid] = @productid";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@productid", ProductId) };
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(sequel, paras);
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
        /// 所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_ordercard [where] 1=1 [order by] id asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 前台标签所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_ordercard [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion

        #region "Other function"
        string selectSequel = string.Empty;
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "Select *,1 PersistStatus  From [yxs_ordercard] ";
                return selectSequel;
            }
            set
            {
                this.selectSequel = value;
            }
        }
        /// <summary>
        /// 
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

        public IDbDataParameter[] ValueParas(ShowShop.Model.OrderCard.OrderCardInfo model)
        {
            SqlParameter[] paras = new SqlParameter[18];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@productid", SqlDbType.Int, 4);
            paras[1].Value = model.ProductID;
            paras[2] = new SqlParameter("@iswebsitersale", SqlDbType.Int, 4);
            paras[2].Value = model.IsWhetherSale;
            paras[3] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            paras[3].Value = model.Type;
            paras[4] = new SqlParameter("@cardnumber", SqlDbType.VarChar, 50);
            paras[4].Value = model.CardNumber;
            paras[5] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            paras[5].Value = model.Password;
            paras[6] = new SqlParameter("@facevalue", SqlDbType.Decimal, 9);
            paras[6].Value =model.FaceValue;
            paras[7] = new SqlParameter("@point", SqlDbType.VarChar, 50);
            paras[7].Value = model.Point;
            paras[8] = new SqlParameter("@unit", SqlDbType.Char, 10);
            paras[8].Value = model.Unit;
            paras[9] = new SqlParameter("@expirationdate", SqlDbType.DateTime, 8);
            paras[9].Value = model.ExpirationDate;
            paras[10] = new SqlParameter("@businessagent", SqlDbType.VarChar, 200);
            paras[10].Value = model.BusinessAgent;
            paras[11] = new SqlParameter("@createdate", SqlDbType.DateTime, 8);
            paras[11].Value = model.CreateDate;
            paras[12] = new SqlParameter("@appearance", SqlDbType.Int, 4);
            paras[12].Value = model.Appearance;
            paras[13] = new SqlParameter("@price", SqlDbType.Float, 8);
            paras[13].Value = model.Price;
            paras[14] = new SqlParameter("@whetherRelease", SqlDbType.Int, 4);
            paras[14].Value = model.WhetherRelease;
            paras[15] = new SqlParameter("@updatedate", SqlDbType.DateTime, 8);
            paras[15].Value = model.UpdateDate;
            paras[16] = new SqlParameter("@username", SqlDbType.VarChar, 50);
            paras[16].Value = model.UserName;
            paras[17] = new SqlParameter("@fullmoneydate", SqlDbType.DateTime,8);
            paras[17].Value = model.FullMoneyDate;

            return paras;
        }

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
