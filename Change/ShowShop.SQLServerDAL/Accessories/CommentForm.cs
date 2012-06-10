using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Accessories;
using System.Data.SqlClient;
using System.Data;

namespace ShowShop.SQLServerDAL.Accessories
{
    public class CommentForm:ICommentForm
    {
        #region "DataBase Operation"
        /// <summary>
        /// 在数据库中新增一个持久化对象,自增长列Prop_ID的值会自动从数据库中返回
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Accessories.CommentForm model)
        {
            SqlParameter[] paras = (SqlParameter[])this.VauleParas(model);
            string sequel = "Insert into [yxs_commentform](";
            sequel = sequel + "[filed], [datavalue], [type], [isrequire])";
            sequel = sequel + "Values(";
            sequel = sequel + "@filed,@datavalue,@type,@isrequire) Select scope_IDENTITY() ";
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
            sequel = "Delete From [yxs_commentform]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIdParas(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Update(ShowShop.Model.Accessories.CommentForm model)
        {
            string sequel = "Update [yxs_commentform] set  ";
            sequel = sequel + "[filed] =@filed ,[datavalue]=@datavalue ,[type] =@type ,[isrequire] =@isrequire";
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
            string sequel = "Update [yxs_commentform] set ";
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
        public ShowShop.Model.Accessories.CommentForm GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Accessories.CommentForm model = new ShowShop.Model.Accessories.CommentForm();
            if (row != null)
            {
                model.ID = int.Parse(row["id"].ToString());
                model.Filed = row["filed"].ToString();
                model.Datavalue = row["datavalue"].ToString();
                model.IsRequire = int.Parse(row["isrequire"].ToString());
                model.Type = int.Parse(row["type"].ToString());
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
        public ShowShop.Model.Accessories.CommentForm GetModelID(int id)
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
        /// 查询所有数据
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_commentform [where] 1=1 [order by] id asc";
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
                    selectSequel = "SELECT [id], [filed], [datavalue], [type], [isrequire]  FROM [yxs_commentform] ";
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
        public IDbDataParameter[] VauleParas(ShowShop.Model.Accessories.CommentForm model)
        {
            SqlParameter[] paras = new SqlParameter[5];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@filed", SqlDbType.VarChar, 2000);
            paras[1].Value = model.Filed;
            paras[2] = new SqlParameter("@datavalue", SqlDbType.VarChar, 2000);
            paras[2].Value = model.Datavalue;
            paras[3] = new SqlParameter("@type", SqlDbType.Int, 4);
            paras[3].Value = model.Type;
            paras[4] = new SqlParameter("@isrequire", SqlDbType.Int, 4);
            paras[4].Value = model.IsRequire;
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

