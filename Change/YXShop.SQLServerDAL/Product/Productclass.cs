using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;
using System.Data;

namespace ShowShop.SQLServerDAL.Product
{

    /// <summary>
    /// 数据访问类Productclass。
    /// </summary>
    public class Productclass : IProductclass
    {
        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Product.Productclass model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into [yxs_productclass](";
            sequel = sequel + "[fatherid], [name], [sort], [description], [parentpath])";
            sequel = sequel + "Values(";
            sequel = sequel + "@fatherid, @name,@sort,@description,@parentpath) Select scope_IDENTITY() ";
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
            sequel = "Delete From [yxs_productclass]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.PrimarykeyValueParas(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <remarks></remarks>
        public int Update(ShowShop.Model.Product.Productclass model)
        {
            string sequel = "Update [yxs_productclass] set  ";
            sequel = sequel + "[fatherid] =@fatherid ,[name] =@name ,[sort]=@sort,[description] =@description ,[parentpath] =@parentpath";
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
        /// 修改某个字段的值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update [yxs_productclass] set ";
            sequel = sequel + "[" + columnName + "] =@value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@value", value), new SqlParameter("@cid", id) };
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
        public ShowShop.Model.Product.Productclass GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Product.Productclass model = new ShowShop.Model.Product.Productclass();
            if (row != null)
            {
                model.ID = int.Parse(row["cid"].ToString());
                model.Name = row["name"].ToString();
                model.Fatherid = int.Parse(row["fatherid"].ToString());
                model.Sort = int.Parse(row["sort"].ToString());
                model.Description = row["description"].ToString();
                model.Parentpath = row["parentpath"].ToString();
               
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得集合 
        /// 11.16 kevin
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Product.Productclass> GetAll()
        {
            string sql = "select * from yxs_productclass";
            List<ShowShop.Model.Product.Productclass> classList = new List<ShowShop.Model.Product.Productclass>();
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.Productclass model = new ShowShop.Model.Product.Productclass();
                    model.ID = (int)reader["cid"];
                    model.Fatherid = Convert.ToInt32(reader["fatherid"]);
                    model.Name = (string)reader["name"];
                    model.Sort = Convert.ToInt32(reader["sort"]);
                    model.Description = reader["description"] == null ? "" : reader["description"].ToString();
                    model.Parentpath = (string)reader["parentpath"];
                   
                    classList.Add(model);
                }
            }
            return classList;
        }
        /// <summary>
        /// ID查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.Product.Productclass GetModelID(int id)
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
        /// fatherid查询
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetFatherList(int fatherid)
        {
            string strSql = this.SelectSequel + "Where [fatherid] = @fatherid";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@fatherid", SqlDbType.Int, 4);
            paras[0].Value = fatherid;
            return ChangeHope.DataBase.SQLServerHelper.Query(strSql, paras).Tables[0];
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public DataTable GetBlurList(string ParentPath)
        {
            string strSql = this.SelectSequel + " where parentpath like '%" + ParentPath + "%'";
            DataTable dt = ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0];
            return dt;
        }

        public DataTable GetClassId(int CID, string ParentPath)
        {
            string strSql = this.SelectSequel + " where parentpath like '%" + ParentPath + "%' or fatherid="+CID;
            DataTable dt = ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 返加多个分类名称
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public DataTable GetMoreThanClassName(string strId)
        {
            string strSql = this.SelectSequel + "Where cid in (" + strId + ") ";
            return ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0];
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] *[from] yxs_productclass [where] 1=1 [order by] sort asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 前台标签查询所有数据
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_productclass [where] 1=1 " + Conditions + " " + orderfield + "";
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
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
                    selectSequel = "SELECT * FROM [yxs_productclass]";
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
                return " Where [cid] = @cid";
            }
        }

        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>
        protected IDbDataParameter[] ValueParas(ShowShop.Model.Product.Productclass model)
        {
            SqlParameter[] paras = new SqlParameter[6];
            paras[0] = new SqlParameter("@cid", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@fatherid", SqlDbType.Int, 4);
            paras[1].Value = model.Fatherid;
            paras[2] = new SqlParameter("@name", SqlDbType.VarChar, 100);
            paras[2].Value = model.Name;
            paras[3] = new SqlParameter("@sort", SqlDbType.Int, 4);
            paras[3].Value = model.Sort;
            paras[4] = new SqlParameter("@description", SqlDbType.VarChar, 100);
            paras[4].Value = model.Description;
            paras[5] = new SqlParameter("@parentpath", SqlDbType.VarChar, 100);
            paras[5].Value = model.Parentpath;
           
            return paras;
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>
        protected IDbDataParameter[] PrimarykeyValueParas(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@cid", SqlDbType.Int, 4);
            paras[0].Value = id;
            return paras;
        }
        #endregion

    }
}
