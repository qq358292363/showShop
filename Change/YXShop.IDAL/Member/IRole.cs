using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ShowShop.IDAL.Member
{
    public interface IRole
    {
        int Create(ShowShop.Model.Member.Role mr);
        int Amend(ShowShop.Model.Member.Role mr);
        int Delete(int id);
        DataTable GetListByColumn(string columnName, Object value);
        ChangeHope.DataBase.DataByPage GetList();
        ShowShop.Model.Member.Role GetModelID(int id);
    }
}
