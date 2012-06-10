using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;

namespace ShowShop.SQLServerDAL.Product
{
    public class ProductSparepart:DbBase,IProductSparepart
    {
        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Product.ProductSparepart model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            strSql.Append("insert into " + Pre + "productsparepart(");
            strSql.Append("ProductId,SparepartName,BuyMinCount,BuyMaxCount,FavourableType,FavourableLimit,SparepartProduct)");
            strSql.Append(" values (");
            strSql.Append("@ProductId,@SparepartName,@BuyMinCount,@BuyMaxCount,@FavourableType,@FavourableLimit,@SparepartProduct)");
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
        /// 删除数据
        /// </summary>
        /// <remarks></remarks>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete " + Pre + "productsparepart ");
            strSql.Append(this.UpdateWhereSequel);
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除单个商品的配件
        /// </summary>
        /// <remarks></remarks>
        public void DeleteProductSparepart(int ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete " + Pre + "productsparepart ");
            strSql.Append("where ProductId=@ProductId");
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@ProductId", ProductId);
            paras[0].DbType = DbType.Int32;
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }
        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Amend(ShowShop.Model.Product.ProductSparepart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "productsparepart set ");
            strSql.Append("ProductId=@ProductId,");
            strSql.Append("SparepartName=@SparepartName,");
            strSql.Append("BuyMinCount=@BuyMinCount,");
            strSql.Append("BuyMaxCount=@BuyMaxCount,");
            strSql.Append("FavourableType=@FavourableType,");
            strSql.Append("FavourableLimit=@FavourableLimit,");
            strSql.Append("SparepartProduct=@SparepartProduct");
            strSql.Append(this.UpdateWhereSequel);
            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), (SqlParameter[])this.ValueParas(model));
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
            string sequel = "Update [" + Pre + "productsparepart] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@Id", id) };
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
        public ShowShop.Model.Product.ProductSparepart GetModelID(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(this.SelectSequel);
            strSql.Append(this.UpdateWhereSequel);
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);

            ShowShop.Model.Product.ProductSparepart model = new ShowShop.Model.Product.ProductSparepart();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
                }
                model.SparepartName = ds.Tables[0].Rows[0]["SparepartName"].ToString();
                if (ds.Tables[0].Rows[0]["BuyMinCount"].ToString() != "")
                {
                    model.BuyMinCount = int.Parse(ds.Tables[0].Rows[0]["BuyMinCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyMaxCount"].ToString() != "")
                {
                    model.BuyMaxCount = int.Parse(ds.Tables[0].Rows[0]["BuyMaxCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FavourableType"].ToString() != "")
                {
                    model.FavourableType = int.Parse(ds.Tables[0].Rows[0]["FavourableType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FavourableLimit"].ToString() != "")
                {
                    model.FavourableLimit = decimal.Parse(ds.Tables[0].Rows[0]["FavourableLimit"].ToString());
                }
                model.SparepartProduct = ds.Tables[0].Rows[0]["SparepartProduct"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 跟据ProductId查询规格
        /// </summary>
        /// <param name="ProductId">商品ID</param>
        /// <returns></returns>
        public List<ShowShop.Model.Product.ProductSparepart> GetSparepart(int ProductId)
        {
            List<ShowShop.Model.Product.ProductSparepart> list = new List<ShowShop.Model.Product.ProductSparepart>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(this.SelectSequel);
            strSql.Append(" where ProductId=@ProductId");
            SqlParameter[] parameters ={
					new SqlParameter("@ProductId", SqlDbType.Int,4)};
            parameters[0].Value = ProductId;

            
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    ShowShop.Model.Product.ProductSparepart model = new ShowShop.Model.Product.ProductSparepart();
                    if (ds.Tables[0].Rows[i]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ProductId"].ToString() != "")
                    {
                        model.ProductId = int.Parse(ds.Tables[0].Rows[i]["ProductId"].ToString());
                    }
                    model.SparepartName = ds.Tables[0].Rows[i]["SparepartName"].ToString();
                    if (ds.Tables[0].Rows[i]["BuyMinCount"].ToString() != "")
                    {
                        model.BuyMinCount = int.Parse(ds.Tables[0].Rows[i]["BuyMinCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["BuyMaxCount"].ToString() != "")
                    {
                        model.BuyMaxCount = int.Parse(ds.Tables[0].Rows[i]["BuyMaxCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["FavourableType"].ToString() != "")
                    {
                        model.FavourableType = int.Parse(ds.Tables[0].Rows[i]["FavourableType"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["FavourableLimit"].ToString() != "")
                    {
                        model.FavourableLimit = decimal.Parse(ds.Tables[0].Rows[i]["FavourableLimit"].ToString());
                    }
                    model.SparepartProduct = ds.Tables[0].Rows[i]["SparepartProduct"].ToString();
                    list.Add(model);
                }

            }
            return list;
        }
        #endregion

        #region "Other function"
        string selectSequel = string.Empty;
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "Select Id,ProductId,SparepartName,BuyMinCount,BuyMaxCount,FavourableType,FavourableLimit,SparepartProduct,1 PersistStatus  From [" + Pre + "productsparepart] ";
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
                return " Where [Id] = @Id";
            }
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>

        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.ProductSparepart model)
        {
            SqlParameter[] paras = new SqlParameter[8];
            paras[0] = new SqlParameter("@ProductId", SqlDbType.Int, 4);
            paras[1] = new SqlParameter("@SparepartName", SqlDbType.VarChar, 100);
            paras[2] = new SqlParameter("@BuyMinCount", SqlDbType.Int, 4);
            paras[3] = new SqlParameter("@BuyMaxCount", SqlDbType.Int, 4);
            paras[4] = new SqlParameter("@FavourableType", SqlDbType.Int, 4);
            paras[5] = new SqlParameter("@FavourableLimit", SqlDbType.Real, 4);
            paras[6] = new SqlParameter("@SparepartProduct", SqlDbType.VarChar, 200);
            paras[7] = new SqlParameter("@Id",SqlDbType.Int,4);

            paras[0].Value = model.ProductId;
            paras[1].Value = model.SparepartName;
            paras[2].Value = model.BuyMinCount;
            paras[3].Value = model.BuyMaxCount;
            paras[4].Value = model.FavourableType;
            paras[5].Value = model.FavourableLimit;
            paras[6].Value = model.SparepartProduct;
            paras[7].Value = model.Id;
          
            return paras;
        }

        public IDbDataParameter[] ValueIDPara(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@Id", id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }

        #endregion
    }
}
