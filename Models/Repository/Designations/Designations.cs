using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Designations;
using MyMCE.Models.IRepository.Designations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.Designations
{
    public class Designations : IDesignations
    {
        public string AddDesignation(tbl_MCE_Designations mce_Designations)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "DESIGNATIONINSERT");
            param.Add("@P_intDesignationID", mce_Designations.intDesignationID);
            param.Add("@P_vchDesignation", mce_Designations.vchDesignation);
            param.Add("@P_vchDesignationDescription", mce_Designations.vchDesignationDescription);
            param.Add("@P_vchRemarks", mce_Designations.vchRemarks);

            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Designation_DLM", param, "@P_VCHMSGOUT");

        }

        public tbl_MCE_Designations DesignationDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "DESIGNATIONDETAILS");
            param.Add("@P_intDesignationID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Designations>("SP_MCE_Designation_Report", param);
        }

        public IEnumerable<tbl_MCE_Designations> DesignationList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "DESIGNATIONALL");

            return DapperORM.ReturnList<tbl_MCE_Designations>("SP_MCE_Designation_Report", param);
        }

        public string EditDesignation(tbl_MCE_Designations mce_Designations)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "DESIGNATIONUPDATE");
            param.Add("@P_intDesignationID", mce_Designations.intDesignationID);

            param.Add("@P_vchDesignation", mce_Designations.vchDesignation);
            param.Add("@P_vchDesignationDescription", mce_Designations.vchDesignationDescription);

            param.Add("@P_vchRemarks", mce_Designations.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Designations.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Designation_DLM", param, "@P_VCHMSGOUT");
        }

        public string DeleteDesignation(tbl_MCE_Designations mce_Designations)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "DESIGNATIONDELETE");
            param.Add("@P_intDesignationID", mce_Designations.intDesignationID);


            param.Add("@P_intCreatedBy", mce_Designations.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Designation_DLM", param, "@P_VCHMSGOUT");
        }
    }
}