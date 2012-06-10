using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Accessories
{
    public class CommentInfo
    {
        #region "member variant"
        private int _id;
        private int _type;
        private string _username;
        private int _uid;
        private int _isreguser;
        private int _grade;
        private string _tag;
        private string _title;
        private string _contentlist;
        private Nullable<DateTime> _commenttime;
        private int _commentid;
        private int _againstnum;
        private int _supportnum;
        private int _flowernum;
        #endregion

        #region "Constructor"
        public CommentInfo()
        {}
        #endregion

        #region "Property"
        /// <summary>
        /// 与数据库基本列ID相对应的公共属性, Caption:id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 与数据库基本列Type相对应的公共属性, Caption:点评类型
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 与数据库基本列UserName相对应的公共属性, Caption:点评类型
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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
        /// 与数据库基本列IsReguser相对应的公共属性, Caption:是否是注册会员
        /// </summary>
        public int IsReguser
        {
            set { _isreguser = value; }
            get { return _isreguser; }
        }
        /// <summary>
        /// 与数据库基本列Grade相对应的公共属性, Caption:评分
        /// </summary>
        public int Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        ///  与数据库基本列title相对应的公共属性, Caption:标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        ///  与数据库基本列Tag相对应的公共属性, Caption:标签
        /// </summary>
        public string Tag
        {
            set { _tag = value; }
            get { return _tag; }
        }
        /// <summary>
        ///  与数据库基本列ContentList相对应的公共属性, Caption:扩展内容
        /// </summary>
        public string ContentList
        {
            set { _contentlist = value; }
            get { return _contentlist; }
        }
        /// <summary>
        /// 与数据库基本列CommentTime相对应的公共属性, Caption:评论时间
        /// </summary>
        public Nullable<DateTime> CommentTime
        {
            set { _commenttime = value; }
            get { return _commenttime; }
        }
        /// <summary>
        /// 与数据库基本列CommentID相对应的公共属性, Caption:评论项ID
        /// </summary>
        public int CommentID
        {
            set { _commentid = value; }
            get { return _commentid; }
        }
        /// <summary>
        /// 与数据库基本列Againstnum相对应的公共属性, Caption:反对数
        /// </summary>
        public int Againstnum
        {
            set { _againstnum = value; }
            get { return _againstnum; }
        }
        /// <summary>
        /// 与数据库基本列SupportNum相对应的公共属性, Caption:支持数
        /// </summary>
        public int SupportNum
        {
            set { _supportnum = value; }
            get { return _supportnum; }
        }
        /// <summary>
        /// 与数据库基本列FlowerNum相对应的公共属性, Caption:FlowerNum
        /// </summary>
        public int FlowerNum
        {
            set { _flowernum = value; }
            get { return _flowernum; }
        }
        #endregion
    }
}
