using System;

namespace ShowShop.Model.Order
{
    /// <summary>
    /// 订单状态码
    /// </summary>
    [Serializable]
    public class CodeOrderStep
    {
        public CodeOrderStep()
        {
        }
        #region Model
        private string code;
        private string content;
        /// <summary>
        /// ID
        /// </summary>
        public string Code
        {
            set { code = value; }
            get { return code; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { content = value; }
            get { return content; }
        }
        #endregion Model
    }
}
