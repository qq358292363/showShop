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
using System.Text;
using System.Collections.Generic;

namespace ShowShop.Web.admin.product
{
    public partial class productclass_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                InitWebControl();

                #region 编辑绑定数据
                if (ChangeHope.WebPage.PageRequest.GetInt("id") >0 )
                {
                    Bind(ChangeHope.WebPage.PageRequest.GetInt("id"));
                }
                #endregion
                #region 新增分类
                if (ChangeHope.WebPage.PageRequest.GetInt("fatherid") > 0)
                {
                    int fatherid=ChangeHope.WebPage.PageRequest.GetInt("fatherid") ;
                    ShowShop.BLL.Product.Productclass data = new ShowShop.BLL.Product.Productclass();
                    ShowShop.Model.Product.Productclass model = data.GetModelID(fatherid);
                    if (model != null)
                    {
                        this.ddlTheirclass.Items.Add(new ListItem(model.Name, "0"));
                        this.hffatherid.Value = fatherid.ToString();
                        this.hfparentpath.Value =model.Parentpath+","+fatherid;
                    }
                  // this.returnLink.NavigateUrl = "productclass_list.aspx?w_d_fatherid=" + fatherid;
                    this.returnLinkBottom.NavigateUrl = "productclass_list.aspx?w_d_fatherid=" + fatherid;
                }
                else if (ChangeHope.WebPage.PageRequest.GetInt("fatherid") == 0)
                {
                    this.ddlTheirclass.Items.Add(new ListItem("顶级分类","0"));
                    this.hffatherid.Value = "0";
                    this.hfparentpath.Value = "0";
                   // this.returnLink.NavigateUrl = "productclass_list.aspx?w_d_fatherid=0";
                    this.returnLinkBottom.NavigateUrl = "productclass_list.aspx?w_d_fatherid=0";
                }
                #endregion
                
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Save();
        }
        /// <summary>
        /// 验证
        /// </summary>
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.txtName, "输入商品分类的名称,您可以对商品进行归类", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.txtSort, "输入数字将作为显示的排列顺序", "isint", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
            //this.txtWebPagePath.Attributes.Add("onclick", "GetFile(this)");
            //this.txtWebPagePath.Attributes.Add("readonly", "readonly");
            //this.txtListPageTemplate.Attributes.Add("onclick", "GetFile(this)");
            //this.txtListPageTemplate.Attributes.Add("readonly", "readonly");
            //this.txtContentPageTemplate.Attributes.Add("onclick", "GetFile(this)");
            //this.txtContentPageTemplate.Attributes.Add("readonly", "readonly");
            GetFileList();
        }
        private void GetFileList()
        {
            ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
            ChangeHope.Common.FileHelper file = new ChangeHope.Common.FileHelper();

            StringBuilder filelist = new StringBuilder();
            file.rootUrl = Server.MapPath("~/" + sp.WebSiteTemplatePath);
            file.listFiles(file.rootUrl, 0);

            filelist.AppendLine("<script type=\"text/javascript\">");
            filelist.AppendLine("d = new dTree('d');");
            filelist.AppendLine("d.add(0,-1,'请选择模版');");
            filelist.AppendLine(file.fileTree.ToString());
            filelist.AppendLine("document.write(d);");
            filelist.AppendLine("$(\"fileLists\").style.visibility=\"hidden\";");
            filelist.AppendLine("</script>");
           // this.ltlFileList.Text = filelist.ToString();
            file = null;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="id"></param>
        private void Bind(int id)
        {
            ShowShop.BLL.Product.Productclass data = new ShowShop.BLL.Product.Productclass();
            ShowShop.Model.Product.Productclass model = data.GetModelID(id);
            if (model != null)
            {
                //this.returnLink.NavigateUrl = "productclass_list.aspx?w_d_fatherid=" + model.Fatherid.ToString();
                this.returnLinkBottom.NavigateUrl = "productclass_list.aspx?w_d_fatherid=" + model.Fatherid.ToString();
                this.hffatherid.Value = model.Fatherid.ToString();
                this.hfparentpath.Value = model.Parentpath;
                this.txtDescription.Text = model.Description;
                this.txtName.Text = model.Name;
                this.txtSort.Text = model.Sort.ToString();
                //this.rdolstIsRecommend.SelectedValue = model.Isrecommend.ToString();
                //this.txtContentPageTemplate.Text= model.Contenttemplate ;
                //this.txtListPageTemplate.Text = model.Listtemplate;
                //this.txtWebPagePath.Text=model.Sectiontemplate ;
                //this.ddlProductType.SelectedValue = model.ProductTypeId.ToString();
                model = data.GetModelID(Convert.ToInt32(model.Fatherid));
                if (model != null)
                {
                    this.ddlTheirclass.Items.Add(new ListItem(model.Name, id.ToString()));
                }
                else
                {
                    this.ddlTheirclass.Items.Add(new ListItem("顶级分类", id.ToString()));
                }
            }
            
            model = null;
        }

        private void Save()
        {
            ShowShop.BLL.Product.Productclass data = new ShowShop.BLL.Product.Productclass();
            ShowShop.Model.Product.Productclass model = new ShowShop.Model.Product.Productclass();
            model.ID = ChangeHope.Common.StringHelper.StringToInt(this.ddlTheirclass.SelectedValue);
            model.Fatherid = ChangeHope.Common.StringHelper.StringToInt(this.hffatherid.Value);
            model.Name = this.txtName.Text;
            model.Description = this.txtDescription.Text;
            model.Sort = ChangeHope.Common.StringHelper.StringToInt(this.txtSort.Text);
           // model.Isrecommend = ChangeHope.Common.StringHelper.StringToInt(this.rdolstIsRecommend.SelectedValue);
            model.Parentpath = this.hfparentpath.Value;
            //model.Contenttemplate = this.txtContentPageTemplate.Text;
            //model.Listtemplate = this.txtListPageTemplate.Text;
            //model.Sectiontemplate = this.txtWebPagePath.Text;
            //model.ProductTypeId = Convert.ToInt32(this.ddlProductType.SelectedValue);
            if (model.ID > 0)
            {
                ShowShop.Common.PromptInfo.Popedom("001001004", "对不起，您没有权限进行编辑");
                data.Update(model);
                this.ltlMsg.Text = "操作成功， 已保存该信息.";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";
               
                
            }
            else
            {
                ShowShop.Common.PromptInfo.Popedom("001001002", "对不起，您没有权限进行新增");
                data.Add(model);
                this.ltlMsg.Text = "操作成功，已保存该信息.";
                this.pnlMsg.Visible = true;
                this.pnlMsg.CssClass = "actionOk";

            }
        }

        //protected void BindProductType()
        //{
        //    ShowShop.BLL.Product.ProductType bll = new ShowShop.BLL.Product.ProductType();
        //    List<ShowShop.Model.Product.ProductType> list = bll.GetAllByWhere("");
        //    if (list.Count > 0)
        //    {
        //        this.ddlProductType.Items.Add(new ListItem("通用商品类型", "0"));
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            this.ddlProductType.Items.Add(new ListItem(list[i].TypeName, list[i].Id.ToString()));
        //        }
        //    }
        //}
    }
}
