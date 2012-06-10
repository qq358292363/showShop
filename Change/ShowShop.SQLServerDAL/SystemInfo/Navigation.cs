using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.SystemInfo;
using System.Data.SqlClient;
using System.Data;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    public class Navigation : DbBase, INavigation
    {
        #region "DataBase Operation"
        /// <summary>
        /// 在数据库中新增一个持久化对象,自增长列Prop_ID的值会自动从数据库中返回
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.SystemInfo.Navigation model)
        {
            SqlParameter[] paras = (SqlParameter[])this.VauleParas(model);
            string sequel = "Insert into " + Pre + "navigation(";
            sequel = sequel + "[contentregion],[filed], [link], [type], [sort], [isshow],[isnewwindow],[part])";
            sequel = sequel + "Values(";
            sequel = sequel + "@contentregion,@filed,@link,@type,@sort,@isshow,@isnewwindow,@part) Select scope_IDENTITY() ";
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
        /// 删除数据库中指定的持久化对象的数据, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public void Delete(int id)
        {
            string sequel = string.Empty;
            sequel = "Delete From " + Pre + "navigation" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIdParas(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Update(ShowShop.Model.SystemInfo.Navigation model)
        {
            string sequel = "Update " + Pre + "navigation set  ";
            sequel = sequel + "[contentregion]=@contentregion,[filed] =@filed ,[link]=@link ,[type]=@type ,[sort] =@sort ,[isshow] =@isshow ,[isnewwindow] =@isnewwindow,[part]=@part";
            sequel = sequel + UpdateWhereSequel;
            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, (SqlParameter[])this.VauleParas(model));
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
            string sequel = "Update " + Pre + "navigation set ";
            sequel = sequel + "[" + columnName + "] =@value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@value", value), new SqlParameter("@id", id) };
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
        public ShowShop.Model.SystemInfo.Navigation GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.SystemInfo.Navigation model = new ShowShop.Model.SystemInfo.Navigation();
            if (row != null)
            {
                model.Id = int.Parse(row["id"].ToString());
                model.Contentregion = row["contentregion"].ToString();
                model.Filed = row["filed"].ToString();
                model.Link = row["link"].ToString();
                model.Type = int.Parse(row["type"].ToString());
                model.Sort = int.Parse(row["sort"].ToString());
                model.Isshow = int.Parse(row["isshow"].ToString());
                model.Isnewwindow = int.Parse(row["isnewwindow"].ToString());
                model.Part = int.Parse(row["part"].ToString());
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
        public ShowShop.Model.SystemInfo.Navigation GetModelID(int id)
        {
            string sequel = SelectSequel + UpdateWhereSequel;
            SqlParameter[] paras = (SqlParameter[])this.ValueIdParas(id);
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
        /// 跟据导航位置part查询属性
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public DataTable GetProperty(string part)
        {
            string strSql = this.SelectSequel + "Where ','+[part]+',' like '%," + part + ",%'";
            DataTable dt = ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0];
            return dt;

        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] " + Pre + "navigation [where] 1=1 [order by] sort asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 查询第一条数据
        /// </summary>
        /// <returns></returns>
        public ShowShop.Model.SystemInfo.Navigation GetFirstData()
        {
            DataRow dr = null;
            string strSql = "select top 1 * from " + Pre + "navigation";
            if (ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0] != null && ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0].Rows.Count != 0)
            {
                dr = ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0].Rows[0];

            }
            ShowShop.Model.SystemInfo.Navigation mem = this.GetModel(dr);

            return mem;
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
                    selectSequel = "SELECT [id], [contentregion], [filed], [link],[type], [sort], [isshow], [isnewwindow], [part] FROM " + Pre + "navigation ";
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
        public IDbDataParameter[] VauleParas(ShowShop.Model.SystemInfo.Navigation model)
        {
            SqlParameter[] paras = new SqlParameter[9];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.Id;
            paras[1] = new SqlParameter("@contentregion", SqlDbType.VarChar, 1000);
            paras[1].Value = model.Contentregion;
            paras[2] = new SqlParameter("@filed", SqlDbType.VarChar, 2000);
            paras[2].Value = model.Filed;
            paras[3] = new SqlParameter("@link", SqlDbType.VarChar, 2000);
            paras[3].Value = model.Link;
            paras[4] = new SqlParameter("@type", SqlDbType.Int, 4);
            paras[4].Value = model.Type;
            paras[5] = new SqlParameter("@sort", SqlDbType.Int, 4);
            paras[5].Value = model.Sort;
            paras[6] = new SqlParameter("@isshow", SqlDbType.Int, 4);
            paras[6].Value = model.Isshow;
            paras[7] = new SqlParameter("@isnewwindow", SqlDbType.Int, 4);
            paras[7].Value = model.Isnewwindow;
            paras[8] = new SqlParameter("@part", SqlDbType.Int, 4);
            paras[8].Value = model.Part;
            
            return paras;
        }
        public IDbDataParameter[] ValueIdParas(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@id", (object)id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }
        #endregion
    }
}
