using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Order;
using ChangeHope.DataBase;
namespace ShowShop.SQLServerDAL.Order
{
    /// <summary>
    /// 数据访问类Orders。
    /// </summary>
    public class Orders : DbBase,IOrders
    {
        private string tableName = "";
        public Orders()
        {
            tableName = "" + Pre + "orders";
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + tableName);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Order.Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + tableName + "(");
            strSql.Append("OrderId,UserId,ReceiverId,ShopDate,OrderDate,ConsigneeRealName,ConsigneeName,ConsigneePhone,ConsigneeProvince,ConsigneeAddress,ConsigneeZip,ConsigneeTel,ConsigneeFax,ConsigneeEmail,WhetherCouAndinte,ParvalueAndInte,PaymentType,Payment,Courier,TotalPrice,FactPrice,Invoice,Remark,OrderStatus,SaleUserID,SaleUserType,BusinessmanID,Carriage,OrderType,PaymentStatus)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@UserId,@ReceiverId,@ShopDate,@OrderDate,@ConsigneeRealName,@ConsigneeName,@ConsigneePhone,@ConsigneeProvince,@ConsigneeAddress,@ConsigneeZip,@ConsigneeTel,@ConsigneeFax,@ConsigneeEmail,@WhetherCouAndinte,@ParvalueAndInte,@PaymentType,@Payment,@Courier,@TotalPrice,@FactPrice,@Invoice,@Remark,@OrderStatus,@SaleUserID,@SaleUserType,@BusinessmanID,@Carriage,@OrderType,@PaymentStatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiverId", SqlDbType.VarChar,50),
					new SqlParameter("@ShopDate", SqlDbType.DateTime),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@ConsigneeRealName", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeName", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneePhone", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeProvince", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeAddress", SqlDbType.VarChar,200),
					new SqlParameter("@ConsigneeZip", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeTel", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeFax", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeEmail", SqlDbType.VarChar,50),
					new SqlParameter("@WhetherCouAndinte", SqlDbType.VarChar,50),
					new SqlParameter("@ParvalueAndInte", SqlDbType.Float,8),
					new SqlParameter("@PaymentType", SqlDbType.VarChar,50),
					new SqlParameter("@Payment", SqlDbType.Float,8),
					new SqlParameter("@Courier", SqlDbType.Float,8),
					new SqlParameter("@TotalPrice", SqlDbType.Float,8),
					new SqlParameter("@FactPrice", SqlDbType.Float,8),
					new SqlParameter("@Invoice", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@OrderStatus", SqlDbType.Int,4),
					new SqlParameter("@SaleUserID", SqlDbType.VarChar,50),
					new SqlParameter("@SaleUserType", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessmanID", SqlDbType.VarChar,50),
					new SqlParameter("@Carriage", SqlDbType.Float,8),
                    new SqlParameter("@OrderType",SqlDbType.Int,4),
                    new SqlParameter("@PaymentStatus",SqlDbType.Int,4)
                    /**
                     *
                     * kevin
                     * 2009-12.16
                     */
                                        };
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.ReceiverId;
            parameters[3].Value = model.ShopDate;
            parameters[4].Value = model.OrderDate;
            parameters[5].Value = model.ConsigneeRealName;
            parameters[6].Value = model.ConsigneeName;
            parameters[7].Value = model.ConsigneePhone;
            parameters[8].Value = model.ConsigneeProvince;
            parameters[9].Value = model.ConsigneeAddress;
            parameters[10].Value = model.ConsigneeZip;
            parameters[11].Value = model.ConsigneeTel;
            parameters[12].Value = model.ConsigneeFax;
            parameters[13].Value = model.ConsigneeEmail;
            parameters[14].Value = model.WhetherCouAndinte;
            parameters[15].Value = model.ParvalueAndInte;
            parameters[16].Value = model.PaymentType;
            parameters[17].Value = model.Payment;
            parameters[18].Value = model.Courier;
            parameters[19].Value = model.TotalPrice;
            parameters[20].Value = model.FactPrice;
            parameters[21].Value = model.Invoice;
            parameters[22].Value = model.Remark;
            parameters[23].Value = model.OrderStatus;
            parameters[24].Value = model.SaleUserID;
            parameters[25].Value = model.SaleUserType;
            parameters[26].Value = model.BusinessmanID;
            parameters[27].Value = model.Carriage;
            parameters[28].Value = model.OrderType;
            parameters[29].Value = model.PaymentStatus;

            object obj = SQLServerHelper.GetSingle(strSql.ToString(), parameters);
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
        public void Update(ShowShop.Model.Order.Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + tableName + " set ");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("ReceiverId=@ReceiverId,");
            strSql.Append("ShopDate=@ShopDate,");
            strSql.Append("OrderDate=@OrderDate,");
            strSql.Append("ConsigneeRealName=@ConsigneeRealName,");
            strSql.Append("ConsigneeName=@ConsigneeName,");
            strSql.Append("ConsigneePhone=@ConsigneePhone,");
            strSql.Append("ConsigneeProvince=@ConsigneeProvince,");
            strSql.Append("ConsigneeAddress=@ConsigneeAddress,");
            strSql.Append("ConsigneeZip=@ConsigneeZip,");
            strSql.Append("ConsigneeTel=@ConsigneeTel,");
            strSql.Append("ConsigneeFax=@ConsigneeFax,");
            strSql.Append("ConsigneeEmail=@ConsigneeEmail,");
            strSql.Append("WhetherCouAndinte=@WhetherCouAndinte,");
            strSql.Append("ParvalueAndInte=@ParvalueAndInte,");
            strSql.Append("PaymentType=@PaymentType,");
            strSql.Append("Payment=@Payment,");
            strSql.Append("Courier=@Courier,");
            strSql.Append("TotalPrice=@TotalPrice,");
            strSql.Append("FactPrice=@FactPrice,");
            strSql.Append("Invoice=@Invoice,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("OrderStatus=@OrderStatus,");
            strSql.Append("SaleUserID=@SaleUserID,");
            strSql.Append("SaleUserType=@SaleUserType,");
            strSql.Append("BusinessmanID=@BusinessmanID,");
            strSql.Append("Carriage=@Carriage,");
            strSql.Append("PaymentStatus=@PaymentStatus");
            /**
             *
             * kevin
             *修改时间2009-12.16
             */
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiverId", SqlDbType.VarChar,50),
					new SqlParameter("@ShopDate", SqlDbType.DateTime),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@ConsigneeRealName", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeName", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneePhone", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeProvince", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeAddress", SqlDbType.VarChar,200),
					new SqlParameter("@ConsigneeZip", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeTel", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeFax", SqlDbType.VarChar,50),
					new SqlParameter("@ConsigneeEmail", SqlDbType.VarChar,50),
					new SqlParameter("@WhetherCouAndinte", SqlDbType.VarChar,50),
					new SqlParameter("@ParvalueAndInte", SqlDbType.Float,8),
					new SqlParameter("@PaymentType", SqlDbType.VarChar,50),
					new SqlParameter("@Payment", SqlDbType.Float,8),
					new SqlParameter("@Courier", SqlDbType.Float,8),
					new SqlParameter("@TotalPrice", SqlDbType.Float,8),
					new SqlParameter("@FactPrice", SqlDbType.Float,8),
					new SqlParameter("@Invoice", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@OrderStatus", SqlDbType.Int,4),
					new SqlParameter("@SaleUserID", SqlDbType.VarChar,50),
					new SqlParameter("@SaleUserType", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessmanID", SqlDbType.VarChar,50),
					new SqlParameter("@Carriage", SqlDbType.Float,8),
                    new SqlParameter("@PaymentStatus",SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.OrderId;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.ReceiverId;
            parameters[4].Value = model.ShopDate;
            parameters[5].Value = model.OrderDate;
            parameters[6].Value = model.ConsigneeRealName;
            parameters[7].Value = model.ConsigneeName;
            parameters[8].Value = model.ConsigneePhone;
            parameters[9].Value = model.ConsigneeProvince;
            parameters[10].Value = model.ConsigneeAddress;
            parameters[11].Value = model.ConsigneeZip;
            parameters[12].Value = model.ConsigneeTel;
            parameters[13].Value = model.ConsigneeFax;
            parameters[14].Value = model.ConsigneeEmail;
            parameters[15].Value = model.WhetherCouAndinte;
            parameters[16].Value = model.ParvalueAndInte;
            parameters[17].Value = model.PaymentType;
            parameters[18].Value = model.Payment;
            parameters[19].Value = model.Courier;
            parameters[20].Value = model.TotalPrice;
            parameters[21].Value = model.FactPrice;
            parameters[22].Value = model.Invoice;
            parameters[23].Value = model.Remark;
            parameters[24].Value = model.OrderStatus;
            parameters[25].Value = model.SaleUserID;
            parameters[26].Value = model.SaleUserType;
            parameters[27].Value = model.BusinessmanID;
            parameters[28].Value = model.Carriage;
            parameters[29].Value = model.PaymentStatus;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
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
            string sequel = "Update [" + tableName + "] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + " where Id=@Id";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@Id", id) };
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
        /// 删除一条数据
        /// </summary>
        public void Delete(string strId)
        {
            string orderSql = "delete from " + tableName + " where Id in (" + strId + ")";
            string orderProductSql = "delete from yxs_orderproduct where OrderId in (" + strId + ")";
            SQLServerHelper.ExecuteSql(orderSql);
            SQLServerHelper.ExecuteSql(orderProductSql);
        }

        public ShowShop.Model.Order.Orders GetModel(string orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,OrderId,UserId,ReceiverId,ShopDate,OrderDate,ConsigneeRealName,ConsigneeName,ConsigneePhone,ConsigneeProvince,ConsigneeAddress,ConsigneeZip,ConsigneeTel,ConsigneeFax,ConsigneeEmail,WhetherCouAndinte,ParvalueAndInte,PaymentType,Payment,Courier,TotalPrice,FactPrice,Invoice,Remark,OrderStatus,SaleUserID,SaleUserType,BusinessmanID,Carriage,PaymentStatus,OgisticsStatus,OrderType,IsOrderNormal from " + tableName);
            strSql.Append(" where OrderId=@OrderId ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.VarChar,50)};
            parameters[0].Value = orderId;

            ShowShop.Model.Order.Orders model = new ShowShop.Model.Order.Orders();
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.OrderId = ds.Tables[0].Rows[0]["OrderId"].ToString();
                model.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                model.ReceiverId = ds.Tables[0].Rows[0]["ReceiverId"].ToString();
                if (ds.Tables[0].Rows[0]["ShopDate"].ToString() != "")
                {
                    model.ShopDate = DateTime.Parse(ds.Tables[0].Rows[0]["ShopDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                model.ConsigneeRealName = ds.Tables[0].Rows[0]["ConsigneeRealName"].ToString();
                model.ConsigneeName = ds.Tables[0].Rows[0]["ConsigneeName"].ToString();
                model.ConsigneePhone = ds.Tables[0].Rows[0]["ConsigneePhone"].ToString();
                model.ConsigneeProvince = ds.Tables[0].Rows[0]["ConsigneeProvince"].ToString();
                model.ConsigneeAddress = ds.Tables[0].Rows[0]["ConsigneeAddress"].ToString();
                model.ConsigneeZip = ds.Tables[0].Rows[0]["ConsigneeZip"].ToString();
                model.ConsigneeTel = ds.Tables[0].Rows[0]["ConsigneeTel"].ToString();
                model.ConsigneeFax = ds.Tables[0].Rows[0]["ConsigneeFax"].ToString();
                model.ConsigneeEmail = ds.Tables[0].Rows[0]["ConsigneeEmail"].ToString();
                model.WhetherCouAndinte = ds.Tables[0].Rows[0]["WhetherCouAndinte"].ToString();
                if (ds.Tables[0].Rows[0]["ParvalueAndInte"].ToString() != "")
                {
                    model.ParvalueAndInte = decimal.Parse(ds.Tables[0].Rows[0]["ParvalueAndInte"].ToString());
                }
                model.PaymentType = ds.Tables[0].Rows[0]["PaymentType"].ToString();
                if (ds.Tables[0].Rows[0]["Payment"].ToString() != "")
                {
                    model.Payment = decimal.Parse(ds.Tables[0].Rows[0]["Payment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Courier"].ToString() != "")
                {
                    model.Courier = decimal.Parse(ds.Tables[0].Rows[0]["Courier"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactPrice"].ToString() != "")
                {
                    model.FactPrice = decimal.Parse(ds.Tables[0].Rows[0]["FactPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Invoice"].ToString() != "")
                {
                    model.Invoice = int.Parse(ds.Tables[0].Rows[0]["Invoice"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = int.Parse(ds.Tables[0].Rows[0]["OrderStatus"].ToString());
                }
                model.SaleUserID = ds.Tables[0].Rows[0]["SaleUserID"].ToString();
                model.SaleUserType = ds.Tables[0].Rows[0]["SaleUserType"].ToString();
                model.BusinessmanID = ds.Tables[0].Rows[0]["BusinessmanID"].ToString();
                if (ds.Tables[0].Rows[0]["Carriage"].ToString() != "")
                {
                    model.Carriage = decimal.Parse(ds.Tables[0].Rows[0]["Carriage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PaymentStatus"].ToString() != "")
                {
                    model.PaymentStatus = int.Parse(ds.Tables[0].Rows[0]["PaymentStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OgisticsStatus"].ToString() != "")
                {
                    model.OgisticsStatus = int.Parse(ds.Tables[0].Rows[0]["OgisticsStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOrderNormal"].ToString() != "")
                {
                    model.IsOrderNormal = int.Parse(ds.Tables[0].Rows[0]["IsOrderNormal"].ToString());
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
        public ShowShop.Model.Order.Orders GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,OrderId,UserId,ReceiverId,ShopDate,OrderDate,ConsigneeRealName,ConsigneeName,ConsigneePhone,ConsigneeProvince,ConsigneeAddress,ConsigneeZip,ConsigneeTel,ConsigneeFax,ConsigneeEmail,WhetherCouAndinte,ParvalueAndInte,PaymentType,Payment,Courier,TotalPrice,FactPrice,Invoice,Remark,OrderStatus,SaleUserID,SaleUserType,BusinessmanID,Carriage,PaymentStatus,OgisticsStatus,OrderType,IsOrderNormal from " + tableName);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ShowShop.Model.Order.Orders model = new ShowShop.Model.Order.Orders();
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.OrderId = ds.Tables[0].Rows[0]["OrderId"].ToString();
                model.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                model.ReceiverId = ds.Tables[0].Rows[0]["ReceiverId"].ToString();
                if (ds.Tables[0].Rows[0]["ShopDate"].ToString() != "")
                {
                    model.ShopDate = DateTime.Parse(ds.Tables[0].Rows[0]["ShopDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                model.ConsigneeRealName = ds.Tables[0].Rows[0]["ConsigneeRealName"].ToString();
                model.ConsigneeName = ds.Tables[0].Rows[0]["ConsigneeName"].ToString();
                model.ConsigneePhone = ds.Tables[0].Rows[0]["ConsigneePhone"].ToString();
                model.ConsigneeProvince = ds.Tables[0].Rows[0]["ConsigneeProvince"].ToString();
                model.ConsigneeAddress = ds.Tables[0].Rows[0]["ConsigneeAddress"].ToString();
                model.ConsigneeZip = ds.Tables[0].Rows[0]["ConsigneeZip"].ToString();
                model.ConsigneeTel = ds.Tables[0].Rows[0]["ConsigneeTel"].ToString();
                model.ConsigneeFax = ds.Tables[0].Rows[0]["ConsigneeFax"].ToString();
                model.ConsigneeEmail = ds.Tables[0].Rows[0]["ConsigneeEmail"].ToString();
                model.WhetherCouAndinte = ds.Tables[0].Rows[0]["WhetherCouAndinte"].ToString();
                if (ds.Tables[0].Rows[0]["ParvalueAndInte"].ToString() != "")
                {
                    model.ParvalueAndInte = decimal.Parse(ds.Tables[0].Rows[0]["ParvalueAndInte"].ToString());
                }
                model.PaymentType = ds.Tables[0].Rows[0]["PaymentType"].ToString();
                if (ds.Tables[0].Rows[0]["Payment"].ToString() != "")
                {
                    model.Payment = decimal.Parse(ds.Tables[0].Rows[0]["Payment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Courier"].ToString() != "")
                {
                    model.Courier = decimal.Parse(ds.Tables[0].Rows[0]["Courier"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactPrice"].ToString() != "")
                {
                    model.FactPrice = decimal.Parse(ds.Tables[0].Rows[0]["FactPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Invoice"].ToString() != "")
                {
                    model.Invoice = int.Parse(ds.Tables[0].Rows[0]["Invoice"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = int.Parse(ds.Tables[0].Rows[0]["OrderStatus"].ToString());
                }
                model.SaleUserID = ds.Tables[0].Rows[0]["SaleUserID"].ToString();
                model.SaleUserType = ds.Tables[0].Rows[0]["SaleUserType"].ToString();
                model.BusinessmanID = ds.Tables[0].Rows[0]["BusinessmanID"].ToString();
                if (ds.Tables[0].Rows[0]["Carriage"].ToString() != "")
                {
                    model.Carriage = decimal.Parse(ds.Tables[0].Rows[0]["Carriage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PaymentStatus"].ToString() != "")
                {
                    model.PaymentStatus = int.Parse(ds.Tables[0].Rows[0]["PaymentStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OgisticsStatus"].ToString() != "")
                {
                    model.OgisticsStatus = int.Parse(ds.Tables[0].Rows[0]["OgisticsStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOrderNormal"].ToString() != "")
                {
                    model.IsOrderNormal = int.Parse(ds.Tables[0].Rows[0]["IsOrderNormal"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public ChangeHope.DataBase.DataByPage GetListByPage(string sqlWhere)
        {
            ChangeHope.DataBase.DataByPage datapage = new DataByPage();
            datapage.Sql = "[select] *,(select content from yxs_code_order_step where code=" + tableName + ".OrderStatus) as OrderStatusContent [from] " + tableName + " [where] 1=1 " + sqlWhere + " [order by] OrderDate desc";
            datapage.GetRecordSetByPage();
            return datapage;
        }
        /// <summary>
        /// 前台
        /// </summary>
        /// <param name="orderfield"></param>
        /// <param name="pagesize"></param>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] *,(select content from yxs_code_order_step where code=" + tableName + ".OrderStatus) as OrderStatusContent [from] " + tableName + " [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        #endregion  成员方法
    }
}

