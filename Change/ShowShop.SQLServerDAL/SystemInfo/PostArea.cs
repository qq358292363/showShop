using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.SystemInfo;
using System.Data.SqlClient;
using System.Data;

namespace ShowShop.SQLServerDAL.SystemInfo
{
    public class PostArea:DbBase,IPostArea
    {
        #region "DataBase Operation"
        /// <summary>
        /// 在数据库中新增一个持久化对象,自增长列Prop_ID的值会自动从数据库中返回
        /// </summary>
        /// <remarks></remarks>
        public int Add(ShowShop.Model.SystemInfo.PostArea model)
        {
            SqlParameter[] paras = (SqlParameter[])this.VauleParas(model);
            string sequel = "Insert into " + Pre + "deliveryareasetting(";
            sequel = sequel + "[DeliveryMode],[AreaName],[AreaId], [BasicFees], [FreeAmount], [CODPayFees], [FeesCalculationWay],[SingleProductFees],[Overweight],[Overweight2],[PackagingCosts],[putouttyid],[putoutid])";
            sequel = sequel + "Values(";
            sequel = sequel + "@DeliveryMode,@AreaName,@AreaId,@BasicFees,@FreeAmount,@CODPayFees,@FeesCalculationWay,@SingleProductFees,@Overweight,@Overweight2,@PackagingCosts,@putouttyid,@putoutid) Select scope_IDENTITY() ";
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
        /// 删除数据库中指定的持久化对象的数据, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public void Delete(int id)
        {
            string sequel = string.Empty;
            sequel = "Delete From " + Pre + "deliveryareasetting where Id=@Id";
            SqlParameter[] parameters = (SqlParameter[])this.ValueIdParas(id);
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, parameters);
        }

        /// <summary>
        /// 将一个持久化对象的修改保存到数据库, 并提供事务支持
        /// </summary>
        /// <remarks></remarks>
        public int Update(ShowShop.Model.SystemInfo.PostArea model)
        {
            string sequel = "Update " + Pre + "deliveryareasetting set  ";
            sequel = sequel + "[DeliveryMode]=@DeliveryMode,[AreaName]=@AreaName,[AreaId] =@AreaId ,[BasicFees]=@BasicFees ,[FreeAmount]=@FreeAmount ,[CODPayFees] =@CODPayFees ,[FeesCalculationWay] =@FeesCalculationWay ,[SingleProductFees] =@SingleProductFees,[Overweight]=@Overweight,[Overweight2]=@Overweight2,[PackagingCosts]=@PackagingCosts,[putouttyid]=@putouttyid,[putoutid]=@putoutid";
            sequel = sequel + UpdateWhereSequelID;
            object obj = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sequel, (SqlParameter[])this.VauleParas(model));
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
        /// 修改某个字段的值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Amend(int id, string columnName, Object value)
        {
            string sequel = "Update " + Pre + "deliveryareasetting set ";
            sequel = sequel + "[" + columnName + "] =@value ";
            sequel = sequel + UpdateWhereSequel;
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@value", value), new SqlParameter("@id", id) };
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
        public ShowShop.Model.SystemInfo.PostArea GetModel(System.Data.DataRow row)
        {
            ShowShop.Model.SystemInfo.PostArea model = new ShowShop.Model.SystemInfo.PostArea();
            if (row != null)
            {
                model.Id = int.Parse(row["Id"].ToString());
                model.Deliverymode = int.Parse(row["DeliveryMode"].ToString());
                model.Areaname = row["AreaName"].ToString();
                model.Areaid = row["AreaId"].ToString();
                model.Basicfees = float.Parse(row["BasicFees"].ToString());
                model.Freeamount = float.Parse(row["FreeAmount"].ToString());
                model.CODpayfees = float.Parse(row["CODPayFees"].ToString());
                model.Feescalculationway = int.Parse(row["FeesCalculationWay"].ToString());
                model.Initialfees = float.Parse(row["SingleProductFees"].ToString());
                model.Overweight = float.Parse(row["Overweight"].ToString());
                model.Packagingcosts = float.Parse(row["PackagingCosts"].ToString());
                model.Overweight2 = float.Parse(row["Overweight2"].ToString());
                model.Putoutid = int.Parse(row["putoutid"].ToString());
                model.Putouttyid = int.Parse(row["putouttyid"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据配送方式ＩＤ查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.SystemInfo.PostArea GetModelID(int id)
        {
            string sequel = SelectSequel + UpdateWhereSequelID;
            SqlParameter[] paras = (SqlParameter[])this.ValueIdParas(id);
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
        /// 根据配送区域ＩＤ查询
        /// </summary>
        /// <remarks></remarks>
        public ShowShop.Model.SystemInfo.PostArea GetModelByAreaID(int id)
        {
            string sequel = "select * from " + Pre + "deliveryareasetting Where Id = @Id order by Id asc";
            SqlParameter[] paras = (SqlParameter[])this.ValueIdParas(id);
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
        /// 跟据AreaName查询属性
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetProperty(string AreaName)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = this.SelectSequel + "Where ','+[AreaName]+',' like '%," + AreaName + ",%'";
            dataPage.GetRecordSetByPage();
            return dataPage;

        }

        /// <summary>
        /// 跟据AreaId查询属性
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<ShowShop.Model.SystemInfo.PostArea> GetPostMethodByAreaId(string AreaId,string strWhere)
        {
            List<ShowShop.Model.SystemInfo.PostArea> list = new List<ShowShop.Model.SystemInfo.PostArea>();
            string strSql = this.SelectSequel + "Where ','+[AreaId]+',' like '%," + AreaId + ",%'";
            if (strWhere != null && strWhere != "")
            {
                strSql+=(" and " + strWhere + " ");
            }
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    ShowShop.Model.SystemInfo.PostArea model = new ShowShop.Model.SystemInfo.PostArea();
                    model.Id = reader.GetInt32(0);
                    model.Deliverymode = Convert.ToInt32(reader["DeliveryMode"].ToString());
                    model.Areaname = reader["AreaName"].ToString();
                    model.Areaid = reader["AreaId"].ToString();
                    model.Basicfees = float.Parse(reader["BasicFees"].ToString());
                    model.Freeamount = float.Parse(reader["FreeAmount"].ToString());
                    model.CODpayfees = float.Parse(reader["CODPayFees"].ToString());
                    model.Feescalculationway = int.Parse(reader["FeesCalculationWay"].ToString());
                    model.Initialfees = float.Parse(reader["SingleProductFees"].ToString());
                    model.Overweight = float.Parse(reader["Overweight"].ToString());
                    model.Packagingcosts = float.Parse(reader["PackagingCosts"].ToString());
                    model.Overweight2 = float.Parse(reader["Overweight2"].ToString());
                    model.Putoutid = int.Parse(reader["putoutid"].ToString());
                    model.Putouttyid = int.Parse(reader["putouttyid"].ToString());
                    list.Add(model);
                }
            }
            return list;
            return null;

        }

        /// <summary>
        /// 跟据配送方式ID查询对应的配送区域列表
        /// </summary>
        /// <param name="cid">配送方式ID</param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetAreasByPostMethod(int cid)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] " + Pre + "deliveryareasetting [where] DeliveryMode=" + cid.ToString() + " [order by] Id asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 跟据配送方式条件查询对应的配送区域列表
        /// </summary>
        /// <param name="cid">配送方式ID</param>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetAreasBy(string Condits)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] " + Pre + "deliveryareasetting [where] 1=1 "+Condits+" [order by] Id asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList()
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] " + Pre + "deliveryareasetting [where] 1=1 [order by] Id asc";
            dataPage.GetRecordSetByPage();
            return dataPage;
        }

        /// <summary>
        /// 查询第一条数据
        /// </summary>
        /// <returns></returns>
        public ShowShop.Model.SystemInfo.PostArea GetFirstData()
        {
            DataRow dr = null;
            string strSql = "select top 1 * from " + Pre + "deliveryareasetting";
            if (ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0] != null && ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0].Rows.Count != 0)
            {
                dr = ChangeHope.DataBase.SQLServerHelper.Query(strSql).Tables[0].Rows[0];

            }
            ShowShop.Model.SystemInfo.PostArea mem = this.GetModel(dr);

            return mem;
        }
        #endregion

