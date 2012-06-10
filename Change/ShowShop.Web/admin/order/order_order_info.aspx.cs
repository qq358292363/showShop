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
using System.Collections.Generic;

namespace ShowShop.Web.admin.order
{
    public partial class order_order_info : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowShop.Common.PromptInfo.Popedom("005001001");
            #region 删除反馈信息
            if (ChangeHope.WebPage.PageRequest.GetFormString("LeaveOption") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormInt("id") > 0)
            {
                string types = Request.Form["LeaveOption"].Trim();
                int leaveId = ChangeHope.WebPage.PageRequest.GetFormInt("id");
                if (types == "delleave")
                {
                    this.DeleteLeave(leaveId.ToString());
                }
                Response.End();
                return;
            }
            #endregion

            int id = ChangeHope.WebPage.PageRequest.GetQueryInt("OrderId");

            #region 订单操作
            string option = ChangeHope.WebPage.PageRequest.GetQueryString("option");
            if (option != string.Empty && id > 0)
            {
                ShowShop.BLL.Order.Orders orderBll = new ShowShop.BLL.Order.Orders();
                ShowShop.Model.Order.Orders orderModel = orderBll.GetModel(id);
                //删除操作
                if (option == "del")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001003","对不起，您没有权限进行删除");
                    DeleteOrder(id.ToString());
                }
                //结清订单
                else if (option == "over")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001010","对不起，您没有该权限");
                    int Status=ShowShop.Common.OrdersStatusEnum.OrderStatu.已结清.GetHashCode();
                    this.HandleOrder(id);
                    ModfiyOrderStatus(id, "OrderStatus", Status, "订单已经结清。");
                }
                //确认订单
                else if (option == "confirm")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001005","对不起，您没有该权限");
                    int Status = ShowShop.Common.OrdersStatusEnum.OrderStatu.已经确认.GetHashCode();
                    ModfiyOrderStatus(id, "OrderStatus", Status, "订单已经确认。");
                }
                //取消
                else if (option == "cancel")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001006","对不起，您没有该权限");
                    int Status = ShowShop.Common.OrdersStatusEnum.OrderStatu.取消确认.GetHashCode();
                    ModfiyOrderStatus(id, "OrderStatus", Status, "订单已经取消确认。");
                }
                //订单作废
                else if (option == "invalid")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001007","对不起，您没有该权限");
                    int Status = ShowShop.Common.OrdersStatusEnum.OrderStatu.已经作废.GetHashCode();
                    ModfiyOrderStatus(id, "OrderStatus", Status, "订单已经作废。");
                }
                //暂停处理
                else if (option == "stop")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001008","对不起，您没有该权限");
                    int Status = 0;
                    ModfiyOrderStatus(id, "IsOrderNormal", Status, "订单已经暂停处理。");
                }
                //回复正常
                else if (option == "goon")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001009","对不起，您没有该权限");
                    int Status = 1;
                    ModfiyOrderStatus(id, "IsOrderNormal", Status, "订单已经回复正常。");
                }
                //客户已签收
                else if (option == "cusover")
                {
                    ShowShop.Common.PromptInfo.Popedom("005001011","对不起，您没有该权限");
                    int Status = ShowShop.Common.OrdersStatusEnum.OgisticsStatus.已签收.GetHashCode();
                    ModfiyOrderStatus(id, "OgisticsStatus", Status, "订单客户已经签收。");
                }
                return;
            }
            #endregion

            if (!IsPostBack)
            {
                if (id > 0)
                {
                    this.InitWebControl(id);
                    this.OrderInfo(id);
                    this.OrdersProduct(id);
                    this.lblMoneyList.Text = this.GetMoneyList(this.blOrderNo.Text.Trim());
                    this.lblConsignList.Text = this.GetConsignList(this.blOrderNo.Text.Trim());
                    this.lblTransList.Text = this.GetTransList(this.blOrderNo.Text.Trim());
                    this.lblOrderLeaveList.Text = this.GetOrderLeaveList(this.blOrderNo.Text.Trim());
                }
            }
        }
        private void ModfiyOrderStatus(int id,string ColumnName,int Value,string Str)
        {
            ShowShop.BLL.Order.Orders ordbll = new ShowShop.BLL.Order.Orders();
            ordbll.Amend(id, ColumnName, Value);
            ChangeHope.WebPage.BasePage.PageRight(Str, "order_order_info.aspx?OrderId=" + id, "");
        }

        #region 订单结清处理
        private void HandleOrder(int id)
        {
            ShowShop.BLL.Order.Orders ordersbll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders ordersModel = ordersbll.GetModel(id);
            if (ordersModel != null)
            {
                ShowShop.BLL.Order.OrderProduct orderProductbll = new ShowShop.BLL.Order.OrderProduct();
                DataTable orderProductDT = orderProductbll.GetListOrderProduct(id.ToString());

                ShowShop.BLL.Member.MemberAccount memberaccountbll = new ShowShop.BLL.Member.MemberAccount();
                ShowShop.Model.Member.MemberAccount memberaccounModel = memberaccountbll.GetModel(ordersModel.UserId);
                
             //   ShowShop.BLL.Product.ProductSpecification spebll = new ShowShop.BLL.Product.ProductSpecification();
                decimal DonateIntegral = 0;
                if (orderProductDT.Rows.Count > 0)
                {
                    ShowShop.BLL.Product.ProductInfo productinfoBll = new ShowShop.BLL.Product.ProductInfo();
                    for (int i = 0; i < orderProductDT.Rows.Count; i++)
                    {
                        ShowShop.Model.Product.ProductInfo productInfoModel = productinfoBll.GetModel(Convert.ToInt32(orderProductDT.Rows[i]["ProId"].ToString()));
                        if (productInfoModel != null)
                        {
                           // DonateIntegral += Convert.ToDecimal(productInfoModel.pro_DonateIntegral);
                           // productinfoBll.Amend(productInfoModel.pro_ID, "pro_SaleNum", productInfoModel.pro_SaleNum + Convert.ToInt32(orderProductDT.Rows[i]["ProNum"].ToString()));
                            if (!string.IsNullOrEmpty(orderProductDT.Rows[i]["Specification"].ToString()))
                            {
                              //  List<ShowShop.Model.Product.ProductSpecification> spcList = spebll.GetSpecification(" and ProductId=" + orderProductDT.Rows[i]["ProId"].ToString() + " and Specifications='" + orderProductDT.Rows[i]["Specification"].ToString() + "'");
                              //  if (spcList.Count > 0)
                              //  {
                                  //  spebll.Amend(spcList[0].Id, "ProductStock", Convert.ToInt32(spcList[0].ProductStock) - Convert.ToInt32(orderProductDT.Rows[i]["ProNum"].ToString()));
                              //  }
                            }
                            else
                            {
                                //if (Convert.ToInt32(productInfoModel.pro_Stock) >= Convert.ToInt32(orderProductDT.Rows[i]["ProNum"].ToString()))
                                {
                                   // productinfoBll.Amend(productInfoModel.pro_ID, "pro_Stock", Convert.ToInt32(productInfoModel.pro_Stock) - Convert.ToInt32(orderProductDT.Rows[i]["ProNum"].ToString()));
                                }

                            }
                        }
                    }
                    //购买商品赠送积分
                    if (memberaccounModel != null)
                    {
                        if (DonateIntegral > 0)
                        {
                            if (memberaccountbll.Amend(memberaccounModel.UID, "Points", memberaccounModel.Points + DonateIntegral) > 0)
                            {
                                ShowShop.BLL.Member.Integral integralBll = new ShowShop.BLL.Member.Integral();
                                ShowShop.Model.Member.Integral integral = new ShowShop.Model.Member.Integral();
                                integral.Userid = memberaccounModel.UID;
                                integral.OrderId = ordersModel.OrderId;
                                integral.IntegralClass = 1;
                                integral.IntegralNum = memberaccounModel.Points + DonateIntegral;
                                integral.GainDate = Convert.ToDateTime(System.DateTime.Now);
                                integral.NoteDate = Convert.ToDateTime(System.DateTime.Now);
                                integral.NoteName = "系统";
                                integral.Remark = "购买商品后赠送的积分";
                                integral.IntegralStatus = 0;
                                integral.Origin = "订单";
                                integralBll.Add(integral);
                            }
                        }

                    }
                }
            }
            
        }
        #endregion

        #region 订单信息
        private void OrderInfo(int id)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model=bll.GetModel(id);
            if (model != null)
            {
                ShowShop.BLL.Member.MemberAccount mabll = new ShowShop.BLL.Member.MemberAccount();
                ShowShop.Model.Member.MemberAccount mamodel = mabll.GetModel(model.UserId);
                if (mamodel != null)
                {
                        
                    this.lbUserName.Text = "<a href='../member/member_view.aspx?uid=" + mamodel.UID + "'>" + model.UserId + "</a>";
                }
                else
                {
                    this.lbUserName.Text = model.UserId ;
                }
                this.lbName.Text = model.ConsigneeName;
                this.blOrderNo.Text = model.OrderId;
                ShowShop.Common.OrdersStatusEnum ose = new ShowShop.Common.OrdersStatusEnum();
                this.lbOrderStatue.Text = ose.OrderStatus(model.OrderStatus);
                this.lbLogisticsStatus.Text = ose.OgisticsStatu(model.OgisticsStatus);
                this.lbPayment.Text = ose.PaymentStatus(model.PaymentStatus);
                this.lbOrderDateTime.Text = model.OrderDate.ToString();
                this.lbConsigneeName.Text = model.ConsigneeName;
                this.lbConsigneeAddress.Text = model.ConsigneeAddress;
                this.lbConsigneeEmail.Text = model.ConsigneeEmail;
                this.lbConsigneeModile.Text = model.ConsigneePhone;
                this.lbConsigneeTel.Text = model.ConsigneeTel;
                this.lbConsigneeZip.Text = model.ConsigneeZip;
                this.lbConstructionSigns.Text = model.ConsigneeRealName;
                this.lbConsigneTime.Text = model.ConsigneeFax;
                this.lbPaymentMode.Text = Payments(model.PaymentType);
                this.lbDeliveryMode.Text = this.Courier(int.Parse(model.Carriage.ToString()));
                this.lbOrderTotalPrice.Text =Convert.ToDouble(model.FactPrice).ToString("f2");
                this.lbCarriage.Text = Convert.ToDouble(model.Courier).ToString("f4");
                this.lbpaid.Text = GetPayed(model.OrderId.ToString());
            }
        }
        #endregion

        #region 计算商品总价
        private double TotalPrice(string orderId)
        {
            ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
            DataTable dt = bll.GetListOrderProduct(orderId);
            double totalPrice = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalPrice += Convert.ToDouble(dt.Rows[i]["ProPrice"].ToString()) * Convert.ToDouble(dt.Rows[i]["ProNum"].ToString());
                }
            }
            return totalPrice;
        }
        #endregion

        #region 订单商品信息
        private void OrdersProduct(int orderId)
        {
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetListByPage(" and OrderId=" + orderId);
            table.AddHeadCol("50%", "商品名称");
            table.AddHeadCol("", "单价");
            table.AddHeadCol("", "数量");
            table.AddHeadCol("", "小计(单位：元)");
            table.AddRow();
            double ProductTotalPrice = 0;
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    string fittingsProductId = dataPage.DataReader["FittingsProductId"].ToString();
                    string fittingsId = dataPage.DataReader["FittingsId"].ToString();
                    string fittingsProductCount = dataPage.DataReader["FittingsProductCount"].ToString();
                    string fittingProductInfo = "";
                    double fittingTotalPrice = 0;
                    if (!string.IsNullOrEmpty(fittingsProductId.Trim()) && !string.IsNullOrEmpty(fittingsId.Trim()) && Convert.ToInt32(fittingsId) > 0)
                    {
                        //配件
                        int fittingProductCount = 0;
                        double fittingProductWeight = 0;
                        double fittingProductIntergal = 0;
                        ShowShop.Common.ProductInfo.FittingDisposal(fittingsId, fittingsProductId, fittingsProductCount, out fittingProductCount, out fittingProductInfo, out fittingTotalPrice, out fittingProductWeight, out fittingProductIntergal);
                    }
                    string specificationValue = dataPage.DataReader["Specification"].ToString();
                    string specVa = "";
                    if (specificationValue != "")
                    {
                        specVa = "&nbsp;&nbsp;" + specificationValue + "";
                    }
                    table.AddCol("<a href='../../product/productcontent.aspx?q_productid=" + dataPage.DataReader["ProId"].ToString() + "' target='_blank'>" + dataPage.DataReader["ProName"].ToString() + specVa + fittingProductInfo + "</a>");
                    table.AddCol(Convert.ToDouble(dataPage.DataReader["ProPrice"].ToString()).ToString("f2"));
                    table.AddCol(dataPage.DataReader["ProNum"].ToString());
                    table.AddCol((Convert.ToDouble(dataPage.DataReader["ProPrice"].ToString()) * Convert.ToDouble(dataPage.DataReader["ProNum"].ToString()) + fittingTotalPrice).ToString("f2"));
                    table.AddRow();
                    ProductTotalPrice += Convert.ToDouble(dataPage.DataReader["ProPrice"].ToString()) * Convert.ToDouble(dataPage.DataReader["ProNum"].ToString()) + fittingTotalPrice ;
                }
                table.AddCol("4", "<strong>本页金额合计：" + ProductTotalPrice.ToString("f2") + "</strong>");
                table.AddRow();
                string view = table.GetTable() + dataPage.PageToolBar;
                dataPage.Dispose();
                dataPage = null;
                this.litData.Text = view;
            }
            else
            {
                this.litData.Text = "没有找到该订单的商品信息";
            }

        }
        #endregion

        #region 付款信息

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected string GetMoneyList(string orderId)
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            //银行资金
            ShowShop.BLL.Order.RemittanceInfo remBll = new ShowShop.BLL.Order.RemittanceInfo();
            ChangeHope.DataBase.DataByPage remData = remBll.GetList(" 1=1 and orderid='" + orderId + "'");
            //预付款
            ShowShop.BLL.Order.PrepayMoney preBll = new ShowShop.BLL.Order.PrepayMoney();
            ChangeHope.DataBase.DataByPage preData = preBll.GetList(" 1=1 and orderid='" + orderId + "'"); 
            //现金付款
            ShowShop.BLL.Order.PaymentMoney payBll = new ShowShop.BLL.Order.PaymentMoney();
            ChangeHope.DataBase.DataByPage payData = payBll.GetList(" 1=1 and orderid='" + orderId + "'"); 

            //第一步先添加表头
            table.AddHeadCol("", "客户名称");
            table.AddHeadCol("", "交易时间");
            table.AddHeadCol("", "交易方式");
            table.AddHeadCol("", "交易金额");
            table.AddHeadCol("", "备注/说明");
            table.AddHeadCol("", "赠送点卷");
            table.AddRow();
            //添加银行付款的内容
            if (remData.DataReader != null)
            {
                while (remData.DataReader.Read())
                {
                    table.AddCol(remData.DataReader["username"].ToString());
                    table.AddCol(remData.DataReader["remittancedate"].ToString());
                    table.AddCol("银行支付");
                    if (remData.DataReader["remittancemoney"].ToString() == "0")
                    {
                        table.AddCol("");
                    }
                    else
                    {
                        table.AddCol(remData.DataReader["remittancemoney"].ToString());
                    }
                    table.AddCol(remData.DataReader["remark"].ToString());
                    table.AddCol(remData.DataReader["presentticket"].ToString());
                    table.AddRow();
                }
            }
            //添加预付款的内容
            if (preData.DataReader != null)
            {
                while (preData.DataReader.Read())
                {
                    table.AddCol(preData.DataReader["username"].ToString());
                    table.AddCol(preData.DataReader["notedate"].ToString());
                    table.AddCol("预付款支付");
                    table.AddCol(preData.DataReader["payoutmoney"].ToString());
                    table.AddCol(preData.DataReader["remark"].ToString());
                    table.AddCol("0");
                    table.AddRow();
                }
            }
            //添加现金付款的内容
            if (payData.DataReader != null)
            {
                while (payData.DataReader.Read())
                {
                    table.AddCol(payData.DataReader["username"].ToString());
                    table.AddCol(payData.DataReader["gatheringdate"].ToString());
                    table.AddCol("现金付款");
                    table.AddCol(payData.DataReader["gatheringmoney"].ToString());
                    table.AddCol(payData.DataReader["remark"].ToString());
                    table.AddCol(payData.DataReader["presentticket"].ToString());
                    table.AddRow();
                }
            }
            string view = table.GetTable();
            remData.Dispose();
            remData = null;
            preData.Dispose();
            preData = null;
            payData.Dispose();
            payData = null;
            return view;
        }
        #endregion

        #region 发退货记录
        protected string GetConsignList(string orderId)
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            //发货
            ShowShop.BLL.Order.ConsignMent Bll = new ShowShop.BLL.Order.ConsignMent();
            ChangeHope.DataBase.DataByPage pageData = Bll.GetList(" 1=1 and orderid='" + orderId + "'");

            //第一步先添加表头
            table.AddHeadCol("", "客户名称");
            table.AddHeadCol("", "交易时间");
            table.AddHeadCol("", "快递公司");
            table.AddHeadCol("", "快递单号");
            table.AddHeadCol("", "经办人");
            table.AddHeadCol("", "备注/说明");
            table.AddHeadCol("", "类型");
            table.AddRow();
            //添加发退货记录的内容
            if (pageData.DataReader != null)
            {
                while (pageData.DataReader.Read())
                {
                    table.AddCol(pageData.DataReader["username"].ToString());
                    table.AddCol(pageData.DataReader["consignmentdate"].ToString());
                    table.AddCol(pageData.DataReader["expresscompany"].ToString());
                    table.AddCol(pageData.DataReader["expressoddnumbers"].ToString());
                    table.AddCol(pageData.DataReader["consignmentpeople"].ToString());
                    table.AddCol(pageData.DataReader["remark"].ToString());
                    table.AddCol(pageData.DataReader["consignmenttype"].ToString() == "0" ? "发货" : "退货");
                    table.AddRow();
                }
            }
            string view = table.GetTable() + pageData.PageToolBar;
            pageData.Dispose();
            pageData = null;
            return view;
        }
        #endregion

        #region 订单过户记录
        protected string GetTransList(string orderId)
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            //过户
            ShowShop.BLL.Order.OrderTransfer Bll = new ShowShop.BLL.Order.OrderTransfer();
            ChangeHope.DataBase.DataByPage pageData = Bll.GetList(" 1=1 and orderid='" + orderId + "'");

            //第一步先添加表头
            table.AddHeadCol("", "原属客户");
            table.AddHeadCol("", "先属客户");
            table.AddHeadCol("", "手续费");
            table.AddHeadCol("", "手续费支付者");
            table.AddHeadCol("", "备注/说明");
            table.AddHeadCol("", "操作时间");
            table.AddRow();
            //过户的内容
            if (pageData.DataReader != null)
            {
                while (pageData.DataReader.Read())
                {
                    table.AddCol(pageData.DataReader["username"].ToString());
                    table.AddCol(pageData.DataReader["transfername"].ToString());
                    table.AddCol(pageData.DataReader["poundage"].ToString());
                    table.AddCol(pageData.DataReader["poundagepaymentperson"].ToString());
                    table.AddCol(pageData.DataReader["remark"].ToString());
                    table.AddCol(pageData.DataReader["uptime"].ToString());
                    table.AddRow();
                }
            }
            string view = table.GetTable() + pageData.PageToolBar;
            pageData.Dispose();
            pageData = null;
            return view;
        }
        #endregion

        #region 反馈记录
        protected string GetOrderLeaveList(string orderId)
        {

            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            //反馈
            ShowShop.BLL.Order.OrderLeave Bll = new ShowShop.BLL.Order.OrderLeave();
            ChangeHope.DataBase.DataByPage pageData = Bll.GetList(" 1=1 and orderid='" + orderId + "'");

            //第一步先添加表头
            table.AddHeadCol("", "内容");
            table.AddHeadCol("", "留言人账号");
            table.AddHeadCol("", "时间");
            table.AddHeadCol("", "类型");
            table.AddHeadCol("", "操作");
            table.AddRow();
            if (pageData.DataReader != null)
            {
                while (pageData.DataReader.Read())
                {
                    table.AddCol(pageData.DataReader["content"].ToString());
                    table.AddCol(pageData.DataReader["memberid"].ToString() == "-1" ? "管理员" : this.GetUserIdByuId(Convert.ToInt32(pageData.DataReader["memberid"].ToString())));
                    table.AddCol(pageData.DataReader["createdate"].ToString());
                    table.AddCol(pageData.DataReader["state"].ToString() == "1" ? "用户提交" : "管理员回复");
                    string option = string.Empty;
                    option=string.Format("<a href='javascript:void(0)' onclick='Del({0})'>删除</a> <a href=order_leave_modify.aspx?id={0}>修改</a> ",pageData.DataReader["id"].ToString());
                    if (pageData.DataReader["state"].ToString() == "1") //用户
                    {
                        option = option + string.Format("<a href=order_leave_reply.aspx?id={0}>回复</a>", pageData.DataReader["id"].ToString());
                    }
                    table.AddCol(option);
                    table.AddRow();
                }
            }
            string view = table.GetTable() + pageData.PageToolBar;
            pageData.Dispose();
            pageData = null;
            return view;
        }
        #endregion

        #region 配送信息
        private string Courier(int id)
        {
            string reStr = string.Empty;
            ShowShop.BLL.SystemInfo.PostArea bll = new ShowShop.BLL.SystemInfo.PostArea();
            ShowShop.Model.SystemInfo.PostArea model = bll.GetModelByAreaID(id);
            if (model != null)
            {
                if (model.Deliverymode > 0)
                {
                    ShowShop.BLL.SystemInfo.Deliver dbll = new ShowShop.BLL.SystemInfo.Deliver();
                    ShowShop.Model.SystemInfo.Deliver dmodel = dbll.GetModelByID(model.Deliverymode);
                    if (dmodel != null)
                    {
                        reStr = dmodel.Distributionname;
                    }
                }
            }
            return reStr;
        }
        #endregion
        
        #region 订单操作
        private void InitWebControl(int id)
        {
            ShowShop.BLL.Order.Orders ordbll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders ordmodel = ordbll.GetModel(id);
            int OrderStatus = 0;
            int PaymentStatus = 0;
            int OgisticsStatus = 0;
            int IsOrderNormul = 0;
            if (ordmodel != null)
            {
                OrderStatus = int.Parse(ordmodel.OrderStatus.ToString());
                PaymentStatus = int.Parse(ordmodel.PaymentStatus.ToString());
                OgisticsStatus = int.Parse(ordmodel.OgisticsStatus.ToString());
                IsOrderNormul=int.Parse(ordmodel.IsOrderNormal.ToString());
            }
            #region 订单状态
            if (IsOrderNormul == 0)
            {
                this.hlSuspendHandleOrder.Enabled = false;
                this.hlResumeNormal.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=goon";
            }
            else if (IsOrderNormul == 1)
            {
                this.hlSuspendHandleOrder.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=stop";
                this.hlResumeNormal.Enabled = false;
            }
            switch (OrderStatus)
            {
                case 0:
                    this.hlModfiyOrder.NavigateUrl = "order_modify.aspx?OrderId=" + id + "";
                    this.hlConfirmOrder.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=confirm";
                    this.hlCancelConfirm.Enabled = false;
                    this.hlOrderInvalidated.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=invalid";
                    this.hlBankPayment.Enabled = false;
                    this.hlFuturePayment.Enabled = false;
                    this.hlCash.Enabled = false;
                    this.hlRefundment.Enabled = false;
                    this.hlConsignment.Enabled = false;
                    this.hlReturned.Enabled = false;
                    this.hlSquare.Enabled = false;
                    this.hlSign.Enabled = false;
                    this.hlDel.Enabled = false;
                    break;
                case 1:
                    this.hlModfiyOrder.NavigateUrl = "order_modify.aspx?OrderId=" + id + "";
                    this.hlConfirmOrder.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=confirm";
                    this.hlCancelConfirm.Enabled = false;
                    this.hlOrderInvalidated.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=invalid";
                    
                    this.hlBankPayment.Enabled = false;
                    this.hlFuturePayment.Enabled = false;
                    this.hlCash.Enabled = false;
                    this.hlRefundment.Enabled = false;
                    this.hlConsignment.Enabled = false;
                    this.hlReturned.Enabled = false;
                    this.hlSquare.Enabled = false;
                    this.hlSign.Enabled = false;
                    this.hlDel.Enabled = false;
                    break;
                case 2:
                    this.hlModfiyOrder.Enabled = false;
                    this.hlConfirmOrder.Enabled = false;
                    this.hlCancelConfirm.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=cancel";
                    this.hlOrderInvalidated.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=invalid";
                    if (PaymentStatus == 1)
                    {
                       this.hlBankPayment.Enabled = false;
                        this.hlFuturePayment.Enabled = false;
                        this.hlCash.Enabled = false;
                        this.hlConsignment.NavigateUrl = "order_consignment.aspx?OrderId=" + id + "";
                        this.hlRefundment.NavigateUrl = "order_refundment.aspx?OrderId=" + id + "";
                    }
                    else
                    {
                        this.hlBankPayment.NavigateUrl = "order_bank_pay.aspx?OrderId=" + id + "";
                        this.hlFuturePayment.NavigateUrl = "order_pre_pay.aspx?OrderId=" + id + "";
                        this.hlCash.NavigateUrl = "order_cash_pay.aspx?OrderId=" + id + "";
                        this.hlConsignment.Enabled = false; 
                        this.hlRefundment.Enabled = false;
                    }
                   
                    
                    this.hlReturned.Enabled = false;
                    this.hlSquare.Enabled = false;
                    this.hlSign.Enabled = false;
                    this.hlDel.Enabled = false;
                    break;
                case 6:
                    this.hlModfiyOrder.NavigateUrl = "order_modify.aspx?OrderId=" + id + "";
                    this.hlConfirmOrder.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=confirm";
                    this.hlCancelConfirm.Enabled = false;
                    this.hlOrderInvalidated.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=invalid";
                    this.hlBankPayment.Enabled = false;
                    this.hlFuturePayment.Enabled = false;
                    this.hlCash.Enabled = false;
                    this.hlRefundment.Enabled = false;
                    this.hlConsignment.Enabled = false;
                    this.hlReturned.Enabled = false;
                    this.hlSquare.Enabled = false;
                    this.hlSign.Enabled = false;
                    this.hlDel.Enabled = false;
                    break;
                case 4:
                    this.hlModfiyOrder.Enabled = false;
                    this.hlConfirmOrder.Enabled = false;
                    this.hlOrderInvalidated.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=invalid";

                    if (PaymentStatus==1)
                    {
                        this.hlBankPayment.Enabled = false;
                        this.hlFuturePayment.Enabled = false;
                        this.hlCash.Enabled = false;
                        this.hlConsignment.NavigateUrl = "order_consignment.aspx?OrderId=" + id + "";
                    }
                    else
                    {
                        this.hlBankPayment.NavigateUrl = "order_bank_pay.aspx?OrderId=" + id + "";
                        this.hlFuturePayment.NavigateUrl = "order_pre_pay.aspx?OrderId=" + id + "";
                        this.hlCash.NavigateUrl = "order_cash_pay.aspx?OrderId=" + id + "";
                        this.hlConsignment.Enabled = false;
                    }
                    this.hlRefundment.NavigateUrl = "order_refundment.aspx?OrderId=" + id + "";



                    this.hlDel.Enabled = false;

                    #region 配送状态
                    if (OgisticsStatus == 1)
                    {
                        this.hlSquare.Enabled = false;
                        this.hlConsignment.Enabled = false;
                        this.hlReturned.NavigateUrl = "order_back_consignment.aspx?OrderId=" + id + "";
                        this.hlSign.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=cusover";
                    }
                    else if (OgisticsStatus == 2)
                    {

                        this.hlSquare.NavigateUrl = "order_order_info.aspx?OrderId=" + id + "&option=over";
                        this.hlSign.Enabled = false;
                    }
                    else
                    {
                        this.hlSquare.Enabled = false;
                        this.hlReturned.Enabled = false;
                    }
                    #endregion
                    break;
                default:
                    this.hlModfiyOrder.Enabled = false;
                    this.hlConfirmOrder.Enabled = false;
                    this.hlCancelConfirm.Enabled = false;
                    this.hlOrderInvalidated.Enabled = false;
                    this.hlSuspendHandleOrder.Enabled = false;
                    this.hlResumeNormal.Enabled = false;
                    this.hlBankPayment.Enabled = false;
                    this.hlFuturePayment.Enabled = false;
                    this.hlCash.Enabled = false;
                    this.hlRefundment.Enabled = false;
                    this.hlConsignment.Enabled = false;
                    this.hlReturned.Enabled = false;
                    this.hlSquare.Enabled = false;
                    this.hlSign.Enabled = false;
                    this.hlDel.Enabled = false;
                    break;
            }
            #endregion
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 根据ID得到订单号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetOrderId(int id)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model=bll.GetModel(id);
            if (model != null)
            {
                return model.OrderId;
            }
            else
            {
                return string.Empty;
            }
        }

        protected string GetUserIdByuId(int uid)
        {
            ShowShop.BLL.Member.MemberAccount bll = new ShowShop.BLL.Member.MemberAccount();
            ShowShop.Model.Member.MemberAccount model = bll.GetModel(uid);
            if (model != null)
            {
                return model.UserId;
            }
            else
            {
                return "无此用户";
            }
        }

        /// <summary>
        /// 删除订单 
        /// </summary>
        /// <param name="id"></param>
        protected void DeleteOrder(string id)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            try
            {
                bll.Delete(id);
                this.ltlMsg.Text = "操作成功，已删除该订单";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            catch
            {
                this.ltlMsg.Text = "操作失败";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
        }

        /// <summary>
        /// 订单操作  更改状态
        /// </summary>
        /// <param name="id"></param>
        protected void ShowMes(string msg)
        {
            this.ltlMsg.Text = msg;
            this.pnlMsg.Visible = true;
            this.pnlMsg.CssClass = "actionOk";
        }

        /// <summary>
        /// 删除反馈
        /// </summary>
        /// <param name="id"></param>
        protected void DeleteLeave(string id)
        {
            ShowShop.BLL.Order.OrderLeave bll = new ShowShop.BLL.Order.OrderLeave();
            bll.Delete(id);
            Response.Write("ok");
        }
        #endregion

        #region 已付金额
        /// <summary>
        /// 计算已付款
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        protected string GetPayed(string orderId)
        {
            string totle = string.Empty;
            decimal remPrice = 0;
            decimal payPrice = 0;
            decimal prePrice = 0;
            //银行支付
            ShowShop.BLL.Order.RemittanceInfo remBll = new ShowShop.BLL.Order.RemittanceInfo();
            List<ShowShop.Model.Order.RemittanceInfo> remdate = remBll.GetAll("orderid='" + orderId + "'");
            if (remdate.Count > 0)
            {
                foreach (ShowShop.Model.Order.RemittanceInfo da in remdate)
                {
                    remPrice += Convert.ToDecimal(da.RemittanceMoney.ToString());
                }
            }
            //现金支付
            ShowShop.BLL.Order.PaymentMoney payBll = new ShowShop.BLL.Order.PaymentMoney();
            List<ShowShop.Model.Order.PaymentMoney> paydata = payBll.GetAll("orderid='" + orderId + "'");
            if (paydata.Count > 0)
            {
                foreach (ShowShop.Model.Order.PaymentMoney da in paydata)
                {
                    payPrice += Convert.ToDecimal(da.GatheringMoney.ToString());
                }
            }
            //预付款
            ShowShop.BLL.Order.PrepayMoney preBll = new ShowShop.BLL.Order.PrepayMoney();
            List<ShowShop.Model.Order.PrepayMoney> predata = preBll.GetAll("orderid='" + orderId + "'");
            if (predata.Count > 0)
            {
                foreach (ShowShop.Model.Order.PrepayMoney da in predata)
                {
                    prePrice += Convert.ToDecimal(da.PayoutMoney);
                }
            }
            totle = (remPrice + payPrice + prePrice).ToString();
            return totle;
        }
        #endregion

        #region 付款方式
        private string Payments(string PaymentId)
        {
            if (!string.IsNullOrEmpty(PaymentId))
            {
                ShowShop.BLL.SystemInfo.TerraceManage tmbll = new ShowShop.BLL.SystemInfo.TerraceManage();
                ShowShop.Model.SystemInfo.TerraceManage tmmodel = tmbll.GetModelById(Convert.ToInt32(PaymentId));
                if (tmmodel != null)
                {
                    return tmmodel.Tmname;
                }
            }
            return string.Empty;
        }
        #endregion
    }
}
