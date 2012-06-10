using System;
namespace ShowShop.Model.SystemInfo
{
    /// <summary>
    /// 实体类ArticleChannel 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ArticleChannel
    {
        public ArticleChannel()
        { }
        #region Model
        private string _id;
        private string _name;
        private string _shop;
        private string _users;
        private string _description;
        private string _type;
        private string _projectname;
        private string _projectutil;
        private string _target;
        private string _externallink;
        private string _metekey;
        private string _metedescription;
        private string _power;
        private string _defaulttemplate;
        private string _listtemplate;
        private string _contenttemplate;
        /// <summary>
        /// 栏目ID
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 栏目名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 频道类别
        /// </summary>
        public string Shop
        {
            set { _shop = value; }
            get { return _shop; }
        }
        /// <summary>
        /// 录入人
        /// </summary>
        public string Users
        {
            set { _users = value; }
            get { return _users; }
        }
        /// <summary>
        /// 栏目描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 栏目类型
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 项目名
        /// </summary>
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        /// <summary>
        /// 项目单位
        /// </summary>
        public string ProjectUtil
        {
            set { _projectutil = value; }
            get { return _projectutil; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// 外部链接
        /// </summary>
        public string ExternalLink
        {
            set { _externallink = value; }
            get { return _externallink; }
        }
        /// <summary>
        /// MeteKey
        /// </summary>
        public string MeteKey
        {
            set { _metekey = value; }
            get { return _metekey; }
        }
        /// <summary>
        /// Mete描述
        /// </summary>
        public string MeteDescription
        {
            set { _metedescription = value; }
            get { return _metedescription; }
        }
        /// <summary>
        /// 用户组权限
        /// </summary>
        public string Power
        {
            set { _power = value; }
            get { return _power; }
        }
        /// <summary>
        /// 栏目首页模板
        /// </summary>
        public string DefaultTemplate
        {
            set { _defaulttemplate=value; }
            get { return _defaulttemplate; }
        }
        /// <summary>
        /// 内容页模板
        /// </summary>
        public string ContentTemplate
        {
            set { _contenttemplate = value; }
            get { return _contenttemplate; }
        }
        /// <summary>
        /// 列表页模板
        /// </summary>
        public string ListTemplate
        {
            set { _listtemplate = value; }
            get { return _listtemplate; }
        }
        #endregion Model

    }
}

