using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Accessories
{
    public class CommentReply
    {
         #region "member variant"
        private int _rid;
        private int _commentid;
        private int _uid;
        private string _content;
        private Nullable<DateTime> _replytime;
        #endregion

        #region "Constructor"
        public CommentReply()
        {}
        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列RID相对应的公共属性, Caption:rid
        /// </summary>
        public int RID
        {
            set { _rid = value; }
            get { return _rid; }
        }
        /// <summary>
        /// 与数据库基本列UID相对应的公共属性, Caption:会员ID
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        
        /// <summary>
        ///  与数据库基本列Content相对应的公共属性, Caption:扩展内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 与数据库基本列CommentTime相对应的公共属性, Caption:评论时间
        /// </summary>
        public Nullable<DateTime> ReplyTime
        {
            set { _replytime = value; }
            get { return _replytime; }
        }
        /// <summary>
        /// 与数据库基本列CommentID相对应的公共属性, Caption:评论项ID
        /// </summary>
        public int CommentID
        {
            set { _commentid = value; }
            get { return _commentid; }
        }
        #endregion
    }
}
