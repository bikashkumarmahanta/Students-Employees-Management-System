using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMCE.Models.Domain.GroupLinkAccess;
using MyMCE.Models.Repository.GroupLinkAccess;

namespace MyMCE.Models.IRepository.GroupLinkAccess
{
    interface IGroupLinkAccess
    {
        //Add new GroupLink
        string AddGroupLinkAccess(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess);

        //To get All Subject List for View
        IEnumerable<tbl_MCE_GroupLinkAccess> GroupLinkAccessList();

        //To get subject details of specific subject
        tbl_MCE_GroupLinkAccess GroupLinkAccessDetails(int ID);

        string EditGroupLinkAccess(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess);

        //delete 
        string DeleteGroupLinkAccess(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess);
        //SEARCH PANEL
        IEnumerable<tbl_MCE_GroupLinkAccess> GroupLinkAccessList(GroupLinkAccessSearchPanel groupLinkAccessSearchPanel);

    }
}