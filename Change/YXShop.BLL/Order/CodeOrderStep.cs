using System;
using System.Data;
using System.Collections.Generic;
using ShowShop.Model.Order;
using ShowShop.DALFactory;
using ShowShop.IDAL.Order;
namespace ShowShop.BLL.Order
{
    public class CodeOrderStep
    {
        private readonly ICodeOrderStep dal = DataAccess.CreateCodeOrderStep();
        public CodeOrderStep()
        { }
        #region Data Load
        public ShowShop.Model.Order.CodeOrderStep GetModel(string codeId)
        {
            return dal.GetModel(codeId);
        }

        #endregion
    }
}
