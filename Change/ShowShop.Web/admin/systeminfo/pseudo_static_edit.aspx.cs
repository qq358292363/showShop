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
using System.Xml;

namespace ShowShop.Web.admin.systeminfo
{
    public partial class pseudo_static_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitWebControl();
            }
        }
        /// <summary>
        /// 验证
        /// </summary>
        private void InitWebControl()
        {
            ChangeHope.WebPage.WebControl.Validate(this.tb_name, "输入名称的名称,方便你区分", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.tb_path, "输入虚拟地址,将作为伪静态后的地址", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.tb_pattern, "输入虚拟规则", "isnull", "必填", "该项为必填项");
            ChangeHope.WebPage.WebControl.Validate(this.tb_page, "输入真实地址,将作为要伪静态的地址", "isnull", "必填", "该项为必填项");
            this.Form.Attributes.Add("onsubmit", "return CheckForm()");
        }
        /// <summary>
        /// 添加规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_add_Click(object sender, EventArgs e)
        {
            AddElement(tb_name.Text.ToString().Trim(), tb_path.Text.ToString().Trim() + DDL_Lastname.SelectedValue,
                tb_pattern.Text.ToString().Trim() + DDL_Lastname.SelectedValue,
            tb_page.Text.ToString().Trim(), tb_query.Text.ToString().Trim());
            Response.Redirect("pseudo_static_edit.aspx");
        }
        private XmlDocument xmlDoc;
        /// <summary>
        /// 加载xml文件
        /// </summary>
        private void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("../xml/siteurls.xml"));
        }
        /// <summary>
        /// 添加节点 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="pattern"></param>
        /// <param name="page"></param>
        /// <param name="querystring"></param>

        private void AddElement(string name, string path, string pattern, string page, string querystring)
        {

            LoadXml();

            XmlNode xmldocSelect = xmlDoc.SelectSingleNode("SiteUrls");

            XmlElement el = xmlDoc.CreateElement("rewrite"); //添加rewrite节点 
            el.SetAttribute("name", name); //添加rewrite节点的属性"name" 
            el.SetAttribute("path", path);   //添加rewrite节点的属性 "path" 
            el.SetAttribute("pattern", pattern);   //添加rewrite节点的属性 "pattern" 
            el.SetAttribute("page", page);//添加rewrite节点的属性 "page" 
            el.SetAttribute("querystring", querystring);//添加rewrite节点的属性 "querystring" 
            xmldocSelect.AppendChild(el);
            xmlDoc.Save(Server.MapPath("~/admin/xml/siteurls.xml"));
        }
    }
}
