using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMCE.Models.Domain.Course;

namespace MyMCE.Models.IRepository.Course
{
    interface ICourse
    {
        //Add new Course
        string AddCourse(tbl_MCE_Course mce_Course);

        //To get All Course List for View
        IEnumerable<tbl_MCE_Course> CourseList();

        //To get Course details of specific course
        tbl_MCE_Course CourseDetails(int ID);

        //Update Course
        string Editcourse(tbl_MCE_Course mce_Course);

        //Update Course
        string Deletecourse(tbl_MCE_Course mce_Course);

        IEnumerable<Course_DDL> CourseList1();
    }
}
