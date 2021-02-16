using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.PrimaryLink;
using MyMCE.Models.IRepository.PrimaryLink;

namespace MyMCE.Models.Repository.PrimaryLink
{
    public class PrimaryLink : IPrimaryLink
    {
        public string AddPlinks(tbl_MCE_PrimaryLink mce_Primarylink)
        {


            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "PRIMARYLINKINSERT");

            param.Add("@p_vchPLinkName", mce_Primarylink.vchPLinkName);
            param.Add("@p_intGLinkID", mce_Primarylink.intGLinkID);
            param.Add("@p_intFunctionID", mce_Primarylink.intFunctionID);
            param.Add("@p_intSlNo", mce_Primarylink.intSlNo);
            param.Add("@p_vchExternalURL", mce_Primarylink.vchExternalURL);
            param.Add("@p_bitLinkType ", mce_Primarylink.bitLinkType);
            param.Add("@p_bitShowOnHomePage", mce_Primarylink.bitShowOnHomePage);
            param.Add("@p_intAccessID", mce_Primarylink.intAccessID);
            param.Add("@p_intAccess ", mce_Primarylink.intAccess);
            param.Add("@p_intUserID", mce_Primarylink.intUserID);
            param.Add("@p_vchAction1", mce_Primarylink.vchAction1);
            param.Add("@p_vchIcon", mce_Primarylink.vchIcon);
            param.Add("@P_vchRemarks", mce_Primarylink.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Primarylink.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Primarylink_DML", param, "@P_VCHMSGOUT");


            throw new NotImplementedException();
        }

        public string DeletePrimarylink(tbl_MCE_PrimaryLink mce_Primarylink)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "PRIMARYLINKDELETE");
            param.Add("@p_intPLinkID", mce_Primarylink.intPLinkID);


            param.Add("@P_intUpdatedBy", mce_Primarylink.intUpdatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Primarylink_DML", param, "@P_VCHMSGOUT");
            throw new NotImplementedException();
        }

        public string EditPrimarylink(tbl_MCE_PrimaryLink mce_Primarylink)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "PRIMARYLINKUPDATE");
            param.Add("@p_intPLinkID", mce_Primarylink.intPLinkID);
            param.Add("@p_vchPLinkName", mce_Primarylink.vchPLinkName);
            param.Add("@p_intGLinkID", mce_Primarylink.intGLinkID);
            param.Add("@p_intFunctionID", mce_Primarylink.intFunctionID);
            param.Add("@p_intSlNo", mce_Primarylink.intSlNo);
            param.Add("@p_bitLinkType ", mce_Primarylink.bitLinkType);
            param.Add("@p_bitShowOnHomePage", mce_Primarylink.bitShowOnHomePage);
            param.Add("@p_vchIcon", mce_Primarylink.vchIcon);
            param.Add("@P_vchRemarks", mce_Primarylink.vchRemarks);



            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Primarylink_DML", param, "@P_VCHMSGOUT");


            throw new NotImplementedException();
        }

        public tbl_MCE_PrimaryLink PrimarylinkDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "PRIMARYLINKDETAILS");
            param.Add("@P_intPLinkID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_PrimaryLink>("SP_MCE_Primarylink_Report", param);
        }

        public IEnumerable<tbl_MCE_PrimaryLink> PlinkList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "PRIMARYLINKALL");


            return DapperORM.ReturnList<tbl_MCE_PrimaryLink>("SP_MCE_Primarylink_Report", param);
        }

        public IEnumerable<tbl_MCE_PrimaryLink> PrimaryLinkList(PrimaryLinkSearchPanel primaryLinkSearchPanel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "PRIMARYLINKALLSP");
            if (primaryLinkSearchPanel.vchGLinkName != null)
            {
                param.Add("@P_vchGLinkName", primaryLinkSearchPanel.vchGLinkName);
            }

            if (primaryLinkSearchPanel.vchPLinkName != null)
            {
                param.Add("@P_vchPLinkName", primaryLinkSearchPanel.vchPLinkName);
            }
            if (primaryLinkSearchPanel.vchFunctionName != null)
            {
                param.Add("@P_vchFunctionName", primaryLinkSearchPanel.vchFunctionName);
            }

            return DapperORM.ReturnList<tbl_MCE_PrimaryLink>("SP_MCE_Primarylink_Report", param);
        }
    }
}