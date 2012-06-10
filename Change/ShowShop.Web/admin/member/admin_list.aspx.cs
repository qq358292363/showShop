﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;


namespace ShowShop.Web.admin.member
{
    public partial class admin_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if(!this.Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("007001001");
                GetList();
            }
        }
        
        private void GetList()
        {
            ShowShop.BLL.Admin.Administrators bll = new ShowShop.BLL.Admin.Administrators();
            string action = ChangeHope.WebPage.PageRequest.GetQueryString("action");
            int adminid = ChangeHope.WebPage.PageRequest.GetInt("adminid");
            if (action.Equals("del") && adminid>0)
            {
                ShowShop.Common.PromptInfo.Popedom("007001003","对不起，您没有权限进行删除");
                bll.Delete(adminid);
                
            }
            this.ltlView.Text = bll.GetList();
            bll = null;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GetList();
        }
    }
}
