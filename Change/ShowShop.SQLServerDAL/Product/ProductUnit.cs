using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Product;
using System.Data;
using System.Data.SqlClient;

namespace ShowShop.SQLServerDAL.Product
{

    /// <summary>
    /// 数据访问类Productunit。
    /// </summary>
    public class ProductUnit : IProductUnit
    {
        #region "DataBase Operation"
        /// <summary>
        /// 是否存在该单位
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_productunit");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50)};
            parameters[0].Value = name;

            return ChangeHope.DataBase.SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Product.ProductUnit model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into [yxs_productunit](";
            sequel = sequel + "[name], [sort])";
            sequel = sequel + "Values(";
            sequel = sequel + "@name,@sort) Select scope_IDENTITY() ";
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
        public void Delete(int id)
        {
            string sequel = string.Empty;
            sequel = "Delete From [yxs_productunit]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.PrimarykeyValueParas(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <remarks></remarks>
        public int Update(ShowShop.Model.Product.ProductUnit model)
        {
            string sequel = "Update [yxs_productunit] set  ";
            sequel = sequel + "[name] =@name ,[sort]=@sort";
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
        #endregion

        #region "Data Load"
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ShowShop.Model.Product.ProductUnit GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Product.ProductUnit model = new ShowShop.Model.Product.ProductUnit();
            if (row != null)
            {
                model.ID = int.Parse(row["id"].ToString());
                model.Name = row["name"].ToString();
                model.Sort = int.Parse(row["sort"].ToString());
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
        public ShowShop.Model.Product.ProductUnit GetModelID(int id)
        {
            string sequel = SelectSequel + UpdateWhereSequel;
            SqlParameter[] paras = (SqlParameter[])this.PrimarykeyValueParas(id);
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
        /// 查询所有数据
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_productunit [where] 1=1 [order by] sort asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 得到指定条件的所有集合
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Product.ProductUnit> GetAll(string strWhere)
        {
            List<ShowShop.Model.Product.ProductUnit> list = new List<ShowShop.Model.Product.ProductUnit>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   id,name,sort from yxs_productunit ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            strSql.Append(" order by sort asc");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.ProductUnit model = new ShowShop.Model.Product.ProductUnit();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.Sort = reader.GetInt32(2);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion

        #region "Other function"
        string selectSequel = string.Empty;
        /// <summary>
        /// 该数据访问对象从数据库中提取数据的Sql语句 
        /// </summary>
        /// <remarks></remarks>
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "SELECT [id], [name], [sort] FROM [yxs_productunit]";
                return selectSequel;
            }
            set
            {
                this.selectSequel = value;
            }
        }
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
        protected IDbDataParameter[] ValueParas(ShowShop.Model.Product.ProductUnit model)
        {
            SqlParameter[] paras = new SqlParameter[3];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            paras[1].Value = model.Name;
            paras[2] = new SqlParameter("@sort", SqlDbType.Int, 4);
            paras[2].Value = model.Sort;
            return paras;
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>
        protected IDbDataParameter[] PrimarykeyValueParas(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = id;
            return paras;
        }
        #endregion
    }
}
