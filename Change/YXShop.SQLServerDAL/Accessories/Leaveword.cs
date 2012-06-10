using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Accessories;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Accessories
{
    public class Leaveword:ILeaveword
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加一条新的友情链接
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.Leaveword model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_leaveword(");
            strSql.Append("[type],[username],[telephone],[qq],[msn],[email],[title],[ip],[isreguser],[content],[adddate],[isread],[replycontent],[isreply],[replydate],[isauditing],[storeid],[address])");
            strSql.Append(" values (");
            strSql.Append("@type,@username,@telephone,@qq,@msn,@email,@title,@ip,@isreguser,@content,@adddate,@isread,@replycontent,@isreply,@replydate,@isauditing,@storeid,@address)");
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
            strSql.Append("delete from yxs_leaveword ");
            strSql.Append(" where id in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }
        public void DeleteById(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_leaveword ");
            strSql.Append("where id=@id");
            SqlParameter[] parameters ={
                                           new SqlParameter("@id",SqlDbType.Int,4)
                                      };
            parameters[0].Value = id;
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.Leaveword model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_leaveword set ");
            strSql.Append("[type]=@type,");
            strSql.Append("[username]=@username,");
            strSql.Append("[telephone]=@telephone,");
            strSql.Append("[qq]=@qq,");
            strSql.Append("[msn]=@msn,");
            strSql.Append("[email]=@email,");
            strSql.Append("[title]=@title,");
            strSql.Append("[ip]=@ip,");
            strSql.Append("[isreguser]=@isreguser,");
            strSql.Append("[content]=@content,");
            strSql.Append("[adddate]=@adddate,");
            strSql.Append("[isread]=@isread,");
            strSql.Append("[replycontent]=@replycontent,");
            strSql.Append("[isreply]=@isreply,");
            strSql.Append("[replydate]=@replydate,");
            strSql.Append("[isauditing]=@isauditing,");
            strSql.Append("[storeid]=@storeid,");
            strSql.Append("[address]=@address");
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
            string sequel = "Update [yxs_leaveword] set ";
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
        public ShowShop.Model.Accessories.Leaveword GetModelByID(int id)
        {
            ShowShop.Model.Accessories.Leaveword model = new ShowShop.Model.Accessories.Leaveword();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[type],[username],[telephone],[qq],[msn],[email],[title],[ip],[isreguser],[content],[adddate],[isread],[replycontent],[isreply],[replydate],[isauditing],[storeid],[address] from yxs_leaveword ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.Type = reader.GetInt32(1);
                    model.UserName = reader.GetString(2)==""?" ":reader.GetString(2);
                    model.Telephone = reader.GetString(3)==""?" ":reader.GetString(3);
                    model.QQ = reader.GetString(4) == "" ? " " : reader.GetString(4);
                    model.MSN = reader.GetString(5) == "" ? " " : reader.GetString(5);
                    model.Email = reader.GetString(6) == "" ? " " : reader.GetString(6);
                    model.Title = reader.GetString(7)== ""?" ":reader.GetString(7);
                    model.IP = reader.GetString(8) == ""? " " : reader.GetString(8);
                    model.IsRegUser = reader.GetInt32(9);
                    model.Content = reader.GetString(10) == ""? " " : reader.GetString(10);
                    model.AddDate = reader.GetDateTime(11);
                    model.IsRead = reader.GetInt32(12);
                    model.ReplyContent = reader["replycontent"] == DBNull.Value ? " " : reader["replycontent"].ToString();
                    model.IsReply = reader.GetInt32(14);
                    model.ReplyDate = reader["replydate"] == DBNull.Value ? DateTime.Parse("0001-01-01") : Convert.ToDateTime(reader["replydate"]);
                    model.IsAuditing = reader.GetInt32(16);
                    model.StoreId = reader.GetInt32(17);
                    model.Address = reader["address"] == DBNull.Value ? " " : reader["address"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.Leaveword> GetAll()
        {
            List<ShowShop.Model.Accessories.Leaveword> list = new List<ShowShop.Model.Accessories.Leaveword>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id],[type],[username],[telephone],[qq],[msn],[email],[title],[ip],[isreguser],[content],[adddate],[isread],[replycontent],[isreply],[replydate],[isauditing],[storeid],[address] from yxs_leaveword ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Accessories.Leaveword model = new ShowShop.Model.Accessories.Leaveword();
                    model.ID = reader.GetInt32(0);
                    model.Type = reader.GetInt32(1);
                    model.UserName = reader.GetString(2);
                    model.Telephone = reader.GetString(3);
                    model.QQ = reader.GetString(4);
                    model.MSN = reader.GetString(5);
                    model.Email = reader.GetString(6);
                    model.Title = reader.GetString(7);
                    model.IP = reader.GetString(8);
                    model.IsRegUser = reader.GetInt32(9);
                    model.Content = reader.GetString(10);
                    model.AddDate = reader.GetDateTime(11);
                    model.IsRead = reader.GetInt32(12);
                    model.ReplyContent = reader.GetString(13);
                    model.IsReply = reader.GetInt32(14);
                    model.ReplyDate = reader.GetDateTime(15);
                    model.IsAuditing = reader.GetInt32(16);
                    model.StoreId = reader.GetInt32(17);
                    model.Address = reader.GetString(18);
                    list.Add(model);
                }
            }
            return list;

        }

        /// <summary>
        /// 得到所有记录
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_leaveword [where] 1=1 [order by] id desc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 根据任何条件得到分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_leaveword [where] " + strWhere + " [order by] id desc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 前台标签所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_leaveword [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Accessories.Leaveword model)
        {
            SqlParameter[] paras = new SqlParameter[19];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@type", SqlDbType.Int, 4);
            paras[1].Value = model.Type;
            paras[2] = new SqlParameter("@username", SqlDbType.NVarChar, 50);
            paras[2].Value = model.UserName;
            paras[3] = new SqlParameter("@telephone", SqlDbType.NVarChar, 20);
            paras[3].Value = model.Telephone;
            paras[4] = new SqlParameter("@qq", SqlDbType.NVarChar, 50);
            paras[4].Value = model.QQ;
            paras[5] = new SqlParameter("@msn", SqlDbType.NVarChar, 50);
            paras[5].Value = model.MSN;
            paras[6] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            paras[6].Value = model.Email;
            paras[7] = new SqlParameter("@title", SqlDbType.NVarChar, 50);
            paras[7].Value = model.Title;
            paras[8] = new SqlParameter("@ip", SqlDbType.NVarChar, 50);
            paras[8].Value = model.IP;
            paras[9] = new SqlParameter("@isreguser", SqlDbType.Int, 4);
            paras[9].Value = model.IsRegUser;
            paras[10] = new SqlParameter("@content", SqlDbType.NVarChar, 3000);
            paras[10].Value = model.Content;
            paras[11] = new SqlParameter("@adddate", SqlDbType.DateTime);
            paras[11].Value = model.AddDate;
            paras[12] = new SqlParameter("@isread", SqlDbType.Int, 4);
            paras[12].Value = model.IsRead;
            paras[13] = new SqlParameter("@replycontent", SqlDbType.NVarChar, 3000);
            paras[13].Value = model.ReplyContent;
            paras[14] = new SqlParameter("@isreply", SqlDbType.Int, 4);
            paras[14].Value = model.IsReply;
            paras[15] = new SqlParameter("@replydate", SqlDbType.DateTime);
            paras[15].Value = model.ReplyDate;
            paras[16] = new SqlParameter("@isauditing", SqlDbType.Int, 4);
            paras[16].Value = model.IsAuditing;
            paras[17] = new SqlParameter("@storeid", SqlDbType.Int, 4);
            paras[17].Value = model.StoreId;
            paras[18] = new SqlParameter("@address",SqlDbType.VarChar,100);
            paras[18].Value = model.Address;
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
