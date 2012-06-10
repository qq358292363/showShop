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
    public partial class order_modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty)
            {
                string types = Request["Option"].Trim();
                string id = ChangeHope.WebPage.PageRequest.GetFormString("Id");
                if (types == "ModifyPrice")
                {
                    string price = ChangeHope.WebPage.PageRequest.GetFormString("Price");
                    ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
                    ShowShop.Model.Order.OrderProduct orderProductModel = bll.GetModel(Convert.ToInt32(id));
                    if (orderProductModel != null)
                    {
                        ShowShop.BLL.Order.Orders ordbll = new ShowShop.BLL.Order.Orders();
                        ShowShop.Model.Order.Orders ordModel = ordbll.GetModel(Convert.ToInt32(orderProductModel.OrderId));
                        if (ordModel != null)
                        {
                            if (Convert.ToDecimal(orderProductModel.ProPrice) > Convert.ToDecimal(price))
                            {
                                decimal productPrice = Convert.ToDecimal(orderProductModel.ProPrice) - Convert.ToDecimal(price);
                                ordbll.Amend(ordModel.Id, "TotalPrice", Convert.ToDecimal(ordModel.TotalPrice) - (Convert.ToDecimal(orderProductModel.ProNum) * Convert.ToDecimal(productPrice)));
                                ordbll.Amend(ordModel.Id, "FactPrice", Convert.ToDecimal(ordModel.FactPrice) - (Convert.ToDecimal(orderProductModel.ProNum) * Convert.ToDecimal(productPrice)));
                            }
                            else
                            {
                                decimal productPrice = Convert.ToDecimal(price) - Convert.ToDecimal(orderProductModel.ProPrice);
                                ordbll.Amend(ordModel.Id, "TotalPrice", Convert.ToDecimal(ordModel.TotalPrice) + (Convert.ToDecimal(orderProductModel.ProNum) * Convert.ToDecimal(productPrice)));
                                ordbll.Amend(ordModel.Id, "FactPrice", Convert.ToDecimal(ordModel.FactPrice) + (Convert.ToDecimal(orderProductModel.ProNum) * Convert.ToDecimal(productPrice)));
                            }
                            if (bll.Amend(Convert.ToInt32(id), "ProPrice", price) != 1)
                            {
                                Response.Write("ok");
                            }
                        }
                    }
                }
                else if (types == "ModifyCount")
                {
                    string Count = ChangeHope.WebPage.PageRequest.GetFormString("Count");
                    ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
                    ShowShop.Model.Order.OrderProduct orderProductModel = bll.GetModel(Convert.ToInt32(id));
                    if (orderProductModel != null)
                    {
                        ShowShop.BLL.Order.Orders ordbll = new ShowShop.BLL.Order.Orders();
                        ShowShop.Model.Order.Orders ordModel = ordbll.GetModel(Convert.ToInt32(orderProductModel.OrderId));
                        if (ordModel != null)
                        {
                            if (Convert.ToInt32(orderProductModel.ProNum) > Convert.ToInt32(Count))
                            {
                                int productCount = Convert.ToInt32(orderProductModel.ProNum) - Convert.ToInt32(Count);
                                ordbll.Amend(ordModel.Id, "TotalPrice", Convert.ToDecimal(ordModel.TotalPrice) - (Convert.ToDecimal(orderProductModel.ProPrice) * Convert.ToDecimal(productCount)));
                                ordbll.Amend(ordModel.Id, "FactPrice", Convert.ToDecimal(ordModel.FactPrice) - (Convert.ToDecimal(orderProductModel.ProPrice) * Convert.ToDecimal(productCount)));
                            }
                            else
                            {
                                int productCount = Convert.ToInt32(Count) - Convert.ToInt32(orderProductModel.ProNum);
                                ordbll.Amend(ordModel.Id, "TotalPrice", Convert.ToDecimal(ordModel.TotalPrice) + (Convert.ToDecimal(orderProductModel.ProPrice) * Convert.ToDecimal(productCount)));
                                ordbll.Amend(ordModel.Id, "FactPrice", Convert.ToDecimal(ordModel.FactPrice) + (Convert.ToDecimal(orderProductModel.ProPrice) * Convert.ToDecimal(productCount)));
                            }
                            if (bll.Amend(Convert.ToInt32(id), "ProNum", Count) != 1)
                            {
                                Response.Write("ok");
                            }
                        }
                    }
                    
                }
                else if (types == "DelProduct")
                {
                    string OrderID = ChangeHope.WebPage.PageRequest.GetFormString("OrderID");
                    ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
                    DataTable dt = bll.GetListOrderProduct(OrderID.Trim());
                    if (dt.Rows.Count > 1)
                    {
                        ShowShop.Model.Order.OrderProduct orderProductModel = bll.GetModel(Convert.ToInt32(id));
                        if (orderProductModel != null)
                        {
                            ShowShop.BLL.Order.Orders ordbll = new ShowShop.BLL.Order.Orders();
                            ShowShop.Model.Order.Orders ordModel = ordbll.GetModel(Convert.ToInt32(OrderID));
                            if (ordModel != null)
                            {
                                ordbll.Amend(ordModel.Id, "TotalPrice", Convert.ToDecimal(ordModel.TotalPrice) - (Convert.ToDecimal(orderProductModel.ProPrice)*Convert.ToDecimal(orderProductModel.ProNum)));
                                ordbll.Amend(ordModel.Id, "FactPrice", Convert.ToDecimal(ordModel.FactPrice) - (Convert.ToDecimal(orderProductModel.ProPrice) * Convert.ToDecimal(orderProductModel.ProNum)));
                                bll.Delete(Convert.ToInt32(id));
                            }
                        }

                    }
                    else
                    {
                        Response.Write("删除失败,该订单删除后没有商品列表!");
                    }
                }
                Response.End();
            }

            int orderId = ChangeHope.WebPage.PageRequest.GetQueryInt("OrderId");
            if (!IsPostBack)
            {
                this.DeliverBind();
                this.OrderInfo(orderId);
                this.OrdersProduct(orderId);
            }
        }

        #region 订单信息
        private void OrderInfo(int id)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model = bll.GetModel(id);
            this.hlBackList.NavigateUrl = "order_order_info.aspx?OrderId=" + id;
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            this.txtProductName.Attributes.Add("readonly", "readonly");
            this.txtProductName.Attributes.Add("onclick", "selectFile('Product',new Array(" + this.hfid.ClientID + "," + this.txtProductName.ClientID + "),310,550,'" + sp.DummyPaht + "');");
            if (model != null)
            {
                ShowShop.BLL.Member.MemberAccount mabll = new ShowShop.BLL.Member.MemberAccount();
                ShowShop.Model.Member.MemberAccount mamodel = mabll.GetModel(model.UserId);
                if (mamodel != null)
                {
                    ShowShop.BLL.Member.MemberInfo mibll = new ShowShop.BLL.Member.MemberInfo();
                    ShowShop.Model.Member.MemberInfo mimodel = mibll.GetModel(mamodel.UID);
                    if (mimodel != null)
                    {
                        this.lbName.Text = mimodel.TrueName;
                    }
                    this.lbUserName.Text = "<a href='../member/member_view.aspx?uid=" + mamodel.UID + "'>" + model.UserId + "</a>";
                }
                else
                {
                    this.lbUserName.Text = model.UserId;
                }
                this.paymentInfo(model.SaleUserType, model.SaleUserID);
                this.hfOrderId.Value = id.ToString();
                this.blOrderNo.Text = model.OrderId;
                ShowShop.Common.OrdersStatusEnum ose = new ShowShop.Common.OrdersStatusEnum();
                this.lbOrderStatue.Text = ose.OrderStatus(model.OrderStatus);
                this.lbLogisticsStatus.Text = ose.OgisticsStatu(model.OgisticsStatus);
                this.lbPayment.Text = ose.PaymentStatus(model.PaymentStatus);
                this.lbOrderDateTime.Text = model.OrderDate.ToString();
                this.txtConsigneeName.Text = model.ConsigneeName;
                this.txtConsigneeAddress.Text = model.ConsigneeAddress;
                this.txtConsigneeEmail.Text = model.ConsigneeEmail;
                this.txtConsigneeModile.Text = model.ConsigneePhone;
                this.txtConsigneeTel.Text = model.ConsigneeTel;
                this.txtConsigneeZip.Text = model.ConsigneeZip;
                this.txtConstructionSigns.Text = model.ConsigneeRealName;
                this.txtConsigneTime.Text = model.ConsigneeFax;
                this.txtRemark.Text = string.IsNullOrEmpty(model.Remark) ? "" : model.Remark;
                this.ddlPayMent.SelectedValue = model.PaymentType.ToString();
                this.ddlDeliver.SelectedValue = model.Carriage.ToString();
                this.lbOrderTotalPrice.Text =Convert.ToDouble(model.FactPrice).ToString("f2");
                this.txtCarriage.Text = Convert.ToDouble(model.Courier).ToString("f2");
            }
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
            table.AddHeadCol("", "操作");
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
                    table.AddCol("<a href='../../product/productcontent.aspx?q_productid=" + dataPage.DataReader["ProId"].ToString() + "' target=\"_blank\">" + dataPage.DataReader["ProName"].ToString() + specVa + fittingProductInfo +"</a>");
                    table.AddCol("<input name=\"singlePrice\" id=\"singlePrice\" onblur=\"updatePrice(" + dataPage.DataReader["Id"].ToString() + ",this.value)\" type=\"text\" style=\"width:80px\" value=\"" + Convert.ToDouble(dataPage.DataReader["ProPrice"].ToString()).ToString("f4") + "\" />");
                    table.AddCol("<input name=\"singleNum\" id=\"singleNum\" onblur=\"updateNum(" + dataPage.DataReader["Id"].ToString() + ",this.value)\" type=\"text\" style=\"width:40px\" value=\"" + dataPage.DataReader["ProNum"].ToString() + "\">");
                    table.AddCol((Convert.ToDouble(dataPage.DataReader["ProPrice"].ToString()) * Convert.ToDouble(dataPage.DataReader["ProNum"].ToString()) + fittingTotalPrice).ToString("f2"));
                    table.AddCol("<a href='javascript:DeleteProduct(" + dataPage.DataReader["Id"].ToString() + "," + dataPage.DataReader["OrderId"].ToString() + ")'>删除</a>");
                    table.AddRow();
                    ProductTotalPrice += Convert.ToDouble(dataPage.DataReader["ProPrice"].ToString()) * Convert.ToDouble(dataPage.DataReader["ProNum"].ToString()) + fittingTotalPrice;
                }
                table.AddCol("4", "<strong>本页合计：" + ProductTotalPrice.ToString("f2") + "</strong>");
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

        protected void DeliverBind()
        {
            ShowShop.BLL.Product.Deliver bll = new ShowShop.BLL.Product.Deliver();
            List<ShowShop.Model.Product.Deliver> list = bll.GetAll();
            this.ddlDeliver.DataSource = list;
            this.ddlDeliver.DataTextField = "Name";
            this.ddlDeliver.DataValueField = "ID";
            this.ddlDeliver.DataBind();
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            ShowShop.BLL.Order.Orders bll = new ShowShop.BLL.Order.Orders();
            ShowShop.Model.Order.Orders model = bll.GetModel(this.blOrderNo.Text);
            model.ConsigneeName = this.txtConsigneeName.Text;
            model.ConsigneeAddress = this.txtConsigneeAddress.Text;
            model.ConsigneeEmail = this.txtConsigneeEmail.Text;
            model.ConsigneePhone = this.txtConsigneeModile.Text;
            model.ConsigneeTel = this.txtConsigneeTel.Text;
            model.ConsigneeZip = this.txtConsigneeZip.Text;
            model.ConsigneeFax = this.txtConsigneTime.Text;
            model.ConsigneeRealName = this.txtConstructionSigns.Text;
            model.Remark = this.txtRemark.Text.Trim();
            model.Courier = Convert.ToDecimal(this.txtCarriage.Text.Trim());
            try
            {
                bll.Update(model);
                this.ltlMsg.Text = "操作成功，已保存该信息";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
            }
            catch
            {
                this.ltlMsg.Text = "操作失败";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionErr";
            }
            finally
            {
                bll = null;
                model = null;
                GC.Collect();
            }
        }

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string orderId = this.hfOrderId.Value.Trim();
            if (string.IsNullOrEmpty(this.hfid.Value))
            {
                ChangeHope.WebPage.BasePage.PageError("请选择商品.", "order_modify.aspx?OrderId=" + orderId, "");
            }
            ShowShop.Model.Order.OrderProduct model = new ShowShop.Model.Order.OrderProduct();
            ShowShop.BLL.Order.OrderProduct bll = new ShowShop.BLL.Order.OrderProduct();
            ShowShop.BLL.Order.Orders ordbll = new ShowShop.BLL.Order.Orders();
            ShowShop.BLL.Product.ProductInfo bllProductInfo = new ShowShop.BLL.Product.ProductInfo();
            string[] idStr = this.hfid.Value.Split(',');
            string productId = idStr[0];
            string specificationId = idStr.Length > 1 ? idStr[1] : "";
            string specificationVa = "";
            decimal spePrice = 0;
            //if (!string.IsNullOrEmpty(specificationId.Trim()))
            //{
               // ShowShop.BLL.Product.ProductSpecification proSpe = new ShowShop.BLL.Product.ProductSpecification();
               // ShowShop.Model.Product.ProductSpecification proModel = proSpe.GetModelID(Convert.ToInt32(specificationId));
                //if (proModel != null)
                //{
                //    specificationVa = proModel.Specifications;
                //    spePrice = Convert.ToDecimal(proModel.SalePrice);
                //}
          //  }
            ChangeHope.DataBase.DataByPage db = bll.GetListByPage(" and ProId=" + productId + " and OrderId=" + orderId + " and Specification='" + specificationVa + "'");
            ShowShop.Model.Order.Orders ordModel = ordbll.GetModel(this.blOrderNo.Text.Trim());
            if (db.DataReader == null)
            {
                ShowShop.Model.Product.ProductInfo modelProductInfo = bllProductInfo.GetModel(Convert.ToInt32(productId));
                if (modelProductInfo != null)
                {
                    model.AddTime = System.DateTime.Now;
                    model.OrderId =Convert.ToInt32(orderId);
                    model.ProId = Convert.ToInt32(modelProductInfo.ProductID);
                    model.ProClass = modelProductInfo.ClassID.ToString();
                    model.ProImg = modelProductInfo.Thumbnail;
                    model.ProName = modelProductInfo.ProductName;
                    model.ProNum = 1;
                    model.ProOtherPara = "";
                    model.ProPrice = spePrice;
                    model.Specification = specificationVa;
                    model.FittingsId = 0;
                    model.FittingsProductCount = "";
                    model.FittingsProductId = "";
                    model.FittingsProductPrice = "";
                    bll.Add(model);
                    if (ordModel != null)
                    {
                        ordbll.Amend(ordModel.Id, "TotalPrice",Convert.ToDecimal(ordModel.TotalPrice)+Convert.ToDecimal(spePrice));
                        ordbll.Amend(ordModel.Id, "FactPrice", Convert.ToDecimal(ordModel.FactPrice) + Convert.ToDecimal(spePrice));
                    }
                }
            }
            else
            {
                if(db.DataReader.Read())
                {
                    bll.Amend(Convert.ToInt32(db.DataReader["Id"].ToString()), "ProNum", Convert.ToInt32(db.DataReader["ProNum"].ToString()) + 1);
                    if (ordModel != null)
                    {
                        ordbll.Amend(ordModel.Id, "TotalPrice", Convert.ToDecimal(ordModel.TotalPrice) + Convert.ToDecimal(db.DataReader["ProPrice"].ToString()));
                        ordbll.Amend(ordModel.Id, "FactPrice", Convert.ToDecimal(ordModel.FactPrice) + Convert.ToDecimal(db.DataReader["ProPrice"].ToString()));
                    }
                }
                
            }
            DataTable ordProductdt = bll.GetListOrderProduct(orderId);
            if (ordProductdt.Rows.Count > 0)
            {
            }
            ChangeHope.WebPage.BasePage.PageRight("向" + this.blOrderNo.Text + "添加商品成功.", "order_modify.aspx?OrderId="+orderId, "");
        }

        #region 支付信息
        private void paymentInfo(string UserTypeId, string UserId)
        {
            ShowShop.BLL.SystemInfo.TerraceManage tmbll = new ShowShop.BLL.SystemInfo.TerraceManage();
            ChangeHope.DataBase.DataByPage dbp = null;
            
                if (UserTypeId == "0")
                {
                    dbp = tmbll.GetList(" [order by] payment_id asc", 10, " and payment_putouttypeid=0");
                }
                else
                {
                    dbp = tmbll.GetList(" [order by] payment_id asc", 10, " and payment_putouttypeid=1 and payment_putoutid=" + UserId + "");
                }
         
            if (dbp.DataReader != null)
            {
                while (dbp.DataReader.Read())
                {
                    this.ddlPayMent.Items.Add(new ListItem(dbp.DataReader["payment_name"].ToString(), dbp.DataReader["payment_id"].ToString()));
                }
            }  
        }
        #endregion

    }
}
