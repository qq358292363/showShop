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
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using ShowShop.BLL.Admin;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class paymentmanage_list : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount memberBll = new ShowShop.BLL.Member.MemberAccount();
        ShowShop.BLL.SystemInfo.TerraceManage terraceBll=new ShowShop.BLL.SystemInfo.TerraceManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                ShowShop.Common.PromptInfo.Popedom("010002001");
                InitWebControl();
               if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id")!="")                 
                {
                    
                    string types = Request["Option"].Trim();
                    string id = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("010002003") != "ok")
                        {
                            terraceBll.Delete(Convert.ToInt32(id));
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    if (types == "delAll")
                    {
                        if (ShowShop.Common.PromptInfo.Message("010002003") != "ok")
                        {
                       terraceBll.DeleteAll(id);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
               }
               // BindType();
                this.litPay.Text = GetList();
                this.Link.NavigateUrl = "paymentmanage_edit.aspx?paytype=0";
            }
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table= new ChangeHope.WebPage.Table();
            ShowShop.BLL.SystemInfo.TerraceManage tmDate = new ShowShop.BLL.SystemInfo.TerraceManage();
            ChangeHope.DataBase.DataByPage datePage = tmDate.GetAllList();
            //添加头
            table.AddHeadCol("8%", "<input id=\"chall\" type=\"checkbox\" onclick=\"SelectAll(chall)\" />全选");
            table.AddHeadCol("6%", "排序");
            table.AddHeadCol("15%", "平台名称");
            table.AddHeadCol("10%", "支付平台");
            table.AddHeadCol("8%", "发布类型");
            table.AddHeadCol("7%", "发布人");
            table.AddHeadCol("", "商户ID");
            table.AddHeadCol("8%", "手续费率");
            table.AddHeadCol("16%", "常规操作");
            table.AddRow();
            //添加内容
            if(datePage.DataReader != null){
                int curpage = ChangeHope.WebPage.PageRequest.GetInt("pageindex");
                if (curpage < 0)
                {
                    curpage = 1;
                }
                int count = 0;
                while(datePage.DataReader.Read()){
                    count++;
                    string No = (15 * (curpage - 1) + count).ToString();
                    table.AddCol("<input id=\"cbTm\"  type=\"checkbox\" value=" + datePage.DataReader["payment_id"] + " />");
                   // table.AddCol(datePage.DataReader["payment_taxis"].ToString());
                    table.AddCol(No);
                    table.AddCol(datePage.DataReader["payment_name"].ToString());
                    table.AddCol(PaymentByID(Convert.ToInt32(datePage.DataReader["payment_garden"])));
                    table.AddCol(datePage.DataReader["payment_putouttypeid"].ToString()=="0"?"管理员":"会员");
                    //这里需要会员信息
                    table.AddCol(IsInsiderOrAdmin(Convert.ToInt32(datePage.DataReader["payment_putoutid"]),datePage.DataReader["payment_putouttypeid"].ToString()=="0"?true:false));
                    table.AddCol(datePage.DataReader["payment_seller"].ToString());
                    table.AddCol(datePage.DataReader["payment_expenses"].ToString()+"");
                    table.AddCol("<a href='paymentmanage_edit.aspx?Payment_ID=" + datePage.DataReader["payment_id"] + "'>编辑</a>  <a href=\"#\" onclick='Del(" + datePage.DataReader["payment_id"] + ")'> 删除</a>&nbsp;" + PaymentById(Convert.ToInt32(datePage.DataReader["payment_garden"])));
                    table.AddRow();
                }
            }
            string view = table.GetTable() + datePage.PageToolBar;
            datePage.Dispose();
            datePage = null;
            return view;
        }

        #region 管理员还是会员
        //判断是管理员还是会员
        public string IsInsiderOrAdmin(int id,bool flag)
        {
            string reStr = string.Empty;
            if (flag)
            {
                ShowShop.BLL.Admin.Administrators adminBll = new Administrators();
                ShowShop.Model.Admin.Administrators adminInfo = adminBll.GetModel(id);
                if (adminInfo != null)
                {
                    reStr=adminInfo.Name.ToString();
                }
            }
            else
            {
                ShowShop.Model.Member.MemberAccount member = memberBll.GetModel(id);
                if (member != null)
                {
                    reStr= member.UserId.ToString();
                }
            }
            return reStr;
        }
        #endregion

        #region 支付平台申请
        private string PaymentById(int id)
        {
            //1,支付宝；2，财付通，3网银，4线下支付
            string str = "";
            switch (id)
            {
                case 1:
                    str = "<a href='../include/paymentapplication/tenpay.aspx'>申请商户</a>";
                    break;
                case 2:
                    str = "";
                    break;              
                case 3:
                    str = "";
                    break;
                case 4:
                    str = "";
                    break;
                default:
                    break;
            }
            return str;
        }
        #endregion

        #region 查询支付平台
        protected string PaymentByID(int PayId)
        {
            string str = "";
            switch (PayId)
            {
                case 2:
                    str = "支付宝";
                    break;
                case 1:
                    str = "财付通";
                    break;
                case 3:
                    str = "网银";
                    break;
                case 4:
                    str = "线下付款";
                    break;
                default:
                    str = "余额支付";
                    break;

            }
            return str.ToString();
        }
        #endregion

        #region  绑定类型
        public void BindType()
        {  
           ShowShop.BLL.Member.MemberRank rankBll=new ShowShop.BLL.Member.MemberRank();
           List<ShowShop.Model.Member.MemberRank> ranks = rankBll.GetAllMemberRank();
           if(ranks!=null&&ranks.Count>0)
           {
               this.w_l_payment_putouttypeid.DataSource = ranks;
               this.w_l_payment_putouttypeid.DataTextField = "Name";
               this.w_l_payment_putouttypeid.DataValueField = "Id";
               this.w_l_payment_putouttypeid.DataBind();
               this.w_l_payment_putouttypeid.Items.Insert(0, new ListItem("选择", ""));
           }
        }
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.SetDropDownList(this.w_l_payment_putouttypeid, "Id", "Name", "yxs_memberrank",true);
            this.w_l_payment_putouttypeid.Items.Add(new ListItem("管理员","0"));
        }
        #endregion
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            this.litPay.Text = GetList();
        }
       
    }
}
