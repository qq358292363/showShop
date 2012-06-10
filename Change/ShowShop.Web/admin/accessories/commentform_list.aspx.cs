using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ShowShop.Web.admin.accessories
{
    public partial class commentform_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012005001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                   
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        if(ShowShop.Common.PromptInfo.Message("012005003")!="ok")
                        {
                         del(id);
                        }
                        else
                        {
                         Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
                }
                this.Literal1.Text = GetList();
            }
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Accessories.CommentForm data = new ShowShop.BLL.Accessories.CommentForm();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList();
            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("15%", "属性名称");
            table.AddHeadCol("25%", "所属值");
            table.AddHeadCol("10%", "所属类型");
            table.AddHeadCol("10%", "是否必填");
            table.AddHeadCol("10%", "操作");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                int curpage = ChangeHope.WebPage.PageRequest.GetInt("pageindex");
                if (curpage < 0)
                {
                    curpage = 1;
                }
                int count = 0;
                while (dataPage.DataReader.Read())
                {
                    count++;
                    string No = (15 * (curpage - 1) + count).ToString();
                    table.AddCol(No);
                    table.AddCol(dataPage.DataReader["filed"].ToString());
                    table.AddCol(dataPage.DataReader["datavalue"].ToString().Replace("\n",","));
                    table.AddCol(Type(dataPage.DataReader["type"].ToString()));
                    table.AddCol(string.Format("<img src='../images/{0}.gif'/>", dataPage.DataReader["isrequire"].ToString()));
                    table.AddCol(string.Format("<a href=commentform_edit.aspx?id={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));

                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        protected string Type(string value)
        {
            string reStr = string.Empty;
            switch (value)
            {
                case "1":
                    reStr = "下拉列表";
                    break;
                case "2":
                    reStr = "单选";
                    break;
                case "3":
                    reStr = "多选";
                    break;
                case "4":
                    reStr = "单行文本";
                    break;
                case "5":
                    reStr = "多行文本";
                    break;
            }
            return reStr;
        }
        private void del(int id)
        {
            
                ShowShop.BLL.Accessories.CommentForm bll = new ShowShop.BLL.Accessories.CommentForm();
                bll.Delete(id);
                Response.Write("ok");
        }
    }
}
