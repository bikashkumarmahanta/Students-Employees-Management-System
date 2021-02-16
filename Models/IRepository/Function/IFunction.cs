using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMCE.Models.Domain.Function;

namespace MyMCE.Models.IRepository.Function
{
    interface IFunction
    {
        // To add  a new function
        string AddFunction(tbl_MCE_Function MCE_Function);

        //Update Function
        string EditFunction(tbl_MCE_Function MCE_Function);

        //Delete Function
        string DeleteFunction(tbl_MCE_Function MCE_Function);


        //To get All Function List for View
        IEnumerable<tbl_MCE_Function> FunctionList();

        //To get function details of specific function
        tbl_MCE_Function FunctionDetails(int ID);

        //To get All Function List for View with respect to parameter
        IEnumerable<tbl_MCE_Function> FunctionList(FunctionSearchPanel functionSearchPanel);

    }
}
