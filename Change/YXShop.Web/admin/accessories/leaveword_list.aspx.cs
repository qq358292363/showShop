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
    public partial class leaveword_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012003001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
                {
                    string types = Request.Form["Option"].Trim();
                    string StrID = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("012003003") != "ok")
                        {
                            Del(StrID);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    else if (types == "exam")
                    {
                        
                        //是否审核
                        if (ShowShop.Common.PromptInfo.Message("012003007") != "ok")
                        {
                        int Num = ChangeHope.WebPage.PageRequest.GetFormInt("examid");
                        SetAudit(Convert.ToInt32(StrID),Num);
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
            ShowShop.BLL.Accessories.Leaveword bll = new ShowShop.BLL.Accessories.Leaveword();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            //第一步先添加表头
            table.AddHeadCol("", "<input type=\"checkbox\" id=\"chkAll\" onclick=\"CheckAll(this.form)\" alt=\"全选/取消\" />选择");
            table.AddHeadCol("", "留言类别");
            table.AddHeadCol("", "联系方式");
            table.AddHeadCol("", "留言内容");
            table.AddHeadCol("", "留言时间");
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

                    table.AddCol(GetLeavType(dataPage.DataReader["type"].ToString()));

                    table.AddCol("<textarea rows=\"6\" cols=\"8\" style=\"width:200px;\">" +
                        ContactInfo(dataPage.DataReader["username"].ToString(),
                        dataPage.DataReader["telephone"].ToString(), dataPage.DataReader["qq"].ToString(),
                        dataPage.DataReader["email"].ToString(), dataPage.DataReader["msn"].ToString()) + "</textarea>");
                    table.AddCol("<textarea rows=\"6\" cols=\"8\"  style=\"width:160px;\">" + GetContent(dataPage.DataReader["title"].ToString(), dataPage.DataReader["content"].ToString()) + "</textarea>");
                    table.AddCol(dataPage.DataReader["adddate"].ToString());
                    table.AddCol(GetExamBtn(dataPage.DataReader["id"].ToString(), dataPage.DataReader["isauditing"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }
        #region 对数据进行判断
        protected string ContactInfo(string username, string telphone, string qq, string email, string msn)
        {
            string info = string.Empty;
            info += "留言人：" + username + "\n";
            info += "电话：" + telphone + "\n";
            info += "QQ：" + qq + "\n";
            info += "MSN：" + msn + "\n";
            info += "Email：" + email;
            return info;
        }

        protected string GetContent(string title, string content)
        {
            string info = string.Empty;
            info += "主题：" + title + "\n";
            info += "内容：" + content;
            return info;
        }

        protected string GetExamBtn(string id,string isaudit)
        {
            if (isaudit == "0")
            {
                return string.Format("<a href='leaveword_reply.aspx?id={0}' title=\"回复留言\">回复</a>&nbsp;<a href='javascript:void(0)' onclick='Del({0})'>删除</a>&nbsp;<a href='javascript:void(0)' onclick='SetAudit({0},1)'><font color=\"red\">未审核</font></a>", id);
            }
            else
            {
                return string.Format("<a href='leaveword_reply.aspx?id={0}' title=\"回复留言\">回复</a>&nbsp;<a href='javascript:void(0)' onclick='Del({0})'>删除</a>&nbsp;<a href='javascript:void(0)' onclick='SetAudit({0},0)'><font color=\"green\">已审核</font></a>", id);
            }
        }

        protected string GetLeavType(string type)
        {
            string leavType = string.Empty;
            switch (type)
            {
                case "1":
                    leavType = "普通反馈";
                    break;
                case "2":
                    leavType = "购物投诉";
                    break;
                case "3":
                    leavType = "询问求购";
                    break;
                case "4":
                    leavType = "售后咨询";
                    break;
                case "5":
                    leavType = "加盟合作";
                    break;
                default:
                    break;
            }
            return leavType;
        }
        #endregion
        private void SetAudit(int id, int isaudit)
        {
            
                ShowShop.BLL.Accessories.Leaveword bll = new ShowShop.BLL.Accessories.Leaveword();
                bll.Amend(id, "isauditing", isaudit);
                Response.Write("ok");
           
        }

        private void Del(string id)
        {
            
            ShowShop.BLL.Accessories.Leaveword bll = new ShowShop.BLL.Accessories.Leaveword();
            bll.Delete(id);
            Response.Write("ok");
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
