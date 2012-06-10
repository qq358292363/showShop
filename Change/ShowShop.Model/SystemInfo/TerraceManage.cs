using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ShowShop.Model.SystemInfo
{  
   [Serializable()]
   public class TerraceManage
    {
       //支付平台
        #region model
       
        private int _tmid;
        /// <summary>
        ///  TM_ID
        /// </summary>
        public int Tmid
        {
            get { return _tmid; }
            set { _tmid = value; }
        }
       
        private string _tmseller;
        /// <summary>
        /// 商户ID
        /// </summary>
        public string Tmseller
        {
            get { return _tmseller; }
            set { _tmseller = value; }
        }
       
        private string _tmkey;
        /// <summary>
        /// MD5密钥
        /// </summary>
        public string Tmkey
        {
            get { return _tmkey; }
            set { _tmkey = value; }
        }
       
        private Nullable<Decimal> _tmexpenses;
        /// <summary>
        /// 手续费率
        /// </summary>
        public Nullable<Decimal> Tmexpenses
        {
            get { return _tmexpenses; }
            set { _tmexpenses = value; }
        }
      
        private Nullable<Int32> _tmsetup;
        /// <summary>
        /// 设置默认与禁用（0，1）
        /// </summary>
        public Nullable<Int32> Tmsetup
        {
            get { return _tmsetup; }
            set { _tmsetup = value; }
        }
       
        private string _tmname;
        /// <summary>
        /// 平台名称
        /// </summary>
        public string Tmname
        {
            get { return _tmname; }
            set { _tmname = value; }
        }
       
        private int _tmgarden;
        /// <summary>
        /// 支付平台:1,财付通；2，支付宝，3网银，4线下支付（通过邮局汇款或者银行转账）5余额支付
        /// </summary>
        public int Tmgarden
        {
            get { return _tmgarden; }
            set { _tmgarden = value; }
        }
      
        private int _tmputoutid;
        /// <summary>
        /// 发布人ID
        /// </summary>
        public int Tmputoutid
        {
            get { return _tmputoutid; }
            set { _tmputoutid = value; }
        }
      
        private int _tmputouttypeid;
        /// <summary>
        /// 发布人类型(0为管理员,1为会员)
        /// </summary>
        public int Tmputouttypeid
        {
            get { return _tmputouttypeid; }
            set { _tmputouttypeid = value; }
        }
       
        private int _tmtaxis;
        /// <summary>
        /// 排序
        /// </summary>
        public int Tmtaxis
        {
            get { return _tmtaxis; }
            set { _tmtaxis = value; }
        }
       
        private string _tmaccount;
        /// <summary>
        /// 帐户油箱
        /// </summary>
        public string Tmaccount
        {
            get { return _tmaccount; }
            set { _tmaccount = value; }
        }

        private string _payment_description;
       /// <summary>
       /// 支付方式描述
       /// </summary>
        public string Payment_description
        {
            get { return _payment_description; }
            set { _payment_description = value; }
        }

        private string _porttype;
       /// <summary>
       /// 接口类型（支付宝平台属性）
       /// </summary>
        public string Porttype
        {
            get { return _porttype; }
            set { _porttype = value; }
        }
        #endregion

 
        #region "Constructor"
        /// <summary>
        /// 构造一个空的新的数据访问对象
        /// </summary>
        /// <remarks></remarks>
        public TerraceManage()
        { }
     
        #endregion

       
    }
}
