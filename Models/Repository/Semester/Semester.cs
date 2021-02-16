using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Semester;
using MyMCE.Models.IRepository.Semester;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.Semester
{
    public class Semester : ISemester
    {
        //To add new semester
        public string AddSemester(tbl_MCE_Semester mce_Semester)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SEMESTERINSERT");

            param.Add("@P_vchAdmissionBatch", mce_Semester.vchAdmissionBatch);

            param.Add("@P_intCourseID", mce_Semester.intCourseID);
            param.Add("@P_intBranchID", mce_Semester.intBranchID);
            param.Add("@p_vchCourseName", mce_Semester.vchCourseName);

            param.Add("@p_vchBranchName", mce_Semester.vchBranchName);
            param.Add("@P_intSemester", mce_Semester.intSemester);
            param.Add("@P_vchSection", mce_Semester.vchSection);
            param.Add("@P_dtmStartDate", mce_Semester.dtmStartDate);
            param.Add("@P_dtmEndDate", mce_Semester.dtmEndDate);

            param.Add("@P_vchRemarks", mce_Semester.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Semester.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Semester_DML", param, "@P_VCHMSGOUT");

        }

        //To display all semester in the table
        public IEnumerable<tbl_MCE_Semester> SemesterList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SEMESTERALL");


            return DapperORM.ReturnList<tbl_MCE_Semester>("SP_MCE_Semester_Report", param);

        }

        // To display details of one semester
        public tbl_MCE_Semester SemesterDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SEMESTERDETAILS");
            param.Add("@P_intSemesterID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Semester>("SP_MCE_Semester_Report", param);
        }

        //To edit semester details
        public string EditSemester(tbl_MCE_Semester mce_Semester)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SEMESTERUPDATE");
            param.Add("@P_intSemesterID", mce_Semester.intSemesterID);

            param.Add("@P_intSemester", mce_Semester.intSemester);
            param.Add("@P_vchSection", mce_Semester.vchSection);

            param.Add("@P_dtmStartDate", mce_Semester.dtmStartDate);
            param.Add("@P_dtmEndDate", mce_Semester.dtmEndDate);
            param.Add("@P_vchRemarks", mce_Semester.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Semester.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Semester_DML", param, "@P_VCHMSGOUT");


        }

        //To delete semester info from data table
        public string DeleteSemester(tbl_MCE_Semester mce_Semester)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SEMESTERDELETE");
            param.Add("@P_intSemesterID", mce_Semester.intSemesterID);


            param.Add("@P_intCreatedBy", mce_Semester.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Semester_DML", param, "@P_VCHMSGOUT");


        }

        //To view data of semester table based on parameters selected
        public IEnumerable<tbl_MCE_Semester> SemesterList(SemesterSearchPanel semesterSearchPanel)
        {


            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "SEMESTERSP");
            if (semesterSearchPanel.intCourseID != 0 && semesterSearchPanel.intCourseID != null)
            {
                param.Add("@P_intCourseID", semesterSearchPanel.intCourseID);
            }
            if (semesterSearchPanel.intBranchID != 0 && semesterSearchPanel.intBranchID != null)
            {
                param.Add("@P_intBranchID", semesterSearchPanel.intBranchID);
            }
            if (semesterSearchPanel.intSemester != null)
            {
                param.Add("@P_intSemester", semesterSearchPanel.intSemester);
            }
            if (semesterSearchPanel.vchAdmissionBatch != null)
            {
                param.Add("@P_vchAdmissionBatch", semesterSearchPanel.vchAdmissionBatch);
            }

            return DapperORM.ReturnList<tbl_MCE_Semester>("SP_MCE_Semester_Report", param);

        }
    }
}