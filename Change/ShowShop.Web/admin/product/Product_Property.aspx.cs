using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ShowShop.Web.admin.product
{
    public partial class Product_Property : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request["del"];
            if (!string.IsNullOrWhiteSpace(id))
            {
                Del(id);
            }

            if (!IsPostBack)
            {
                var name = Request["name"];
                GetList(name);
            }
        }
        public void Del(string id)
        {
            var name = Pname.Text;
            var sql = @"delete Property where PropertyID = @pid
                         and not exists
                         (
	                        select * from PropertyValue where PropertyID = @pid
                         )";

           var res = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sql, new System.Data.SqlClient.SqlParameter("@pid", id));

            GetList("");

            if (res < 1)
            {
             Response.Write("<script>alert('请先删除该属性值')</script>");
            }
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected void GetList(string name)
        {
            var data = GetListByWhere(name, 0, 20);
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
           // ShowShop.BLL.Product.ProductInfo data = new ShowShop.BLL.Product.ProductInfo();
            ChangeHope.DataBase.DataByPage dataPage = data;
            //第一步先添加表头
            table.AddHeadCol("30%", "ID");
            table.AddHeadCol("30%", "属性名");
            table.AddHeadCol("40%", "编辑");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol("<span>" + dataPage.DataReader["PropertyID"] + "</span>");
                    table.AddCol("<span>" + dataPage.DataReader["PropertyName"] + "</span>");
                    table.AddCol(string.Format("<a onclick='return confirm(\"是否删除\");' href='Product_Property.aspx?del={0}'>删除</a> <a href=Product_PropertyValue.aspx?id={0}&name={1}>添加属性值</a>", dataPage.DataReader["PropertyID"].ToString(), dataPage.DataReader["PropertyName"]));


                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.Literal1.Text = view;
        }

        public ChangeHope.DataBase.DataByPage GetListByWhere(string name,int topNumber, int pagesize)
        {

            ChangeHope.DataBase.DataByPage dataPage = new ChangeHope.DataBase.DataByPage();
            if (!string.IsNullOrWhiteSpace(name))
                dataPage.Sql = "[select] * [from] Property [where] PropertyName like '%" + name + "%' [order by] PropertyID desc;";
            else
                dataPage.Sql = "[select] * [from] Property [where] 1=1 [order by] PropertyID desc;";



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

        protected void AddP_Click(object sender, EventArgs e)
        {
            var name = Pname.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                var sql = @"if not exists (select * from Property where PropertyName = @PName)
begin
insert into Property (PropertyName) values(@PName)
end;";

                var res = ChangeHope.DataBase.SQLServerHelper.ExecuteSql(sql, new System.Data.SqlClient.SqlParameter("@PName", name)); 
                if (res < 1)
                {
                    Response.Write( "<script>alert('不能添加重复值')</script>");
                }
            }
            GetList("");
            

        }

        protected void bt_Search_Click(object sender, EventArgs e)
        {
            GetList(txtName.Text.Trim());
        }

    
    }
}