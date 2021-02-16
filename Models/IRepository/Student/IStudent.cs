using MyMCE.Models.Domain.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMCE.Models.IRepository.Student
{
    interface IStudent
    {
        //Add new Subject
        string AddStudent(tbl_MCE_Student_Basic MCE_Student_Basic);

        //To get All Student List for View
        IEnumerable<tbl_MCE_Student> StudentList();

    }
}
