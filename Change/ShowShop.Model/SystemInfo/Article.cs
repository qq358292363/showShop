using System;
namespace ShowShop.Model.SystemInfo
{
    /// <summary>
    /// 实体类Article 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Article
    {
        public Article()
        { }
        #region Model
        private int _id;
        private string _channel;
        private string _title;
        private string _subtitle;
        private string _keyword;
        private string _content;
        private string _copyfrom;
        private string _linkurl;
        private string _author;
        private string _users;
        private string _editor;
        private int? _hits;
        private string _introduction;
        private DateTime? _createtime;
        private DateTime? _updatetime;
        private bool _istop;
        private bool _iselite;
        private bool _ispic;
        private bool _ispagetype;
        private int? _state;
        private string _area;
        private string _property;
        private string _imagesaddress;
        private int _imagessoure;
        private int _browseCount;
        /// <summary>
        /// 文章ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 频道ID
        /// </summary>
        public string Channel
        {
            set { _channel = value; }
            get { return _channel; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImagesAddress
        {
            set { _imagesaddress = value; }
            get { return _imagesaddress; }
        }
        /// <summary>
        /// 图片来源
        /// </summary>
        public int ImagesSoure
        {
            set { _imagessoure = value; }
            get { return _imagessoure; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int BrowseCount
        {
            set { _browseCount = value; }
            get { return _browseCount; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string CopyFrom
        {
            set { _copyfrom = value; }
            get { return _copyfrom; }
        }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Users
        {
            set { _users = value; }
            get { return _users; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string Editor
        {
            set { _editor = value; }
            get { return _editor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction
        {
            set { _introduction = value; }
            get { return _introduction; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 是否置顶0否1是
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 是否精华0否1是
        /// </summary>
        public bool IsElite
        {
            set { _iselite = value; }
            get { return _iselite; }
        }
        /// <summary>
        /// 是否图片信息0否1是
        /// </summary>
        public bool IsPic
        {
            set { _ispic = value; }
            get { return _ispic; }
        }
        /// <summary>
        /// 是否分页0否1是
        /// </summary>
        public bool IsPageType
        {
            set { _ispagetype = value; }
            get { return _ispagetype; }
        }
        /// <summary>
        /// 状态 （是否审核）0否1是
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 文章属性
        /// </summary>
        public string Property
        {
            set { _property = value; }
            get { return _property; }
        }

        #endregion Model

    }
}

