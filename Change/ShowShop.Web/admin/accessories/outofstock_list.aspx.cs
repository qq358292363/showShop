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
    public partial class outofstock_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012008001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
                {
                   
                    string types = Request.Form["Option"].Trim();
                    string StrID = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("012008003")!="ok")
                        {
                            Del(StrID);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
                }
                this.lblList.Text = GetList();
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Accessories.Outofstock bll = new ShowShop.BLL.Accessories.Outofstock();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            //第一步先添加表头
            table.AddHeadCol("", "<input type=\"checkbox\" id=\"chkAll\" onclick=\"CheckAll(this.form)\" alt=\"全选/取消\" />选择");
            table.AddHeadCol("", "缺货信息");
            table.AddHeadCol("", "联系信息");
            table.AddHeadCol("", "备注信息");
            table.AddHeadCol("", "联系人");
            table.AddHeadCol("", "操作");
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

                    table.AddCol("<input ID=\"cBox\" type=\"checkbox\" value=\"" + dataPage.DataReader["id"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["proclassandname"].ToString());
                    table.AddCol("<textarea rows=\"6\" cols=\"8\" style=\"width:200px;\">" +
                        ContactInfo(dataPage.DataReader["telphone"].ToString(),
                        dataPage.DataReader["mobile"].ToString(), dataPage.DataReader["qq"].ToString(),
                        dataPage.DataReader["email"].ToString(), dataPage.DataReader["msn"].ToString()) + "</textarea>");
                    table.AddCol(string.Format("<textarea rows=\"6\" cols=\"8\"  style=\"width:120px;\">{0}</textarea>", dataPage.DataReader["content"].ToString()));
                    table.AddCol(dataPage.DataReader["username"].ToString());
                    table.AddCol(string.Format("<a href='javascript:void(0)' onclick='Del({0})'>删除</a>", dataPage.DataReader["id"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }

        protected string ContactInfo(string telphone, string mobile, string qq, string email, string msn)
        {
            string info = string.Empty;
            info += "固定电话：" + telphone + "\n";
            info += "移动电话：" + mobile + "\n";
            info += "电子邮件：" + email + "\n";
            info += "MSN：" + msn + "\n";
            info += "QQ：" + qq;
            return info;
        }

        private void Del(string id)
        {
            ShowShop.BLL.Accessories.Outofstock bll = new ShowShop.BLL.Accessories.Outofstock();
            bll.Delete(id);
            Response.Write("ok");
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        protected string ProductClassName(string strId)
        {
            string reStr = string.Empty;
            string str = "暂无归类";
            if (!string.IsNullOrEmpty(strId))
            {
                ShowShop.BLL.Product.Productclass dll = new ShowShop.BLL.Product.Productclass();
                DataTable dt = dll.GetMoreThanClassName(strId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(reStr))
                    {
                        reStr = reStr + "," + dt.Rows[i]["name"].ToString();
                    }
                    else
                    {
                        reStr = dt.Rows[i]["name"].ToString();
                    }
                }
                if (!string.IsNullOrEmpty(reStr))
                {
                    str = reStr;
                }
            }
            return str;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
