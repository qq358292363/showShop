using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowShop.IDAL.Order
{
    public interface ICodeOrderStep
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ShowShop.Model.Order.CodeOrderStep GetModel(string codeId);
    }
}
