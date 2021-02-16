using MyMCE.Models.Domain.Levels;
using MyMCE.Models.IRepository.Levels;
using MyMCE.Models.Repository.Levels;
using MyMCE.Models.ConnectionFactory;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MyMCE.Models.Repository.Levels
{
    public class Levels : ILevels
    {
        public string AddLevel(tbl_MCE_Levels mce_Levels)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "LEVELINSERT");
            param.Add("@P_intLevelID", mce_Levels.intLevelID);
            param.Add("@P_vchLevelName", mce_Levels.vchLevelName);
            param.Add("@P_vchRemarks", mce_Levels.vchRemarks);

            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Level_DLM", param, "@P_VCHMSGOUT");
        }

        public string DeleteLevel(tbl_MCE_Levels mce_Levels)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "LEVELDELETE");
            param.Add("@P_intLevelID", mce_Levels.intLevelID);


            param.Add("@P_intCreatedBy", mce_Levels.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Level_DLM", param, "@P_VCHMSGOUT");
        }

        public string EditLevel(tbl_MCE_Levels mce_Levels)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "LEVELUPDATE");
            param.Add("@P_intLevelID", mce_Levels.intLevelID);

            param.Add("@P_vchLevelName", mce_Levels.vchLevelName);


            param.Add("@P_vchRemarks", mce_Levels.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Levels.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Level_DLM", param, "@P_VCHMSGOUT");
        }

        public tbl_MCE_Levels LevelDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "LEVELDETAILS");
            param.Add("@P_intLevelID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Levels>("SP_MCE_Level_Report", param);
        }

        public IEnumerable<tbl_MCE_Levels> LevelList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "LEVELALL");

            return DapperORM.ReturnList<tbl_MCE_Levels>("SP_MCE_Level_Report", param);
        }
    }
}