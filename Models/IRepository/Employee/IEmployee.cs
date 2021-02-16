using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyMCE.Models.Domain.Employee;
using MyMCE.Models.Repository.Employee;

namespace MyMCE.Models.IRepository.Employee
{
    interface IEmployee
    {
        //Add new Employee
        string AddEmployee(tbl_MCE_Employee mce_Employee);

        //To get All Subject List for View
        IEnumerable<tbl_MCE_Employee> EmployeeList();

        //To get employee details of specific employee
        tbl_MCE_Employee EmployeeDetails(int ID);

        IEnumerable<Employee_DDL> EmployeeList1();

        //Update employee
        string Editemployee(tbl_MCE_Employee mce_Employee);

        //Update employee
        string Deleteemployee(tbl_MCE_Employee mce_Employee);
    }
}