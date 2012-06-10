namespace ChangeHope.WebPage
{
    using ChangeHope.DataBase;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI.WebControls;

    public class WebControl
    {
        public static void SetDate(TextBox textBox)
        {
            textBox.Attributes.Add("readonly", "readonly");
            textBox.Attributes.Add("onclick", "GetDateCalendar(this);");
        }

        public static void SetDropDownList(DropDownList ddl, string value, string text, string table)
        {
            SetDropDownList(ddl, value, text, table, false);
        }

        public static void SetDropDownList(DropDownList ddl, string value, string text, string table, bool isnull)
        {
            ddl.Items.Clear();
            if (isnull)
            {
                ddl.Items.Add(new ListItem("不限", ""));
            }
            SqlDataReader reader = SQLServerHelper.ExecuteReader("select " + value + "," + text + " from " + table);
            while (reader.Read())
            {
                ddl.Items.Add(new ListItem(reader[1].ToString(), reader[0].ToString()));
            }
            reader.Close();
            reader.Dispose();
            reader = null;
        }

        public static void Validate(TextBox textBox, string tip, string validatetype, string warning, string error)
        {
            textBox.Attributes.Add("tip", tip);
            textBox.Attributes.Add("validatetype", validatetype);
            textBox.Attributes.Add("warning", warning);
            textBox.Attributes.Add("error", error);
        }
    }
}

