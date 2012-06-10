using System;
namespace ShowShop.Model.Member
{
    /// <summary>
    /// 短消息实体类
    /// </summary>
    [Serializable]
    public class Message
    {
        public Message()
		{}
		#region Model
		private int id;
		private int uid;
		private string userid;
		private string title;
		private string content;
		private string adminid;
		private DateTime? sendtime;
		private int? state;
		private int? isread;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ id=value;}
			get{return id;}
		}
		/// <summary>
		/// 用户的ID
		/// </summary>
		public int UID
		{
			set{ uid=value;}
			get{return uid;}
		}
		/// <summary>
		/// 用户账号
		/// </summary>
		public string UserId
		{
			set{ userid=value;}
			get{return userid;}
		}
		/// <summary>
		/// 短消息标题
		/// </summary>
		public string Title
		{
			set{ title=value;}
			get{return title;}
		}
		/// <summary>
		/// 短消息内容
		/// </summary>
		public string Content
		{
			set{ content=value;}
			get{return content;}
		}
		/// <summary>
		/// 发送人
		/// </summary>
		public string AdminId
		{
			set{ adminid=value;}
			get{return adminid;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime? SendTime
		{
			set{ sendtime=value;}
			get{return sendtime;}
		}
		/// <summary>
		/// 状态  0 草稿箱  1 收件箱 2 发件箱 3 废件箱
		/// </summary>
		public int? State
		{
			set{ state=value;}
			get{return state;}
		}
		/// <summary>
		/// 是否阅读 0否 1是
		/// </summary>
		public int? IsRead
		{
			set{ isread=value;}
			get{return isread;}
		}
		#endregion Model
    }
}
