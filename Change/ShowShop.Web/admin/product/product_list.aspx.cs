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

namespace ShowShop.Web.admin.product
{
    public partial class product_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("001008001");
                if (ChangeHope.WebPage.PageRequest.GetFormString("Option") != string.Empty && ChangeHope.WebPage.PageRequest.GetFormString("id") != string.Empty)
                {

                    string types = Request.Form["Option"].Trim();
                    string StrID = ChangeHope.WebPage.PageRequest.GetFormString("id");
                    if (types == "del")
                    {

                        if (ShowShop.Common.PromptInfo.Message("001008003") != "ok")
                        {
                            del(StrID);
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    Response.End();
                    return;
                }
                //string PutoutType = ChangeHope.WebPage.PageRequest.GetString("q_PutoutType");
                //if (PutoutType != "")
                //{
                //    if (PutoutType == "0")
                //    {
                //        this.OptionMember.Visible = false;
                //    }
                //    this.returnLinkBottom.NavigateUrl = "product_info_edit.aspx?putoutType=" + PutoutType;
                //   // this.w_d_pro_PutoutType.Value = PutoutType;

                //}
                GetList("");
                BindProductBrand();
                InitWebControl();
            }
        }

        #region 搜索设置
        private void InitWebControl()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            //this.txtArea.Attributes.Add("readonly", "readonly");
            // this.txtArea.Attributes.Add("onclick", "selectFile('Area',new Array(" + this.w_l_pro_Area.ClientID + "," + this.txtArea.ClientID + "),310,450,'" + sp.DummyPaht + "');");
            this.txtProductClass.Attributes.Add("readonly", "readonly");
            this.txtProductClass.Attributes.Add("onclick", "selectFile('Productclass',new Array(" + this.w_d_pro_CID.ClientID + "," + this.txtProductClass.ClientID + "),310,450,'" + sp.DummyPaht + "');");
            //this.txtUserName.Attributes.Add("readonly", "readonly");
            //this.txtUserName.Attributes.Add("onclick", "selectFile('Memberlist',new Array(" + this.w_d_pro_PutoutID.ClientID + "," + this.txtUserName.ClientID + "),310,450,'" + sp.DummyPaht + "');");
        }
        #endregion

        #region 商品品牌
        protected void BindProductBrand()
        {
            ShowShop.BLL.Product.ProductBrand bll = new ShowShop.BLL.Product.ProductBrand();
            ChangeHope.DataBase.DataByPage dataPage = bll.GetList();
            this.w_d_pro_BrandID.Items.Add(new ListItem("--所有品牌--", ""));
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    this.w_d_pro_BrandID.Items.Add(new ListItem(dataPage.DataReader["name"].ToString(), dataPage.DataReader["bid"].ToString()));
                }
            }
        }
        #endregion
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        protected void GetList(string PutoutType)
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.WebPage.Table table = new ChangeHope.WebPage.Table();
            ShowShop.BLL.Product.ProductInfo data = new ShowShop.BLL.Product.ProductInfo();
            ChangeHope.DataBase.DataByPage dataPage = data.GetList("[order by] ProductID desc", 20, "");
            //第一步先添加表头
            table.AddHeadCol("5%", "<input type=\"checkbox\" id=\"chkAll\" onclick=\"CheckAll(this.form)\" alt=\"全选/取消\" />选择");
            table.AddHeadCol("10%", "商品编号");
            table.AddHeadCol("18%", "商品名称");
            table.AddHeadCol("15%", "所属分类");
            table.AddHeadCol("10%", "品牌");
            table.AddHeadCol("14%", "创建时间");
            table.AddHeadCol("8%", "上架状态");
            table.AddHeadCol("20%", "操作");
            table.AddRow();
            //添加表的内容
            if (dataPage.DataReader != null)
            {
                while (dataPage.DataReader.Read())
                {
                    string pic_url = sp.DummyPaht + dataPage.DataReader["Thumbnail"].ToString();
                    table.AddCol("<input ID=\"cBox\" type=\"checkbox\" value=\"" + dataPage.DataReader["ProductID"].ToString() + "\" />");
                    table.AddCol(dataPage.DataReader["ProductNo"].ToString());
                    table.AddCol("<span style='cursor:hand'  onMouseOut=\"hiddenPic();\" onMouseMove=\"showPic('" + pic_url + "');\">" + dataPage.DataReader["ProductName"].ToString() + "(" + dataPage.DataReader["ProductAttachName"].ToString() + ")</span>");
                    table.AddCol(ProductClassName(dataPage.DataReader["cid"].ToString()));
                    table.AddCol(dataPage.DataReader["BrandID"].ToString());
                    table.AddCol(dataPage.DataReader["CreateTime"].ToString());
                    table.AddCol(dataPage.DataReader["IsShelves"].ToString() == "1" ? "上架" : "未上架");
                    table.AddCol(string.Format("<a href=product_info_edit.aspx?productNo={0}>编辑</a> <a href='#' onclick='Del({0})'>删除</a> <a href=product_info_edit.aspx?productNo={0}>属性添加</a> <a href='../../product/productcontent.aspx?q_productid={0}' target='_blank'>SKU添加</a>", dataPage.DataReader["ProductID"].ToString(), dataPage.DataReader["cid"].ToString(), PutoutType));

                    
                    table.AddRow();
                }
            }
            string view = table.GetTable() + dataPage.PageToolBar;
            dataPage.Dispose();
            dataPage = null;
            this.Literal1.Text = view; 
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
        #region 状态
        protected string States(int str)
        {
            string reStr = string.Empty;


            switch (str)
            {
                case 1:
                    reStr = "<span style='color:red'>首页</span>";

                    break;
                case 2:
                    reStr = "<span style='color:red'>最新</span>";
                    break;
                case 3:
                    reStr = "<span style='color:red'>推荐</span>";
                    break;
                case 4:
                    reStr = "<span style='color:red'>特价</span>";
                    break;
                case 5:
                    reStr = "<span style='color:red'>热卖</span>";
                    break;


            }
            return reStr;
        }
        #endregion


        #region
        private void del(string StrID)
        {

            ShowShop.BLL.Product.ProductInfo bll = new ShowShop.BLL.Product.ProductInfo();
            ShowShop.BLL.Product.ProductAlbum pabll = new ShowShop.BLL.Product.ProductAlbum();
            ShowShop.BLL.Product.ProductSparepart sbll = new ShowShop.BLL.Product.ProductSparepart();
            DataTable dt = bll.GetPartData(StrID);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChangeHope.Common.FileHelper fh = new ChangeHope.Common.FileHelper();
                    if (!dt.Rows[i]["pro_Original"].ToString().Contains("http://"))
                    {
                        fh.DeleteFile(Server.MapPath("~//" + dt.Rows[i]["pro_Original"].ToString()));
                    }
                    sbll.DeleteProductSparepart(Convert.ToInt32(dt.Rows[i]["pro_ID"].ToString()));
                }
            }
            bll.Delete(StrID);
            pabll.DelAll(StrID);
            Response.Write("ok");
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetList(w_d_pro_CID.Value);
        }

    }
}
