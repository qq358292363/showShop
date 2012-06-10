using System;
namespace ShowShop.Model.Accessories
{

    /// <summary>
    /// 缺货登记实体类
    /// </summary>
    [Serializable]
    public class Outofstock
    {
        public Outofstock()
        { }
        #region Model
        private int id;
        private int? proid;
        private string proclassandname;
        private DateTime? addtime;
        private string addip;
        private string username;
        private int? issreguser;
        private string telphone;
        private string mobile;
        private string qq;
        private string email;
        private string msn;
        private int? neednum;
        private string content;
        private int? state;
        private int? isdeal;
        private DateTime? dealtime;
        private string dealremark;
        /// <summary>
        /// 缺货登记ID
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 缺货的商品ID
        /// </summary>
        public int? Proid
        {
            set { proid = value; }
            get { return proid; }
        }
        /// <summary>
        /// 缺货登记的商品分类和商品名称
        /// </summary>
        public string ProClassAndName
        {
            set { proclassandname = value; }
            get { return proclassandname; }
        }
        /// <summary>
        /// 缺货登记的提交提交时间
        /// </summary>
        public DateTime? AddTime
        {
            set { addtime = value; }
            get { return addtime; }
        }
        /// <summary>
        ///  登记提交时的IP地址
        /// </summary>
        public string AddIp
        {
            set { addip = value; }
            get { return addip; }
        }
        /// <summary>
        /// 登记者的用户名（但是登录会员时，直接获取会员的注册用户名）
        /// </summary>
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        /// <summary>
        /// 该条等级记录是否是网站会员提交的（避免垃圾信息）
        /// </summary>
        public int? IssRegUser
        {
            set { issreguser = value; }
            get { return issreguser; }
        }
        /// <summary>
        ///  登记者的联系电话
        /// </summary>
        public string Telphone
        {
            set { telphone = value; }
            get { return telphone; }
        }
        /// <summary>
        /// 登记者的联系手机
        /// </summary>
        public string Mobile
        {
            set { mobile = value; }
            get { return mobile; }
        }
        /// <summary>
        /// 登记者的联系QQ
        /// </summary>
        public string QQ
        {
            set { qq = value; }
            get { return qq; }
        }
        /// <summary>
        /// 登记者的Email
        /// </summary>
        public string Email
        {
            set { email = value; }
            get { return email; }
        }
        /// <summary>
        /// 登记者的MSN账号
        /// </summary>
        public string MSN
        {
            set { msn = value; }
            get { return msn; }
        }
        /// <summary>
        /// 登记者需要的商品数量
        /// </summary>
        public int? NeedNum
        {
            set { neednum = value; }
            get { return neednum; }
        }
        /// <summary>
        /// 缺货信息备注（可以提示用户填写要货的时间等）
        /// </summary>
        public string Content
        {
            set { content = value; }
            get { return content; }
        }
        /// <summary>
        /// 紧急状态：1：普通；2：紧急；3：非常紧急
        /// </summary>
        public int? State
        {
            set { state = value; }
            get { return state; }
        }
        /// <summary>
        /// 缺货等级是否查看并处理：1:已经查看但未处理；2:已经处理
        /// </summary>
        public int? IsDeal
        {
            set { isdeal = value; }
            get { return isdeal; }
        }
        /// <summary>
        /// 缺货登记处理完成时间
        /// </summary>
        public DateTime? DealTime
        {
            set { dealtime = value; }
            get { return dealtime; }
        }
        /// <summary>
        /// 缺货登记处理备注
        /// </summary>
        public string DealRemark
        {
            set { dealremark = value; }
            get { return dealremark; }
        }
        #endregion Model

    }
}
