using System;
namespace ShowShop.Model.Accessories
{
    /// <summary>
    /// 留言实体类
    /// </summary>
    [Serializable]
    public class Leaveword
    {
        #region Model
        private int id;
        private int? type;
        private string username;
        private string telephone;
        private string qq;
        private string msn;
        private string email;
        private string title;
        private string ip;
        private int? isreguser;
        private string content;
        private DateTime? adddate;
        private int? isread;
        private string replycontent;
        private int? isreply;
        private DateTime? replydate;
        private int? isauditing;
        private int? storeid;
        private string address;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 留言类别（1：普通反馈；2：购物投诉；3：询问求购；4：售后咨询；5：加盟合作）
        /// </summary>
        public int? Type
        {
            set { type = value; }
            get { return type; }
        }
        /// <summary>
        /// 留言者姓名
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            set { telephone = value; }
            get { return telephone; }
        }
        /// <summary>
        /// 留言QQ
        /// </summary>
        public string QQ
        {
            set { qq = value; }
            get { return qq; }
        }
        /// <summary>
        /// 留言MSN
        /// </summary>
        public string MSN
        {
            set { msn = value; }
            get { return msn; }
        }
        /// <summary>
        /// 留言联系Email
        /// </summary>
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        /// <summary>
        /// 留言主题
        /// </summary>
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        /// <summary>
        /// 留言IP
        /// </summary>
        public string IP
        {
            set { ip = value; }
            get { return ip; }
        }
        /// <summary>
        /// 是否是注册会员的留言
        /// </summary>
        public int? IsRegUser
        {
            set { isreguser = value; }
            get { return isreguser; }
        }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string Content
        {
            set { content = value; }
            get { return content; }
        }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime? AddDate
        {
            set { adddate = value; }
            get { return adddate; }
        }
        /// <summary>
        /// 留言是否已经查看
        /// </summary>
        public int? IsRead
        {
            set { isread = value; }
            get { return isread; }
        }
        /// <summary>
        /// 留言回复内容
        /// </summary>
        public string ReplyContent
        {
            set { replycontent = value; }
            get { return replycontent; }
        }
        /// <summary>
        /// 留言是否已回复
        /// </summary>
        public int? IsReply
        {
            set { isreply = value; }
            get { return isreply; }
        }
        /// <summary>
        /// 留言回复时间
        /// </summary>
        public DateTime? ReplyDate
        {
            set { replydate = value; }
            get { return replydate; }
        }
        /// <summary>
        /// 留言是否已经通过审核
        /// </summary>
        public int? IsAuditing
        {
            set { isauditing = value; }
            get { return isauditing; }
        }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int? StoreId
        {
            set { storeid = value; }
            get { return storeid; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address
        {
             set{ address = value; }
            get { return address; }
        }
        #endregion Model
    }
}
