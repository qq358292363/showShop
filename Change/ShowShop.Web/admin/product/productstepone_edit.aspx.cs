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

namespace ShowShop.Web.admin.product
{
    public partial class productstepone_edit : System.Web.UI.Page
    {
        ShowShop.BLL.Product.Productclass bll = new ShowShop.BLL.Product.Productclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("001008002");
                if (Request.Form["Option"] != null && !Request.Form["Option"].Trim().Equals("")
                                && Request.Form["ID"] != null && !Request.Form["ID"].Trim().Equals(""))
                {
                    string types = Request.Form["Option"].Trim();
                    if (types == "first")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());
                        secondClass(id);
                    }
                    else if (types == "Secondarry")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());
                        thirdClass(id);
                    }
                    else if (types == "thirdarry")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());
                        fourClass(id);
                    }
                    else if (types == "Vali")
                    {
                        int id = Convert.ToInt32(Request.Form["ID"].Trim());
                        Vali(id);
                    }
                    Response.End();
                    return;
                }
                ClassList(0);
                
            }
        }
        #region 绑定产品分类

        #region 绑定一级分类
        /// <summary>
        /// 绑定一级分类
        /// </summary>
        /// <param name="CID"></param>
        protected void ClassList(int CID)
        {

            DataTable dt = bll.GetFatherList(CID);
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select id=\"firstClass\" name=\"firstClass\" size=\"18\"  style=\"width:180px\" onchange=\"firstarry(this.value);OptionValue(this.value);\">");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    shtml.Append("<option value=" + dt.Rows[i]["cid"].ToString() + " >" + dt.Rows[i]["name"].ToString() + "</option>");
                }
            }
            shtml.Append("</select>");
            this.lrafirstClass.Text = shtml.ToString();
        }
        #endregion

        #region 绑定二级分类
        private void secondClass(int CID)
        {
            DataTable dt = bll.GetFatherList(CID);
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select id=\"secondClass\" name=\"secondClass\" size=\"18\"  style=\"width:180px\" onchange=\"Secondarry(this.value);OptionValue(this.value);\">");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    shtml.Append("<option value=" + dt.Rows[i]["cid"].ToString() + " >" + dt.Rows[i]["name"].ToString() + "</option>");
                }
            }
            shtml.Append("</select>");
            Response.Write(shtml.ToString());
        }
        #endregion

        #region 绑定三级分类
        private void thirdClass(int CID)
        {
            DataTable dt = bll.GetFatherList(CID);
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select id=\"thirdClass\" name=\"thirdClass\" size=\"18\"  style=\"width:180px\" onchange=\"thirdarry(this.value);OptionValue(this.value);\">");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    shtml.Append("<option value=" + dt.Rows[i]["cid"].ToString() + " >" + dt.Rows[i]["name"].ToString() + "</option>");
                }
            }
            shtml.Append("</select>");
            Response.Write(shtml.ToString());
        }
        #endregion

        #region 绑定四级及以下分类
        private void fourClass(int CID)
        {
            string KG = "";
            ShowShop.Model.Product.Productclass model = bll.GetModelID(CID);
            StringBuilder shtml = new StringBuilder();
            shtml.Append("<select id=\"thirdClass\" name=\"thirdClass\" size=\"18\" onchange=\"OptionValue(this.value);\" style=\"width:180px\">");
            if (model != null)
            {
                string ParentPath = model.Parentpath.ToString() + "," + model.ID.ToString();
                DataTable dt = bll.GetBlurList(ParentPath);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        KG = "";
                        string[] Path = dt.Rows[i]["parentpath"].ToString().Split(',');
                        for (int j = 1; j < Path.Length; j++)
                        {
                            KG += "&nbsp;&nbsp;";
                        }
                        shtml.Append("<option value=" + dt.Rows[i]["cid"].ToString() + " >" + KG + "" + dt.Rows[i]["name"].ToString() + "</option>");
                    }
                }
            }
            shtml.Append("</select>");
            Response.Write(shtml.ToString());
        }
        #endregion

        #region 验证产品分类是否是最后一级
        private void Vali(int CID)
        {
            DataTable dt = bll.GetFatherList(CID);
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
    }
}
