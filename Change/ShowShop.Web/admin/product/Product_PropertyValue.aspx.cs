using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShowShop.Web.admin.product
{
    public partial class Product_PropertyValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request["id"];
            var name = Request["name"];
            if (ViewState["id"] == null)
            {
                ViewState["id"] = id;
            }
            if (ViewState["name"] == null)
            {
                ViewState["name"] = name;
            }


            var del = Request["del"];
            if (!string.IsNullOrWhiteSpace(del))
            {
                Del(del);
            }

            

            if (!IsPostBack)
            {
                Getlist();
            }
        }
        public void Del(string id)
        {
            var name = Pname.Text;
            var sql = @"delete PropertyValue where PropertyValueID = @pid;";

            ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sql, new System.Data.SqlClient.SqlParameter("@pid", id));

            Getlist();
        }
        public ChangeHope.DataBase.DataByPage GetListByWhere(string id, int topNumber, int pagesize)
        {

            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            if (!string.IsNullOrWhiteSpace(id))
                dataPage.Sql = "[select] * [from] PropertyValue [where] PropertyID = " + id + " [order by] PropertyValueID desc;";
            if (topNumber > 0)
            {
                dataPage.PageSize = topNumber;
            }
            else
            {
                dataPage.PageSize = pagesize;
            }
            dataPage.GetRecordSetByPage();
            return dataPage;
        }
        private void Getlist()
        {
            var id = ViewState["id"].ToString();

            var data = GetListByWhere(id, 0, 20);
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            // ShowShop.BLL.Product.ProductInfo data = new ShowShop.BLL.Product.ProductInfo();
            ChangeHope.DataBase.DataByPage dataPage = data;
            //第一步先添加表头
            table.AddHeadCol("30%", "ID");
            table.AddHeadCol("30%", "属性值");
            table.AddHeadCol("40%", "编辑");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol("<span>" + dataPage.DataReader["PropertyValueID"] + "</span>");
                    table.AddCol("<span>" + dataPage.DataReader["PropertyValueName"] + "</span>");
                    table.AddCol("<a onclick='return confirm(\"是否删除\");' href='Product_PropertyValue.aspx?del=" + dataPage.DataReader["PropertyValueID"] + "&id=" + ViewState["id"] + "&name=" + ViewState["name"] + "'>删除</a>");


                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.Literal1.Text = view;

        }

        protected void AddP_Click(object sender, EventArgs e)
        {
            
            var name = Pname.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                var sql = @"insert into PropertyValue (PropertyValueName,PropertyID) values(@PName,@id);";

                ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sql,
                    new System.Data.SqlClient.SqlParameter("@PName", name),
                    new System.Data.SqlClient.SqlParameter("@id", ViewState["id"])
                    );
            }
            Getlist();
        }
    }
}