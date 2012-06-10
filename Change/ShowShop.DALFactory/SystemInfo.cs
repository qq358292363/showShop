using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.SystemInfo;
namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.SystemInfo.IWebSetting CreateWebSetting()
        {
            return (IWebSetting)CreateObject("SystemInfo.WebSetting");
        }

   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.SystemInfo.ICustomerSetting CreateCustomerSetting()
        {
            return (ICustomerSetting)CreateObject("SystemInfo.CustomerSetting");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.SystemInfo.IMailSetting CreateMailSetting()
        {
            return (IMailSetting)CreateObject("SystemInfo.MailSetting");
        }

   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.SystemInfo.IProvinces CreateProvinces()
        {
            return (IProvinces)CreateObject("SystemInfo.Provinces");
        }
 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.SystemInfo.IArticleChannel CreateArticleChannel()
        {
            return (IArticleChannel)CreateObject("SystemInfo.ArticleChannel");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.SystemInfo.IArticle CreateArticle()
        {
            return (IArticle)CreateObject("SystemInfo.Article");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.SystemInfo.ITerraceManage CreateTerrace()
        {
            return (ITerraceManage)CreateObject("SystemInfo.TerraceManage");
        }
       
    

   

      

        /// <summary>
        /// 送货方式
        /// </summary>
        /// <returns></returns>
        public static IDeliver CreateDeliverWay()
        {
            return (IDeliver)CreateObject("SystemInfo.Deliver");
        }
      
    }
}
