using MyMCE.Models.Domain.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMCE.Models.IRepository.Role
{
    interface IRole
    {
        string AddRole(tbl_MCE_Role MCE_Role);

        IEnumerable<tbl_MCE_Role> RoleList();

        tbl_MCE_Role RoleDetails(int ID);

        string EditRole(tbl_MCE_Role MCE_Role);

        string DeleteRole(tbl_MCE_Role MCE_Role);
    }
}