using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Accessories;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Accessories
{
    public class Outofstock:IOutofstock
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.Outofstock model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_outofstock(");
            strSql.Append("[proid],[proclassandname],[addtime],[addip],[username],[issreguser],[telphone],[mobile],[qq],[email],[msn],[neednum],[content],[state],[isdeal],[dealtime],[dealremark])");
            strSql.Append(" values (");
            strSql.Append("@proid,@proclassandname,@addtime,@addip,@username,@issreguser,@telphone,@mobile,@qq,@email,@msn,@neednum,@content,@state,@isdeal,@dealtime,@dealremark)");
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
            strSql.Append("delete from yxs_outofstock ");
            strSql.Append(" where id in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.Outofstock model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_outofstock set ");
            strSql.Append("[proid]=@proid,");
            strSql.Append("[proclassandname]=@proclassandname,");
            strSql.Append("[addtime]=@addtime,");
            strSql.Append("[addip]=@addip,");
            strSql.Append("[username]=@username,");
            strSql.Append("[issreguser]=@issreguser,");
            strSql.Append("[telphone]=@telphone,");
            strSql.Append("[mobile]=@mobile,");
            strSql.Append("[qq]=@qq,");
            strSql.Append("[email]=@email,");
            strSql.Append("[msn]=@msn,");
            strSql.Append("[neednum]=@neednum,");
            strSql.Append("[content]=@content,");
            strSql.Append("[state]=@state,");
            strSql.Append("[isdeal]=@isdeal,");
            strSql.Append("[dealtime]=@dealtime,");
            strSql.Append("[dealremark]=@dealremark");
            strSql.Append(" where id=@id ");
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
            string sequel = "Update [yxs_outofstock] set ";
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
        public ShowShop.Model.Accessories.Outofstock GetModelByID(int id)
        {
            ShowShop.Model.Accessories.Outofstock model = new ShowShop.Model.Accessories.Outofstock();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[proid],[proclassandname],[addtime],[addip],[username],[issreguser],[telphone],[mobile],[qq],[email],[msn],[neednum],[content],[state],[isdeal],[dealtime],[dealremark] from yxs_outofstock ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.Proid = reader.GetInt32(1);
                    model.ProClassAndName = reader.GetString(2);
                    model.AddTime = reader.GetDateTime(3);
                    model.AddIp = reader.GetString(4);
                    model.UserName = reader.GetString(5);
                    model.IssRegUser = reader.GetInt32(6);
                    model.Telphone = reader.GetString(7);
                    model.Mobile = reader.GetString(8);
                    model.QQ = reader.GetString(9);
                    model.Email = reader.GetString(10);
                    model.MSN = reader.GetString(11);
                    model.NeedNum = reader.GetInt32(12);
                    model.Content = reader.GetString(13);
                    model.State = reader.GetInt32(14);
                    model.IsDeal = reader.GetInt32(15);
                    model.DealTime = reader.GetDateTime(16);
                    model.DealRemark = reader.GetString(17);
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.Outofstock> GetAll()
        {
            List<ShowShop.Model.Accessories.Outofstock> list = new List<ShowShop.Model.Accessories.Outofstock>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id],[proid],[proclassandname],[addtime],[addip],[username],[issreguser],[telphone],[mobile],[qq],[email],[msn],[neednum],[content],[state],[isdeal],[dealtime],[dealremark] from yxs_outofstock ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Accessories.Outofstock model = new ShowShop.Model.Accessories.Outofstock();
                    model.ID = reader.GetInt32(0);
                    model.Proid = reader.GetInt32(1);
                    model.ProClassAndName = reader.GetString(2);
                    model.AddTime = reader.GetDateTime(3);
                    model.AddIp = reader.GetString(4);
                    model.UserName = reader.GetString(5);
                    model.IssRegUser = reader.GetInt32(6);
                    model.Telphone = reader.GetString(7);
                    model.Mobile = reader.GetString(8);
                    model.QQ = reader.GetString(9);
                    model.Email = reader.GetString(10);
                    model.MSN = reader.GetString(11);
                    model.NeedNum = reader.GetInt32(12);
                    model.Content = reader.GetString(13);
                    model.State = reader.GetInt32(14);
                    model.IsDeal = reader.GetInt32(15);
                    model.DealTime = reader.GetDateTime(16);
                    model.DealRemark = reader.GetString(17);
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
            dataPage.Sql = "[select] * [from] yxs_outofstock [where] 1=1 [order by] id desc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Accessories.Outofstock model)
        {
            SqlParameter[] paras = new SqlParameter[18];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@proid", SqlDbType.Int, 4);
            paras[1].Value = model.Proid;
            paras[2] = new SqlParameter("@proclassandname", SqlDbType.NVarChar, 3000);
            paras[2].Value = model.ProClassAndName;
            paras[3] = new SqlParameter("@addtime", SqlDbType.DateTime);
            paras[3].Value = model.AddTime;
            paras[4] = new SqlParameter("@addip", SqlDbType.NVarChar, 20);
            paras[4].Value = model.AddIp;
            paras[5] = new SqlParameter("@username", SqlDbType.NVarChar, 50);
            paras[5].Value = model.UserName;
            paras[6] = new SqlParameter("@issreguser", SqlDbType.Int, 4);
            paras[6].Value = model.IssRegUser;
            paras[7] = new SqlParameter("@telphone", SqlDbType.NVarChar, 20);
            paras[7].Value = model.Telphone;
            paras[8] = new SqlParameter("@mobile", SqlDbType.NVarChar, 50);
            paras[8].Value = model.Mobile;
            paras[9] = new SqlParameter("@qq", SqlDbType.NVarChar, 20);
            paras[9].Value = model.QQ;
            paras[10] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            paras[10].Value = model.Email;
            paras[11] = new SqlParameter("@msn", SqlDbType.NVarChar, 50);
            paras[11].Value = model.MSN;
            paras[12] = new SqlParameter("@neednum", SqlDbType.Int, 4);
            paras[12].Value = model.NeedNum;
            paras[13] = new SqlParameter("@content", SqlDbType.Text);
            paras[13].Value = model.Content;
            paras[14] = new SqlParameter("@state", SqlDbType.Int, 4);
            paras[14].Value = model.State;
            paras[15] = new SqlParameter("@isdeal", SqlDbType.Int, 4);
            paras[15].Value = model.IsDeal;
            paras[16] = new SqlParameter("@dealtime", SqlDbType.DateTime);
            paras[16].Value = model.DealTime;
            paras[17] = new SqlParameter("@dealremark", SqlDbType.NVarChar, 1000);
            paras[17].Value = model.DealRemark;
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
