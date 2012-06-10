using System;
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

namespace ShowShop.Web.admin.systeminfo
{
    public partial class area_list : System.Web.UI.Page
    {
        int idform = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("004001001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
                {
                    string types = Request.Form["Option"].Trim();
                    //从表单获取配送区域ID
                    int id = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                    //从url获取配送方式ID
                    idform = ChangeHope.WebPage.PageRequest.GetQueryInt("delivermode");

                    this.HyperLink1.NavigateUrl = "deliver_edit.aspx?delivermode=" + idform.ToString();
                    if (types == "del")
                    {
                        if (ShowShop.Common.PromptInfo.Message("004001003") != "ok")
                        {
                            Del(id);
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



        ///// <summary>
        ///// 列表
        ///// </summary>
        ///// <returns></returns>
        protected string GetList()
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.SystemInfo.PostArea bll = new ShowShop.BLL.SystemInfo.PostArea();

            ChangeHope.DataBase.DataByPage dataPage=null;

            //从url获取配送方式ID
            idform = ChangeHope.WebPage.PageRequest.GetQueryInt("delivermode");
            this.HyperLink1.NavigateUrl = "deliver_edit.aspx?delivermode=" + idform.ToString();
            if (idform != 0 && idform != -1)
            {                
                dataPage = bll.GetAreasByPostMethod(this.idform);

            }
            else
            {
                dataPage = bll.GetAreasByPostMethod(this.idform);
            }
            
            
           

            
            //第一步先添加表头
            table.AddHeadCol("5%", "序号");
            table.AddHeadCol("20%", "配送区域名称");
            table.AddHeadCol("18%", "配送方式");
            table.AddHeadCol("", "配送区域");
            table.AddHeadCol("", "发布人");
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
                    table.AddCol(dataPage.DataReader["AreaName"].ToString());
                    //根据ＩＤ查询配送方式名称
                    ShowShop.BLL.SystemInfo.Deliver deliverbll = new ShowShop.BLL.SystemInfo.Deliver();
                    ShowShop.Model.SystemInfo.Deliver modeldeli = deliverbll.GetModelByID(int.Parse(dataPage.DataReader["DeliveryMode"].ToString()));
                    table.AddCol(modeldeli.Distributionname);
                    //根据ID查询城市名称
                    ShowShop.BLL.SystemInfo.Provinces areaid = new ShowShop.BLL.SystemInfo.Provinces();
                    ShowShop.Model.SystemInfo.Provinces modelpro;
                    string citys = "";
                    string[] arr = dataPage.DataReader["AreaId"].ToString().Split(',');
                    foreach(string i in arr)
                    {
                        modelpro=areaid.GetModel(int.Parse(i));
                        citys += modelpro.CityName + "&nbsp;&nbsp;";
                    }
                    table.AddCol(citys);
                    string userName = "";
                    if (dataPage.DataReader["putouttyid"].ToString() == "0")
                    {
                        userName = "管理员";
                    }
                    else
                    {
                        if (dataPage.DataReader["putoutid"].ToString() != "")
                        {
                            ShowShop.BLL.Member.MemberAccount memberbll = new ShowShop.BLL.Member.MemberAccount();
                            ShowShop.Model.Member.MemberAccount member = memberbll.GetModel(Convert.ToInt32(dataPage.DataReader["putoutid"].ToString()));
                            if (member != null)
                            {
                                userName = "(会员)" + member.UserId.ToString();
                            }
                        }
                    }
                    table.AddCol(userName);
                    table.AddCol(string.Format("<a href=deliver_edit.aspx?delivermode={0}&areaid={1}>编辑</a> <a href='javascript:void(0)' onclick='Del({1})'>删除</a>", dataPage.DataReader["DeliveryMode"].ToString(), dataPage.DataReader["Id"].ToString()));
                    table.AddRow();
                }

            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            return view;
        }

         //<summary>
         //删除
         //</summary>
         //<param name="id"></param>
        private void Del(int id)
        {
            ShowShop.BLL.SystemInfo.PostArea bll = new ShowShop.BLL.SystemInfo.PostArea();
            bll.Delete(id);
            Response.Write("ok");
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            this.lblList.Text = GetList();
        }
    }
}
