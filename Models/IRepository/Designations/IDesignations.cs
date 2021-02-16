using MyMCE.Models.Domain.Designations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyMCE.Models.IRepository.Designations
{
    interface IDesignations
    {
        //To enter the designations
        string AddDesignation(tbl_MCE_Designations mce_Designations);

        //To show designation list
        IEnumerable<tbl_MCE_Designations> DesignationList();

        //Edit Designation
        string EditDesignation(tbl_MCE_Designations MCE_Designations);

        //Delete Designation
        string DeleteDesignation(tbl_MCE_Designations MCE_Designations);

        //To get Designation details of specific Designation
        tbl_MCE_Designations DesignationDetails(int ID);
    }
}
