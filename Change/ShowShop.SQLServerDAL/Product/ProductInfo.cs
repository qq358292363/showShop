using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Product
{
    /// <summary>
    /// 数据访问类ProductInfo。
    /// </summary>
    public class ProductInfo : DbBase, IProductInfo
    {

        #region "DataBase Operation"

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.ProductInfo model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Product(");
            strSql.Append("ProductNo,ProductName,ProductAttachName,cid,BrandID,ShopPrice,MarketPrice,Thumbnail,Unit,Synopsis,ProductContent,UpdateTime,AutoUp,AutoDown,IsShelves)");
            strSql.Append(" values (");
            strSql.Append("@ProductNo,@ProductName,@ProductAttachName,@cid,@BrandID,@ShopPrice,@MarketPrice,@Thumbnail,@Unit,@Synopsis,@ProductContent,@UpdateTime,@AutoUp,@AutoDown,@IsShelves)");
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
        public int Update(ShowShop.Model.Product.ProductInfo model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Product set ");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("ProductAttachName=@ProductAttachName");
            strSql.Append("cid=@cid,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("ShopPrice=@ShopPrice,");
            strSql.Append("MarketPrice=@MarketPrice,");
            strSql.Append("Thumbnail=@Thumbnail,");
            strSql.Append("Synopsis=@Synopsis,");
            strSql.Append("ProductContent=@ProductContent,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("AutoUp=@AutoUp,");
            strSql.Append("AutoDown=@AutoDown,");
            strSql.Append("IsShelves=@IsShelves");
            strSql.Append(" where ProductID=@ProductID ");
            return ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }
        /// <summary>
        /// 任意修改字段
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="columnName">修改字段名</param>
        /// <param name="value">修改的值</param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update Product set ";
            sequel = sequel + "[" + columnName + "] =@value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@value", value), new SqlParameter("@ProductId", id) };
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
        /// <summary>
        /// 删除一条数据或批量删除
        /// </summary>
        public void Delete(string productID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where ProductID in (" + productID + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }
        public void DeleleById(int productID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where ProductID=@id ");
            SqlParameter[] parameters ={
                                           new SqlParameter("@id",SqlDbType.Int,4)
                                       };
            parameters[0].Value = productID;
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion

        #region "Data Load"
        public ProductInfo()
        { }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.ProductInfo GetModel(int productID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ProductID,ProductNo,cid,BrandID,ProductName,ProductAttachName,ShopPrice,MarketPrice,Synopsis,ProductContent,Unit,CreateTime,UpdateTime,AutoUp,AutoDown,Thumbnail from Product ");
            strSql.Append(" where ProductID=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4)};
            parameters[0].Value = productID;

            ShowShop.Model.Product.ProductInfo model = new ShowShop.Model.Product.ProductInfo();
            DataSet ds = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
                }
                model.ProductNo = ds.Tables[0].Rows[0]["ProductNo"].ToString();
                model.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                model.ProductAttachName = ds.Tables[0].Rows[0]["ProductAttachName"].ToString();
                model.ClassID = int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
                if (ds.Tables[0].Rows[0]["BrandID"].ToString() != "")
                {
                    model.BrandID = int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopPrice"].ToString() != "")
                {
                    model.ShopPrice = decimal.Parse(ds.Tables[0].Rows[0]["ShopPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MarketPrice"].ToString() != "")
                {
                    model.MarketPrice = decimal.Parse(ds.Tables[0].Rows[0]["MarketPrice"].ToString());
                }
                model.Thumbnail = ds.Tables[0].Rows[0]["Thumbnail"].ToString();
                model.Synopsis = ds.Tables[0].Rows[0]["Synopsis"].ToString();
                model.ProductContent = ds.Tables[0].Rows[0]["ProductContent"].ToString();

                if (ds.Tables[0].Rows[0]["Unit"].ToString() != "")
                {
                    model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                }

                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AutoUp"].ToString() != "")
                {
                    model.AutoUp = DateTime.Parse(ds.Tables[0].Rows[0]["AutoUp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AutoDown"].ToString() != "")
                {
                    model.AutoDown = DateTime.Parse(ds.Tables[0].Rows[0]["AutoDown"].ToString());
                }


                return model;
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
            dataPage.Sql = "select * from Product where 1=1 order by ProductID desc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 排序所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] [Product] [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 获取部分数据
        /// </summary>
        /// <param name="StrID"></param>
        /// <returns></returns>
        public DataTable GetPartData(string StrID)
        {
            string strSql = "[Select] * [From] [Product] [where] ProductID in (" + StrID + ")";
            DataTable dt = ChangeHope.DataBase.SQLServerHelper.Query(strSql.ToString()).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public string GetMax()
        {
            string strSql = "Select max(ProductNo) From Product";

            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 根据条件返回集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="topNumber">为0时查所有</param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetListByWhere(string where, int topNumber, int pagesize, string orderfield)
        {

            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();

            dataPage.Sql = "select * from Product where  " + where + " order by " + orderfield + " ";

            if (topNumber > 0)
            {
                dataPage.PageSize = topNumber;
            }
            else
            {
                dataPage.PageSize = pagesize;
            }
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 跟据条件返回DataTable
        /// </summary>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public DataTable dtGetListWhere(string Conditions)
        {
            string Sel = this.SelectSequel + " where 1=1 " + Conditions;
            return ChangeHope.DataBase.SQLServerHelper.Query(Sel).Tables[0];
        }
        /// <summary>
        /// 指字段与条件查询
        /// </summary>
        /// <param name="FieldStr">字段</param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataTable GetAppointField(string FieldStr, string Condition)
        {
            string selectSequel = "Select " + FieldStr + ",1 PersistStatus  From Product where 1=1 " + Condition;
            return ChangeHope.DataBase.SQLServerHelper.Query(selectSequel).Tables[0];
        }

        #endregion
        #region "Other function"
        string selectSequel = string.Empty;
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "Select *,1 PersistStatus  From Product ";
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
                return " Where  ProductID = @ProductID";
            }
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>

        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.ProductInfo model)
        {
            SqlParameter[] parameters = new SqlParameter[16];
            parameters[0] = new SqlParameter("@ProductID", SqlDbType.Int, 4);
            parameters[1] = new SqlParameter("@ProductNo", SqlDbType.VarChar, 50);
            parameters[2] = new SqlParameter("@ProductName", SqlDbType.VarChar, 20);
            parameters[3] = new SqlParameter("@ProductAttachName", SqlDbType.VarChar, 20);
            parameters[4] = new SqlParameter("@cid", SqlDbType.Int, 4);
            parameters[5] = new SqlParameter("@BrandID", SqlDbType.Int, 4);
            parameters[6] = new SqlParameter("@ShopPrice", SqlDbType.Decimal, 8);
            parameters[7] = new SqlParameter("@MarketPrice", SqlDbType.Decimal, 8);
            parameters[8] = new SqlParameter("@Thumbnail", SqlDbType.VarChar, 100);
            parameters[9] = new SqlParameter("@Unit", SqlDbType.VarChar,10);
            parameters[10] = new SqlParameter("@Synopsis", SqlDbType.VarChar, 200);
            parameters[11] = new SqlParameter("@ProductContent", SqlDbType.Text);
            parameters[12] = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
            parameters[13] = new SqlParameter("@AutoUp", SqlDbType.DateTime);
            parameters[14] = new SqlParameter("@AutoDown", SqlDbType.DateTime);
            parameters[15] = new SqlParameter("@IsShelves", SqlDbType.Int,4);
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.ProductNo;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.ProductAttachName;
            parameters[4].Value = model.ClassID;
            parameters[5].Value = model.BrandID;
            parameters[6].Value = model.ShopPrice;
            parameters[7].Value = model.MarketPrice;
            parameters[8].Value = model.Thumbnail;
            parameters[9].Value = model.Unit;
            parameters[10].Value = model.Synopsis;
            parameters[11].Value = model.ProductContent;
            parameters[12].Value = model.UpdateTime;
            parameters[13].Value = model.AutoUp;
            parameters[14].Value = model.AutoDown;
            parameters[15].Value = model.IsAuto; 
            return parameters;
        }

        public IDbDataParameter[] ValueIDPara(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@ProductID", id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }


        #endregion
    }
}

