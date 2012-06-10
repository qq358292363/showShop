using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ShowShop.IDAL.Member
{
    public interface IRoles_Permissions
    {
        int Create(ShowShop.Model.Member.Roles_Permissions model);
        int Delete(int id);
        List<ShowShop.Model.Member.Roles_Permissions> GetListByColumn(string Condition);
        ShowShop.Model.Member.Roles_Permissions GetModelID(int id);
        List<ShowShop.Model.Member.Roles_Permissions> GetAll();
        List<ShowShop.Model.Member.Roles_Permissions> GetListByColumn(string columnName, Object value);
        int Add(List<ShowShop.Model.Member.Roles_Permissions> list);
        int Del(List<ShowShop.Model.Member.Roles_Permissions> list); 
    }
}
