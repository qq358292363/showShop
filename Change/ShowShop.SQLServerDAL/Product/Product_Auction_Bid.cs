using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;
using ChangeHope.DataBase;

namespace ShowShop.SQLServerDAL.Product
{
    /// <summary>
    /// 数据访问类ProductauctionBid。
    /// </summary>
    public class Product_Auction_Bid : IProduct_Auction_Bid
    {
        private string tableName = "";
        public Product_Auction_Bid()
        {
            tableName = "yxs_productauction_bid";
        }
        #region "DataBase Operation"
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + tableName);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.Product_Auction_Bid model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + tableName + "(");
            strSql.Append("uid,orderno,productid,price,datetime,count,state,provinces,city,borough,address,tel,phone,zip,username)");
            strSql.Append(" values (");
            strSql.Append("@uid,@orderno,@productid,@price,@datetime,@count,@state,@provinces,@city,@borough,@address,@tel,@phone,@zip,@username)");
            strSql.Append(";select @@IDENTITY");

            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
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
        public int Update(ShowShop.Model.Product.Product_Auction_Bid model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + tableName + " set ");
            strSql.Append("uid=@uid,");
            strSql.Append("orderno=@orderno,");
            strSql.Append("productid=@productid,");
            strSql.Append("price=@price,");
            strSql.Append("datetime=@datetime,");
            strSql.Append("count=@count,");
            strSql.Append("state=@state,");
            strSql.Append("provinces=@provinces,");
            strSql.Append("city=@city,");
            strSql.Append("borough=@borough,");
            strSql.Append("address=@address,");
            strSql.Append("tel=@tel,");
            strSql.Append("phone=@phone,");
            strSql.Append("zip=@zip");
            strSql.Append("username=@username");
            strSql.Append(" where id=@id ");
            string sequel = strSql.ToString() + UpdateWhereSequel;
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
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tableName);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
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
            string sequel = "Update " + tableName + " set ";
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
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.Product_Auction_Bid GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,uid,orderno,productid,price,datetime,count,state,provinces,city,borough,address,tel,phone,zip,username from " + tableName);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            ShowShop.Model.Product.Product_Auction_Bid model = new ShowShop.Model.Product.Product_Auction_Bid();
            DataSet ds = SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.uid = ds.Tables[0].Rows[0]["uid"].ToString();
                model.orderno = ds.Tables[0].Rows[0]["orderno"].ToString();
                if (ds.Tables[0].Rows[0]["productid"].ToString() != "")
                {
                    model.productid = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["datetime"].ToString() != "")
                {
                    model.datetime = DateTime.Parse(ds.Tables[0].Rows[0]["datetime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["count"].ToString() != "")
                {
                    model.count = int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["provinces"].ToString() != "")
                {
                    model.provinces = int.Parse(ds.Tables[0].Rows[0]["provinces"].ToString());
                }
                if (ds.Tables[0].Rows[0]["city"].ToString() != "")
                {
                    model.city = int.Parse(ds.Tables[0].Rows[0]["city"].ToString());
                }
                if (ds.Tables[0].Rows[0]["borough"].ToString() != "")
                {
                    model.borough = int.Parse(ds.Tables[0].Rows[0]["borough"].ToString());
                }
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.zip = ds.Tables[0].Rows[0]["zip"].ToString();
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
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
        public DataByPage GetListByPage()
        {
            DataByPage datapage = new DataByPage();
            datapage.Sql = "[select] * [from] " + tableName + " [where] 1=1 [order by] id asc";
            datapage.GetRecordSetByPage();
            return datapage;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] " + tableName + " [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 获取最大值
        /// </summary>
        public string maxValues(string field, string productid)
        {
            string Sql = "select max("+field+") as price from yxs_productauction_bid where productid="+productid+"";
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region "Other function"
        string selectSequel = string.Empty;
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "Select *,1 PersistStatus  From  " + tableName;
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

        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.Product_Auction_Bid model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.VarChar,50),
					new SqlParameter("@orderno", SqlDbType.VarChar,50),
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@datetime", SqlDbType.DateTime),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@provinces", SqlDbType.Int,4),
					new SqlParameter("@city", SqlDbType.Int,4),
					new SqlParameter("@borough", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,200),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,20),
					new SqlParameter("@zip", SqlDbType.VarChar,20),
                    new SqlParameter("@username",SqlDbType.VarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.uid;
            parameters[2].Value = model.orderno;
            parameters[3].Value = model.productid;
            parameters[4].Value = model.price;
            parameters[5].Value = model.datetime;
            parameters[6].Value = model.count;
            parameters[7].Value = model.state;
            parameters[8].Value = model.provinces;
            parameters[9].Value = model.city;
            parameters[10].Value = model.borough;
            parameters[11].Value = model.address;
            parameters[12].Value = model.tel;
            parameters[13].Value = model.phone;
            parameters[14].Value = model.zip;
            parameters[15].Value = model.username;
            return parameters;
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

