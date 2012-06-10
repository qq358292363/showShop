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

namespace ShowShop.Web.admin.member
{
    public partial class member_view : System.Web.UI.Page
    {
        ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                int uid = ChangeHope.WebPage.PageRequest.GetQueryInt("uid");
                string opreate = ChangeHope.WebPage.PageRequest.GetQueryString("Opreate");
                if (opreate != null && opreate != "")
                {
                    if(opreate.Equals("lock")){
                        bll.LockAddUnLock(uid.ToString(), false);
                    }else if(opreate.Equals("unlock")){
                        bll.LockAddUnLock(uid.ToString(),true);
                    }
                }               
                if(uid>0)
                {              
                    Cache["uid"] = uid;                   
                }
                int id = Convert.ToInt32(Cache["uid"]);
                InitWebControl(id);
                if (id > 0)
                {
                    GetAccount(id);
                    GetInfo(id);
                    GetReceaddress(id);
                    IntegralInfo(id.ToString());
                    this.litData.Text = GetList(id, 2);
                    this.litCoupon.Text = GetList(id,0);
                    this.litCapital.Text = GetCapitalList(id);
                }             
            }
        }

        //td 2010-4-9
        private void GetReceaddress(int id)
        {
            try
            {
                ShowShop.BLL.Member.ReceAddress rbll = new ShowShop.BLL.Member.ReceAddress();
                ShowShop.Model.Member.ReceAddress model = rbll.GetModelByID(id);

                if (model != null)
                {
                    this.lblName.Text = model.UserName;
                    this.lblEmails.Text = model.Email;
                    this.lblAddresss.Text = model.Address;
                    this.lblZips.Text = model.Zip;
                    this.lblTel.Text = model.Phone;
                    this.lblModeil.Text = model.Mobile;
                    this.lblConig.Text = model.ConstructionSigns;
                    this.lblConTime.Text = model.ConsignesTime;
                    string address = "";
                    ShowShop.BLL.SystemInfo.Provinces pbll = new ShowShop.BLL.SystemInfo.Provinces();
                    ShowShop.Model.SystemInfo.Provinces pmodel = pbll.GetModel(int.Parse(model.Province));
                    if (pmodel != null)
                    {
                        address += pmodel.CityName + "&nbsp;&nbsp;";
                    }

                    pmodel = pbll.GetModel(int.Parse(model.City));
                    if (pmodel != null)
                    {
                        address+=pmodel.CityName+"&nbsp;&nbsp;";
                    }
                    pmodel = pbll.GetModel(int.Parse(model.Borough));
                    if (pmodel != null)
                    {
                        address += pmodel.CityName + "&nbsp;&nbsp;";
                    }
                    this.lblAdd.Text = address;
                }

                
            }
            catch { }
            
        }
        private void InitWebControl(int uid)
        {
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_edit.aspx?uid=" + uid + "\">修改会员信息</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_view.aspx?uid=" + uid + "&Opreate=lock\">锁定会员</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_view.aspx?uid=" + uid + "&Opreate=unlock\">解锁会员</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_bank_remit.aspx?uid=" + uid + "\">添加银行汇款</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"shortmessge_send.aspx?uid=" + uid + "\">发送站内信息</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_fund_edit.aspx?uid=" + uid + "\">添加其他收入</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_outfund.aspx?uid=" + uid + "\">添加支出资金</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"mail_send_single.aspx?uid=" + uid + "\">发送邮件</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_cupons_duty.aspx?uid=" + uid + "\">兑换点卷</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_changedata.aspx?uid=" + uid + "\">兑换有效期</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_useful.aspx?uid=" + uid + "&Opreate=add\">添加有效期</a></li>";
            this.linklist.Text += "<li><img src=\"../images/mune.gif\" alt=\"\"/>&nbsp;<a href=\"member_useful.aspx?uid=" + uid + "&Opreate=allay\">扣除有效期</a></li>";
        }
        private void GetAccount(int uid)
        {      
   
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            if (model != null)
            {
                this.ltlUser.Text = "【"+model.UserId+"】";
                this.lblUserType.Text = ChangeHope.DataBase.DataHelper.GetContent("yxs_code_usertype", model.UserType.ToString());
                this.lblUserGroup.Text = ChangeHope.DataBase.DataHelper.GetContent("yxs_memberrank", "Id", "Name", model.UserGroup.ToString());
                this.lblUserId.Text = model.UserId;
                this.lblEmail.Text = model.Email;
                this.lblState.Text = model.State==1?"被冻结":"正常";
                this.lblRegisterDate.Text = model.RegisterDate.ToString();
                this.lblRegisterIP.Text = model.RegisterIP;
                this.lblLastLoginDate.Text = model.LastLoginDate.ToString();
                this.lblLastLoginIP.Text = model.LastLoginIP;
                this.lblCapital.Text = model.Capital.ToString();
                this.lblCoupons.Text = model.Coupons.ToString();
                this.lblPoints.Text = model.Points.ToString();
                this.lblPeriodOfValidity.Text = model.PeriodOfValidity.ToString();
            } 
            model = null;
            bll = null;
        }
        private void GetInfo(int uid)
        {
            ShowShop.BLL.Member.MemberInfo bll = new ShowShop.BLL.Member.MemberInfo();
            ShowShop.Model.Member.MemberInfo model = null;
            try
            {
                model = bll.GetModel(uid);
                if (model != null)
                {
                    this.lblTrueName.Text = model.TrueName + "(籍贯：" + model.Origin + ")";
                    this.lblTitle.Text = model.Title;
                    this.lblBirthday.Text = (model.Birthday != null ? (((DateTime)model.Birthday).ToString("yyyy-MM-dd")) : ("未填写"));
                    this.lblPapersType.Text = ChangeHope.DataBase.DataHelper.GetContent("yxs_code_papers", model.PapersType);
                    this.lblPapersNumber.Text = model.PapersNumber;
                    this.lblNation.Text = model.Nation;
                    this.lblSex.Text = ChangeHope.DataBase.DataHelper.GetContent("yxs_code_sex", model.Sex.ToString());
                    this.lblMarriage.Text = ChangeHope.DataBase.DataHelper.GetContent("yxs_code_marriage", model.Marriage.ToString());
                    this.lblEducation.Text = ChangeHope.DataBase.DataHelper.GetContent("yxs_code_education", model.Education);
                    this.lblGraduateSchool.Text = model.GraduateSchool;
                    //获取省信息
                    string province = "";
                    ShowShop.BLL.SystemInfo.Provinces bllProvinces = new ShowShop.BLL.SystemInfo.Provinces();
                    Model.SystemInfo.Provinces modelProvinces = bllProvinces.GetModel(ChangeHope.Common.StringHelper.StringToInt(model.Province));
                    if (modelProvinces != null)
                    {
                        province = modelProvinces.CityName;
                    }
                    modelProvinces = bllProvinces.GetModel(ChangeHope.Common.StringHelper.StringToInt(model.City));
                    if (modelProvinces != null)
                    {
                        province = province + "." + modelProvinces.CityName;
                    }
                    modelProvinces = bllProvinces.GetModel(ChangeHope.Common.StringHelper.StringToInt(model.Borough));
                    if (modelProvinces != null)
                    {
                        province = province + "." + modelProvinces.CityName;
                    }
                    this.lblProvince.Text = province;
                    this.lblAddress.Text = model.Address;
                    this.lblZip.Text = model.Zip;
                    this.lblOfficePhone.Text = model.OfficePhone;
                    this.lblHomePhone.Text = model.HomePhone;
                    this.lblMobilePhone.Text = model.MobilePhone;
                    this.lblHandPhone.Text = model.HandPhone;
                    this.lblFax.Text = model.Fax;
                    this.lblPersonWebSite.Text = model.PersonWebSite;
                    this.lblQQ.Text = model.QQ;
                    this.lblMSN.Text = model.MSN;
                    this.lblICQ.Text = model.ICQ;
                    this.lblUC.Text = model.UC;
                    this.lblLifeHobbies.Text = model.LifeHobbies;
                    this.lblCultureHobbies.Text = model.CultureHobbies;
                    this.lblEntertainment.Text = model.Entertainment;
                    this.lblSportsHobbies.Text = model.SportsHobbies;
                    this.lblOtherHobbies.Text = model.OtherHobbies;
                    this.lblIncName.Text = model.IncName;
                    this.lblDepartment.Text = model.Department;
                    this.lblPositions.Text = model.Positions;
                    this.lblWorkRange.Text = model.WorkRange;
                    this.lblIncAddress.Text = model.IncAddress;
                    this.lblMonthlyInCome.Text = model.MonthlyInCome + " 元人民币";
                }
            }
            catch { }
            finally
            {
                model = null;
                bll = null;
            }
        }

        #region 点卷日期
        /// <summary>
        /// Table绑定 点卷与日期
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="type">操作明细类型</param>
        /// <returns></returns>
        public string GetList(int id,int type)
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.UserInfoNote noteBll = new ShowShop.BLL.Member.UserInfoNote();
            ChangeHope.DataBase.DataByPage dataPage = noteBll.GetListByIdAndType(id,type);         
            switch (type)
            {  
                case 0:
                    table.AddHeadCol("", "交易时间");
                    table.AddHeadCol("", "增加点卷数");
                    table.AddHeadCol("", "减少点卷数");
                    table.AddHeadCol("", "操作人员");
                    table.AddHeadCol("", "备注/原因");
                    table.AddRow();
                    break;
                case 1:
                    break;
                case 2:
                    table.AddHeadCol("", "时间");
                    table.AddHeadCol("", "添加日期");
                    table.AddHeadCol("", "减少日期");
                    table.AddHeadCol("", "操作人员");
                    table.AddHeadCol("", "备注/原因");
                    table.AddRow();                  
                    break;
                default:
                    break;
            }
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol(dataPage.DataReader["noteDate"].ToString());
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString() == "0" ? dataPage.DataReader["ticketCount"].ToString() : "");
                    table.AddCol(dataPage.DataReader["buckleOrAdd"].ToString() == "1" ? dataPage.DataReader["ticketCount"].ToString() : "");
                    table.AddCol(dataPage.DataReader["noteName"].ToString());
                    table.AddCol(dataPage.DataReader["causation"].ToString());
                    table.AddRow();
                }
                string view = table.GetTable() + dataPage.PageToolBar;
                dataPage.Dispose();
                dataPage = null;
                return view;
            }
            else
            {
                return "没有找到相关的信息";
            }

        }
        #endregion

        #region 银行资金明细
        /// <summary>
        /// 银行资金明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCapitalList(int id)
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.UserinAndExp expBll = new ShowShop.BLL.Member.UserinAndExp();
            ChangeHope.DataBase.DataByPage dataPage = expBll.GetList(" uid="+id+" ");
            table.AddHeadCol("","交易时间");
            table.AddHeadCol("","交易方式");
            table.AddHeadCol("","收入资金");
            table.AddHeadCol("","支出资金");
            table.AddHeadCol("","银行名称");
            table.AddHeadCol("","备注/原因");
            table.AddHeadCol("","状态");
            table.AddRow();
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    table.AddCol(dataPage.DataReader["notedate"].ToString());
                    table.AddCol(GetOutType(Convert.ToInt32(dataPage.DataReader["remitmode"])));
                    table.AddCol(dataPage.DataReader["incomeandexpstate"].ToString() == "0" ? dataPage.DataReader["adsummoney"].ToString() : "");
                    table.AddCol(dataPage.DataReader["incomeandexpstate"].ToString() == "1" ? dataPage.DataReader["adsummoney"].ToString() : "");
                    table.AddCol(dataPage.DataReader["remitbank"].ToString());
                    table.AddCol(dataPage.DataReader["remark"].ToString());
                    table.AddCol(dataPage.DataReader["state"].ToString() == "0" ? "确认" : "未确认");
                    table.AddRow();
                }
                string view = table.GetTable() + dataPage.PageToolBar;
                dataPage.Dispose();
                dataPage = null;
                return view;
            }
            else
            {
                return "没有找到相关信息";
            }


        }
        #endregion

        #region 支付方式
        public string GetOutType(int typeId)
        {
            string str = "";
            switch (typeId)
            {   
                case 1:
                    str = "银行汇款";
                    break;
                case 2:
                    str = "虚拟货币";
                    break;
                case 3:
                    str = "现金支付";
                    break;
                default:
                    break;
            }
            return str;
        }
        #endregion

        #region 积分信息
        protected void IntegralInfo(string UID)
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Member.Integral bll = new ShowShop.BLL.Member.Integral();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList(" 1=1 and userId=" + UID + "");
            //第一步先添加表头
            table.AddHeadCol("", "来源内容");
            table.AddHeadCol("", "获得积分");
            table.AddHeadCol("", "获得时间");
            table.AddHeadCol("", "处理者");
            table.AddHeadCol("", "备注");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    string remark = ChangeHope.Common.StringHelper.SubStringAndAppend(dataPage.DataReader["remark"].ToString(), 100, "...");
                    table.AddCol(dataPage.DataReader["origin"].ToString());
                    table.AddCol(dataPage.DataReader["integral"].ToString());
                    table.AddCol(dataPage.DataReader["gainDate"].ToString());
                    table.AddCol(dataPage.DataReader["noteName"].ToString());
                    table.AddCol(remark);
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.LitIntegral.Text = view;
        }
        #endregion
    }
}
