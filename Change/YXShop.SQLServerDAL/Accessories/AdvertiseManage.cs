using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Accessories;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Accessories
{
    /// <summary>
    /// 广告管理数据访问层
    /// </summary>
    public class AdvertiseManage:IAdvertiseManage
    {
        #region "DataBase Operation"
        /// <summary>
        /// 添加一条新广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(ShowShop.Model.Accessories.AdvertiseManage model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_advertisemanage(");
            strSql.Append("[name],[power],[statbrowse],[statclick],[overduetime],[examine],[upspreadadd],[sizebreadth],[hight],[linkaddress],[hint],[backgortarget],[advertisecont],[browsecount],[clickcount],[adtype])");
            strSql.Append(" values (");
            strSql.Append("@name,@power,@statbrowse,@statclick,@overduetime,@examine,@upspreadadd,@sizebreadth,@hight,@linkaddress,@hint,@backgortarget,@advertisecont,@browsecount,@clickcount,@adtype)");
            strSql.Append(" Select scope_IDENTITY()");
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
        public void Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from yxs_advertisemanage ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(Id);

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Amend(ShowShop.Model.Accessories.AdvertiseManage model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_advertisemanage set ");
            strSql.Append("[name]=@name,");
            strSql.Append("[power]=@power,");
            strSql.Append("[statbrowse]=@statbrowse,");
            strSql.Append("[statclick]=@statclick,");
            strSql.Append("[overduetime]=@overduetime,");
            strSql.Append("[examine]=@examine,");
            strSql.Append("[upspreadadd]=@upspreadadd,");
            strSql.Append("[sizebreadth]=@sizebreadth,");
            strSql.Append("[hight]=@hight,");
            strSql.Append("[linkaddress]=@linkaddress,");
            strSql.Append("[hint]=@hint,");
            strSql.Append("[backgortarget]=@backgortarget,");
            strSql.Append("[advertisecont]=@advertisecont,");
            strSql.Append("[browsecount]=@browsecount,");
            strSql.Append("[clickcount]=@clickcount,");
            strSql.Append("[adtype]=@adtype");
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
            string sequel = "Update [yxs_advertisemanage] set ";
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
        public ShowShop.Model.Accessories.AdvertiseManage GetModelByID(int id)
        {
            ShowShop.Model.Accessories.AdvertiseManage model = new ShowShop.Model.Accessories.AdvertiseManage();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 [id],[name],[power],[statbrowse],[statclick],[overduetime],[examine],[upspreadadd],[sizebreadth],[hight],[linkaddress],[hint],[backgortarget],[advertisecont],[browsecount],[clickcount],[adtype] from yxs_advertisemanage ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(),parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.Power = reader.GetInt32(2);
                    model.StatBrowse = reader.GetInt32(3);
                    model.StatClick = reader.GetInt32(4);
                    model.OverdueTime = reader.GetDateTime(5);
                    model.Examine = reader.GetInt32(6);
                    model.UpspreadAdd = reader.GetString(7);
                    model.SizeBreadth = reader.GetString(8);
                    model.Hight = reader.GetString(9);
                    model.LinkAddress = reader.GetString(10);
                    model.Hint = reader.GetString(11);
                    model.BackgorTarget = reader.GetInt32(12);
                    model.Advertisecont = reader.GetString(13);
                    model.BrowseCount = reader.GetInt32(14);
                    model.ClickCount = reader.GetInt32(15);
                    model.Adtype = reader.GetInt32(16);
                }
            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.Accessories.AdvertiseManage> GetAll()
        {
            List<ShowShop.Model.Accessories.AdvertiseManage> list = new List<ShowShop.Model.Accessories.AdvertiseManage>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  [id],[name],[power],[statbrowse],[statclick],[overduetime],[examine],[upspreadadd],[sizebreadth],[hight],[linkaddress],[hint],[backgortarget],[advertisecont],[browsecount],[clickcount],[adtype] from yxs_advertisemanage ");
            strSql.Append(" where 1=1");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Accessories.AdvertiseManage model = new ShowShop.Model.Accessories.AdvertiseManage();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.Power = reader.GetInt32(2);
                    model.StatBrowse = reader.GetInt32(3);
                    model.StatClick = reader.GetInt32(4);
                    model.OverdueTime = reader.GetDateTime(5);
                    model.Examine = reader.GetInt32(6);
                    model.UpspreadAdd = reader.GetString(7);
                    model.SizeBreadth = reader.GetString(8);
                    model.Hight = reader.GetString(9);
                    model.LinkAddress = reader.GetString(10);
                    model.Hint = reader.GetString(11);
                    model.BackgorTarget = reader.GetInt32(12);
                    model.Advertisecont = reader.GetString(13);
                    model.BrowseCount = reader.GetInt32(14);
                    model.ClickCount = reader.GetInt32(15);
                    model.Adtype = reader.GetInt32(16);
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
            dataPage.Sql = "[select] * [from] yxs_advertisemanage [where] 1=1 [order by] power desc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Accessories.AdvertiseManage model)
        {
           
            SqlParameter[] paras = new SqlParameter[17];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            paras[1].Value = model.Name;
            paras[2] = new SqlParameter("@power", SqlDbType.Int, 4);
            paras[2].Value = model.Power;
            paras[3] = new SqlParameter("@statbrowse", SqlDbType.Int, 4);
            paras[3].Value = model.StatBrowse;
            paras[4] = new SqlParameter("@statclick", SqlDbType.Int, 4);
            paras[4].Value = model.StatClick;
            paras[5] = new SqlParameter("@overduetime", SqlDbType.DateTime);
            paras[5].Value = model.OverdueTime;
            paras[6] = new SqlParameter("@examine", SqlDbType.Int, 4);
            paras[6].Value = model.Examine;
            paras[7] = new SqlParameter("@upspreadadd", SqlDbType.VarChar, 3000);
            paras[7].Value = model.UpspreadAdd;
            paras[8] = new SqlParameter("@sizebreadth", SqlDbType.VarChar, 50);
            paras[8].Value = model.SizeBreadth;
            paras[9] = new SqlParameter("@hight", SqlDbType.VarChar, 50);
            paras[9].Value = model.Hight; ;
            paras[10] = new SqlParameter("@linkaddress", SqlDbType.VarChar, 1000);
            paras[10].Value = model.LinkAddress;
            paras[11] = new SqlParameter("@hint", SqlDbType.VarChar, 1000);
            paras[11].Value = model.Hint;
            paras[12] = new SqlParameter("@backgortarget", SqlDbType.Int, 4);
            paras[12].Value = model.BackgorTarget;
            paras[13] = new SqlParameter("@advertisecont", SqlDbType.VarChar, 2000);
            paras[13].Value = model.Advertisecont;
            paras[14] = new SqlParameter("@browsecount", SqlDbType.Int, 4);
            paras[14].Value = model.BrowseCount;
            paras[15] = new SqlParameter("@clickcount", SqlDbType.Int, 4);
            paras[15].Value = model.ClickCount;
            paras[16] = new SqlParameter("@adtype", SqlDbType.Int, 4);
            paras[16].Value = model.Adtype;

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
