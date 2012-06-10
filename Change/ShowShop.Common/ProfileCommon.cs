using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Profile;


namespace ShowShop.Web
{
    public class ProfileCommon : System.Web.Profile.ProfileBase
    {
        public virtual ShowShop.BLL.Order.Cart ShoppingCart
        {
            get
            {
                return ((ShowShop.BLL.Order.Cart)(HttpContext.Current.Profile.GetPropertyValue("ShoppingCart")));
            }
            set
            {
                this.SetPropertyValue("ShoppingCart", value);
            }
        }

        public virtual ShowShop.BLL.Order.Cart WishList
        {
            get
            {
                return ((ShowShop.BLL.Order.Cart)(HttpContext.Current.Profile.GetPropertyValue("WishList")));
            }
            set
            {
                this.SetPropertyValue("WishList", value);
            }
        }

        public virtual ProfileCommon GetProfile(string username)
        {
            return ((ProfileCommon)(ProfileBase.Create(username)));


        }
    }
}
