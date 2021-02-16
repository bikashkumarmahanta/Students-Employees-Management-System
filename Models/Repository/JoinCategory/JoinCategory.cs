using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.JoinCategory;
using MyMCE.Models.IRepository.JoinCategory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.JoinCategory
{
    public class JoinCategory : IJoinCategory
    {
        public string AddCategory(tbl_MCE_JoinCategory MCE_JoinCategory)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "JOINCATEGORYINSERT");

            param.Add("@P_intLevelID", MCE_JoinCategory.intLevelID);
            param.Add("@P_vchLevelName", MCE_JoinCategory.vchLevelName);
            param.Add("@P_vchJoinCategoryType", MCE_JoinCategory.vchJoinCategoryType);
            param.Add("@P_vchDescription", MCE_JoinCategory.vchDescription);
            param.Add("@P_vchRemarks", MCE_JoinCategory.vchRemarks);
            param.Add("@P_intCreatedBy", MCE_JoinCategory.intCreatedBy);

            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_JoinCategory_DML", param, "@P_VCHMSGOUT");


        }


        //from table

        public IEnumerable<tbl_MCE_JoinCategory> JoinCategoryList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "JOINCATEGORYALL");


            return DapperORM.ReturnList<tbl_MCE_JoinCategory>("SP_MCE_JoinCategory_Report", param);

        }

        //update
        public string EditJoinCategory(tbl_MCE_JoinCategory mce_JoinCategory)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "JOINCATEGORYUPDATE");
            param.Add("@P_intJoinCategoryID", mce_JoinCategory.intJoinCategoryID);

            param.Add("@P_vchJoinCategoryType", mce_JoinCategory.vchJoinCategoryType);
            param.Add("@P_vchDescription", mce_JoinCategory.vchDescription);
            param.Add("@P_vchRemarks", mce_JoinCategory.vchRemarks);
            param.Add("@P_intCreatedBy", mce_JoinCategory.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_JoinCategory_DML", param, "@P_VCHMSGOUT");


        }

        //detail of single category
        public tbl_MCE_JoinCategory JoinCategoryDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "JOINCATEGORYDETAILS");
            param.Add("@P_intJoinCategoryID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_JoinCategory>("SP_MCE_JoinCategory_Report", param);
        }


        public string DeleteJoinCategory(tbl_MCE_JoinCategory mce_JoinCategory)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "JOINCATEGORYDELETE");
            param.Add("@P_intJoinCategoryID", mce_JoinCategory.intJoinCategoryID);


            param.Add("@P_intCreatedBy", mce_JoinCategory.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_JoinCategory_DML", param, "@P_VCHMSGOUT");


        }

        //To view data of joincategory table based on parameters selected
        public IEnumerable<tbl_MCE_JoinCategory> JoinCategoryList(JoinCategorySearchPanel joincategorySearchPanel)
        {


            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "JOINCATEGORYSP");
            if (joincategorySearchPanel.intLevelID != 0 && joincategorySearchPanel.intLevelID != null)
            {
                param.Add("@P_intLevelID", joincategorySearchPanel.intLevelID);
            }

            if (joincategorySearchPanel.vchJoinCategoryType != null)
            {
                param.Add("@P_vchJoinCategoryType", joincategorySearchPanel.vchJoinCategoryType);
            }

            return DapperORM.ReturnList<tbl_MCE_JoinCategory>("SP_MCE_JoinCategory_Report", param);

        }

    }
}