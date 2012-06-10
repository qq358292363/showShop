using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;

namespace ShowShop.SQLServerDAL.Product
{
    public class ProductAuction : IProductAuction
    {
        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Product.ProductAuction model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into [yxs_productauction](";
            sequel = sequel + "[auctionname], [description], [productid], [productname], [starttime], [endtime], [price], [pricerange], [deposit], [putoutid], [putouttypeid])";
            sequel = sequel + "Values(";
            sequel = sequel + "@auctionname, @description,@productid,@productname,@starttime,@endtime,@price,@pricerange,@deposit,@putoutid,@putouttypeid) Select scope_IDENTITY() ";
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
        public void Delete(string id)
        {
            string sequel = "Delete From [yxs_productauction]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(Int32.Parse(id));
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Amend(ShowShop.Model.Product.ProductAuction model)
        {
            string sequel = "Update [yxs_productauction] set  ";
            sequel = sequel + "[auctionname] =@auctionname ,[description] =@description ,[productid]=@productid ,[productname] =@productname ,[starttime] =@starttime ,[endtime] =@endtime ,[price] =@price,[pricerange] =@pricerange,[deposit] =@deposit,[putoutid] =@putoutid,[putouttypeid]=@putouttypeid";
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
            string sequel = "Update [yxs_productauction] set ";
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
        public ShowShop.Model.Product.ProductAuction GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Product.ProductAuction model = new ShowShop.Model.Product.ProductAuction();
            if (row != null)
            {
                model.ID = int.Parse(row["id"].ToString());
                model.AuctionName = row["auctionname"].ToString();
                model.Description = row["description"].ToString();
                model.ProductID = int.Parse(row["productid"].ToString());
                model.ProductName = row["productname"].ToString();
                model.StartTime = Convert.ToDateTime(row["starttime"].ToString());
                model.EndTime = Convert.ToDateTime(row["endtime"].ToString());
                model.Price = decimal.Parse(row["price"].ToString());
                model.PriceRange = decimal.Parse(row["pricerange"].ToString());
                model.Deposit = decimal.Parse(row["deposit"].ToString());
                model.PutoutID = int.Parse(row["putoutid"].ToString());
                model.PutoutTypeID = int.Parse(row["putouttypeid"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ID查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.Product.ProductAuction GetModelID(int id)
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
        public ShowShop.Model.Product.ProductAuction GetModelProductID(int ProductId)
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
            dataPage.Sql = "[select] * [from] yxs_productauction [where] 1=1 [order by] id asc";
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
            dataPage.Sql = "[select] * [from] yxs_productauction [where] 1=1 " + Conditions + " " + orderfield;
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
                    selectSequel = "Select *,1 PersistStatus  From [yxs_productauction] ";
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

        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.ProductAuction model)
        {
            SqlParameter[] paras = new SqlParameter[12];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@auctionname", SqlDbType.VarChar, 100);
            paras[1].Value = model.AuctionName;
            paras[2] = new SqlParameter("@description", SqlDbType.VarChar, 2000);
            paras[2].Value = model.Description;

            paras[3] = new SqlParameter("@productid", SqlDbType.Int, 4);
            paras[3].Value = model.ProductID;
            paras[4] = new SqlParameter("@productname", SqlDbType.VarChar, 2000);
            paras[4].Value = model.ProductName;

            paras[5] = new SqlParameter("@starttime", SqlDbType.DateTime, 8);
            paras[5].Value = model.StartTime;
            paras[6] = new SqlParameter("@endtime", SqlDbType.DateTime, 8);
            paras[6].Value = model.EndTime;
            paras[7] = new SqlParameter("@price", SqlDbType.Float, 8);
            paras[7].Value = model.Price;
            paras[8] = new SqlParameter("@pricerange", SqlDbType.Float, 8);
            paras[8].Value = model.PriceRange;
            paras[9] = new SqlParameter("@deposit", SqlDbType.Float, 8);
            paras[9].Value = model.Deposit;
            paras[10] = new SqlParameter("@putoutid", SqlDbType.Float, 4);
            paras[10].Value = model.PutoutID;
            paras[11] = new SqlParameter("@putouttypeid", SqlDbType.Int, 4);
            paras[11].Value = model.PutoutTypeID;

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
