using System;
namespace ShowShop.Model.Member
{
    /// <summary>
    /// 短消息内容实体类
    /// </summary>
    [Serializable]
    public class MailInfo
    {
        public MailInfo()
        {
        }

        #region Model
        private int id;
        private string sender;
        private DateTime? sendtime;
        private string sendip;
        private string title;
        private string body;
        private int? stat;
        /// <summary>
        /// 主键自增
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 发送人
        /// </summary>
        public string Sender
        {
            set { sender = value; }
            get { return sender; }
        }
        /// <summary>
        /// 发送日期
        /// </summary>
        public DateTime? SendTime
        {
            set { sendtime = value; }
            get { return sendtime; }
        }
        /// <summary>
        /// 发送者的IP
        /// </summary>
        public string SendIp
        {
            set { sendip = value; }
            get { return sendip; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body
        {
            set { body = value; }
            get { return body; }
        }
        /// <summary>
        /// 状态 0发件箱 1草稿箱 2已删除
        /// </summary>
        public int? Stat
        {
            set { stat = value; }
            get { return stat; }
        }
        #endregion Model
    }
}
