using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Accessories;
using System.Data.SqlClient;
using System.Data;

namespace ShowShop.SQLServerDAL.Accessories
{
    public class CommentInfo:ICommentInfo
    {

        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Accessories.CommentInfo model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into [yxs_commentinfo](";
            sequel = sequel + "[type], [username], [uid], [isreguser], [grade], [title], [tag], [contentlist], [commenttime], [commentid], [againstnum], [supportnum], [flowernum])";
            sequel = sequel + "Values(";
            sequel = sequel + "@type, @username,@uid,@isreguser,@grade,@title,@tag,@contentlist,@commenttime,@commentid,@againstnum,@supportnum,@flowernum) Select scope_IDENTITY() ";
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
        /// <remarks></remarks>
        public void Delete(int id)
        {
            string sequel = "Delete From [yxs_commentinfo]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        public void DeleteAll(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From [yxs_commentinfo] ");
            strSql.Append(" where id in(");
            strSql.Append(ids+" )");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Amend(ShowShop.Model.Accessories.CommentInfo model)
        {
            string sequel = "Update [yxs_commentinfo] set  ";
            sequel = sequel + "[type] =@type ,[username] =@username ,[uid]=@uid ,[isreguser] =@isreguser ,[grade] =@grade ,[title] =@title ,[tag] =@tag,[contentlist] =@contentlist,[commenttime] =@commenttime,[commentid] =@commentid,[againstnum] =@againstnum,[supportnum] =@supportnum,[flowernum] =@flowernum";
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
        /// 修改任一字段的记录
        /// </summary>
        /// <param name="uID"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update [yxs_commentinfo] set ";
            sequel = sequel + "[" + columnName + "] =@Value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Value", value), new SqlParameter("@id", id) };
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
        public ShowShop.Model.Accessories.CommentInfo GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Accessories.CommentInfo model = new ShowShop.Model.Accessories.CommentInfo();
            if (row != null)
            {
                model.ID = int.Parse(row["id"].ToString());
                model.Type = int.Parse(row["type"].ToString());
                model.UserName = row["username"].ToString();
                model.UID =int.Parse(row["uid"].ToString());
                model.IsReguser = int.Parse(row["isreguser"].ToString());
                model.Grade = int.Parse(row["grade"].ToString());
                model.Title = row["title"].ToString();
                model.Tag = row["tag"].ToString();
                model.ContentList = row["contentlist"].ToString();
                model.CommentTime = DateTime.Parse(row["commenttime"].ToString());
                model.CommentID = int.Parse(row["commentid"].ToString());
                model.Againstnum = int.Parse(row["againstnum"].ToString());
                model.SupportNum = int.Parse(row["supportnum"].ToString());
                model.FlowerNum = int.Parse(row["flowernum"].ToString());
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
        public ShowShop.Model.Accessories.CommentInfo GetModelID(int id)
        {
            string sequel = SelectSequel + UpdateWhereSequel;
            SqlParameter[] paras = (SqlParameter[])this.ValueIDPara(id);
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
        /// 跟据CommentID查询
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public System.Data.DataTable GetComentList(string CommentID)
        {
            string strSql = this.SelectSequel + "Where [commentid] = @commentid";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@commentid", SqlDbType.Int, 4);
            paras[0].Value = CommentID;
            return ChangeHope.DataBase.SQLServerHelper.Query(strSql, paras).Tables[0];
        }
        /// <summary>
        /// 所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_commentinfo [where] 1=1 [order by] id asc";
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
            dataPage.Sql = "[select] * [from] yxs_commentinfo [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion

        #region "Other function"
        string selectSequel = string.Empty;
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "Select *,1 PersistStatus  From [yxs_commentinfo] ";
                return selectSequel;
            }
            set
            {
                this.selectSequel = value;
            }
        }
        /// <summary>
        /// 
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

        public IDbDataParameter[] ValueParas(ShowShop.Model.Accessories.CommentInfo model)
        {
            SqlParameter[] paras = new SqlParameter[14];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@type", SqlDbType.Int, 4);
            paras[1].Value = model.Type;
            paras[2] = new SqlParameter("@username", SqlDbType.NVarChar, 50);
            paras[2].Value = model.UserName;
            paras[3] = new SqlParameter("@uid", SqlDbType.Int, 4);
            paras[3].Value = model.UID;
            paras[4] = new SqlParameter("@isreguser", SqlDbType.Int, 4);
            paras[4].Value = model.IsReguser;
            paras[5] = new SqlParameter("@grade", SqlDbType.Int, 4);
            paras[5].Value = model.Grade;
            paras[6] = new SqlParameter("@title", SqlDbType.NVarChar, 200);
            paras[6].Value = model.Title;
            paras[7] = new SqlParameter("@tag", SqlDbType.NVarChar, 200);
            paras[7].Value = model.Tag;
            paras[8] = new SqlParameter("@contentlist", SqlDbType.Text);
            paras[8].Value = model.ContentList;
            paras[9] = new SqlParameter("@commenttime", SqlDbType.DateTime, 8);
            paras[9].Value = model.CommentTime;
            paras[10] = new SqlParameter("@commentid", SqlDbType.Int, 4);
            paras[10].Value = model.CommentID;
            paras[11] = new SqlParameter("@againstnum", SqlDbType.Int, 4);
            paras[11].Value = model.Againstnum;
            paras[12] = new SqlParameter("@supportnum", SqlDbType.Int, 4);
            paras[12].Value = model.SupportNum;
            paras[13] = new SqlParameter("@flowernum", SqlDbType.Int, 4);
            paras[13].Value = model.FlowerNum;

            return paras;
        }

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
