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

namespace ShowShop.Web.Admin
{
    public partial class index : System.Web.UI.Page
    {
        protected string WebName;
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!this.Page.IsPostBack)
           {
               ShowShop.Common.SysParameter sp = new ShowShop.Common.SysParameter();
               WebName = sp.WebSiteName; 
           }
        }

        public string message = "";
        protected void Login_Click(object sender, ImageClickEventArgs e)
        {
            ShowShop.BLL.Admin.AdminLoginLog log = new ShowShop.BLL.Admin.AdminLoginLog();
            ShowShop.Model.Admin.AdminLoginLog logModel = new ShowShop.Model.Admin.AdminLoginLog();
            
            //检查填写的表单
            if (!CheckForm())
            {
                return;
            }
            //系统登陆
            string userLoginName = this.txtUserLoginName.Text;
            string userLoginPwd = this.txtUserLoginPwd.Text;
            userLoginPwd = ChangeHope.Common.DEncryptHelper.Encrypt(userLoginPwd, 1);
            bool loginResult = false;
            ShowShop.BLL.Admin.Administrators administrators = new ShowShop.BLL.Admin.Administrators();
            loginResult = this.AdminLogin(userLoginName, userLoginPwd);
            if (!loginResult)
            {
                ChangeHope.WebPage.Script.Alert("温馨提示:"+message);
            }
            logModel.OperateNote = message;
            administrators = null;

            //写入日志
            logModel.HostComputerName = Request.UserHostName;
            logModel.LoginInTime = System.DateTime.Now;
            logModel.LoginIp = Request.UserHostAddress;
            logModel.LoginOutTime = System.DateTime.Now;
            logModel.PassWord = userLoginPwd;
            logModel.AdminName = userLoginName;
            log.Add(logModel);
            logModel = null;
            log = null;

            if (loginResult)
            {
                this.Response.Redirect("admin_index.aspx");
            }
        }
        /// <summary>
        /// 系统管理员登陆系统
        /// </summary>
        /// <param name="adminName"></param>
        /// <param name="adminPwd"></param>
        /// <returns></returns>
        public bool AdminLogin(string adminName, string adminPwd)
        {
            ShowShop.BLL.Admin.Administrators bll = new ShowShop.BLL.Admin.Administrators();
            ShowShop.Model.Admin.Administrators model = bll.GetModelByAdminName(adminName);
            //无数据
            if (model == null)
            {
                message = "用户名错误!";
                return false;
            }
            //密码错误
            if (!model.PassWord.ToLower().Equals(adminPwd.ToLower()))
            {
                message = "密码错误!";
                model = null;
                return false;
            }

            //帐号被冻结
            if (model.State.Equals(1))
            {
                message = "您输入的账户以被冻结!";
                model = null;
                return false;
            }

            //帐号已经过期
            if (model.ManageEndTime < DateTime.Now)
            {
                message = "你的帐户已经过期!";
                model = null;
                return false;
            }

            //初始化权限
            ShowShop.Model.Admin.AdminInfo admin = new ShowShop.Model.Admin.AdminInfo();
            if (model.Power.Equals(0))
            {
                admin.AdminPowerType = "all";
            }
            else
            {
                //非管理员权限，等待添加相关内容
                admin.AdminPowerType = "";
            }

            admin.AdminId = model.AdminId;
            admin.AdminName = model.Name;
            admin.AdminRole = model.Role;
            ShowShop.Common.AdministrorManager.Set(admin);
            admin = null;
            message = "登陆成功!";
            return true;
        }

       
        /// <summary>
        /// 检查表单
        /// </summary>
        private bool CheckForm()
        {
            string message = "";
            //检查浏览器是否打开Cookies
            if (Request.Cookies["CheckCode"] == null)
            {
                message = "您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统。";
                ChangeHope.WebPage.Script.Alert(message);
                return false;
            }

            //检查验证码
            if (!Request.Cookies["CheckCode"].Value.Equals(txtCheckCode.Text.ToUpper()))
            {
                message = "温馨提示：验证码错误";
                ChangeHope.WebPage.Script.Alert(message);
                return false;
            }

            //系统登陆
            string userLoginName = this.txtUserLoginName.Text;
            string userLoginPwd = this.txtUserLoginPwd.Text;

            if (userLoginName.Equals("") || userLoginPwd.Equals(""))
            {
                message = "温馨提示：用户名或者密码为空";
                return false;
            }
            return true;
        }
    }
}
