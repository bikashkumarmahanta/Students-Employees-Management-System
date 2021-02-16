using MyMCE.Models.Domain.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMCE.Models.IRepository.Branches
{
    interface IBranches
    {
        //list
        IEnumerable<Branch_DDL> BranchList();
        IEnumerable<tbl_MCE_Branch> BranchL();

        //create
        string AddBranch(tbl_MCE_Branch mce_Branch);

        //edit
        //Update Subject
        string EditBranch(tbl_MCE_Branch MCE_Branch);

        //To get subject details of specific subject
        tbl_MCE_Branch BranchDetails(int ID);

        //Delete Subject
        string DeleteBranch(tbl_MCE_Branch MCE_Branch);
        //To get All Course List for View with respect to parameter
        IEnumerable<tbl_MCE_Branch> BranchList(BranchSearchPanel branchSearchPanel);
    }
}