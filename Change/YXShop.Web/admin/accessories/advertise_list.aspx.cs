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
    public partial class advertise_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012001001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    string types = Request.Form["Option"].Trim();
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("012001003") != "ok")
                        {
                            Del(id);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    else if (types == "power")
                    {
                        
                        //权重
                        if (ShowShop.Common.PromptInfo.Message("012001004") != "ok")
                        {
                        int Num = ChangeHope.WebPage.PageRequest.GetFormInt("powerID");
                        PowerBy(id, Num);
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
        /// 广告列表
        /// </summary>
        /// <returns></returns>
        protected string GetList()
        {
            
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            //第一步先添加表头
            table.AddHeadCol("", "序号");
            table.AddHeadCol("", "广告名称");
            table.AddHeadCol("", "权重");
            table.AddHeadCol("", "点击数");
            table.AddHeadCol("", "浏览数");
            table.AddHeadCol("", "结束日期");
            table.AddHeadCol("", "审核");
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
                    table.AddCol(No);
                    table.AddCol(string.Format("<a href='?Ads_ID={0}'>{1}</a>", dataPage.DataReader["id"].ToString(), dataPage.DataReader["name"].ToString()));
                    table.AddCol(string.Format("<input id='power{0}' value='{1}' size='3' onblur='PowerBy({0})'/>", dataPage.DataReader["id"].ToString(), dataPage.DataReader["power"].ToString()));
                    table.AddCol(dataPage.DataReader["clickcount"].ToString());
                    table.AddCol(dataPage.DataReader["browsecount"].ToString());
                    table.AddCol(Convert.ToDateTime(dataPage.DataReader["overduetime"]).ToShortDateString());
                    table.AddCol(string.Format("<img src='../images/{0}.gif' alt='审核与否'/>", dataPage.DataReader["examine"].ToString()));
                    table.AddCol(string.Format("<a href=advertise_info_edit.aspx?Ads_ID={0}&type={1}>编辑</a> <a href='javascript:void(0)' onclick='Del({0})'>删除</a> <a href=advertise_createjs.aspx?Ads_ID={0}>生成JS广告</a>", dataPage.DataReader["id"].ToString(), dataPage.DataReader["adtype"].ToString()));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void Del(int id)
        {

                ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
                bll.Delete(id);
         
        }

        /// <summary>
        /// 修改权重
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        private void PowerBy(int id, int power)
        {
                ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
                bll.Amend(id, "power", power);
                Response.Write("ok");
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
        
    }
}
