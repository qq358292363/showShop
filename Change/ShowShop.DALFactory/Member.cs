using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.IDAL.Member;

namespace ShowShop.DALFactory
{
    public sealed partial class DataAccess
    {
        /// <summary>
        /// 会员组
        /// </summary>
        /// <returns></returns>
        public static IMemberRank CreateMemberRank()
        {
            return (IMemberRank)CreateObject("Member.MemberRank");
        }
        /// <summary>
        /// 会员详细信息
        /// </summary>
        /// <returns></returns>
        public static IMemberInfo CreateMemberInfo()
        {
            return (IMemberInfo)CreateObject("Member.MemberInfo");
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        public static IMemberAccount CreateMemberAccount()
        {
            return (IMemberAccount)CreateObject("Member.MemberAccount");
        }

        /// <summary>
        /// 自定义会员注册
        /// </summary>
        /// <returns></returns>
        public static IMemberProperty CreateMemberProperty()
        {
            return (IMemberProperty)CreateObject("Member.MemberProperty");
        }


        /// <summary>
        /// 操作明细
        /// </summary>
        /// <returns></returns>
        public static IUserInfoNote CreateInfoNote()
        {
            return (IUserInfoNote)CreateObject("Member.UserInfoNote");
        }
        /// <summary>
        /// 短消息 
        /// </summary>
        /// <returns></returns>
        public static IMessage CreateMessage()
        {
            return (IMessage)CreateObject("Member.Message");
        }

        /// <summary>
        /// 银行汇款
        /// </summary>
        /// <returns></returns>
        public static IUserinAndExp CreateUserinAndExp()
        {
            return (IUserinAndExp)CreateObject("Member.UserinAndExp");
        }
        /// <summary>
        /// 会员积分
        /// </summary>
        /// <returns></returns>
        public static IIntegral CreateIntegral()
        {
            return (IIntegral)CreateObject("Member.Integral");
        }

        /// <summary>
        /// 短消息内容 
        /// </summary>
        /// <returns></returns>
        public static IMailinfo CreateMailinfo()
        {
            return (IMailinfo)CreateObject("Member.Mailinfo");
        }

        /// <summary>
        /// 短消息 收件信息
        /// </summary>
        /// <returns></returns>
        public static IMailReceiver CreateMailReceiver()
        {
            return (IMailReceiver)CreateObject("Member.MailReceiver");
        }

        /// <summary>
        /// 收货地址
        /// </summary>
        /// <returns></returns>
        public static IReceAddress CreateReceAddress()
        {
            return (IReceAddress)CreateObject("Member.ReceAddress");
        }

        /// <summary>
        /// 角色
        /// </summary>
        /// <returns></returns>
        public static IRole CreateRole()
        {
            return (IRole)CreateObject("Member.Role");
        }
        /// <summary>
        /// 角色值
        /// </summary>
        /// <returns></returns>
        public static IRoles_Permissions CreateRoles_Permissions()
        {
            return (IRoles_Permissions)CreateObject("Member.Roles_Permissions");
        }
    }
}
