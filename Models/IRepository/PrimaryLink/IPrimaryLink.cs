using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMCE.Models.Domain.PrimaryLink;

namespace MyMCE.Models.IRepository.PrimaryLink
{
    interface IPrimaryLink
    {
        //Add New PrimaryLink
        string AddPlinks(tbl_MCE_PrimaryLink MCE_Primarylink);

        //list
        IEnumerable<tbl_MCE_PrimaryLink> PlinkList();

        //Details
        tbl_MCE_PrimaryLink PrimarylinkDetails(int ID);

        //Update /Edit
        string EditPrimarylink(tbl_MCE_PrimaryLink mce_Primarylink);

        //delete 
        string DeletePrimarylink(tbl_MCE_PrimaryLink mce_Primarylink);

        //To get All  List for View with respect to parameter
        IEnumerable<tbl_MCE_PrimaryLink> PrimaryLinkList(PrimaryLinkSearchPanel primaryLinkSearchPanel);
    }
}


