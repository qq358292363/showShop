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
using System.Text;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class deliver_edit : System.Web.UI.Page
    {
        ShowShop.BLL.SystemInfo.Provinces bll = new ShowShop.BLL.SystemInfo.Provinces();
        ShowShop.BLL.SystemInfo.PostArea bllarea = new ShowShop.BLL.SystemInfo.PostArea();
        ShowShop.BLL.SystemInfo.Deliver blldeliver = new ShowShop.BLL.SystemInfo.Deliver();
        int urlid = 0;
        int areaid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("010002002", "对不起，您没有权限进行编辑");
                ShowShop.Common.PromptInfo.Popedom("010002004", "对不起，您没有权限进行编辑");
                //从url获取配送方式ID
                urlid = ChangeHope.WebPage.PageRequest.GetQueryInt("delivermode");
                areaid = ChangeHope.WebPage.PageRequest.GetQueryInt("areaid");
                InitWebControl();
                if (urlid != 0 && urlid!=-1)
                {
                    this.HyperLink1.NavigateUrl = "area_list.aspx?delivermode="+urlid.ToString();
                    ShowShop.Model.SystemInfo.Deliver objdeliver = blldeliver.GetModelByID(urlid);
                    this.txtTitle.Text = objdeliver.Distributionname;
                    switch(urlid)
                   {
                       case 1:                           
                           this.tab0.Style.Add("display", "block");
                           break;
                       case 2:                           
                           this.tab1.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 3:
                           this.tab2.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 4:
                           this.tab3.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 5:
                           this.tab4.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 6:
                           this.tab5.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 7:
                           this.tab6.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 8:
                           this.tab7.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 9:
                           this.tab8.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 10:
                           this.tab9.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                       case 11:
                           this.tab10.Style.Add("display", "block");
                           this.tab0.Style.Add("display", "none");
                           break;
                   }

                    if (areaid != 0 && areaid != -1)
                    {
                        ShowShop.Model.SystemInfo.PostArea objarea = bllarea.GetModelByAreaID(areaid);
                        if (objarea != null)
                        {
                            ViewState["PutoutID"] = objarea.Putoutid;
                            ViewState["PutoutTypeID"] = objarea.Putouttyid;
                            ArrayList arrarea = new ArrayList();
                            string[] arrid = objarea.Areaid.Split(',');
                            for (int i = 0; i < arrid.Length; i++)
                            {
                                string txt = bll.GetModel(int.Parse(arrid[i])).CityName;
                                arrarea.Add(txt);
                            }
                            switch (urlid)
                            {
                                case 1:
                                    this.txtAreaName1.Text = objarea.Areaname;

                                    break;
                                case 2:
                                    this.txtAreaName2.Text = objarea.Areaname;
                                    this.txtBasicFees2.Text = objarea.Basicfees.ToString();
                                    this.txtCODPayFees2.Text = objarea.CODpayfees.ToString();
                                    this.txtFreeAmount2.Text = objarea.Freeamount.ToString();

                                    break;
                                case 3:
                                    this.txtAreaName3.Text = objarea.Areaname;
                                    int way = objarea.Feescalculationway;
                                    this.txtFreeAmount3.Text = objarea.Freeamount.ToString();
                                    if (way == 1)
                                    {
                                        this.rdtype1.Checked = true;
                                        this.txtBasicFrees3.Text = objarea.Basicfees.ToString();
                                        this.txtOverweight3.Text = objarea.Overweight.ToString();

                                        this.trBasicFrees3.Style.Add("display", "block");
                                        this.trOverweight3.Style.Add("display", "block");
                                        this.trSingle3.Style.Add("display", "none");
                                        this.txtSingle3.Attributes.Remove("tip");
                                        txtSingle3.Attributes.Remove("validatetype");
                                        txtSingle3.Attributes.Remove("warning");
                                        txtSingle3.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees3, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtOverweight3, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                                    }
                                    else
                                    {
                                        this.rdtype2.Checked = true;
                                        this.txtSingle3.Text = objarea.Initialfees.ToString();

                                        this.trBasicFrees3.Style.Add("display", "none");
                                        this.trOverweight3.Style.Add("display", "none");
                                        this.trSingle3.Style.Add("display", "block");
                                        this.txtBasicFrees3.Attributes.Remove("tip");
                                        txtBasicFrees3.Attributes.Remove("validatetype");
                                        txtBasicFrees3.Attributes.Remove("warning");
                                        txtBasicFrees3.Attributes.Remove("error");
                                        this.txtOverweight3.Attributes.Remove("tip");
                                        txtOverweight3.Attributes.Remove("validatetype");
                                        txtOverweight3.Attributes.Remove("warning");
                                        txtOverweight3.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtSingle3, "请输入单件商品价格", "isfloat", "必填", "该项必须为数字");
                                    }

                                    break;
                                case 4:
                                    this.txtAreaName4.Text = objarea.Areaname;
                                    this.txtBasicFrees4.Text = objarea.Basicfees.ToString();
                                    this.txtFreeAmount4.Text = objarea.Freeamount.ToString();
                                    this.txtCODPayFees4.Text = objarea.CODpayfees.ToString();

                                    break;
                                case 5:
                                    this.txtAreaName5.Text = objarea.Areaname;
                                    this.txtFreeAmount5.Text = objarea.Freeamount.ToString();

                                    break;
                                case 6:
                                    this.txtAreaName6.Text = objarea.Areaname;
                                    this.txtFreeAmount6.Text = objarea.Freeamount.ToString();
                                    way = objarea.Feescalculationway;
                                    if (way == 1)
                                    {
                                        this.rdtype3.Checked = true;
                                        this.txtBasicFrees6.Text = objarea.Basicfees.ToString();
                                        this.txtOverweight6.Text = objarea.Overweight.ToString();
                                        this.txtOverweight26.Text = objarea.Overweight2.ToString();
                                        this.trBasicFrees6.Style.Add("display", "block");
                                        this.trOverweight6.Style.Add("display", "block");
                                        this.trOverweight26.Style.Add("display", "block");
                                        this.trSingle6.Style.Add("display", "none");
                                        this.txtSingle6.Attributes.Remove("tip");
                                        txtSingle6.Attributes.Remove("validatetype");
                                        txtSingle6.Attributes.Remove("warning");
                                        txtSingle6.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees6, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtOverweight6, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                                    }
                                    else
                                    {
                                        this.rdtype4.Checked = true;
                                        this.txtSingle6.Text = objarea.Initialfees.ToString();

                                        this.trBasicFrees6.Style.Add("display", "none");
                                        this.trOverweight6.Style.Add("display", "none");
                                        this.trOverweight26.Style.Add("display", "none");
                                        this.trSingle6.Style.Add("display", "block");
                                        this.txtBasicFrees6.Attributes.Remove("tip");
                                        txtBasicFrees6.Attributes.Remove("validatetype");
                                        txtBasicFrees6.Attributes.Remove("warning");
                                        txtBasicFrees6.Attributes.Remove("error");
                                        this.txtOverweight6.Attributes.Remove("tip");
                                        txtOverweight6.Attributes.Remove("validatetype");
                                        txtOverweight6.Attributes.Remove("warning");
                                        txtOverweight6.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtSingle6, "请输入单件商品价格", "isfloat", "必填", "该项必须为数字");
                                    }

                                    break;
                                case 7:
                                    this.txtAreaName7.Text = objarea.Areaname;
                                    this.txtPackagingCosts7.Text = objarea.Packagingcosts.ToString();
                                    this.txtFreeAmount7.Text = objarea.Freeamount.ToString();
                                    way = objarea.Feescalculationway;
                                    if (way == 1)
                                    {
                                        this.rdtype5.Checked = true;
                                        this.txtBasicFrees7.Text = objarea.Basicfees.ToString();
                                        this.txtOverweight7.Text = objarea.Overweight.ToString();
                                        this.txtOverweight27.Text = objarea.Overweight2.ToString();
                                        this.trBasicFrees7.Style.Add("display", "block");
                                        this.trOverweight7.Style.Add("display", "block");
                                        this.trOverweight27.Style.Add("display", "block");
                                        this.trSingle7.Style.Add("display", "none");
                                        this.txtSingle7.Attributes.Remove("tip");
                                        txtSingle7.Attributes.Remove("validatetype");
                                        txtSingle7.Attributes.Remove("warning");
                                        txtSingle7.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees7, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtOverweight7, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                                    }
                                    else
                                    {
                                        this.rdtype6.Checked = true;
                                        this.txtSingle7.Text = objarea.Initialfees.ToString();

                                        this.trBasicFrees7.Style.Add("display", "none");
                                        this.trOverweight7.Style.Add("display", "none");
                                        this.trOverweight27.Style.Add("display", "none");
                                        this.trSingle7.Style.Add("display", "block");
                                        this.txtBasicFrees7.Attributes.Remove("tip");
                                        txtBasicFrees7.Attributes.Remove("validatetype");
                                        txtBasicFrees7.Attributes.Remove("warning");
                                        txtBasicFrees7.Attributes.Remove("error");
                                        this.txtOverweight7.Attributes.Remove("tip");
                                        txtOverweight7.Attributes.Remove("validatetype");
                                        txtOverweight7.Attributes.Remove("warning");
                                        txtOverweight7.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtSingle7, "请输入单件商品价格", "isfloat", "必填", "该项必须为数字");
                                    }
                                    break;
                                case 8:
                                    this.txtAreaName8.Text = objarea.Areaname;
                                    this.txtFreeAmount8.Text = objarea.Freeamount.ToString();
                                    way = objarea.Feescalculationway;
                                    if (way == 1)
                                    {
                                        this.rdtype7.Checked = true;
                                        this.txtBasicFrees8.Text = objarea.Basicfees.ToString();
                                        this.txtOverweight8.Text = objarea.Overweight.ToString();

                                        this.trBasicFrees8.Style.Add("display", "block");
                                        this.trOverweight8.Style.Add("display", "block");
                                        this.trSingle8.Style.Add("display", "none");
                                        this.txtSingle8.Attributes.Remove("tip");
                                        txtSingle8.Attributes.Remove("validatetype");
                                        txtSingle8.Attributes.Remove("warning");
                                        txtSingle8.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees8, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtOverweight8, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                                    }
                                    else
                                    {
                                        this.rdtype8.Checked = true;
                                        this.txtSingle8.Text = objarea.Initialfees.ToString();

                                        this.trBasicFrees8.Style.Add("display", "none");
                                        this.trOverweight8.Style.Add("display", "none");
                                        this.trSingle8.Style.Add("display", "block");
                                        this.txtBasicFrees8.Attributes.Remove("tip");
                                        txtBasicFrees8.Attributes.Remove("validatetype");
                                        txtBasicFrees8.Attributes.Remove("warning");
                                        txtBasicFrees8.Attributes.Remove("error");
                                        this.txtOverweight8.Attributes.Remove("tip");
                                        txtOverweight8.Attributes.Remove("validatetype");
                                        txtOverweight8.Attributes.Remove("warning");
                                        txtOverweight8.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtSingle8, "请输入单件商品价格", "isfloat", "必填", "该项必须为数字");
                                    }
                                    break;
                                case 9:
                                    this.txtAreaName9.Text = objarea.Areaname;
                                    this.txtFreeAmount9.Text = objarea.Freeamount.ToString();
                                    way = objarea.Feescalculationway;
                                    if (way == 1)
                                    {
                                        this.rdtype9.Checked = true;
                                        this.txtBasicFrees9.Text = objarea.Basicfees.ToString();
                                        this.txtOverweight9.Text = objarea.Overweight.ToString();

                                        this.trBasicFrees9.Style.Add("display", "block");
                                        this.trOverweight9.Style.Add("display", "block");
                                        this.trSingle9.Style.Add("display", "none");
                                        this.txtSingle9.Attributes.Remove("tip");
                                        txtSingle9.Attributes.Remove("validatetype");
                                        txtSingle9.Attributes.Remove("warning");
                                        txtSingle9.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees9, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtOverweight9, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                                    }
                                    else
                                    {
                                        this.rdtype10.Checked = true;
                                        this.txtSingle9.Text = objarea.Initialfees.ToString();

                                        this.trBasicFrees9.Style.Add("display", "none");
                                        this.trOverweight9.Style.Add("display", "none");
                                        this.trSingle9.Style.Add("display", "block");
                                        this.txtBasicFrees9.Attributes.Remove("tip");
                                        txtBasicFrees9.Attributes.Remove("validatetype");
                                        txtBasicFrees9.Attributes.Remove("warning");
                                        txtBasicFrees9.Attributes.Remove("error");
                                        this.txtOverweight9.Attributes.Remove("tip");
                                        txtOverweight9.Attributes.Remove("validatetype");
                                        txtOverweight9.Attributes.Remove("warning");
                                        txtOverweight9.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtSingle9, "请输入单件商品价格", "isfloat", "必填", "该项必须为数字");
                                    }

                                    break;
                                case 10:
                                    this.txtAreaName10.Text = objarea.Areaname;
                                    this.txtFreeAmount10.Text = objarea.Freeamount.ToString();
                                    this.txtCODPayFees10.Text = objarea.CODpayfees.ToString();
                                    way = objarea.Feescalculationway;
                                    if (way == 1)
                                    {
                                        this.rdtype11.Checked = true;
                                        this.txtBasicFrees10.Text = objarea.Basicfees.ToString();
                                        this.txtOverweight10.Text = objarea.Overweight.ToString();

                                        this.trBasicFrees10.Style.Add("display", "block");
                                        this.trOverweight10.Style.Add("display", "block");
                                        this.trSingle10.Style.Add("display", "none");
                                        this.txtSingle10.Attributes.Remove("tip");
                                        txtSingle10.Attributes.Remove("validatetype");
                                        txtSingle10.Attributes.Remove("warning");
                                        txtSingle10.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees10, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtOverweight10, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                                    }
                                    else
                                    {
                                        this.rdtype12.Checked = true;
                                        this.txtSingle10.Text = objarea.Initialfees.ToString();

                                        this.trBasicFrees10.Style.Add("display", "none");
                                        this.trOverweight10.Style.Add("display", "none");
                                        this.trSingle10.Style.Add("display", "block");
                                        this.txtBasicFrees10.Attributes.Remove("tip");
                                        txtBasicFrees10.Attributes.Remove("validatetype");
                                        txtBasicFrees10.Attributes.Remove("warning");
                                        txtBasicFrees10.Attributes.Remove("error");
                                        this.txtOverweight10.Attributes.Remove("tip");
                                        txtOverweight10.Attributes.Remove("validatetype");
                                        txtOverweight10.Attributes.Remove("warning");
                                        txtOverweight10.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtSingle10, "请输入单件商品价格", "isfloat", "必填", "该项必须为数字");
                                    }

                                    break;
                                case 11:
                                    this.txtAreaName11.Text = objarea.Areaname;
                                    this.txtFreeAmount11.Text = objarea.Freeamount.ToString();
                                    way = objarea.Feescalculationway;
                                    if (way == 1)
                                    {
                                        this.rdtype13.Checked = true;
                                        this.txtBasicFrees11.Text = objarea.Basicfees.ToString();
                                        this.txtOverweight11.Text = objarea.Overweight.ToString();

                                        this.trBasicFrees11.Style.Add("display", "block");
                                        this.trOverweight11.Style.Add("display", "block");
                                        this.trSingle11.Style.Add("display", "none");
                                        this.txtSingle11.Attributes.Remove("tip");
                                        txtSingle11.Attributes.Remove("validatetype");
                                        txtSingle11.Attributes.Remove("warning");
                                        txtSingle11.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees11, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtOverweight11, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                                    }
                                    else
                                    {
                                        this.rdtype14.Checked = true;
                                        this.txtSingle11.Text = objarea.Initialfees.ToString();

                                        this.trBasicFrees11.Style.Add("display", "none");
                                        this.trOverweight11.Style.Add("display", "none");
                                        this.trSingle11.Style.Add("display", "block");
                                        this.txtBasicFrees11.Attributes.Remove("tip");
                                        txtBasicFrees11.Attributes.Remove("validatetype");
                                        txtBasicFrees11.Attributes.Remove("warning");
                                        txtBasicFrees11.Attributes.Remove("error");
                                        this.txtOverweight11.Attributes.Remove("tip");
                                        txtOverweight11.Attributes.Remove("validatetype");
                                        txtOverweight11.Attributes.Remove("warning");
                                        txtOverweight11.Attributes.Remove("error");
                                        ChangeHope.WebPage.WebControl.Validate(this.txtSingle11, "请输入单件商品价格", "isfloat", "必填", "该项必须为数字");
                                    }

                                    break;
                            }
                            for (int j = 0; j < arrid.Length; j++)
                            {
                                this.tdArea.InnerHtml += "<input type='checkbox' value='" + arrid[j] + "' name='getid' id='chkcountry'  checked='checked' >" + arrarea[j].ToString() + "</input>";
                            }
                        }


                    }
                }

                ShowShop.Common.PromptInfo.Popedom("001008002");
                if (Request.Form["Option"] != null && !Request.Form["Option"].Trim().Equals("")
                                && Request.Form["ID"] != null && !Request.Form["ID"].Trim().Equals(""))
                {
                    string types = Request.Form["Option"].Trim();
                    if (types == "first")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());
                        secondClass(id.ToString());
                    }
                    else if (types == "Secondarry")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());
                        thirdClass(id.ToString());
                    }
                    else if (types == "thirdarry")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());                        
                    }
                    else if (types == "Vali")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());
                        Vali(id.ToString());
                    }
                    Response.End();
                    return;
                }
                ClassList("0");

            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            if (this.Request.Form["getid"] == "" || this.Request.Form["getid"] == null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "MsgBox", "<script>alert('请选择所辖地区！');</script>");
                return;
            }
            ShowShop.BLL.SystemInfo.PostArea areabll = new ShowShop.BLL.SystemInfo.PostArea();
            ShowShop.Model.SystemInfo.PostArea area = new ShowShop.Model.SystemInfo.PostArea();
            urlid = ChangeHope.WebPage.PageRequest.GetQueryInt("delivermode");
            if (urlid != -1 && urlid != 0)
            {
                area.Deliverymode = urlid;
                area.Areaid = Request.Form["getid"].ToString();
                area.Putoutid = ViewState["PutoutID"] == null ? 0 : Convert.ToInt32(ViewState["PutoutID"].ToString());
                area.Putouttyid = ViewState["PutoutTypeID"] == null ? 0 : Convert.ToInt32(ViewState["PutoutTypeID"].ToString());
                switch(urlid)
                {
                    case 1:
                        area.Areaname = this.txtAreaName1.Text;
                        break;
                    case 2:
                        area.Areaname = this.txtAreaName2.Text;
                        area.Basicfees = float.Parse(this.txtBasicFees2.Text);
                        area.CODpayfees = float.Parse(this.txtCODPayFees2.Text); 
                        area.Freeamount = float.Parse(this.txtFreeAmount2.Text);
                        break;
                    case 3:
                        area.Areaname = this.txtAreaName3.Text;

                        if (this.rdtype1.Checked)
                        {
                            area.Basicfees = float.Parse(this.txtBasicFrees3.Text);
                            area.Overweight = float.Parse(this.txtOverweight3.Text);
                            area.Feescalculationway = 1;
                        }
                        else
                        {
                            area.Initialfees = float.Parse(this.txtSingle3.Text);
                            area.Feescalculationway = 2;
                        }
                        
                        area.Freeamount = float.Parse(this.txtFreeAmount3.Text);
                        break;
                    case 4:
                        area.Areaname = this.txtAreaName4.Text;
                        area.Basicfees = float.Parse(this.txtBasicFrees4.Text);
                        area.CODpayfees = float.Parse(this.txtCODPayFees4.Text);
                        area.Freeamount = float.Parse(this.txtFreeAmount4.Text);
                        break;
                    case 5:
                        area.Areaname = this.txtAreaName5.Text;
                        area.Freeamount = float.Parse(this.txtFreeAmount5.Text);
                        break;
                    case 6:
                        area.Areaname = this.txtAreaName6.Text;
                        if (this.rdtype3.Checked)
                        {
                            area.Basicfees = float.Parse(this.txtBasicFrees6.Text);
                            area.Overweight = float.Parse(this.txtOverweight6.Text);
                            area.Overweight2 = float.Parse(this.txtOverweight26.Text.Trim());
                            area.Feescalculationway = 1;
                        }
                        else
                        {
                            area.Initialfees = float.Parse(this.txtSingle6.Text);
                            area.Feescalculationway = 2;
                        }
                        area.Freeamount = float.Parse(this.txtFreeAmount6.Text);
                        break;
                    case 7:
                        area.Areaname = this.txtAreaName7.Text;
                        if (this.rdtype5.Checked)
                        {
                            area.Basicfees = float.Parse(this.txtBasicFrees7.Text);
                            area.Overweight = float.Parse(this.txtOverweight7.Text);
                            area.Overweight2 = float.Parse(this.txtOverweight27.Text);
                            area.Feescalculationway = 1;
                        }
                        else
                        {
                            area.Initialfees = float.Parse(this.txtSingle7.Text);
                            area.Feescalculationway = 2;
                        }
                        area.Freeamount = float.Parse(this.txtFreeAmount7.Text);
                        area.Packagingcosts = float.Parse(this.txtPackagingCosts7.Text);
                        break;
                    case 8:
                        area.Areaname = this.txtAreaName8.Text;
                        if (this.rdtype7.Checked)
                        {
                            area.Basicfees = float.Parse(this.txtBasicFrees8.Text);
                            area.Overweight = float.Parse(this.txtOverweight8.Text);
                            area.Feescalculationway = 1;
                        }
                        else
                        {
                            area.Initialfees = float.Parse(this.txtSingle8.Text);
                            area.Feescalculationway = 2;
                        }
                        
                        area.Freeamount = float.Parse(this.txtFreeAmount8.Text);
                        break;
                    case 9:
                        area.Areaname = this.txtAreaName9.Text;
                        if (this.rdtype9.Checked)
                        {
                            area.Basicfees = float.Parse(this.txtBasicFrees9.Text);
                            area.Overweight = float.Parse(this.txtOverweight9.Text);
                            area.Feescalculationway = 1;
                        }
                        else
                        {
                            area.Initialfees = float.Parse(this.txtSingle9.Text);
                            area.Feescalculationway = 2;
                        }
                        area.Freeamount = float.Parse(this.txtFreeAmount9.Text);
                        break;
                    case 10:
                        area.Areaname = this.txtAreaName10.Text;
                        if (this.rdtype11.Checked)
                        {
                            area.Basicfees = float.Parse(this.txtBasicFrees10.Text);
                            area.Overweight = float.Parse(this.txtOverweight10.Text);
                            area.Feescalculationway = 1;
                        }
                        else
                        {
                            area.Initialfees = float.Parse(this.txtSingle10.Text);
                            area.Feescalculationway = 2;
                        }
                        area.Freeamount = float.Parse(this.txtFreeAmount10.Text);
                        area.CODpayfees = float.Parse(this.txtCODPayFees10.Text);
                        break;
                    case 11:
                        area.Areaname = this.txtAreaName11.Text;
                        if (this.rdtype11.Checked)
                        {
                            area.Basicfees = float.Parse(this.txtBasicFrees11.Text);
                            area.Overweight = float.Parse(this.txtOverweight11.Text);
                            area.Feescalculationway = 1;
                        }
                        else
                        {
                            area.Initialfees = float.Parse(this.txtSingle11.Text);
                            area.Feescalculationway = 2;
                        }
                        area.Freeamount = float.Parse(this.txtFreeAmount11.Text);
                        break;

                }

                areaid = ChangeHope.WebPage.PageRequest.GetQueryInt("areaid");
                if (areaid!=0 && areaid!= -1)
                {
                    area.Id = areaid;
                    areabll.Update(area);
                    ChangeHope.WebPage.BasePage.PageRight("修改成功！","area_list.aspx?delivermode="+area.Deliverymode.ToString());
                    
                }
                else
                { 
                    areabll.Add(area);
                }                
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
        }


        #region 绑定产品分类

        #region 绑定一级分类
        /// <summary>
        /// 绑定一级分类
        /// </summary>
        /// <param name="CID"></param>
        protected void ClassList(string CID)
        {

            DataTable dt = bll.GetChid(CID.ToString());
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select id=\"firstClass\" name=\"firstClass\" size=\"18\"  style=\"width:150px\" onchange=\"firstarry(this.value);OptionValue(this.value);\">");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    shtml.Append("<option value=" + dt.Rows[i]["Id"].ToString() + " >" + dt.Rows[i]["CityName"].ToString() + "</option>");
                }
            }
            shtml.Append("</select>");
            this.lrafirstClass.Text = shtml.ToString();
        }
        #endregion

        #region 绑定二级分类
        private void secondClass(string CID)
        {
            DataTable dt = bll.GetChid(CID);
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select id=\"secondClass\" name=\"secondClass\" size=\"18\"  style=\"width:150px\" onchange=\"Secondarry(this.value);OptionValue(this.value);\">");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    shtml.Append("<option value=" + dt.Rows[i]["Id"].ToString() + "/" + dt.Rows[i]["CityName"].ToString()+ ">" + dt.Rows[i]["CityName"].ToString() + "</option>");
                }
            }
            shtml.Append("</select>");
            Response.Write(shtml.ToString());
        }
        #endregion

        #region 绑定三级分类
        private void thirdClass(string CID)
        {
            DataTable dt = bll.GetChid(CID);
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select id=\"thirdClass\" name=\"thirdClass\" size=\"18\"  style=\"width:150px\" onchange=\"thirdarry(this.value);OptionValue(this.value);\">");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    shtml.Append("<option value=" + dt.Rows[i]["Id"].ToString() + "/" + dt.Rows[i]["CityName"].ToString() +" >" + dt.Rows[i]["CityName"].ToString() + "</option>");
                }
            }
            shtml.Append("</select>");
            Response.Write(shtml.ToString());
        }
        #endregion

        #region 绑定四级及以下分类
        //private void fourClass(int CID)
        //{
        //    string KG = "";
        //    ShowShop.Model.SystemInfo.Provinces model = bll.GetModel(CID);
        //    StringBuilder shtml = new StringBuilder();
        //    shtml.Append("<select id=\"thirdClass\" name=\"thirdClass\" size=\"18\" onchange=\"OptionValue(this.value);\" style=\"width:180px\">");
        //    if (model != null)
        //    {
        //        string ParentPath = model.ParentPath.ToString() + "," + model.Id.ToString();
        //        //DataTable dt = bll.GetBlurList(ParentPath);
        //        DataTable dt = bll.GetChid(model.Id.ToString());
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                KG = "";
        //                string[] Path = dt.Rows[i]["parentpath"].ToString().Split(',');
        //                for (int j = 1; j < Path.Length; j++)
        //                {
        //                    KG += "&nbsp;&nbsp;";
        //                }
        //                shtml.Append("<option value=" + dt.Rows[i]["Id"].ToString() + " >" + KG + "" + dt.Rows[i]["CityName"].ToString() + "</option>");
        //            }
        //        }
        //    }
        //    shtml.Append("</select>");
        //    Response.Write(shtml.ToString());
        //}
        #endregion

        #region 验证产品分类是否是最后一级
        private void Vali(string CID)
        {
            DataTable dt = bll.GetChid(CID);
            if (dt.Rows.Count > 0)
            {
                Response.Write("true");
            }
            else
            {
                Response.Write("false");
            }
        }
        #endregion


        #endregion


        #region 验证
        //验证
        private void InitWebControl()
        {
            switch(urlid)
            {
                case 1:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName1, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    break;
                case 2:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName2, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFees2, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtCODPayFees2, "请输入货到付款支付费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount2, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    break;
                case 3:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName3, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees3, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount3, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtOverweight3, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtSingle3, "请输入单件商品费用", "ifisfloat", "必填", "该项必须为数字");
                    break;
                case 4:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName4, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees4, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtCODPayFees4, "请输入货到付款支付费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount4, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    break;
                case 5:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName5, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount5, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    break;
                case 6:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName6, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees6, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtOverweight6, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount6, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtSingle6, "请输入单件商品费用", "ifisfloat", "必填", "该项必须为数字");
                    break;
                case 7:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName7, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees7, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtOverweight7, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount7, "请输入包装费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtPackagingCosts7, "请输入包装费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtSingle7, "请输入单件商品费用", "ifisfloat", "必填", "该项必须为数字");
                    break;
                case 8:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName8, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees8, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtOverweight8, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount8, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtSingle8, "请输入单件商品费用", "ifisfloat", "必填", "该项必须为数字");

                    break;
                case 9:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName9, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees9, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtOverweight9, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount9, "请输入免费额度", "isfloat", "必填", "该项必须为数字");  
                    ChangeHope.WebPage.WebControl.Validate(this.txtSingle9, "请输入单件商品费用", "ifisfloat", "必填", "该项必须为数字");

                    break;
                case 10:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName10, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees10, "请输入首重费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtOverweight10, "请输入续重费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount10, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtCODPayFees10, "请输入货到付款支付费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtSingle10, "请输入单件商品费用", "ifisfloat", "必填", "该项必须为数字");

                    break;
                case 11:
                    ChangeHope.WebPage.WebControl.Validate(this.txtAreaName11, "请输入配送区域名称", "isnull", "必填", "该项为必填项");
                    ChangeHope.WebPage.WebControl.Validate(this.txtBasicFrees11, "请输入基本费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtOverweight11, "请输入超过重量费用", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtFreeAmount11, "请输入免费额度", "isfloat", "必填", "该项必须为数字");
                    ChangeHope.WebPage.WebControl.Validate(this.txtSingle11, "请输入单件商品费用", "ifisfloat", "必填", "该项必须为数字");

                    break;
            }
            
            
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }

        #endregion

     
        

        
    }
}
