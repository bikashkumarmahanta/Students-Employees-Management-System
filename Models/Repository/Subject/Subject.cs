using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Subject;
using MyMCE.Models.IRepository.Subject;


namespace MyMCE.Models.Repository.Subject
{
    public class Subject : ISubject
    {
        public string AddSubject(tbl_MCE_Subject mce_Subject)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SUBJECTINSERT");

            param.Add("@P_vchSubjectCode", mce_Subject.vchSubjectCode);
            param.Add("@P_vchSubjectName", mce_Subject.vchSubjectName);
            param.Add("@P_vchSubjectDescription", mce_Subject.vchSubjectDescription);
            param.Add("@P_intCourseID", mce_Subject.intCourseID);
            param.Add("@P_intBranchID", mce_Subject.intBranchID);
            param.Add("@p_vchCourseName", mce_Subject.vchCourseName);
            param.Add("@p_vchBranchCode", mce_Subject.vchBranchCode);
            param.Add("@p_vchBranchName", mce_Subject.vchBranchName);
            param.Add("@P_intSemister", mce_Subject.intSemister);
            param.Add("@P_vchSubjectType", mce_Subject.vchSubjectType);
            param.Add("@P_vchSubjectCategory", mce_Subject.vchSubjectCategory);
            param.Add("@P_decCredit", mce_Subject.decCredit);
            param.Add("@P_decHours", mce_Subject.decHours);
            param.Add("@P_vchRemarks", mce_Subject.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Subject.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Subject_DML", param, "@P_VCHMSGOUT");



        }

        public string EditSubject(tbl_MCE_Subject mce_Subject)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SUBJECTUPDATE");
            param.Add("@P_intSubjectID", mce_Subject.intSubjectID);

            param.Add("@P_vchSubjectName", mce_Subject.vchSubjectName);
            param.Add("@P_vchSubjectDescription", mce_Subject.vchSubjectDescription);

            param.Add("@P_decCredit", mce_Subject.decCredit);
            param.Add("@P_decHours", mce_Subject.decHours);
            param.Add("@P_vchRemarks", mce_Subject.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Subject.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Subject_DML", param, "@P_VCHMSGOUT");


        }
        public string DeleteSubject(tbl_MCE_Subject mce_Subject)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SUBJECTDELETE");
            param.Add("@P_intSubjectID", mce_Subject.intSubjectID);


            param.Add("@P_intCreatedBy", mce_Subject.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Subject_DML", param, "@P_VCHMSGOUT");


        }
        public tbl_MCE_Subject SubjectDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SUBJECTDETAILS");
            param.Add("@P_intSubjectID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Subject>("SP_MCE_Subject_Report", param);
        }

        public IEnumerable<tbl_MCE_Subject> SubjectList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "SUBJECTALL");


            return DapperORM.ReturnList<tbl_MCE_Subject>("SP_MCE_Subject_Report", param);

        }
    }
}