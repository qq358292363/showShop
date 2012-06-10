using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Accessories;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Accessories
{
    public class Collection:ICollection
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加一条新的友情链接
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.Collection model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_collection(");
            strSql.Append("[collectiontype],[collectionid],[collectionname],[collectiondate],[collectionuid])");
            strSql.Append(" values (");
            strSql.Append("@collectiontype,@collectionid,@collectionname,@collectiondate,@collectionuid)");
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
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_collection ");
            strSql.Append(" where id in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.Collection model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_collection set ");
            strSql.Append("[collectiontype]=@collectiontype,");
            strSql.Append("[collectionid]=@collectionid,");
            strSql.Append("[collectionname]=@collectionname,");
            strSql.Append("[collectiondate]=@collectiondate,");
            strSql.Append("[collectionuid]=@collectionuid");
            strSql.Append(" where [id]=@id ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }


        /// <summary>
        /// 更新任意一个字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, object value)
        {
            string sequel = "Update [yxs_collection] set ";
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

        #region "Data Load"
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.Accessories.Collection GetModelByID(int id)
        {
            ShowShop.Model.Accessories.Collection model = new ShowShop.Model.Accessories.Collection();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[collectiontype],[collectionid],[collectionname],[collectiondate],[collectionuid] from yxs_collection ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.CollectionType = reader.GetInt32(1);
                    model.CollectionId = reader.GetInt32(2);
                    model.CollectionName = reader.GetString(3);
                    model.CollectionDate = reader.GetDateTime(4);
                    model.CollectionId = reader.GetInt32(5);
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.Collection> GetAll()
        {
            List<ShowShop.Model.Accessories.Collection> list = new List<ShowShop.Model.Accessories.Collection>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[collectiontype],[collectionid],[collectionname],[collectiondate],[collectionuid] from yxs_collection ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Accessories.Collection model = new ShowShop.Model.Accessories.Collection();
                    model.ID = reader.GetInt32(0);
                    model.CollectionType = reader.GetInt32(1);
                    model.CollectionId = reader.GetInt32(2);
                    model.CollectionName = reader.GetString(3);
                    model.CollectionDate = reader.GetDateTime(4);
                    model.CollectionId = reader.GetInt32(5);
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
            dataPage.Sql = "[select] * [from] yxs_collection [where] " + strWhere + " [order by] id asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 得到所有记录
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_collection [where] 1=1 [order by] id desc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Accessories.Collection model)
        {
            SqlParameter[] paras = new SqlParameter[6];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@collectiontype", SqlDbType.Int, 4);
            paras[1].Value = model.CollectionType;
            paras[2] = new SqlParameter("@collectionid", SqlDbType.Int, 4);
            paras[2].Value = model.CollectionId;
            paras[3] = new SqlParameter("@collectionname", SqlDbType.VarChar, 50);
            paras[3].Value = model.CollectionName;
            paras[4] = new SqlParameter("@collectiondate", SqlDbType.DateTime);
            paras[4].Value = model.CollectionDate;
            paras[5] = new SqlParameter("@collectionuid", SqlDbType.Int, 4);
            paras[5].Value = model.CollectionUid;
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
