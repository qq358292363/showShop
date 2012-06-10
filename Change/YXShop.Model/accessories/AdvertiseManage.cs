using System;
namespace ShowShop.Model.Accessories
{
    /// <summary>
    /// 广告实体类
    /// </summary>
    [Serializable]
    public class AdvertiseManage
    {
        public AdvertiseManage()
        { }
        #region Model
        private int id;
        private string name;
        private int? power;
        private int? statbrowse;
        private int? statclick;
        private DateTime? overduetime;
        private int? examine;
        private string upspreadadd;
        private string sizebreadth;
        private string hight;
        private string linkaddress;
        private string hint;
        private int? backgortarget;
        private string advertisecont;
        private int? browsecount;
        private int? clickcount;
        private int? adtype;
        /// <summary>
        /// 主键自增
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        /// <summary>
        /// 广告权重
        /// </summary>
        public int? Power
        {
            set { power = value; }
            get { return power; }
        }
        /// <summary>
        /// 是否统计浏览次数
        /// </summary>
        public int? StatBrowse
        {
            set { statbrowse = value; }
            get { return statbrowse; }
        }
        /// <summary>
        /// 是否统计点击次数
        /// </summary>
        public int? StatClick
        {
            set { statclick = value; }
            get { return statclick; }
        }
        /// <summary>
        /// 广告过期的时间
        /// </summary>
        public DateTime? OverdueTime
        {
            set { overduetime = value; }
            get { return overduetime; }
        }
        /// <summary>
        /// 是否通过审核 1为通过 0为否
        /// </summary>
        public int? Examine
        {
            set { examine = value; }
            get { return examine; }
        }
        /// <summary>
        /// 上传地址
        /// </summary>
        public string UpspreadAdd
        {
            set { upspreadadd = value; }
            get { return upspreadadd; }
        }
        /// <summary>
        /// 尺寸宽
        /// </summary>
        public string SizeBreadth
        {
            set { sizebreadth = value; }
            get
            {
                return sizebreadth == string.Empty ? "0" : sizebreadth;
            }
        }
        /// <summary>
        /// 尺寸高
        /// </summary>
        public string Hight
        {
            set { hight = value; }
            get { return hight == string.Empty ? "0" : hight; }
        }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string LinkAddress
        {
            set { linkaddress = value; }
            get { return linkaddress; }
        }
        /// <summary>
        /// 连接提示
        /// </summary>
        public string Hint
        {
            set { hint = value; }
            get { return hint; }
        }
        /// <summary>
        /// 0不透明 1透明 ( 0新窗口 1原窗口 )
        /// </summary>
        public int? BackgorTarget
        {
            set { backgortarget = value; }
            get { return backgortarget; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Advertisecont
        {
            set { advertisecont = value; }
            get { return advertisecont; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int? BrowseCount
        {
            set { browsecount = value; }
            get { return browsecount; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int? ClickCount
        {
            set { clickcount = value; }
            get { return clickcount; }
        }
        /// <summary>
        /// 广告类型
        /// </summary>
        public int? Adtype
        {
            set { adtype = value; }
            get { return adtype; }
        }
        #endregion Model

    }
}
