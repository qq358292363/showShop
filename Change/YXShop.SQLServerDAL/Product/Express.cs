using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Product
{
    public class Express:IExpress
    {
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.Express model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_express(");
            strSql.Append("name,fullname,address,phone,person,numstr,sort)");
            strSql.Append(" values (");
            strSql.Append("@name,@fullname,@address,@phone,@person,@numstr,@sort)");
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
        public void Amend(ShowShop.Model.Product.Express model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_express set ");
            strSql.Append("name=@name,");
            strSql.Append("fullname=@fullname,");
            strSql.Append("address=@address,");
            strSql.Append("phone=@phone,");
            strSql.Append("person=@person,");
            strSql.Append("numstr=@numstr,");
            strSql.Append("sort=@sort");
            strSql.Append(" where id=@id ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_express ");
            strSql.Append(" where [id] in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            string sequel = "Update [yxs_express] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Value", value),
                new SqlParameter("@id", id) 
            };
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

        #region  "Data Load"
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShowShop.Model.Product.Express GetModelByID(int id)
        {
            ShowShop.Model.Product.Express model = new ShowShop.Model.Product.Express();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,fullname,address,phone,person,numstr,sort from yxs_express ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.FullName = reader.GetString(2);
                    model.Address = reader.GetString(3);
                    model.Person = reader.GetString(4);
                    model.Phone = reader.GetString(5);
                    model.Numstr = reader.GetString(6);
                    model.Sort = reader.GetInt32(7);
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Product.Express> GetAll()
        {
            List<ShowShop.Model.Product.Express> list = new List<ShowShop.Model.Product.Express>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,fullname,address,phone,person,numstr,sort from yxs_express ");
            strSql.Append(" where 1=1");
            strSql.Append(" order by sort asc");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.Express model = new ShowShop.Model.Product.Express();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.FullName = reader.GetString(2);
                    model.Address = reader.GetString(3);
                    model.Person = reader.GetString(4);
                    model.Phone = reader.GetString(5);
                    model.Numstr = reader.GetString(6);
                    model.Sort = reader.GetInt32(7);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Product.Express> GetAll(string strWhere)
        {
            List<ShowShop.Model.Product.Express> list = new List<ShowShop.Model.Product.Express>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,fullname,address,phone,person,numstr,sort from yxs_express ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            strSql.Append(" order by sort asc");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.Express model = new ShowShop.Model.Product.Express();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.FullName = reader.GetString(2);
                    model.Address = reader.GetString(3);
                    model.Person = reader.GetString(4);
                    model.Phone = reader.GetString(5);
                    model.Numstr = reader.GetString(6);
                    model.Sort = reader.GetInt32(7);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到不同条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_express [where] " + strWhere + " [order by] sort asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_express [where] 1=1 [order by] sort asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion

        #region "Other function"

        /// <summary>
        /// 更新条件
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.Express model)
        {
            SqlParameter[] paras = new SqlParameter[8];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@name", SqlDbType.NVarChar, 20);
            paras[1].Value = model.Name;
            paras[2] = new SqlParameter("@fullname", SqlDbType.VarChar, 50);
            paras[2].Value = model.FullName;
            paras[3] = new SqlParameter("@address", SqlDbType.VarChar, 200);
            paras[3].Value = model.Address;
            paras[4] = new SqlParameter("@phone", SqlDbType.VarChar, 15);
            paras[4].Value = model.Phone;
            paras[5] = new SqlParameter("@person", SqlDbType.VarChar, 20);
            paras[5].Value = model.Person;
            paras[6] = new SqlParameter("@numstr", SqlDbType.VarChar, 200);
            paras[6].Value = model.Numstr;
            paras[7] = new SqlParameter("@sort", SqlDbType.Int,4);
            paras[7].Value = model.Sort;
            return paras;
        }

        /// <summary>
        /// 主键参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
