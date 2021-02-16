using Dapper;
using MyMCE.Models.Helper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Student;
using MyMCE.Models.IRepository.Student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.Student
{
    public class Student : IStudent
    {
        public string AddStudent(tbl_MCE_Student_Basic MCE_Student_Basic)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "STUDENTINS");

            param.Add("@P_vchName", MCE_Student_Basic.vchName);
            param.Add("@P_vchUserName", MCE_Student_Basic.vchUserName);
            param.Add("@P_vchPassword ", Util.GetHashByte(MCE_Student_Basic.vchPassword));
            param.Add("@P_intRoleID", MCE_Student_Basic.intRoleID);
            param.Add("@P_intLevelID", MCE_Student_Basic.intLevelID);
            param.Add("@P_vchAdmissionBatch", MCE_Student_Basic.vchAdmissionBatch);
            param.Add("@P_intCourseID", MCE_Student_Basic.intCourseID);
            param.Add("@P_vchCourseName", MCE_Student_Basic.vchCourseName);
            param.Add("@P_intBranchID", MCE_Student_Basic.intBranchID);
            param.Add("@P_vchBranchName", MCE_Student_Basic.vchBranchName);
            param.Add("@P_intSemister", MCE_Student_Basic.intSemister);
            param.Add("@P_intJoinCategoryID", MCE_Student_Basic.intJoinCategoryID);
            param.Add("@P_dtmDOB", MCE_Student_Basic.dtmDOB);
            param.Add("@P_vchGender", MCE_Student_Basic.vchGender);
            param.Add("@P_vchRemarks", MCE_Student_Basic.vchRemarks);

            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_STUDENT_DLM", param, "@P_VCHMSGOUT");

        }

        public IEnumerable<tbl_MCE_Student> StudentList()
        {
            throw new NotImplementedException();
        }
    }
}