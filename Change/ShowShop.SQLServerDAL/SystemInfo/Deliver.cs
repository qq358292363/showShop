using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.SystemInfo;
using System.Data.SqlClient;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    public class Deliver : DbBase, IDeliver
    {
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.Deliver model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Pre + "deliverymode(");
            strSql.Append("name,inceptprice,inceptweight,arrivepay,description,addpriceladder,addweightladder,boundprice,isspecial,isused,putoutid,putouttyid,sort)");
            strSql.Append(" values (");
            strSql.Append("@name,@inceptprice,@inceptweight,@arrivepay,@description,@addpriceladder,@addweightladder,@boundprice,@isspecial,@isused,@putoutid,@putouttyid,@sort)");
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
        /// 跟据导航位置AreaName查询属性
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetProperty(string DistributionName)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] " + Pre + "deliverymode Where ','+[DistributionName]+',' like '%," + DistributionName + ",%'";
            dataPage.GetRecordSetByPage();
            return dataPage;

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.SystemInfo.Deliver model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "deliverymode set ");
            strSql.Append("name=@name,");
            strSql.Append("inceptprice=@inceptprice,");
            strSql.Append("inceptweight=@inceptweight,");
            strSql.Append("arrivepay=@arrivepay,");
            strSql.Append("description=@description,");
            strSql.Append("addpriceladder=@addpriceladder,");
            strSql.Append("addweightladder=@addweightladder,");
            strSql.Append("boundprice=@boundprice,");
            strSql.Append("isspecial=@isspecial,");
            strSql.Append("isused=@isused,");
            strSql.Append("putoutid=@putoutid,");
            strSql.Append("putouttyid=@putouttyid,");
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
            strSql.Append("delete from " + Pre + "deliverymode ");
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
            string sequel = "Update [" + Pre + "deliverymode] set ";
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
        public ShowShop.Model.SystemInfo.Deliver GetModelByID(int id)
        {
            ShowShop.Model.SystemInfo.Deliver model = new ShowShop.Model.SystemInfo.Deliver();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,DistributionName,DistributionDescription,InsuredCosts,IsCOD,Author,Version,IsInstallation from " + Pre + "deliverymode ");
            strSql.Append(" where [Id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.Id = reader.GetInt32(0);
                    model.Distributionname = reader.GetString(1);
                    model.Distributiondescription = reader["DistributionDescription"].ToString();
                    model.Insuredcosts = float.Parse(reader["InsuredCosts"].ToString());
                    model.IsCOD = reader.GetInt32(4);
                    model.Author = reader["Author"].ToString();
                    model.Version = reader["Version"].ToString();
                    model.Isinstallation = Convert.ToInt32(reader["IsInstallation"]);
                }
                else
                {
                    model = null;
                }

            }
            return model;
        }

        /// <summary>
        /// 所有数据集合
        /// </summary>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.Deliver> GetAll()
        {
            List<ShowShop.Model.SystemInfo.Deliver> list = new List<ShowShop.Model.SystemInfo.Deliver>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,DistributionName,DistributionDescription,InsuredCosts,IsCOD,Author,Version,IsInstallation from " + Pre + "deliverymode ");
            strSql.Append(" where 1=1");
            strSql.Append(" order by Id asc");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.SystemInfo.Deliver model = new ShowShop.Model.SystemInfo.Deliver();
                    model.Id = reader.GetInt32(0);
                    model.Distributionname = reader.GetString(1);
                    model.Distributiondescription = reader["DistributionDescription"].ToString();
                    model.Insuredcosts = float.Parse(reader["InsuredCosts"].ToString());
                    model.IsCOD = reader.GetInt32(4);
                    model.Author = reader["Author"].ToString();
                    model.Version = reader["Version"].ToString();
                    model.Isinstallation = Convert.ToInt32(reader["IsInstallation"]);
                    list.Add(model);
                }
            }
            return list;
            return null;
        }

        /// <summary>
        /// 得到指定条件的所有短消息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.Deliver> GetAll(string strWhere)
        {
            //List<ShowShop.Model.SystemInfo.Deliver> list = new List<ShowShop.Model.SystemInfo.Deliver>();
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  id,name,inceptprice,inceptweight,arrivepay,description,addpriceladder,addweightladder,boundprice,isspecial,isused,putoutid,putouttyid,sort from "+Pre+"deliverymode ");
            //if (strWhere != null && strWhere != "")
            //{
            //    strSql.Append("where " + strWhere + " ");
            //}
            //strSql.Append(" order by sort asc");
            //using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            //{
            //    while (reader.Read())
            //    {
            //        ShowShop.Model.SystemInfo.Deliver model = new ShowShop.Model.SystemInfo.Deliver();
            //        model.ID = reader.GetInt32(0);
            //        model.Name = reader.GetString(1);
            //        model.InceptPrice = Convert.ToDecimal(reader["inceptprice"]);
            //        model.InceptWeight = Convert.ToDecimal(reader["inceptweight"]);
            //        model.ArrivePay = reader.GetInt32(4);
            //        model.Description = reader.GetString(5);
            //        model.AddPriceLadder = Convert.ToDecimal(reader["addpriceladder"]);
            //        model.AddWeightLadder = Convert.ToDecimal(reader["addweightladder"]);
            //        model.BoundPrice = reader.GetString(8);
            //        model.IsSpecial = reader.GetInt32(9);
            //        model.IsUsed = reader.GetInt32(10);
            //        model.PutoutId = reader.GetInt32(11);
            //        model.PutouttyId = reader.GetInt32(12);
            //        model.Sort = reader.GetInt32(13);
            //        list.Add(model);
            //    }
            //}
            //return list;
            return null;
        }

        /// <summary>
        /// 得到不同条件得到列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetList(string strWhere)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] " + Pre + "deliverymode [where] " + strWhere + " [order by] Id asc";
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
            dataPage.Sql = "[select] * [from] " + Pre + "deliverymode [where] 1=1 [order by] Id asc";
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
                return " Where [Id] = @Id";
            }
        }

        /// <summary>
        /// 该数据访问对象的属性值装载到数据库更新参数数组
        /// </summary>
        /// <remarks></remarks>
        public IDbDataParameter[] ValueParas(ShowShop.Model.SystemInfo.Deliver model)
        {
            SqlParameter[] paras = new SqlParameter[8];
            paras[0] = new SqlParameter("@Id", SqlDbType.Int, 4);
            paras[0].Value = model.Id;
            paras[1] = new SqlParameter("@DistributionName", SqlDbType.NVarChar, 50);
            paras[1].Value = model.Distributionname;
            paras[2] = new SqlParameter("@DistributionDescription", SqlDbType.NVarChar, 500);
            paras[2].Value = model.Distributiondescription;
            paras[3] = new SqlParameter("@InsuredCosts", SqlDbType.Float, 8);
            paras[3].Value = model.Insuredcosts;
            paras[4] = new SqlParameter("@IsCOD", SqlDbType.Int, 4);
            paras[4].Value = model.IsCOD;
            paras[5] = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
            paras[5].Value = model.Author;
            paras[6] = new SqlParameter("@Version", SqlDbType.NVarChar, 50);
            paras[6].Value = model.Version;
            paras[7] = new SqlParameter("@IsInstallation", SqlDbType.Int, 4);
            paras[7].Value = model.Isinstallation;
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
            paras[0] = new SqlParameter("@Id", id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }

        #endregion
    }
}
