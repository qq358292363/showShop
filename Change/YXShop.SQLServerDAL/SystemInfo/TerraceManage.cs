 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ShowShop.IDAL.SystemInfo;
namespace ShowShop.SQLServerDAL.SystemInfo
{
    public class TerraceManage:ITerraceManage
    {

      #region "DataBase Operation"
        /// <summary>
        /// 添加
        /// </summary>
        public int Add(ShowShop.Model.SystemInfo.TerraceManage model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters;
            strSql.Append("Insert into [yxs_paymentmanage](");
            if(model.Tmgarden==1 || model.Tmgarden==3)
            {
                strSql.Append("[payment_seller], [payment_key], [payment_expenses],[payment_setup],[payment_name],[payment_garden],[payment_putoutid],[payment_putouttypeid],[payment_taxis],[payment_account],[payment_description])");
                strSql.Append("Values(");
                strSql.Append("@TM_Seller, @TM_key, @TM_Expenses,@TM_Sz,@TM_name,@TM_Payment,@TM_PutoutID,@TM_PutoutTypeID,@TM_taxis,@TM_Account,@payment_desc) Select scope_IDENTITY() ");
                parameters = (SqlParameter[])this.ValueParams13(model); 
            }
            else if (model.Tmgarden == 2)
            {
                strSql.Append("[payment_seller], [payment_key], [payment_expenses],[payment_setup],[payment_name],[payment_garden],[payment_putoutid],[payment_putouttypeid],[payment_taxis],[payment_account],[payment_description],[porttype])");
                strSql.Append("Values(");
                strSql.Append("@TM_Seller, @TM_key, @TM_Expenses,@TM_Sz,@TM_name,@TM_Payment,@TM_PutoutID,@TM_PutoutTypeID,@TM_taxis,@TM_Account,@payment_desc,@porttype) Select scope_IDENTITY() ");
                parameters = (SqlParameter[])this.ValueParams(model); 
            }
            else
            {
                strSql.Append("[payment_expenses],[payment_name],[payment_garden],[payment_putoutid],[payment_putouttypeid],[payment_description])");
                strSql.Append("Values(");
                strSql.Append(" @TM_Expenses,@TM_name,@TM_Payment,@TM_PutoutID,@TM_PutoutTypeID,@payment_desc) Select scope_IDENTITY() ");
                parameters = (SqlParameter[])this.ValueParams45(model); 
            }
            
            
            
            object obj = ChangeHope.DataBase.SQLServerHelper.GetSingle(strSql.ToString(), parameters);
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
        /// 修改
        /// </summary>  
        public void Update(ShowShop.Model.SystemInfo.TerraceManage model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters;
            strSql.Append("Update [yxs_paymentmanage] set  ");
            if(model.Tmgarden==1 || model.Tmgarden==3)
            {
                strSql.Append("[payment_seller] =@TM_Seller,[payment_key] =@TM_key ,[payment_expenses] =@TM_Expenses ,[payment_setup]=@TM_Sz ,[payment_name] =@TM_name ,[payment_garden] =@TM_Payment ,[payment_putoutid] =@TM_PutoutID,[payment_putouttypeid] =@TM_PutoutTypeID,[payment_taxis] =@TM_taxis,[payment_account]=@TM_Account,[payment_description]=@payment_desc ");
                parameters = (SqlParameter[])this.ValueParams13(model);
            }
            else if (model.Tmgarden == 2)
            {
                strSql.Append("[payment_seller] =@TM_Seller,[payment_key] =@TM_key ,[payment_expenses] =@TM_Expenses ,[payment_setup]=@TM_Sz ,[payment_name] =@TM_name ,[payment_garden] =@TM_Payment ,[payment_putoutid] =@TM_PutoutID,[payment_putouttypeid] =@TM_PutoutTypeID,[payment_taxis] =@TM_taxis,[payment_account]=@TM_Account,[payment_description]=@payment_desc,[porttype]=@porttype ");
                parameters = (SqlParameter[])this.ValueParams(model);
            }
            else
            {
                strSql.Append("[payment_expenses] =@TM_Expenses ,[payment_name] =@TM_name ,[payment_garden] =@TM_Payment ,[payment_putoutid] =@TM_PutoutID,[payment_putouttypeid] =@TM_PutoutTypeID,[payment_description]=@payment_desc ");
                parameters = (SqlParameter[])this.ValueParams45(model);
            }
                strSql.Append(" Where [payment_id] = @TM_ID");
            
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From [yxs_paymentmanage] ");
            strSql.Append("Where [payment_id] = @TM_ID");
            SqlParameter[] parameters ={
                                        new SqlParameter("@TM_ID",SqlDbType.Int,4)
                                    };
            parameters[0].Value = id;
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString(),parameters);

        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAll(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From [yxs_paymentmanage] Where [payment_id] in(");
            strSql.Append(id + " )");
            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(strSql.ToString());
        }
       #endregion

      #region "Data Load"
        /// <summary>
        /// 根据ID得实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShowShop.Model.SystemInfo.TerraceManage GetModelById(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select top 1 [payment_id], [payment_seller], [payment_key], [payment_expenses],[payment_setup],[payment_name],[payment_garden],[payment_putoutid],[payment_putouttypeid],[payment_taxis],[payment_account],[payment_description],[porttype] From [yxs_paymentmanage] ");
            strSql.Append("Where [payment_id]=@TM_ID");
            SqlParameter[] parameters={
                                         new SqlParameter("@TM_ID",SqlDbType.Int,4) 
                                    };
            parameters[0].Value = id;
            ShowShop.Model.SystemInfo.TerraceManage terrace = null;
            using(SqlDataReader reader=ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(),parameters)){
                while(reader.Read()){
                    terrace = new ShowShop.Model.SystemInfo.TerraceManage();
                    terrace.Tmid = reader["payment_id"] != DBNull.Value ? (int)reader["payment_id"] : 0;
                    terrace.Tmseller = reader["payment_seller"] != DBNull.Value? (string)reader["payment_seller"] : "无";
                    terrace.Tmkey = reader["payment_key"] != DBNull.Value ? (string)reader["payment_key"] : "无";
                    terrace.Tmexpenses = reader["payment_expenses"] != DBNull.Value ? Convert.ToDecimal(reader["payment_expenses"]) : 0;
                    terrace.Tmsetup = reader["payment_setup"] != DBNull.Value ? Convert.ToInt32(reader["payment_setup"]) : 0;
                    terrace.Tmname = reader["payment_name"] != DBNull.Value ? (string)reader["payment_name"] : "无";
                    terrace.Tmgarden = reader["payment_garden"] != DBNull.Value ? (int)reader["payment_garden"] : 0;
                    terrace.Tmputoutid = reader["payment_putoutid"] != DBNull.Value ? (int)reader["payment_putoutid"] : 0;
                    terrace.Tmputouttypeid = reader["payment_putouttypeid"] != DBNull.Value ? (int)reader["payment_putouttypeid"] : 0;
                    terrace.Tmtaxis = reader["payment_taxis"] != DBNull.Value ? (int)reader["payment_taxis"] : 0;
                    terrace.Tmaccount = reader["payment_account"] != DBNull.Value ? (string)reader["payment_account"] : "无";
                    terrace.Payment_description = reader["payment_description"] != DBNull.Value ? (string)reader["payment_description"] : "暂无描述";
                    terrace.Porttype = reader["porttype"] != DBNull.Value ? (string)reader["porttype"] : "无";
                }
            }
            return terrace;
        }
        public ShowShop.Model.SystemInfo.TerraceManage GetModelByName(string  name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select top 1 [payment_id], [payment_seller], [payment_key], [payment_expenses],[payment_setup],[payment_name],[payment_garden],[payment_putoutid],[payment_putouttypeid],[payment_taxis],[payment_account] From [yxs_paymentmanage] ");
            strSql.Append("Where [payment_name]=@name");
            SqlParameter[] parameters ={
                                         new SqlParameter("@name",SqlDbType.VarChar,50) 
                                    };
            parameters[0].Value = name;
            ShowShop.Model.SystemInfo.TerraceManage terrace = null;
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), parameters))
            {
                while (reader.Read())
                {
                    terrace = new ShowShop.Model.SystemInfo.TerraceManage();
                    terrace.Tmid = (int)reader["payment_id"];
                    terrace.Tmseller = (string)reader["payment_seller"];
                    terrace.Tmkey = (string)reader["payment_key"];
                    terrace.Tmexpenses = Convert.ToDecimal(reader["payment_expenses"]);
                    terrace.Tmsetup = Convert.ToInt32(reader["payment_setup"]);
                    terrace.Tmname = (string)reader["payment_name"];
                    terrace.Tmgarden = (int)reader["payment_garden"];
                    terrace.Tmputoutid = (int)reader["payment_putoutid"];
                    terrace.Tmputouttypeid = (int)reader["payment_putouttypeid"];
                    terrace.Tmtaxis = (int)reader["payment_taxis"];
                    terrace.Tmaccount = (string)reader["payment_account"];
                }
            }
            return terrace;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public ChangeHope.DataBase.DataByPage GetAllList()
        {
            string sql = "[select] * [from] yxs_paymentmanage [where] 1=1 [order by] payment_taxis asc";
            ChangeHope.DataBase.DataByPage datapage = new ChangeHope.DataBase.DataByPage();
            datapage.Sql = sql;
            datapage.GetRecordSetByPage();
            return datapage;
        }
        /// <summary>
        /// 排序所有记录
        /// </summary>
        /// <remarks></remarks>
        public ChangeHope.DataBase.DataByPage GetList(string orderfield, int pagesize, string Conditions)
        {
            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            dataPage.Sql = "[select] * [from] yxs_paymentmanage [where] 1=1 " + Conditions + " " + orderfield;
            dataPage.PageSize = pagesize;
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        #endregion

      #region "Other function"

        public IDataParameter[] ValueParams(ShowShop.Model.SystemInfo.TerraceManage model)
        {
             SqlParameter[] parameters =new SqlParameter[13];
             parameters[0] = new SqlParameter("@TM_ID", SqlDbType.Int, 4);
             parameters[1] = new SqlParameter("@TM_Seller", SqlDbType.VarChar, 50);
             parameters[2] = new SqlParameter("@TM_key", SqlDbType.VarChar, 50);
             parameters[3] = new SqlParameter("@TM_Expenses", SqlDbType.Float, 8);
             parameters[4] = new SqlParameter("@TM_Sz", SqlDbType.Int, 4);
             parameters[5] = new SqlParameter("@TM_name", SqlDbType.VarChar, 50);
             parameters[6] = new SqlParameter("@TM_Payment", SqlDbType.Int, 4);
             parameters[7] = new SqlParameter("@TM_PutoutID", SqlDbType.Int, 4);
             parameters[8] = new SqlParameter("@TM_PutoutTypeID", SqlDbType.Int, 4);
             parameters[9] = new SqlParameter("@TM_taxis", SqlDbType.Int, 4);
             parameters[10] = new SqlParameter("@TM_Account", SqlDbType.VarChar, 100);
             parameters[11] = new SqlParameter("@payment_desc", SqlDbType.VarChar, 1000);
             parameters[12] = new SqlParameter("@porttype", SqlDbType.VarChar, 200);
             parameters[0].Value = model.Tmid;
             parameters[1].Value = model.Tmseller;
             parameters[2].Value = model.Tmkey;
             parameters[3].Value = model.Tmexpenses;
             parameters[4].Value = model.Tmsetup;
             parameters[5].Value = model.Tmname;
             parameters[6].Value = model.Tmgarden;
             parameters[7].Value = model.Tmputoutid;
             parameters[8].Value = model.Tmputouttypeid;
             parameters[9].Value = model.Tmtaxis;
             parameters[10].Value = model.Tmaccount;
             parameters[11].Value = model.Payment_description;
             parameters[12].Value = model.Porttype;
             return parameters;
        }

        public IDataParameter[] ValueParams13(ShowShop.Model.SystemInfo.TerraceManage model)
        {
            SqlParameter[] parameters = new SqlParameter[12];
            parameters[0] = new SqlParameter("@TM_ID", SqlDbType.Int, 4);
            parameters[1] = new SqlParameter("@TM_Seller", SqlDbType.VarChar, 50);
            parameters[2] = new SqlParameter("@TM_key", SqlDbType.VarChar, 50);
            parameters[3] = new SqlParameter("@TM_Expenses", SqlDbType.Float, 8);
            parameters[4] = new SqlParameter("@TM_Sz", SqlDbType.Int, 4);
            parameters[5] = new SqlParameter("@TM_name", SqlDbType.VarChar, 50);
            parameters[6] = new SqlParameter("@TM_Payment", SqlDbType.Int, 4);
            parameters[7] = new SqlParameter("@TM_PutoutID", SqlDbType.Int, 4);
            parameters[8] = new SqlParameter("@TM_PutoutTypeID", SqlDbType.Int, 4);
            parameters[9] = new SqlParameter("@TM_taxis", SqlDbType.Int, 4);
            parameters[10] = new SqlParameter("@TM_Account", SqlDbType.VarChar, 100);
            parameters[11] = new SqlParameter("@payment_desc", SqlDbType.VarChar, 1000);
            parameters[0].Value = model.Tmid;
            parameters[1].Value = model.Tmseller;
            parameters[2].Value = model.Tmkey;
            parameters[3].Value = model.Tmexpenses;
            parameters[4].Value = model.Tmsetup;
            parameters[5].Value = model.Tmname;
            parameters[6].Value = model.Tmgarden;
            parameters[7].Value = model.Tmputoutid;
            parameters[8].Value = model.Tmputouttypeid;
            parameters[9].Value = model.Tmtaxis;
            parameters[10].Value = model.Tmaccount;
            parameters[11].Value = model.Payment_description;
            return parameters;
        }

        public IDataParameter[] ValueParams45(ShowShop.Model.SystemInfo.TerraceManage model)
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@TM_ID", SqlDbType.Int, 4);
            parameters[1] = new SqlParameter("@TM_Expenses", SqlDbType.Float, 8);
            parameters[2] = new SqlParameter("@TM_name", SqlDbType.VarChar, 50);
            parameters[3] = new SqlParameter("@TM_Payment", SqlDbType.Int, 4);
            parameters[4] = new SqlParameter("@TM_PutoutID", SqlDbType.Int, 4);
            parameters[5] = new SqlParameter("@TM_PutoutTypeID", SqlDbType.Int, 4);
            parameters[6] = new SqlParameter("@payment_desc", SqlDbType.VarChar, 1000);
            parameters[0].Value = model.Tmid;
            parameters[1].Value = model.Tmexpenses;
            parameters[2].Value = model.Tmname;
            parameters[3].Value = model.Tmgarden;
            parameters[4].Value = model.Tmputoutid;
            parameters[5].Value = model.Tmputouttypeid;
            parameters[6].Value = model.Payment_description;
            return parameters;
        }
      #endregion
    }
}
