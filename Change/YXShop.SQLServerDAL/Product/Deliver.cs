using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Product;
using System.Collections.Generic;

namespace ShowShop.SQLServerDAL.Product
{
    public class Deliver:IDeliver
    {
        #region  "DataBase Operation"
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShowShop.Model.Product.Deliver model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into yxs_deliver(");
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
        /// 更新一条数据
        /// </summary>
        public void Amend(ShowShop.Model.Product.Deliver model)
        {
            SqlParameter[] paras = (SqlParameter[])this.ValueParas(model);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update yxs_deliver set ");
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
            strSql.Append("delete from yxs_deliver ");
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
            string sequel = "Update [yxs_deliver] set ";
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
        public ShowShop.Model.Product.Deliver GetModelByID(int id)
        {
            ShowShop.Model.Product.Deliver model = new ShowShop.Model.Product.Deliver();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,inceptprice,inceptweight,arrivepay,description,addpriceladder,addweightladder,boundprice,isspecial,isused,putoutid,putouttyid,sort from yxs_deliver ");
            strSql.Append(" where [id]=@id ");
            SqlParameter[] parameters = (SqlParameter[])this.ValueIDPara(id);
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                if (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.InceptPrice = Convert.ToDecimal(reader["inceptprice"]);
                    model.InceptWeight = Convert.ToDecimal(reader["inceptweight"]);
                    model.ArrivePay = reader.GetInt32(4);
                    model.Description = reader.GetString(5);
                    model.AddPriceLadder = Convert.ToDecimal(reader["addpriceladder"]);
                    model.AddWeightLadder = Convert.ToDecimal(reader["addweightladder"]);
                    model.BoundPrice = reader.GetString(8);
                    model.IsSpecial = reader.GetInt32(9);
                    model.IsUsed = reader.GetInt32(10);
                    model.PutoutId = reader.GetInt32(11);
                    model.PutouttyId = reader.GetInt32(12);
                    model.Sort = reader.GetInt32(13);
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
        public List<ShowShop.Model.Product.Deliver> GetAll()
        {
            List<ShowShop.Model.Product.Deliver> list = new List<ShowShop.Model.Product.Deliver>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,inceptprice,inceptweight,arrivepay,description,addpriceladder,addweightladder,boundprice,isspecial,isused,putoutid,putouttyid,sort from yxs_deliver ");
            strSql.Append(" where 1=1");
            strSql.Append(" order by sort asc");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.Deliver model = new ShowShop.Model.Product.Deliver();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.InceptPrice = Convert.ToDecimal(reader["inceptprice"]);
                    model.InceptWeight = Convert.ToDecimal(reader["inceptweight"]);
                    model.ArrivePay = reader.GetInt32(4);
                    model.Description = reader.GetString(5);
                    model.AddPriceLadder = Convert.ToDecimal(reader["addpriceladder"]);
                    model.AddWeightLadder = Convert.ToDecimal(reader["addweightladder"]);
                    model.BoundPrice = reader.GetString(8);
                    model.IsSpecial = reader.GetInt32(9);
                    model.IsUsed = reader.GetInt32(10);
                    model.PutoutId = reader.GetInt32(11);
                    model.PutouttyId = reader.GetInt32(12);
                    model.Sort = reader.GetInt32(13);
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
        public List<ShowShop.Model.Product.Deliver> GetAll(string strWhere)
        {
            List<ShowShop.Model.Product.Deliver> list = new List<ShowShop.Model.Product.Deliver>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,name,inceptprice,inceptweight,arrivepay,description,addpriceladder,addweightladder,boundprice,isspecial,isused,putoutid,putouttyid,sort from yxs_deliver ");
            if (strWhere != null && strWhere != "")
            {
                strSql.Append("where " + strWhere + " ");
            }
            strSql.Append(" order by sort asc");
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.Product.Deliver model = new ShowShop.Model.Product.Deliver();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.InceptPrice = Convert.ToDecimal(reader["inceptprice"]);
                    model.InceptWeight = Convert.ToDecimal(reader["inceptweight"]);
                    model.ArrivePay = reader.GetInt32(4);
                    model.Description = reader.GetString(5);
                    model.AddPriceLadder = Convert.ToDecimal(reader["addpriceladder"]);
                    model.AddWeightLadder = Convert.ToDecimal(reader["addweightladder"]);
                    model.BoundPrice = reader.GetString(8);
                    model.IsSpecial = reader.GetInt32(9);
                    model.IsUsed = reader.GetInt32(10);
                    model.PutoutId = reader.GetInt32(11);
                    model.PutouttyId = reader.GetInt32(12);
                    model.Sort = reader.GetInt32(13);
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
            dataPage.Sql = "[select] * [from] yxs_deliver [where] " + strWhere + " [order by] sort asc";
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
            dataPage.Sql = "[select] * [from] yxs_deliver [where] 1=1 [order by] sort asc";
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
        public IDbDataParameter[] ValueParas(ShowShop.Model.Product.Deliver model)
        {
            SqlParameter[] paras = new SqlParameter[14];
            paras[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            paras[0].Value = model.ID;
            paras[1] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            paras[1].Value = model.Name;
            paras[2] = new SqlParameter("@inceptprice", SqlDbType.Float, 8);
            paras[2].Value = model.InceptPrice;
            paras[3] = new SqlParameter("@inceptweight", SqlDbType.Float, 8);
            paras[3].Value = model.InceptWeight;
            paras[4] = new SqlParameter("@arrivepay", SqlDbType.Int, 4);
            paras[4].Value = model.ArrivePay;
            paras[5] = new SqlParameter("@description", SqlDbType.NVarChar, 1000);
            paras[5].Value = model.Description;
            paras[6] = new SqlParameter("@addpriceladder", SqlDbType.Float, 8);
            paras[6].Value = model.AddPriceLadder;
            paras[7] = new SqlParameter("@addweightladder", SqlDbType.Float, 8);
            paras[7].Value = model.AddWeightLadder;
            paras[8] = new SqlParameter("@boundprice", SqlDbType.NVarChar, 1000);
            paras[8].Value = model.BoundPrice;
            paras[9] = new SqlParameter("@isspecial", SqlDbType.Int, 4);
            paras[9].Value = model.IsSpecial;
            paras[10] = new SqlParameter("@isused", SqlDbType.Int, 4);
            paras[10].Value = model.IsUsed;
            paras[11] = new SqlParameter("@putoutid", SqlDbType.Int, 4);
            paras[11].Value = model.PutoutId;
            paras[12] = new SqlParameter("@putouttyid", SqlDbType.Int, 4);
            paras[12].Value = model.PutouttyId;
            paras[13] = new SqlParameter("@sort", SqlDbType.Int, 4);
            paras[13].Value = model.Sort;
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
