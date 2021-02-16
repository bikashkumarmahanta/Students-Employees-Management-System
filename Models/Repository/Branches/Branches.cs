using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Branches;
using MyMCE.Models.IRepository.Branches;

namespace MyMCE.Models.Repository.Branches
{
    public class Branches : IBranches
    {
        public string AddBranch(tbl_MCE_Branch mce_Branch)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "BRANCHINSERT");

            param.Add("@P_vchBranchCode", mce_Branch.vchBranchCode);
            param.Add("@P_vchBranchName", mce_Branch.vchBranchName);
            param.Add("@P_vchBranchDescription", mce_Branch.vchBranchDescription);
            param.Add("@P_intCourseID", mce_Branch.intCourseID);
            param.Add("@P_vchCourseName", mce_Branch.vchCourseName);
            param.Add("@P_vchRemarks", mce_Branch.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Branch.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Branch_DML", param, "@P_VCHMSGOUT");


            throw new NotImplementedException();
        }

        public IEnumerable<Branch_DDL> BranchList()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "BRANCHALL");
            return DapperORM.ReturnList<Branch_DDL>("SP_MCE_Branch_Report", param);

        }



        //from table

        public IEnumerable<tbl_MCE_Branch> BranchL()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "BRANCHALL");


            return DapperORM.ReturnList<tbl_MCE_Branch>("SP_MCE_Branch_Report", param);

        }

        //detail of single employee
        public tbl_MCE_Branch BranchDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "BRANCHDETAILS");
            param.Add("@P_intBranchID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Branch>("SP_MCE_Branch_Report", param);
        }


        //update
        public string EditBranch(tbl_MCE_Branch mce_Branch)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "BRANCHUPDATE");
            param.Add("@P_intBranchID", mce_Branch.intBranchID);

            param.Add("@P_vchBranchName", mce_Branch.vchBranchName);
            param.Add("@P_vchBranchDescription", mce_Branch.vchBranchDescription);
            param.Add("@P_vchRemarks", mce_Branch.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Branch.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Branch_DML", param, "@P_VCHMSGOUT");


        }


        public string DeleteBranch(tbl_MCE_Branch mce_Branch)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "BRANCHDELETE");
            param.Add("@P_intBranchID", mce_Branch.intBranchID);


            param.Add("@P_intCreatedBy", mce_Branch.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Branch_DML", param, "@P_VCHMSGOUT");


        }


        public IEnumerable<tbl_MCE_Branch> BranchList(BranchSearchPanel branchSearchPanel)
        {


            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "BRANCHALLSP");
            if (branchSearchPanel.intCourseID != 0 && branchSearchPanel.intCourseID != null)
            {
                param.Add("@P_intCourseID", branchSearchPanel.intCourseID);
            }

            if (branchSearchPanel.vchBranchDescription != null)
            {
                param.Add("@P_vchBranchDescription", branchSearchPanel.vchBranchDescription);
            }

            return DapperORM.ReturnList<tbl_MCE_Branch>("SP_MCE_Branch_Report", param);

        }
    }
}