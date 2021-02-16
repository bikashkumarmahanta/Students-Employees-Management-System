using MyMCE.Models.Domain.GlobalLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMCE.Models.IRepository.GlobalLink
{
    interface IGlobalLink
    {
        string AddGlobalLink(tbl_MCE_GlobalLink MCE_Globallink);

        IEnumerable<tbl_MCE_GlobalLink> GlobalLinkList();

        tbl_MCE_GlobalLink GLDetails(int ID);

        string EditGloballink(tbl_MCE_GlobalLink MCE_Globallink);

        string DeleteGloballink(tbl_MCE_GlobalLink MCE_Globallink);

        //To get All Subject List for View with respect to parameter
        IEnumerable<tbl_MCE_GlobalLink> GlobalLinkListSP(GlobalLinkSearchPanel globallinkSearchPanel);
    }
}