using MyMCE.Models.Domain.Semester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace MyMCE.Models.IRepository.Semester
{
    interface ISemester
    {
        //Add new Semester
        string AddSemester(tbl_MCE_Semester MCE_Semester);

        //Update Semester
        string EditSemester(tbl_MCE_Semester MCE_Semester);

        //Delete Semester
        string DeleteSemester(tbl_MCE_Semester MCE_Semester);

        //To get All Semester List for View
        IEnumerable<tbl_MCE_Semester> SemesterList();

        //To get subject SemesterDetails of specific semester
        tbl_MCE_Semester SemesterDetails(int ID);

        //To get All Semester List for View with respect to parameter
        IEnumerable<tbl_MCE_Semester> SemesterList(SemesterSearchPanel semesterSearchPanel);
    }
}