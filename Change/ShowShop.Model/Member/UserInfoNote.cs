using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Member
{
    [Serializable]
   public class UserInfoNote
   {
       #region model
        private int _id;
        private int? _userid;
        private decimal? _ticketcount;
        private string _causation;
        private string _bosomnote;
        private DateTime? _notedate;
        private string _notename;
        private int? _notetype;
        private int? _buckleoradd;
        private string _username;

       

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 修改数
        /// </summary>
        public decimal? TicketCount
        {
            set { _ticketcount = value; }
            get { return _ticketcount; }
        }
        /// <summary>
        /// 原因
        /// </summary>
        public string Causation
        {
            set { _causation = value; }
            get { return _causation; }
        }
        /// <summary>
        /// 内部记录
        /// </summary>
        public string BosomNote
        {
            set { _bosomnote = value; }
            get { return _bosomnote; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? NoteDate
        {
            set { _notedate = value; }
            get { return _notedate; }
        }
        /// <summary>
        /// 录入人
        /// </summary>
        public string NoteName
        {
            set { _notename = value; }
            get { return _notename; }
        }
        /// <summary>
        /// 信息类型
        /// </summary>
        public int? NoteType
        {
            set { _notetype = value; }
            get { return _notetype; }
        }
        /// <summary>
        /// (0为增加,1为扣除)
        /// </summary>
        public int? BuckleOrAdd
        {
            set { _buckleoradd = value; }
            get { return _buckleoradd; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
       #endregion
   }
}
