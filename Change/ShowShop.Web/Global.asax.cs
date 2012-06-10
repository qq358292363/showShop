using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ShowShop.Model;
using System.Web.Profile;
using System.Diagnostics;
using ShowShop.BLL.Order;
using ShowShop.Model.Order;


namespace ShowShop.Web
{
    
    public class Global : System.Web.HttpApplication
    {
        void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs e)
        {
            ProfileCommon Profile = new ProfileCommon();
            ProfileCommon anonProfile = Profile.GetProfile(e.AnonymousID);
            foreach (CartItemInfo cartItem in anonProfile.ShoppingCart.CartItems)
                Profile.ShoppingCart.Add(cartItem);

            foreach (CartItemInfo cartItem in anonProfile.WishList.CartItems)
                Profile.WishList.Add(cartItem);

            ProfileManager.DeleteProfile(e.AnonymousID);
            AnonymousIdentificationModule.ClearAnonymousIdentifier();

            Profile.Save();
        }

        private static string LOG_SOURCE = ConfigurationManager.AppSettings["Event Log Source"];
        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception x = Server.GetLastError().GetBaseException();
            //EventLog.WriteEntry(LOG_SOURCE, x.ToString(), EventLogEntryType.Error);
        }

        #region SQL注入式攻击代码分析
        ///<summary>
        ///防止SQL注入
        ///</summary>
        ///<param ></param>
        ///<param ></param>
        void Application_BeginRequest(Object sender, EventArgs e)
        {
            StartProcessRequest();

        }
        
        ///<summary>
        ///处理用户提交的请求 
        ///</summary>
        private void StartProcessRequest()
        {
            try
            {
                string getkeys = "";
                if (System.Web.HttpContext.Current.Request.QueryString != null)
                {

                    for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys]))
                        {
                            ChangeHope.WebPage.Script.Alert("请输入安全字符,谢谢！");
                           System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
                if (System.Web.HttpContext.Current.Request.Form != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                        if (getkeys == "__VIEWSTATE") continue;
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.Form[getkeys]))
                        {
                            ChangeHope.WebPage.Script.Alert("请输入安全字符,谢谢！");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
            }
            catch
            {
                // 错误处理: 处理用户提交信息! 
            }
        }
        ///<summary>
        ///分析用户请求是否正常 
        ///</summary>
        ///<param >传入用户提交数据 </param>
        ///<returns>返回是否含有SQL注入式攻击代码 </returns>
        private bool ProcessSqlStr(string Str)
        {
            bool ReturnValue = true;
            try
            {
                if (Str.Trim() != "")
                {
                    string SqlStr = "and .exec .insert .delete .update .count .* .chr .mid .master .truncate .char .declare";

                    string[] anySqlStr = SqlStr.Split('.');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.ToLower().IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
        #endregion
    }
}