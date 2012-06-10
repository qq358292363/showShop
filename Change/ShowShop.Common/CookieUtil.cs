using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ChangeHope.Common;
using System.Net;


namespace ShowShop.Common
{
    public class CookieUtil
    {
        private static string HISTORY_NAME  = "history_"; //Cookie中，历史浏览前缀名
        private static string HISTORY_PATH = "/";  //历史浏览的Cookie的路径

       // 清除所有商品的浏览记录
        public static void RemoveAllHistoryCookie()
        {
              HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
              if (null == cookies || cookies.Count == 0)
              {
                 return;
              }
  
              for (int i = 0; i < cookies.Count; i++)
              {
                  HttpCookie thisCookie = cookies[i];
                  if (thisCookie.Name.StartsWith(HISTORY_NAME))
                  {
                      thisCookie.Expires = System.DateTime.Now.AddHours(-1); // 删除这个cookie
                      thisCookie.Path = HISTORY_PATH;
                      HttpContext.Current.Response.Cookies.Add(thisCookie);
                  }
              }
        }
        // 清除单个商品的浏览记录
        public static void RemoveHistoryCookie(string waraId)
        {
            if(waraId==null)
            {
                return;
            }
            HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
            if(cookies==null || cookies.Count==0)
            {
                return;
            }
            for (int i = 0; i < cookies.Count; i++)
            {
                HttpCookie cookie = cookies[i];
                if(cookie.Name.Equals(HISTORY_NAME+waraId.ToString()))
                {
                    cookie.Expires = System.DateTime.Now.AddHours(-1);
                    cookie.Path = HISTORY_PATH;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    break;
                }        
            }

        }

        //加入单个商品浏览记录到cookie(有效期10天)
        public static void SetHistoryCookie(string wareId)
        {
            if(wareId==null)
            {
                return;
            }
            string cookieName = HISTORY_NAME + wareId.ToString();
            HttpCookie cookie = new HttpCookie(cookieName,wareId.ToString());
            cookie.Path = HISTORY_PATH;
            cookie.Expires = System.DateTime.Now.AddDays(10);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

       //添加商品浏览记录/判断是否存在/是否超出/
        public static void AddHistoryCookie(string wareId)
        {
            if(wareId==null)
            {
                return;
            }
            int number = 10;//页面商品显示的个数（默认显示10）
            string cookieName = HISTORY_NAME + wareId.ToString();
            HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
            int historyCookieNum = 0; //历史浏览的当前 cookie 数目
            if(cookies!=null&&cookies.Count>0)
            {
                for (int i = 0; i < cookies.Count; i++)
                {
                    HttpCookie cookie = cookies[i];
                    if(cookie.Name.StartsWith(HISTORY_NAME))
                    {
                        historyCookieNum++;
                    }
                }
            }
            //历史记录小于显示规定数目
            if(historyCookieNum<number)
            {   
                //记录是否存在相同的商品
                string flag = "no";
                for (int i = 0; i < cookies.Count; i++)
                {
                    HttpCookie item = cookies[i];
                     if(item.Name.Equals(cookieName))
                     {
                         RemoveHistoryCookie(wareId);
                         SetHistoryCookie(wareId);
                         flag = "yes";
                         break;
                     }
                }
                //cookie中不存在则直接加入cookie
                if(flag.Equals("no"))
                {
                    SetHistoryCookie(wareId);
                }

            }
            //等于显示数目的时候移去最旧一个记录 加入新的记录
            if(historyCookieNum==number)
            {
                //存放当前的历史cookie
                List<string> list = new List<string>();
                for (int i = 0; i < cookies.Count; i++)
                {
                    HttpCookie thisCookie = cookies[i];
                     if(thisCookie.Name.StartsWith(HISTORY_NAME))
                     {
                         string oldWareId = thisCookie.Value.ToString();
                         list.Add(oldWareId);
                     }
                }
                //判断（防止详细页面不断刷新调用add方法）
                if (list.Contains(wareId.ToString()))
                {
                    RemoveHistoryCookie(wareId);
                    SetHistoryCookie(wareId);
                }
                else
                {
                    for (int i = 0; i < cookies.Count; i++)
                    {
                        HttpCookie item = cookies[i];
                        //去掉第一条旧的历史记录
                        if (item.Name.StartsWith(HISTORY_NAME))
                        {
                            string oldWaraId = item.Value.ToString(); //旧商品ID
                            RemoveHistoryCookie(oldWaraId);
                            SetHistoryCookie(wareId);
                            break;
                        }
                    }
                }
            }
        } 
        //获取所有Cookie
        public static List<string> GetAllHistoryCookie()
        {
            List<string> list = new List<string>();
            HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
            for (int i = cookies.Count-1; i > 0 ; i--)
            {
                HttpCookie item = cookies[i];
                 if(item.Name.StartsWith(HISTORY_NAME))
                 {                      
                     string productId = item.Value.ToString();
                     if(list.Contains(productId))
                     {
                         continue;
                     }
                     list.Add(productId);
                 }
            }
            return list;
        }
    }
}
