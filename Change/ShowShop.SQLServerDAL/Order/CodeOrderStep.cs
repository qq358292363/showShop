using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ShowShop.IDAL.Order;
using ChangeHope.DataBase;

namespace ShowShop.SQLServerDAL.Order
{
    public class CodeOrderStep:ICodeOrderStep
    {
        #region Data Load
        public ShowShop.Model.Order.CodeOrderStep GetModel(string codeId)
        {
            ShowShop.Model.Order.CodeOrderStep model = new ShowShop.Model.Order.CodeOrderStep();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 code,content from yxs_code_order_step ");
            strSql.Append(" where code=@code");
            SqlParameter param = new SqlParameter("@code", SqlDbType.VarChar, 50);
            param.Value = codeId;
            using (SqlDataReader reader = ChangeHope.DataBase.SQLServerHelper.ExecuteReader(strSql.ToString(), param))
            {
                if (reader.Read())
                {
                    model.Code = reader.GetString(0);
                    model.Content = reader.GetString(1);
                }
            }
            return model;
        }

        #endregion
    }
}
