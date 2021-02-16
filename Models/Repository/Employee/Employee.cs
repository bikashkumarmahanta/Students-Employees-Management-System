using Dapper;
using MyMCE.Models.ConnectionFactory;
using MyMCE.Models.Domain.Employee;
using MyMCE.Models.IRepository.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Repository.Employee
{
    public class Employee : IEmployee
    {

        public string AddEmployee(tbl_MCE_Employee mce_Employee)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "EMPLOYEEINSERT");

            param.Add("@P_vchEmployeeCode", mce_Employee.vchEmployeeCode);
            param.Add("@P_vchUserName", mce_Employee.vchUserName);
            param.Add("@P_vchName", mce_Employee.vchName);
            param.Add("@P_vchPassword ", mce_Employee.vchPassword);
            param.Add("@P_dtDOJ ", mce_Employee.dtDOJ);
            param.Add("@P_dtDOB ", mce_Employee.dtDOB);
            param.Add("@P_intJoinCategoryID", mce_Employee.intJoinCategoryID);
            param.Add("@P_intCourseID", mce_Employee.intCourseID);
            param.Add("@p_vchCourseName", mce_Employee.vchCourseName);
            param.Add("@P_intBranchID", mce_Employee.intBranchID);
            param.Add("@p_vchBranchName", mce_Employee.vchBranchName);
            param.Add("@P_intDesignationID", mce_Employee.intDesignationID);
            param.Add("@P_vchDesignation", mce_Employee.vchDesignation);
            param.Add("@P_intRoleID ", mce_Employee.intRoleID);
            param.Add("@P_intLevelID", mce_Employee.intLevelID);
            param.Add("@P_intRAID", mce_Employee.intRAID);
            param.Add("@P_intApprovalByID ", mce_Employee.intApprovalByID);
            param.Add("@P_vchGender", mce_Employee.vchGender);
            param.Add("@P_vchHighestQualification ", mce_Employee.vchHighestQualification);
            param.Add("@P_decExperienceAsJoiningDate ", mce_Employee.decExperienceAsJoiningDate);
            param.Add("@P_vchRemarks ", mce_Employee.vchRemarks);



            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Employee_DML", param, "@P_VCHMSGOUT");


        }

        public string Deleteemployee(tbl_MCE_Employee mce_Employee)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "EMPLOYEEDELETE");
            param.Add("@P_intID", mce_Employee.intID);


            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Employee_DML", param, "@P_VCHMSGOUT");
        }

        public string Editemployee(tbl_MCE_Employee mce_Employee)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "EMPLOYEEUPDATE");
            param.Add("@P_intID", mce_Employee.intID);

            param.Add("@P_vchEmployeeCode", mce_Employee.vchEmployeeCode);
            param.Add("@P_vchName", mce_Employee.vchName);

            param.Add("@P_dtDOJ ", mce_Employee.dtDOJ);
            param.Add("@P_intJoinCategoryID", mce_Employee.intJoinCategoryID);
            param.Add("@P_intCourseID", mce_Employee.intCourseID);
            param.Add("@p_vchCourseName", mce_Employee.vchCourseName);
            param.Add("@P_intBranchID", mce_Employee.intBranchID);
            param.Add("@p_vchBranchName", mce_Employee.vchBranchName);
            param.Add("@P_intDesignationID", mce_Employee.intDesignationID);
            param.Add("@P_vchDesignation", mce_Employee.vchDesignation);
            param.Add("@P_intRoleID ", mce_Employee.intRoleID);
            param.Add("@P_intLevelID", mce_Employee.intLevelID);
            param.Add("@P_intRAID", mce_Employee.intRAID);
            param.Add("@P_intApprovalByID ", mce_Employee.intApprovalByID);
            param.Add("@P_vchGender", mce_Employee.vchGender);
            param.Add("@P_vchHighestQualification ", mce_Employee.vchHighestQualification);
            param.Add("@P_decExperienceAsJoiningDate ", mce_Employee.decExperienceAsJoiningDate);
            param.Add("@P_vchRemarks ", mce_Employee.vchRemarks);

            param.Add("@P_VCHMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            return DapperORM.ExecuteDML("SP_MCE_Employee_DML", param, "@P_VCHMSGOUT");
        }

        public tbl_MCE_Employee EmployeeDetails(int ID)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "EMPLOYEEDETAILS");
            param.Add("@P_intID", ID);
            return DapperORM.ReturnDetails<tbl_MCE_Employee>("SP_MCE_Employee_Report", param);
        }

        public IEnumerable<tbl_MCE_Employee> EmployeeList()
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@P_CHRACTION", "EMPLOYEEALL");


            return DapperORM.ReturnList<tbl_MCE_Employee>("SP_MCE_Employee_Report", param);
        }

        public IEnumerable<Employee_DDL> EmployeeList1()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@P_CHRACTION", "ELD");
            return DapperORM.ReturnList<Employee_DDL>("SP_MCE_Employee_Report", param);
        }
    }
}