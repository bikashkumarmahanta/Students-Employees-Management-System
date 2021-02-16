using MyMCE.Models.Domain.JoinCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMCE.Models.IRepository.JoinCategory
{
    interface IJoinCategory
    {
        //To get All JoinCategory List for View
        IEnumerable<tbl_MCE_JoinCategory> JoinCategoryList();

        //Add new JoinCategory
        string AddCategory(tbl_MCE_JoinCategory MCE_JoinCategory);

        //Edit
        //Update JoinCategory
        string EditJoinCategory(tbl_MCE_JoinCategory MCE_JoinCategory);

        //To get JoinCategoryDetails of specific category
        tbl_MCE_JoinCategory JoinCategoryDetails(int ID);

        //Delete JoinCategory
        string DeleteJoinCategory(tbl_MCE_JoinCategory MCE_JoinCategory);

        //To get All JoinCategoryList for View with respect to parameter
        IEnumerable<tbl_MCE_JoinCategory> JoinCategoryList(JoinCategorySearchPanel joincategorySearchPanel);
    }
}