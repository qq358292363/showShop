using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Order;
using ChangeHope.DataBase;
namespace ShowShop.SQLServerDAL.Order
{
    /// <summary>
    /// 数据访问类OrderProduct。
    /// </summary>
    public class OrderProduct : IOrderProduct
    {
        private string tableName = "";
        public OrderProduct()
        {
            tableName ="yxs_orderproduct";
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
        public int Add(ShowShop.Model.Order.OrderProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + tableName + "(");
            strSql.Append("OrderId,ProId,ProClass,ProName,ProImg,ProPrice,ProNum,AddTime,ProOtherPara,Specification,FittingsProductId,FittingsProductCount,FittingsProductPrice,FittingsId)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@ProId,@ProClass,@ProName,@ProImg,@ProPrice,@ProNum,@AddTime,@ProOtherPara,@Specification,@FittingsProductId,@FittingsProductCount,@FittingsProductPrice,@FittingsId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@ProId", SqlDbType.Int,4),
					new SqlParameter("@ProClass", SqlDbType.VarChar,50),
					new SqlParameter("@ProName", SqlDbType.VarChar,500),
					new SqlParameter("@ProImg", SqlDbType.VarChar,500),
					new SqlParameter("@ProPrice", SqlDbType.Float,8),
					new SqlParameter("@ProNum", SqlDbType.Float,8),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ProOtherPara", SqlDbType.VarChar,500),
            new SqlParameter("@Specification", SqlDbType.VarChar,500),
					new SqlParameter("@FittingsProductId", SqlDbType.VarChar,200),
					new SqlParameter("@FittingsProductCount", SqlDbType.VarChar,200),
                                        new SqlParameter("@FittingsProductPrice",SqlDbType.VarChar,200),
                                        new SqlParameter("@FittingsId",SqlDbType.Int)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.ProId;
            parameters[2].Value = model.ProClass;
            parameters[3].Value = model.ProName;
            parameters[4].Value = model.ProImg;
            parameters[5].Value = model.ProPrice;
            parameters[6].Value = model.ProNum;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.ProOtherPara;
            parameters[9].Value = model.Specification;
            parameters[10].Value = model.FittingsProductId;
            parameters[11].Value = model.FittingsProductCount;
            parameters[12].Value = model.FittingsProductPrice;
            parameters[13].Value = model.FittingsId;
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
        public void Update(ShowShop.Model.Order.OrderProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + tableName + " set ");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("ProId=@ProId,");
            strSql.Append("ProClass=@ProClass,");
            strSql.Append("ProName=@ProName,");
            strSql.Append("ProImg=@ProImg,");
            strSql.Append("ProPrice=@ProPrice,");
            strSql.Append("ProNum=@ProNum,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("ProOtherPara=@ProOtherPara");
            strSql.Append("Specification=@Specification");
            strSql.Append("FittingsProductId=@FittingsProductId");
            strSql.Append("FittingsProductCount=@FittingsProductCount");
            strSql.Append("FittingsProductPrice=@FittingsProductPrice");
            strSql.Append("FittingsId=@FittingsId");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.Int,4),
					new SqlParameter("@ProId", SqlDbType.Int,4),
					new SqlParameter("@ProClass", SqlDbType.VarChar,50),
					new SqlParameter("@ProName", SqlDbType.VarChar,500),
					new SqlParameter("@ProImg", SqlDbType.VarChar,500),
					new SqlParameter("@ProPrice", SqlDbType.Float,8),
					new SqlParameter("@ProNum", SqlDbType.Float,8),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ProOtherPara", SqlDbType.VarChar,500),
                    new SqlParameter("@Specification", SqlDbType.VarChar,500),
					new SqlParameter("@FittingsProductId", SqlDbType.VarChar,200),
					new SqlParameter("@FittingsProductCount", SqlDbType.VarChar,200),
                                        new SqlParameter("@FittingsProductPrice",SqlDbType.VarChar,200),
                                        new SqlParameter("@FittingsId",SqlDbType.Int)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.OrderId;
            parameters[2].Value = model.ProId;
            parameters[3].Value = model.ProClass;
            parameters[4].Value = model.ProName;
            parameters[5].Value = model.ProImg;
            parameters[6].Value = model.ProPrice;
            parameters[7].Value = model.ProNum;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.ProOtherPara;
            parameters[10].Value = model.Specification;
            parameters[11].Value = model.FittingsProductId;
            parameters[12].Value = model.FittingsProductCount;
            parameters[13].Value = model.FittingsProductPrice;
            parameters[14].Value = model.FittingsId;
            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update [" + tableName + "] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + " where Id=@Id";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@Id", id) };
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(sequel, paras);
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
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Order.OrderProduct GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,OrderId,ProId,ProClass,ProName,ProImg,ProPrice,ProNum,AddTime,ProOtherPara,Specification,FittingsProductId,FittingsProductCount,FittingsProductPrice,FittingsId from " + tableName);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ShowShop.Model.Order.OrderProduct model = new ShowShop.Model.Order.OrderProduct();
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProId"].ToString() != "")
                {
                    model.ProId = int.Parse(ds.Tables[0].Rows[0]["ProId"].ToString());
                }
                model.ProClass = ds.Tables[0].Rows[0]["ProClass"].ToString();
                model.ProName = ds.Tables[0].Rows[0]["ProName"].ToString();
                model.ProImg = ds.Tables[0].Rows[0]["ProImg"].ToString();
                if (ds.Tables[0].Rows[0]["ProPrice"].ToString() != "")
                {
                    model.ProPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProNum"].ToString() != "")
                {
                    model.ProNum = decimal.Parse(ds.Tables[0].Rows[0]["ProNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                model.ProOtherPara = ds.Tables[0].Rows[0]["ProOtherPara"].ToString();
                model.Specification = ds.Tables[0].Rows[0]["Specification"].ToString();
                model.FittingsProductId = ds.Tables[0].Rows[0]["FittingsProductId"].ToString();
                model.FittingsProductCount = ds.Tables[0].Rows[0]["FittingsProductCount"].ToString();
                model.FittingsProductPrice = ds.Tables[0].Rows[0]["FittingsProductPrice"].ToString();
                if (ds.Tables[0].Rows[0]["FittingsId"].ToString() != "")
                {
                    model.FittingsId = Convert.ToInt32(ds.Tables[0].Rows[0]["FittingsId"].ToString());
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
        public ChangeHope.DataBase.DataByPage GetListByPage()
        {
            ChangeHope.DataBase.DataByPage datapage = new DataByPage();
            datapage.Sql = "[select] * [from] " + tableName + " [where] 1=1 [order by] id asc";
            datapage.GetRecordSetByPage();
            return datapage;
        }
        /// <summary>
        /// 跟据条件查询
        /// </summary>
        /// <param name="StrWhere">条件</param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetListByPage(string StrWhere)
        {
            ChangeHope.DataBase.DataByPage datapage = new DataByPage();
            datapage.Sql = "[select] * [from] " + tableName + " [where] 1=1 "+StrWhere+" [order by] id asc";
            datapage.GetRecordSetByPage();
            return datapage;
        }
        /// <summary>
        /// 跟据订单号查询
        /// </summary>
        /// <param name="OrderId">订单ID</param>
        /// <returns></returns>
        public DataTable GetListOrderProduct(string OrderId)
        {
            string sql = "Select * from " + tableName + " where OrderId=@OrderId";
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.Int,4)};
            parameters[0].Value = OrderId;
            return ChangeHope.DataBase.SQLServerHelper.Query(sql, parameters).Tables[0];
        }
        #endregion  成员方法
    }
}

