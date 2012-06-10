using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.Model.Member
{
    /// <summary>
    /// 银行汇款记录表
    /// </summary>
    [Serializable]
    public class UserinAndExp
    {
        public UserinAndExp()
		{}
		#region Model
		private int id;
		private int? uid;
		private DateTime? adsummoneydate;
		private decimal? adsummoney;
        private decimal? presentcoupons;
		private int? remitmode;
		private string remitbank;
		private string remark;
		private string formmode;
		private string bosomnote;
		private DateTime? notedate;
		private string notename;
		private int? incomeandexpstate;
		private int? state;
        private string userid;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ id=value;}
			get{return id;}
		}
		/// <summary>
        /// 会员ID
		/// </summary>
		public int? UID
		{
			set{ uid=value;}
			get{return uid;}
		}
		/// <summary>
		/// 到款日期
		/// </summary>
		public DateTime? AdsumMoneyDate
		{
			set{ adsummoneydate=value;}
			get{return adsummoneydate;}
		}
		/// <summary>
		/// 金额
		/// </summary>
        public decimal? AdsumMoney
		{
			set{ adsummoney=value;}
			get{return adsummoney;}
		}
		/// <summary>
		/// 赠送的点卷数量
		/// </summary>
        public decimal? PresentCoupons
		{
			set{ presentcoupons=value;}
			get{return presentcoupons;}
		}
		/// <summary>
        /// 支付方式(1为银行汇款,2为虚拟货币,3现金支付)
		/// </summary>
		public int? RemitMode
		{
			set{ remitmode=value;}
			get{return remitmode;}
		}
		/// <summary>
		/// 汇入银行
		/// </summary>
		public string RemitBank
		{
			set{ remitbank=value;}
			get{return remitbank;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ remark=value;}
			get{return remark;}
		}
		/// <summary>
		/// 通知方式
		/// </summary>
		public string FormMode
		{
			set{ formmode=value;}
			get{return formmode;}
		}
		/// <summary>
		/// 内部信息
		/// </summary>
		public string BosomNote
		{
			set{ bosomnote=value;}
			get{return bosomnote;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime? NoteDate
		{
			set{ notedate=value;}
			get{return notedate;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string NoteName
		{
			set{ notename=value;}
			get{return notename;}
		}
		/// <summary>
        /// 收支状态(0为收,1为支)
		/// </summary>
		public int? InComeandExpState
		{
			set{ incomeandexpstate=value;}
			get{return incomeandexpstate;}
		}
		/// <summary>
        /// 状态(0为确认,1为不确认)
		/// </summary>
		public int? State
		{
			set{ state=value;}
			get{return state;}
		}

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserId
        {
            set { userid = value; }
            get { return userid; }
        }
		#endregion Model
    }
}
