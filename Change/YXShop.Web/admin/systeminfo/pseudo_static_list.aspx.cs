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
    public partial class pseudo_static_list : System.Web.UI.Page
    {
        public DataSet dsSrc = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.SysParameter ss = new ShowShop.Common.SysParameter();
                BindData();
            }
        }
        /// <summary>
        /// 绑定xml
        /// </summary>
        public void BindData()
        {
            #region 绑定伪静态url的替换规则
            DataGrid1.AllowCustomPaging = false;
            DataGrid1.DataKeyField = "name";
            dsSrc.ReadXml(Server.MapPath("../xml/siteurls.xml"));
            DataGrid1.DataSource = dsSrc.Tables[0];
            DataGrid1.DataBind();
            #endregion
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void DataGrid1_EditCommand(object source, DataGridCommandEventArgs e)
        {

            #region 编辑伪静态Url替换规则
            DataGrid1.EditItemIndex = e.Item.ItemIndex;
            hdf_key.Value = e.Item.Cells[0].Text;

            dsSrc.Reset();
            dsSrc.ReadXml(Server.MapPath("../xml/siteurls.xml"));
            DataGrid1.DataSource = dsSrc.Tables[0];
            DataGrid1.DataBind();

            #endregion
        }

        /// <summary>
        /// 取消编辑 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void DataGrid1_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            #region 取消编辑
            DataGrid1.EditItemIndex = -1;
            dsSrc.Reset();
            dsSrc.ReadXml(Server.MapPath("../xml/siteurls.xml"));
            DataGrid1.DataSource = dsSrc.Tables[0];
            DataGrid1.DataBind();
            #endregion
        }
        /// <summary>
        /// 更新Xml
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void DataGrid1_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            #region url 内容更新

            string name = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
            string path = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
            string pattern = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            string page = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
            string querystring = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
            //     = dr["name"].;
            dsSrc.Reset();
            dsSrc.ReadXml(Server.MapPath("../xml/siteurls.xml"));

            foreach (DataRow dr in dsSrc.Tables["rewrite"].Rows)
            {
                if (name == dr["name"].ToString().Trim())
                {


                    dr["name"] = name;
                    dr["path"] = path;
                    dr["pattern"] = pattern;
                    dr["page"] = page;
                    dr["querystring"] = querystring;

                }
            }

            try
            {
                dsSrc.ReadXml(Server.MapPath("../xml/siteurls.xml"));
                dsSrc.Reset();
                dsSrc.Dispose();

                UpdateElement(hdf_key.Value, name, path, pattern, page, querystring);

                DataGrid1.EditItemIndex = -1;
                dsSrc.Reset();
                dsSrc.ReadXml(Server.MapPath("../xml/siteurls.xml"));
                DataGrid1.DataSource = dsSrc.Tables[0];
                DataGrid1.DataBind();
            }
            catch
            {
                ChangeHope.WebPage.Script.Alert("没有读写文件的权限！");

            }

            #endregion
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
        //修改节点
        private void UpdateElement(string key, string name, string path, string pattern, string page, string querystring)
        {
            LoadXml();

            XmlNode root = xmlDoc.SelectSingleNode("SiteUrls");
            foreach (XmlNode n in root.ChildNodes)//遍历所有子节点
            {

                XmlElement xe = (XmlElement)n;//将子节点类型转换为XmlElement类型
                if (xe.GetAttribute("name") == key)
                {
                    //添加节点
                    string s = xe.Attributes["name"].Value;
                    xe.SetAttribute("name", name);
                    xe.SetAttribute("path", path);
                    xe.SetAttribute("pattern", pattern);
                    xe.SetAttribute("page", page);
                    xe.SetAttribute("querystring", querystring);

                  break;
                }
            }

            xmlDoc.Save(Server.MapPath("../xml/siteurls.xml"));//保存

        }
        /// <summary>
        /// 执行接点删除操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void DataGrid1_DeleteCommand(object source, DataGridCommandEventArgs e)
        {

            deleteNode(e.Item.Cells[0].Text);
            BindData();
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
            xmlDoc.Save(Server.MapPath("../xml/siteurls.xml"));
        }
       
        //删出节点 
        private void deleteNode(string name)
        {

            LoadXml();
            XmlNodeList xnl = xmlDoc.SelectSingleNode("SiteUrls").ChildNodes;

            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;

                if (xe.GetAttribute("name") == name)
                {
                    xe.ParentNode.RemoveChild(xe);
                    break;
                }
            }
            xmlDoc.Save(Server.MapPath("../xml/siteurls.xml"));//保存 
        }
    }
}

