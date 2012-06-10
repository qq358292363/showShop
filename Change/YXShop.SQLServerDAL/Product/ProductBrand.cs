using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;
using System.Data;

namespace ShowShop.SQLServerDAL.Product
{
    public class ProductBrand:IProductBrand
    { 
        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Product.ProductBrand model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into yxs_productbrand (name,sort) Values(@name,@sort) ;select @@IDENTITY ";
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
        /// 删除数据
        /// </summary>
        /// <remarks></remarks>
        public void Delete(int id)
        {
            string sequel = "Delete From [yxs_productbrand]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Amend(ShowShop.Model.Product.ProductBrand model)
        {
            string sequel = "Update [yxs_productbrand] set  ";
            sequel = sequel + "[commontypes] =@commontypes ,[name] =@name ,[image]=@images ,[attirbute] =@attirbute ,[description] =@description ,[sort] =@sort ,[isrecommend] =@isrecommend";
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
            string sequel = "Update [yxs_productbrand] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@bid", id) };
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
        public ShowShop.Model.Product.ProductBrand GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Product.ProductBrand model = new ShowShop.Model.Product.ProductBrand();
            if (row != null)
            {
                model.ID = int.Parse(row["bid"].ToString());
                model.Name = row["name"].ToString();
                model.CommonTypes =int.Parse(row["commontypes"].ToString());
                model.Sort = int.Parse(row["sort"].ToString());
                //model.Description = row["description"].ToString();
                //model.Attirbute = row["attirbute"].ToString();
                //model.Images = row["image"].ToString();
                //model.Isrecommend = int.Parse(row["isrecommend"].ToString());
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
        public ShowShop.Model.Product.ProductBrand GetModelID(int id)
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
        /// BrandName查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.Product.ProductBrand GetModelName(string BrandName)
        {
            string sequel = SelectSequel + " where name=@name";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@name", SqlDbType.VarChar, 100);
            paras[0].Value = BrandName;
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
        /// 跟据CID查询品牌
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public System.Data.DataTable GetBrandList(string CID)
        {
            string strSql = this.SelectSequel + "Where ','+[cid]+',' like '%," + CID + ",%'";
            return ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0];
        }
        /// <summary>
        /// 所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_productbrand [where] 1=1 [order by] sort asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 获取所有记录List
        /// </summary>
        /// <remarks></remarks>
        public List<ShowShop.Model.Product.ProductBrand> GetDTList(string strBrandId)
        {
            List<ShowShop.Model.Product.ProductBrand> list = new List<ShowShop.Model.Product.ProductBrand>();
            string strSql = this.SelectSequel;
            if (strBrandId != "" && strBrandId != string.Empty)
            {
                strSql += " where bid in(" + strBrandId + ")";
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.ProductBrand model = new ShowShop.Model.Product.ProductBrand();
                    model.ID = Convert.ToInt32(reader["bid"]);
                    model.Name = reader["name"].ToString();
                    model.Sort =Convert.ToInt32(reader["sort"].ToString());
                    list.Add(model);
                }
            }
            return list;
        }

        public List<ShowShop.Model.Product.ProductBrand> GetCommonTypes()
        {
            List<ShowShop.Model.Product.ProductBrand> list = new List<ShowShop.Model.Product.ProductBrand>();
            string strSql = this.SelectSequel + " where commontypes=0";
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.ProductBrand model = new ShowShop.Model.Product.ProductBrand();
                    model.ID = Convert.ToInt32(reader["bid"]);
                    model.Name = reader["name"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 前台标签所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_productbrand [where] 1=1 " + Conditions + " " + orderfield;
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
                    selectSequel = "Select *,1 PersistStatus  From [yxs_productbrand] ";
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
                return " Where [bid] = @bid";
            }
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>

        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.ProductBrand model)
        {
            SqlParameter[] paras = new SqlParameter[3];
            paras[0] = new SqlParameter("@bid", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            //paras[1] = new SqlParameter("@commontypes", SqlDbType.Int, 4);
            //paras[1].Value = model.CommonTypes;
            paras[1] = new SqlParameter("@name", SqlDbType.VarChar, 100);
            paras[1].Value = model.Name;
           
            //paras[3] = new SqlParameter("@attirbute", SqlDbType.VarChar,100);
            //paras[3].Value = model.Attirbute;
            //paras[4] = new SqlParameter("@description", SqlDbType.VarChar,1000);
            //paras[4].Value = model.Description;
            
            //paras[5] = new SqlParameter("@images", SqlDbType.VarChar,100);
            //paras[5].Value = model.Images;
            paras[2] = new SqlParameter("@sort", SqlDbType.Int, 4);
            paras[2].Value = model.Sort;
            //paras[7] = new SqlParameter("@isrecommend",SqlDbType.Int,4);
            //paras[7].Value = model.Isrecommend;

            return paras;
        }

        public IDbDataParameter[] ValueIDPara(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@bid", id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }

        #endregion

    }
}
