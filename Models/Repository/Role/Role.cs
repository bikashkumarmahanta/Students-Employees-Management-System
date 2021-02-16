using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Role;
using MyMCE.Models.IRepository.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.Role
{
    public class Role : IRole
    {
        public string AddRole(tbl_MCE_Role mce_Role)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "ROLEINSERT");

            param.Add("@P_vchRoleName", mce_Role.vchRoleName);
            param.Add("@P_vchDescription", mce_Role.vchDescription);

            param.Add("@P_vchRemarks", mce_Role.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Role.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Role_DML", param, "@P_VCHMSGOUT");

            throw new NotImplementedException();
        }

        public string DeleteRole(tbl_MCE_Role mce_Role)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "ROLEDELETE");
            param.Add("@P_intRoleID", mce_Role.intRoleID);





            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Role_DML", param, "@P_VCHMSGOUT");
            throw new NotImplementedException();
        }

        public string EditRole(tbl_MCE_Role mce_Role)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "ROLEUPDATE");
            param.Add("@P_intRoleID", mce_Role.intRoleID);
            param.Add("@P_vchRoleName", mce_Role.vchRoleName);
            param.Add("@P_vchDescription", mce_Role.vchDescription);

            param.Add("@P_vchRemarks", mce_Role.vchRemarks);
            param.Add("@P_intCreatedBy", mce_Role.intCreatedBy);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Role_DML", param, "@P_VCHMSGOUT");

            throw new NotImplementedException();
        }

        public tbl_MCE_Role RoleDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "ROLEDETAILS");
            param.Add("@P_intRoleID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Role>("SP_MCE_Role_Report", param);

            throw new NotImplementedException();
        }

        public IEnumerable<tbl_MCE_Role> RoleList()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "ROLEALL");

            return DapperORM.ReturnList<tbl_MCE_Role>("SP_MCE_Role_Report", param);
            throw new NotImplementedException();
        }


    }
}