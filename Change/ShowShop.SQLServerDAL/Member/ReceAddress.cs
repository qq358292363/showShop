using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Member;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Member
{
    public class ReceAddress:IReceAddress
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Member.ReceAddress model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_receaddress(");
            strSql.Append("uid,userid,username,mobile,phone,fax,province,city,borough,address,zip,email,stat,ConsignesTime,ConstructionSigns)");
            strSql.Append(" values (");
            strSql.Append("@uid,@userid,@username,@mobile,@phone,@fax,@province,@city,@borough,@address,@zip,@email,@stat,@ConsignesTime,@ConstructionSigns)");
            strSql.Append(";select @@IDENTITY");
            int obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), paras);
            if (obj > 0)
            {
                return obj;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_receaddress ");
            strSql.Append(" where [id] in (" + id + ") ");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Member.ReceAddress model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_receaddress set ");
            strSql.Append("uid=@uid,");
            strSql.Append("userid=@userid,");
            strSql.Append("username=@username,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("phone=@phone,");
            strSql.Append("fax=@fax,");
            strSql.Append("province=@province,");
            strSql.Append("city=@city,");
            strSql.Append("borough=@borough,");
            strSql.Append("address=@address,");
            strSql.Append("zip=@zip,");
            strSql.Append("email=@email,");
            strSql.Append("ConsignesTime=@ConsignesTime,");
            strSql.Append("ConstructionSigns=@ConstructionSigns,");
            strSql.Append("stat=@stat");
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
            string sequel = "Update [yxs_receaddress] set ";
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
        /// 判断是否存在默认收货地址
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int checkDefault(int uid, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from yxs_receaddress ");
            strSql.Append(" where [uid] =@uid ");
            strSql.Append(" and stat=@stat ");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@uid", SqlDbType.Int, 4),
                new SqlParameter("@stat", SqlDbType.Int, 4)
            };
            parms[0].Value = uid;
            parms[1].Value = state;
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), parms);
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
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.Member.ReceAddress GetModelByID(int id)
        {
            ShowShop.Model.Member.ReceAddress model = new ShowShop.Model.Member.ReceAddress();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,uid,userid,username,mobile,phone,fax,province,city,borough,address,zip,email,stat,ConsignesTime,ConstructionSigns from yxs_receaddress ");
            strSql.Append(" where [uid]=@id");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.UserId = reader.GetString(2);
                    model.UserName = reader.GetString(3);
                    model.Mobile = reader.GetString(4);
                    model.Phone = reader.GetString(5);
                    model.Fax = reader.GetString(6);
                    model.Province = reader.GetString(7);
                    model.City = reader.GetString(8);
                    model.Borough = reader.GetString(9);
                    model.Address = reader.GetString(10);
                    model.Zip = reader.GetString(11);
                    model.Email = reader.GetString(12);
                    model.Stat = reader.GetInt32(13);
                    model.ConsignesTime = reader["ConsignesTime"].ToString();
                    model.ConstructionSigns = reader["ConstructionSigns"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Member.ReceAddress> GetAll()
        {
            List<ShowShop.Model.Member.ReceAddress> list = new List<ShowShop.Model.Member.ReceAddress>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,uid,userid,username,mobile,phone,fax,province,city,borough,address,zip,email,stat,ConsignesTime,ConstructionSigns from yxs_receaddress ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.ReceAddress model = new ShowShop.Model.Member.ReceAddress();
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.UserId = reader.GetString(2);
                    model.UserName = reader.GetString(3);
                    model.Mobile = reader.GetString(4);
                    model.Phone = reader.GetString(5);
                    model.Fax = reader.GetString(6);
                    model.Province = reader.GetString(7);
                    model.City = reader.GetString(8);
                    model.Borough = reader.GetString(9);
                    model.Address = reader.GetString(10);
                    model.Zip = reader.GetString(11);
                    model.Email = reader.GetString(12);
                    model.Stat = reader.GetInt32(13);
                    model.ConsignesTime = reader.GetString(14);
                    model.ConstructionSigns = reader.GetString(15);
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
        public List<ShowShop.Model.Member.ReceAddress> GetAll(string strWhere)
        {
            List<ShowShop.Model.Member.ReceAddress> list = new List<ShowShop.Model.Member.ReceAddress>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,uid,userid,username,mobile,phone,fax,province,city,borough,address,zip,email,stat,ConsignesTime,ConstructionSigns from yxs_receaddress ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Member.ReceAddress model = new ShowShop.Model.Member.ReceAddress();
                    model.ID = reader.GetInt32(0);
                    model.UID = reader.GetInt32(1);
                    model.UserId = reader.GetString(2);
                    model.UserName = reader.GetString(3);
                    model.Mobile = reader.GetString(4);
                    model.Phone = reader.GetString(5);
                    model.Fax = reader.GetString(6);
                    model.Province = reader.GetString(7);
                    model.City = reader.GetString(8);
                    model.Borough = reader.GetString(9);
                    model.Address = reader.GetString(10);
                    model.Zip = reader.GetString(11);
                    model.Email = reader.GetString(12);
                    model.Stat = reader.GetInt32(13);
                    model.ConsignesTime = reader.GetString(14);
                    model.ConstructionSigns = reader.GetString(15);
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
            dataPage.Sql = "[select] * [from] yxs_receaddress [where] " + strWhere + " [order by] id desc";
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
            dataPage.Sql = "[select] * [from] yxs_receaddress [where] 1=1 [order by] id desc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Member.ReceAddress model)
        {
            SqlParameter[] paras = new SqlParameter[16];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@uid", SqlDbType.Int, 4);
            paras[1].Value = model.UID;
            paras[2] = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            paras[2].Value = model.UserId;
            paras[3] = new SqlParameter("@username", SqlDbType.VarChar, 100);
            paras[3].Value = model.UserName;
            paras[4] = new SqlParameter("@mobile", SqlDbType.VarChar, 50);
            paras[4].Value = model.Mobile;
            paras[5] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            paras[5].Value = model.Phone;
            paras[6] = new SqlParameter("@fax", SqlDbType.VarChar, 50);
            paras[6].Value = model.Fax;
            paras[7] = new SqlParameter("@province", SqlDbType.VarChar, 20);
            paras[7].Value = model.Province;
            paras[8] = new SqlParameter("@city", SqlDbType.VarChar, 20);
            paras[8].Value = model.City;
            paras[9] = new SqlParameter("@borough", SqlDbType.VarChar, 20);
            paras[9].Value = model.Borough;
            paras[10] = new SqlParameter("@address", SqlDbType.VarChar, 500);
            paras[10].Value = model.Address;
            paras[11] = new SqlParameter("@zip", SqlDbType.VarChar, 10);
            paras[11].Value = model.Zip;
            paras[12] = new SqlParameter("@email", SqlDbType.VarChar, 100);
            paras[12].Value = model.Email;
            paras[13] = new SqlParameter("@stat", SqlDbType.Int, 4);
            paras[13].Value = model.Stat;
            paras[14] = new SqlParameter("@ConsignesTime", SqlDbType.VarChar, 100);
            paras[14].Value = model.ConsignesTime;
            paras[15] = new SqlParameter("@ConstructionSigns", SqlDbType.VarChar, 100);
            paras[15].Value = model.ConstructionSigns;
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
