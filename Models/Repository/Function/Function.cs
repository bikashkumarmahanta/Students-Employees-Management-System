using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Function;
using MyMCE.Models.IRepository.Function;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.Function
{
    public class Function : IFunction
    {
        public string AddFunction(tbl_MCE_Function MCE_Function)
        {

            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "FUNCTIONINS");

            param.Add("@P_vchFunctionName", MCE_Function.vchFunctionName);
            param.Add("@P_vchFileName", MCE_Function.vchFileName);
            param.Add("@P_vchDescription", MCE_Function.vchDescription);
            param.Add("@P_vchAction1", MCE_Function.vchAction1);
            param.Add("@P_vchAction2", MCE_Function.vchAction2);
            param.Add("@P_vchAction3", MCE_Function.vchAction3);
            param.Add("@P_vchRemarks", MCE_Function.vchRemarks);
            param.Add("@P_intCreatedBy", MCE_Function.intCreatedBy);

            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Function_DLM", param, "@P_VCHMSGOUT");


            throw new NotImplementedException();

        }

        public string DeleteFunction(tbl_MCE_Function MCE_Function)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "FUNCTIONDEL");
            param.Add("@P_intFunctionID", MCE_Function.intFunctionID);


            param.Add("@P_intCreatedBy", MCE_Function.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Function_DLM", param, "@P_VCHMSGOUT");

        }

        public string EditFunction(tbl_MCE_Function MCE_Function)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "FUNCTIONUP");
            param.Add("@P_intFunctionID", MCE_Function.intFunctionID);

            param.Add("@P_vchFunctionName", MCE_Function.vchFunctionName);
            param.Add("@P_vchFileName", MCE_Function.vchFileName);

            param.Add("@P_vchDescription", MCE_Function.vchDescription);
            param.Add("@P_vchAction1", MCE_Function.vchAction1);
            param.Add("@P_vchAction2", MCE_Function.vchAction2);
            param.Add("@P_vchAction3", MCE_Function.vchAction3);
            param.Add("@P_vchRemarks", MCE_Function.vchRemarks);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Function_DLM", param, "@P_VCHMSGOUT");
        }

        public tbl_MCE_Function FunctionDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "FUNCTIONDTLS");
            param.Add("@P_intFunctionID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Function>("SP_MCE_Function_Report", param);
        }

        public IEnumerable<tbl_MCE_Function> FunctionList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "FUNCTIONALL");


            return DapperORM.ReturnList<tbl_MCE_Function>("SP_MCE_Function_Report", param);
        }

        public IEnumerable<tbl_MCE_Function> FunctionList(FunctionSearchPanel functionSearchPanel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "FUNCTIONALLSP");
            if (functionSearchPanel.vchFunctionName != null)
            {
                param.Add("@P_vchFunctionName", functionSearchPanel.vchFunctionName);
            }
            if (functionSearchPanel.vchDescription != null)
            {
                param.Add("@P_vchDescription", functionSearchPanel.vchDescription);
            }
            return DapperORM.ReturnList<tbl_MCE_Function>("SP_MCE_Function_Report", param);
        }
    }
}