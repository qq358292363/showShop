using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Accessories;
using System.Data;
using System.Data.SqlClient;

namespace ShowShop.SQLServerDAL.Accessories
{
    public class CommentReply:ICommentReply
    {

        #region "DataBase Operation"
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.Accessories.CommentReply model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            string sequel = "Insert into [yxs_commentreply](";
            sequel = sequel + "[commentid], [uid], [content], [replytime])";
            sequel = sequel + "Values(";
            sequel = sequel + "@commentid, @uid,@content,@replytime) Select scope_IDENTITY() ";
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
            string sequel = "Delete From [yxs_commentreply]" + this.UpdateWhereSequel;
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 点评所有回复
        /// </summary>
        /// <remarks></remarks>
        public void AllDelete(string commentid)
        {
            string sequel = "Delete From [yxs_commentreply] where commentid in ("+commentid+")";
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel);
        }
        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Amend(ShowShop.Model.Accessories.CommentReply model)
        {
            string sequel = "Update [yxs_commentreply] set  ";
            sequel = sequel + "[commentid] =@commentid ,[uid]=@uid ,[content] =@content ,[replytime] =@replytime";
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
            string sequel = "Update [yxs_commentreply] set ";
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
        public ShowShop.Model.Accessories.CommentReply GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.Accessories.CommentReply model = new ShowShop.Model.Accessories.CommentReply();
            if (row != null)
            {
                model.RID = int.Parse(row["id"].ToString());
                model.UID = int.Parse(row["uid"].ToString());
                model.Content = row["content"].ToString();
                model.ReplyTime = DateTime.Parse(row["replytime"].ToString());
                model.CommentID = int.Parse(row["commentid"].ToString());
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
        public ShowShop.Model.Accessories.CommentReply GetModelID(int id)
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
        /// 所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_commentreply [where] 1=1 [order by] rid asc";
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
            dataPage.Sql = "[select] * [from] yxs_commentreply [where] 1=1 " + Conditions + " " + orderfield;
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
                    selectSequel = "Select *,1 PersistStatus  From [yxs_commentreply] ";
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
                return " Where [rid] = @rid";
            }
        }
        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>

        public IDbDataParameter[] ValueParas(ShowShop.Model.Accessories.CommentReply model)
        {
            SqlParameter[] paras = new SqlParameter[5];
            paras[0] = new SqlParameter("@rid", SqlDbType.Int, 4);
            paras[0].Value = model.RID;
            paras[1] = new SqlParameter("@uid", SqlDbType.Int, 4);
            paras[1].Value = model.UID;
            paras[2] = new SqlParameter("@content", SqlDbType.Text, 16);
            paras[2].Value = model.Content;
            paras[3] = new SqlParameter("@replytime", SqlDbType.DateTime, 8);
            paras[3].Value = model.ReplyTime;
            paras[4] = new SqlParameter("@commentid", SqlDbType.Int, 4);
            paras[4].Value = model.CommentID;

            return paras;
        }

        public IDbDataParameter[] ValueIDPara(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@rid", id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }

        #endregion
    }
}
