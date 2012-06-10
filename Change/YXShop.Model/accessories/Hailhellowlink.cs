using System;
namespace ShowShop.Model.Accessories
{
    /// <summary>
    /// 友情链接实体类
    /// </summary>
    [Serializable]
    public class Hailhellowlink
    {
        public Hailhellowlink()
        { }
        #region Model
        private int id;
        private string sitename;
        private string siteurl;
        private string sitelogo;
        private int? sitelevel;
        private string sitecontent;
        private int? sitelinktype;
        private int? sitestate;
        private int? siteclickcount;
        private DateTime? createdate;
        private DateTime? updatedate;
        private int? putoutid;
        private int? putouttyid;
        private string aread;
        private string siteimages;

        /// <summary>
        /// Logo图片
        /// </summary>
        public string SiteImages
        {
            get { return siteimages; }
            set { siteimages = value; }
        }
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            set { sitename = value; }
            get { return sitename; }
        }
        /// <summary>
        /// 网站URL
        /// </summary>
        public string SiteUrl
        {
            set { siteurl = value; }
            get { return siteurl; }
        }
        /// <summary>
        /// 网站LOGO地址
        /// </summary>
        public string SiteLogo
        {
            set { sitelogo = value; }
            get { return sitelogo; }
        }
        /// <summary>
        /// 优先级
        /// </summary>
        public int? SiteLevel
        {
            set { sitelevel = value; }
            get { return sitelevel; }
        }
        /// <summary>
        /// 网站简介
        /// </summary>
        public string SiteContent
        {
            set { sitecontent = value; }
            get { return sitecontent; }
        }
        /// <summary>
        /// 链接类型:1为文字,2为图片
        /// </summary>
        public int? SiteLinkType
        {
            set { sitelinktype = value; }
            get { return sitelinktype; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? SiteState
        {
            set { sitestate = value; }
            get { return sitestate; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int? SiteClickCount
        {
            set { siteclickcount = value; }
            get { return siteclickcount; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { createdate = value; }
            get { return createdate; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDate
        {
            set { updatedate = value; }
            get { return updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PutoutID
        {
            set { putoutid = value; }
            get { return putoutid; }
        }
        /// <summary>
        /// 0表示是管理员，1表示会员
        /// </summary>
        public int? PutoutTyID
        {
            set { putouttyid = value; }
            get { return putouttyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Aread
        {
            set { aread = value; }
            get { return aread; }
        }
        #endregion Model

    }
}
