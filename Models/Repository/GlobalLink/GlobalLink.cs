using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.GlobalLink;
using MyMCE.Models.IRepository.GlobalLink;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.GlobalLink
{
    public class GlobalLink : IGlobalLink
    {
        public string AddGlobalLink(tbl_MCE_GlobalLink mce_Globallink)
        {


            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GLOBALLINKINSERT");

            param.Add("@P_vchGLinkName", mce_Globallink.vchGLinkName);
            param.Add("@P_intSortNum", mce_Globallink.intSortNum);
            param.Add("@P_bitHomePage", mce_Globallink.bitHomePage);
            param.Add("@P_vchIcon", mce_Globallink.vchIcon);
            param.Add("@P_vchRemarks", mce_Globallink.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Globallink.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Globallink_DML", param, "@P_VCHMSGOUT");


            throw new NotImplementedException();
        }

        public string DeleteGloballink(tbl_MCE_GlobalLink mce_Globallink)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GLOBALLINKDELETE");
            param.Add("@P_intGLinkID", mce_Globallink.intGLinkID);





            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Globallink_DML", param, "@P_VCHMSGOUT");
        }

        public string EditGloballink(tbl_MCE_GlobalLink mce_Globallink)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GLOBALLINKUPDATE");
            param.Add("@P_intGLinkID", mce_Globallink.intGLinkID);

            param.Add("@P_vchGLinkName", mce_Globallink.vchGLinkName);
            param.Add("@P_intSortNum", mce_Globallink.intSortNum);
            param.Add("@P_bitHomePage", mce_Globallink.bitHomePage);
            param.Add("@P_vchIcon", mce_Globallink.vchIcon);
            param.Add("@P_vchRemarks", mce_Globallink.vchRemarks);



            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Globallink_DML", param, "@P_VCHMSGOUT");
        }

        public tbl_MCE_GlobalLink GLDetails(int ID)
        {

            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "GLOBALLINKDETAILS");
            param.Add("@P_intGLinkID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_GlobalLink>("SP_MCE_Globallink_Report", param);

            throw new NotImplementedException();
        }

        public IEnumerable<tbl_MCE_GlobalLink> GlobalLinkList()
        {
            //Name of the procedure
            //Open The connection

            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "GLOBALLINKALL");

            return DapperORM.ReturnList<tbl_MCE_GlobalLink>("SP_MCE_Globallink_Report", param);
            throw new NotImplementedException();
        }

        public IEnumerable<tbl_MCE_GlobalLink> GlobalLinkListSP(GlobalLinkSearchPanel globallinkSearchPanel)
        {


            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "GLOBALLINKALLSP");
            if (globallinkSearchPanel.vchGLinkName != null)
            {
                param.Add("@P_vchGLinkName", globallinkSearchPanel.vchGLinkName);
            }
            if (globallinkSearchPanel.intSortNum != 0 && globallinkSearchPanel.intSortNum != null)
            {
                param.Add("@P_intSortNum", globallinkSearchPanel.intSortNum);
            }


            return DapperORM.ReturnList<tbl_MCE_GlobalLink>("SP_MCE_Globallink_Report", param);

        }
    }
}