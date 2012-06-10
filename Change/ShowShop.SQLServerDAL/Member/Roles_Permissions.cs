using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;
using System.Data.SqlClient;
using System.Data;

namespace ShowShop.SQLServerDAL.Member
{
    public class Roles_Permissions:IRoles_Permissions
    {
        #region "DataBase Operation"
        /// <summary>
        /// 在数据库中新增一个持久化对象,自增长列id的值会自动从数据库中返回
        /// </summary>
        /// <remarks></remarks>
        public int Create(ShowShop.Model.Member.Roles_Permissions model)
        {
            string sequel = "Insert into [yxs_roles_permissions](";
            sequel = sequel + "[id],[operatecode])";
            sequel = sequel + "Values(";
            sequel = sequel + "@ID,@OperateCode) Select scope_IDENTITY() ";
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
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

        public int Add(List<ShowShop.Model.Member.Roles_Permissions> list)
        {
            int reInt = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into [yxs_roles_permissions]");
            sb.Append("([id],[operatecode])");
            sb.Append("Values");
            sb.Append("(@ID,@OperateCode) Select scope_IDENTITY()");
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[1] = new SqlParameter("@OperateCode", SqlDbType.Int);
            SqlConnection sqlConn = ChangeHope.DataBase.SQLServerHelper.Connection;
            try
            {
                SqlTransaction sqlTran;
                sqlTran = sqlConn.BeginTransaction("AmdinRoles");
                foreach (ShowShop.Model.Member.Roles_Permissions rModel in list)
                {
                    if (sqlTran.Connection == null)
                    {
                        sqlTran = null;
                        break;
                    }
                    parameters[0].Value = rModel.ID;
                    parameters[1].Value = rModel.OperateCode;
                    try
                    {
                        int result =ChangeHope.DataBase.SQLServerHelper.ExecuteNonQuery(sqlTran, sb.ToString(), parameters);
                        if (result < 1)
                            sqlTran.Rollback();
                        else
                            reInt++;
                    }
                    catch
                    {
                        if (sqlTran != null)
                        {
                            sqlTran.Rollback();
                            sqlTran.Dispose();
                        }
                        sqlTran.Dispose();
                    }
                }
                try
                {
                    sqlTran.Commit();
                }
                catch
                {
                    if (sqlTran != null)
                    {
                        sqlTran.Rollback();
                        sqlTran.Dispose();
                    }
                }
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
            return reInt;
        }
        /// <summary>
        /// 删除数据库中指定的持久化对象的数据, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Delete(int id)
        {
            string sequel = string.Empty;
            sequel = "Delete From [yxs_roles_permissions]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.UpdateParas(id);
            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public int Del(List<ShowShop.Model.Member.Roles_Permissions> list)
        {
            int reInt = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete From [yxs_roles_permissions]");
            sb.Append(" Where ");
            sb.Append("[id]=@ID and [operatecode]=@OperateCode");
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
            parameters[1] = new SqlParameter("@OperateCode", SqlDbType.Int);
            SqlConnection sqlConn = ChangeHope.DataBase.SQLServerHelper.Connection;
            try
            {
                SqlTransaction sqlTran;
                sqlTran = sqlConn.BeginTransaction("AmdinRoles");
                foreach (ShowShop.Model.Member.Roles_Permissions rModel in list)
                {
                    if (sqlTran.Connection == null)
                    {
                        sqlTran = null;
                        break;
                    }
                    parameters[0].Value = rModel.ID;
                    parameters[1].Value = rModel.OperateCode;
                    try
                    {
                        int result = ChangeHope.DataBase.SQLServerHelper.ExecuteNonQuery(sqlTran, sb.ToString(), parameters);;
                        if (result < 1)
                            sqlTran.Rollback();
                        else
                            reInt++;
                    }
                    catch
                    {
                        if (sqlTran != null)
                        {
                            sqlTran.Rollback();
                            sqlTran.Dispose();
                        }
                    }
                }
                try
                {
                    sqlTran.Commit();//执行事务
                }
                catch
                {
                    if (sqlTran != null)
                    {
                        sqlTran.Rollback();
                        sqlTran.Dispose();
                    }
                }
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
            return reInt;
        }
        #endregion

        #region "Data Load"
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ShowShop.Model.Member.Roles_Permissions GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Member.Roles_Permissions model = new ShowShop.Model.Member.Roles_Permissions();
            if (row != null)
            {
                model.ID = int.Parse(row["id"].ToString());
                model.OperateCode = int.Parse(row["operatecode"].ToString());
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
        public ShowShop.Model.Member.Roles_Permissions GetModelID(int id)
        {
            string sequel = SelectSequel + UpdateWhereSequel;
            SqlParameter[] paras = (SqlParameter[])this.UpdateParas(id);
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
        /// 装载指定列的值等于指定值的的所有持久性Roles_Permissions对象到集合,一字段查询
        /// </summary>
        /// <remarks></remarks>
        public List<ShowShop.Model.Member.Roles_Permissions> GetListByColumn(string Condition)
        {
            string sequel = (new Roles_Permissions()).SelectSequel + " Where "+Condition+"";
            DataTable dt =ChangeHope.DataBase.SQLServerHelper.Query(sequel).Tables[0];
            return LoadListFromDataTable(dt.DefaultView);
        }

        /// <summary>
        /// 装载对象Roles_Permissions的所有持久性对象到集合，如果数据量大，调用此方法会造成性能上的问题，请谨慎使用
        /// </summary>
        /// <remarks></remarks>
        public List<ShowShop.Model.Member.Roles_Permissions> GetAll()
        {
            DataTable dt =ChangeHope.DataBase.SQLServerHelper.Query((new Roles_Permissions()).SelectSequel).Tables[0];
            return LoadListFromDataTable(dt.DefaultView);
        }
        /// <summary>
        /// 装载指定列的值等于指定值的的所有持久性Roles_Permissions对象到集合,一字段查询
        /// </summary>
        /// <remarks></remarks>
        public List<ShowShop.Model.Member.Roles_Permissions> GetListByColumn(string columnName, Object value)
        {
            string sequel = (new Roles_Permissions()).SelectSequel + " Where [" + columnName + "] =@Value order by operatecode";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value) };
            DataTable dt = ChangeHope.DataBase.SQLServerHelper.Query(sequel, paras).Tables[0];
            return LoadListFromDataTable(dt.DefaultView);
        }
        /// <summary>
        /// 从DataView装载持久性Roles_Permissions对象到集合
        /// </summary>
        /// <remarks></remarks>
        protected List<ShowShop.Model.Member.Roles_Permissions> LoadListFromDataTable(DataView dv)
        {
            List<ShowShop.Model.Member.Roles_Permissions> list = new List<ShowShop.Model.Member.Roles_Permissions>();
            for (int index = 0; index <= dv.Count - 1; index++)
            {
                list.Add(new ShowShop.Model.Member.Roles_Permissions(dv[index].Row));
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
                    selectSequel = "Select	[id],[operatecode], 1 PersistStatus  From [yxs_roles_permissions] ";
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
                return " Where [id] = @ID";
            }
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>
        public IDbDataParameter[] ValueParas(ShowShop.Model.Member.Roles_Permissions model)
        {
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@ID", model.ID);
            paras[1] = new SqlParameter("@operatecode", model.OperateCode);


            paras[0].DbType = DbType.Int32;
            paras[1].DbType = DbType.String;
            return paras;


        }
        public IDbDataParameter[] UpdateParas(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@ID", (object)id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }
        #endregion
    }
}
