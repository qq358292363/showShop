using System;
using System.Text;
using ShowShop.IDAL.Accessories;
namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        /// <summary>
        /// 广告管理
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.IAdvertiseManage CreateAdvertiseManage()
        {
            return (IAdvertiseManage)CreateObject("Accessories.AdvertiseManage");
        }
       
        /// <summary>
        /// 友情链接
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.IHailhellowlink CreateHailhellowlink()
        {
            return (IHailhellowlink)CreateObject("Accessories.Hailhellowlink");
        }

        /// <summary>
        /// 缺货登记
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.IOutofstock CreateOutofstock()
        {
            return (IOutofstock)CreateObject("Accessories.Outofstock");
        }

        /// <summary>
        /// 收藏管理
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.ICollection CreateCollection()
        {
            return (ICollection)CreateObject("Accessories.Collection");
        }

        /// <summary>
        /// 留言管理
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.ILeaveword CreateLeaveword()
        {
            return (ILeaveword)CreateObject("Accessories.Leaveword");
        }
        /// <summary>
        /// 点评表单管理
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.ICommentForm CreateCommentForm()
        {
            return (ICommentForm)CreateObject("Accessories.CommentForm");
        }
        /// <summary>
        /// 点评信息
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.ICommentInfo CreateCommentInfo()
        {
            return (ICommentInfo)CreateObject("Accessories.CommentInfo");
        }
        /// <summary>
        /// 点评回复信息
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.ICommentReply CreateCommentReply()
        {
            return (ICommentReply)CreateObject("Accessories.CommentReply");
        }

        /// <summary>
        /// 热门搜索
        /// </summary>
        /// <returns></returns>
        public static ShowShop.IDAL.Accessories.ITop_Searches CreateTop_Searches()
        {
            return (ITop_Searches)CreateObject("Accessories.Top_Searches");
        }

        ///// <summary>
        ///// 自定义会员注册
        ///// </summary>
        ///// <returns></returns>
        //public static ShowShop.IDAL.Accessories.IMemberPropety CreateMemberPropety()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
