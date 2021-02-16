using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Course;
using MyMCE.Models.IRepository.Course;

namespace MyMCE.Models.Repository.Course
{
    public class Course : ICourse
    {
        public string AddCourse(tbl_MCE_Course mce_Course)
        {


            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "COURSEINSERT");

            param.Add("@P_vchCourseName", mce_Course.vchCourseName);
            param.Add("@P_vchCourseDescription", mce_Course.vchCourseDescription);
            param.Add("@P_intNoOfYears", mce_Course.intNoOfYears);
            param.Add("@P_intNoOfSemesters ", mce_Course.intNoOfSemesters);
            param.Add("@P_intSemesterDuration", mce_Course.intSemesterDuration);
            param.Add("@P_dtmStartDate", mce_Course.dtmStartDate);
            param.Add("@P_dtmEndDate", mce_Course.dtmEndDate);

            param.Add("@P_vchRemarks", mce_Course.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Course.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Course_DML", param, "@P_VCHMSGOUT");

        }

        public tbl_MCE_Course CourseDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "COURSEDETAILS");
            param.Add("@P_intCourseID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Course>("SP_MCE_Course_Report", param);
        }

        public IEnumerable<tbl_MCE_Course> CourseList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "COURSEALL");


            return DapperORM.ReturnList<tbl_MCE_Course>("SP_MCE_Course_Report", param);
        }

        public IEnumerable<Course_DDL> CourseList1()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "CLD");
            return DapperORM.ReturnList<Course_DDL>("SP_MCE_Course_Report", param);
        }

        public string Deletecourse(tbl_MCE_Course mce_Course)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "COURSEDELETE");
            param.Add("@P_intCourseID", mce_Course.intCourseID);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Course_DML", param, "@P_VCHMSGOUT");
        }

        public string Editcourse(tbl_MCE_Course mce_Course)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "COURSEUPDATE");
            param.Add("@P_intCourseID", mce_Course.intCourseID);

            param.Add("@P_vchCourseName", mce_Course.vchCourseName);
            param.Add("@P_vchCourseDescription", mce_Course.vchCourseDescription);

            param.Add("@P_intNoOfYears", mce_Course.intNoOfYears);
            param.Add("@P_intNoOfSemesters", mce_Course.intNoOfSemesters);
            param.Add("@P_intSemesterDuration", mce_Course.intSemesterDuration);
            param.Add("@P_dtmStartDate", mce_Course.dtmStartDate);
            param.Add("@P_dtmEndDate", mce_Course.dtmEndDate);
            param.Add("@P_vchRemarks", mce_Course.vchRemarks);

            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Course_DML", param, "@P_VCHMSGOUT");
        }


    }
}
                                                                                                         
                   