        #region "Other function"
        string selectSequel = string.Empty;
        /// <summary>
        /// 该数据访问对象从数据库中提取数据的Sql语句 
        /// </summary>
        /// <remarks></remarks>
        protected string SelectSequel
        {
            get
            {
                if (selectSequel == string.Empty)
                    selectSequel = "SELECT [Id], [DeliveryMode],[AreaName],[AreaId], [BasicFees], [FreeAmount], [CODPayFees], [FeesCalculationWay],[SingleProductFees],[Overweight],[Overweight2],[PackagingCosts],[putouttyid],[putoutid] FROM " + Pre + "deliveryareasetting ";
                return selectSequel;
            }
            set
            {
                this.selectSequel = value;
            }
        }
        protected string UpdateWhereSequel
        {
            get
            {
                return " Where [DeliveryMode] = @DeliveryMode";
            }
        }

        protected string UpdateWhereSequelID
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
        public IDbDataParameter[] VauleParas(ShowShop.Model.SystemInfo.PostArea model)
        {
            SqlParameter[] paras = new SqlParameter[14];
            paras[0] = new SqlParameter("@Id", SqlDbType.Int, 4);
            paras[0].Value = model.Id;
            paras[1] = new SqlParameter("@DeliveryMode", SqlDbType.Int, 4);
            paras[1].Value = model.Deliverymode;
            paras[2] = new SqlParameter("@AreaName", SqlDbType.VarChar, 1000);
            paras[2].Value = model.Areaname;
            paras[3] = new SqlParameter("@AreaId", SqlDbType.VarChar, 2000);
            paras[3].Value = model.Areaid;
            paras[4] = new SqlParameter("@BasicFees", SqlDbType.Float, 8);
            paras[4].Value = model.Basicfees;
            paras[5] = new SqlParameter("@FreeAmount", SqlDbType.Float, 8);
            paras[5].Value = model.Freeamount;
            paras[6] = new SqlParameter("@CODPayFees", SqlDbType.Float, 8);
            paras[6].Value = model.CODpayfees;
            paras[7] = new SqlParameter("@FeesCalculationWay", SqlDbType.Float, 8);
            paras[7].Value = model.Feescalculationway;
            paras[8] = new SqlParameter("@SingleProductFees", SqlDbType.Float, 8);
            paras[8].Value = model.Initialfees;
            paras[9] = new SqlParameter("@Overweight", SqlDbType.Float, 8);
            paras[9].Value = model.Overweight;
            paras[10] = new SqlParameter("@PackagingCosts", SqlDbType.Float, 8);
            paras[10].Value = model.Packagingcosts;
            paras[11] = new SqlParameter("@Overweight2",SqlDbType.Float,8);
            paras[11].Value = model.Overweight2;
            paras[12] = new SqlParameter("@putoutid", SqlDbType.Int, 4);
            paras[12].Value = model.Putoutid;
            paras[13] = new SqlParameter("@putouttyid", SqlDbType.Int, 4);
            paras[13].Value = model.Putouttyid;
            return paras;
        }
        public IDbDataParameter[] ValueIdParas(int id)
        {
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@Id", (object)id);
            paras[0].DbType = DbType.Int32;
            return paras;
        }

        #endregion
    }
}
