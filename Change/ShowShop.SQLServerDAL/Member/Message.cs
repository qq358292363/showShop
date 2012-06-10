using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Member;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Member
{
    public class Message:IMessage
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Member.Message model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_message(");
            strSql.Append("[uid],[userid],[title],[content],[adminid],[sendtime],[state],[isread])");
            strSql.Append(" values (");
            strSql.Append("@uid,@userid,@title,@content,@adminid,@sendtime,@state,@isread)");
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
            strSql.Append("delete from yxs_message ");
            strSql.Append(" where [id] in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Member.Message model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_message set ");
            strSql.Append("[uid]=@uid,");
            strSql.Append("[userid]=@userid,");
            strSql.Append("[title]=@title,");
            strSql.Append("[content]=@content,");
            strSql.Append("[adminid]=@adminid,");
            strSql.Append("[sendtime]=@sendtime,");
            strSql.Append("[state]=@state,");
            strSql.Append("[isread]=@isread");
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
            string sequel = "Update [yxs_message] set ";
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
        public ShowShop.Model.Member.Message GetModelByID(int id)
        {
            ShowShop.Model.Member.Message model = new ShowShop.Model.Member.Message();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[uid],[userid],[title],[content],[adminid],[sendtime],[state],[isread] from yxs_message ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.UserId = reader.GetString(2);
                    model.Title = reader.GetString(3);
                    model.Content = reader.GetString(4);
                    model.AdminId = reader.GetString(5);
                    model.SendTime = reader.GetDateTime(6);
                    model.State = reader.GetInt32(7);
                    model.IsRead = reader.GetInt32(8);
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.Message> GetAll()
        {
            List<ShowShop.Model.Member.Message> list = new List<ShowShop.Model.Member.Message>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[uid],[userid],[title],[content],[adminid],[sendtime],[state],[isread] from yxs_message ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.Message model = new ShowShop.Model.Member.Message();
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.UserId = reader.GetString(2);
                    model.Title = reader.GetString(3);
                    model.Content = reader.GetString(4);
                    model.AdminId = reader.GetString(5);
                    model.SendTime = reader.GetDateTime(6);
                    model.State = reader.GetInt32(7);
                    model.IsRead = reader.GetInt32(8);
                    list.Add(model);
                }
            }
            return list;

        }

        /// <summary>
        /// 得到指定条件的所有短消息 不加 where
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.Member.Message> GetAll(string strWhere)
        {
            List<ShowShop.Model.Member.Message> list = new List<ShowShop.Model.Member.Message>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[uid],[userid],[title],[content],[adminid],[sendtime],[state],[isread] from yxs_message ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.Message model = new ShowShop.Model.Member.Message();
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.UserId = reader.GetString(2);
                    model.Title = reader.GetString(3);
                    model.Content = reader.GetString(4);
                    model.AdminId = reader.GetString(5);
                    model.SendTime = reader.GetDateTime(6);
                    model.State = reader.GetInt32(7);
                    model.IsRead = reader.GetInt32(8);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据用户ID和信息状态得到短消息列表
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="state">0 草稿箱  1 收件箱 2 发件箱 3 废件箱</param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_message [where] "+strWhere+" [order by] id desc";
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
            dataPage.Sql = "[select] * [from] yxs_message [where] 1=1 [order by] id desc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Member.Message model)
        {
            
            SqlParameter[] paras = new SqlParameter[9];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@uid", SqlDbType.Int, 4);
            paras[1].Value = model.UID;
            paras[2] = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            paras[2].Value = model.UserId;
            paras[3] = new SqlParameter("@title", SqlDbType.VarChar, 500);
            paras[3].Value = model.Title;
            paras[4] = new SqlParameter("@content", SqlDbType.VarChar, 2000);
            paras[4].Value = model.Content;
            paras[5] = new SqlParameter("@adminid", SqlDbType.VarChar, 50);
            paras[5].Value = model.AdminId;
            paras[6] = new SqlParameter("@sendtime", SqlDbType.DateTime);
            paras[6].Value = model.SendTime;
            paras[7] = new SqlParameter("@state", SqlDbType.Int, 4);
            paras[7].Value = model.State;
            paras[8] = new SqlParameter("@isread", SqlDbType.Int, 4);
            paras[8].Value = model.IsRead;
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
