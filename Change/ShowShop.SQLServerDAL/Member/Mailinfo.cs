using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Member;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Member
{
    public class Mailinfo:IMailinfo
    {
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Member.MailInfo model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_mailinfo(");
            strSql.Append("sender,sendtime,sendip,title,body,stat)");
            strSql.Append(" values (");
            strSql.Append("@sender,@sendtime,@sendip,@title,@body,@stat)");
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
        /// 得到发件人发送的最后一封信件的ID
        /// 也就是作为 收件箱的 mailId
        /// </summary>
        public int GetMaxMailId(string sender)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(id) from yxs_mailinfo");
            strSql.Append(" where sender=@sender ");
            SqlParameter[] paras = {
					new SqlParameter("@sender", SqlDbType.VarChar, 50)};
            paras[0].Value = sender;
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), paras);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.Member.MailInfo model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_mailinfo set ");
            strSql.Append("sender=@sender,");
            strSql.Append("sendtime=@sendtime,");
            strSql.Append("sendip=@sendip,");
            strSql.Append("title=@title,");
            strSql.Append("body=@body,");
            strSql.Append("stat=@stat");
            strSql.Append(" where id=@id ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_mailinfo ");
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
            string sequel = "Update [yxs_mailinfo] set ";
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
        public ShowShop.Model.Member.MailInfo GetModelByID(int id)
        {
            ShowShop.Model.Member.MailInfo model = new ShowShop.Model.Member.MailInfo();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[sender],[sendtime],[sendip],[title],[body],[stat] from yxs_mailinfo ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.Sender = reader.GetString(1);
                    model.SendTime = reader.GetDateTime(2);
                    model.SendIp = reader.GetString(3);
                    model.Title = reader.GetString(4);
                    model.Body = reader.GetString(5);
                    model.Stat = reader.GetInt32(6);
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.MailInfo> GetAll()
        {
            List<ShowShop.Model.Member.MailInfo> list = new List<ShowShop.Model.Member.MailInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[sender],[sendtime],[sendip],[title],[body],[stat] from yxs_mailinfo ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.MailInfo model = new ShowShop.Model.Member.MailInfo();
                    model.ID = reader.GetInt32(0);
                    model.Sender = reader.GetString(1);
                    model.SendTime = reader.GetDateTime(2);
                    model.SendIp = reader.GetString(3);
                    model.Title = reader.GetString(4);
                    model.Body = reader.GetString(5);
                    model.Stat = reader.GetInt32(6);
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
        public List<ShowShop.Model.Member.MailInfo> GetAll(string strWhere)
        {
            List<ShowShop.Model.Member.MailInfo> list = new List<ShowShop.Model.Member.MailInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[sender],[sendtime],[sendip],[title],[body],[stat] from yxs_mailinfo ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.MailInfo model = new ShowShop.Model.Member.MailInfo();
                    model.ID = reader.GetInt32(0);
                    model.Sender = reader.GetString(1);
                    model.SendTime = reader.GetDateTime(2);
                    model.SendIp = reader.GetString(3);
                    model.Title = reader.GetString(4);
                    model.Body = reader.GetString(5);
                    model.Stat = reader.GetInt32(6);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到不同用户不用状态的收件列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_mailinfo [where] " + strWhere + " [order by] id desc";
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
            dataPage.Sql = "[select] * [from] yxs_mailinfo [where] 1=1 [order by] id desc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Member.MailInfo model)
        {
            SqlParameter[] paras = new SqlParameter[7];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@sender", SqlDbType.VarChar, 50);
            paras[1].Value = model.Sender;
            paras[2] = new SqlParameter("@sendtime", SqlDbType.DateTime);
            paras[2].Value = model.SendTime;
            paras[3] = new SqlParameter("@sendip", SqlDbType.VarChar, 50);
            paras[3].Value = model.SendIp;
            paras[4] = new SqlParameter("@title", SqlDbType.VarChar, 500);
            paras[4].Value = model.Title;
            paras[5] = new SqlParameter("@body", SqlDbType.NText);
            paras[5].Value = model.Body;
            paras[6] = new SqlParameter("@stat", SqlDbType.Int, 4);
            paras[6].Value = model.Stat;
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
