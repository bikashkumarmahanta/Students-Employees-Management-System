using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.GroupLinkAccess;
using MyMCE.Models.IRepository.GroupLinkAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.GroupLinkAccess
{
    public class GroupLinkAccess : IGroupLinkAccess
    {
        public string AddGroupLinkAccess(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GROUPLINKACCESSINSERT");
            param.Add("@p_vchGroupLinkAccessName", mce_GroupLinkAccess.vchGroupLinkAccessName);
            param.Add("@p_intRoleID", mce_GroupLinkAccess.intRoleID);
            param.Add("@p_intPLinkID", mce_GroupLinkAccess.intPLinkID);
            param.Add("@P_vchRemarks", mce_GroupLinkAccess.vchRemarks);
            param.Add("@P_intCreatedBy", mce_GroupLinkAccess.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_GroupLinkAccess_DML", param, "@P_VCHMSGOUT");


            throw new NotImplementedException();
        }

        public string DeleteGroupLinkAccess(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GROUPLINKACCESSDELETE");
            param.Add("@p_intGroupLinkAccessID", mce_GroupLinkAccess.intGroupLinkAccessID);

            param.Add("@P_intUpdatedBy", mce_GroupLinkAccess.intUpdatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_GroupLinkAccess_DML", param, "@P_VCHMSGOUT");

            throw new NotImplementedException();
        }

        public string EditGroupLinkAccess(tbl_MCE_GroupLinkAccess mce_GroupLinkAccess)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "GROUPLINKACCESSUPDATE");
            param.Add("@p_intGroupLinkAccessID", mce_GroupLinkAccess.intGroupLinkAccessID);
            param.Add("@p_vchGroupLinkAccessName", mce_GroupLinkAccess.vchGroupLinkAccessName);
            param.Add("@p_intRoleID", mce_GroupLinkAccess.intRoleID);
            param.Add("@p_intPLinkID", mce_GroupLinkAccess.intPLinkID);
            param.Add("@P_vchRemarks", mce_GroupLinkAccess.vchRemarks);
            //param.Add("@P_intUpdatedBy", mce_GroupLinkAccess.intUpdatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_GroupLinkAccess_DML", param, "@P_VCHMSGOUT");

            throw new NotImplementedException();
        }

        public tbl_MCE_GroupLinkAccess GroupLinkAccessDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GROUPLINKACCESSDETAILS");
            param.Add("@P_intGroupLinkAccessID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_GroupLinkAccess>("SP_MCE_GroupLinkAccess_Report", param);

        }



        public IEnumerable<tbl_MCE_GroupLinkAccess> GroupLinkAccessList()
        {

            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GROUPLINKACCESSALL");


            return DapperORM.ReturnList<tbl_MCE_GroupLinkAccess>("SP_MCE_GroupLinkAccess_Report", param);
        }

        public IEnumerable<tbl_MCE_GroupLinkAccess> GroupLinkAccessList(GroupLinkAccessSearchPanel groupLinkAccessSearchPanel)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "GROUPLINKACCESSALLSP");
            if (groupLinkAccessSearchPanel.vchGroupLinkAccessName != null)
            {
                param.Add("@P_vchGroupLinkAccessName", groupLinkAccessSearchPanel.vchGroupLinkAccessName);
            }

            if (groupLinkAccessSearchPanel.vchPLinkName != null)
            {
                param.Add("@P_vchPLinkName", groupLinkAccessSearchPanel.vchPLinkName);
            }
            if (groupLinkAccessSearchPanel.vchDescription != null)
            {
                param.Add("@P_vchRoleDescription", groupLinkAccessSearchPanel.vchDescription);
            }

            return DapperORM.ReturnList<tbl_MCE_GroupLinkAccess>("SP_MCE_GroupLinkAccess_Report", param);
        }
    }
}