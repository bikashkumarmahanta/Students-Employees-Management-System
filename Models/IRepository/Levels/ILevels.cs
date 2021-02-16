using MyMCE.Models.Domain.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMCE.Models.IRepository.Levels
{
    interface ILevels
    {
        //To enter the levels
        string AddLevel(tbl_MCE_Levels mce_Levels);

        //To show level list
        IEnumerable<tbl_MCE_Levels> LevelList();

        //Edit level
        //string EditDesignation(tbl_MCE_Designations MCE_Designations);
        string EditLevel(tbl_MCE_Levels MCE_Levels);

        //Delete Level
        //string DeleteDesignation(tbl_MCE_Designations MCE_Designations);
        string DeleteLevel(tbl_MCE_Levels MCE_Levels);

        //To get Level details of specific Level
        //tbl_MCE_Designations DesignationDetails(int ID);
        tbl_MCE_Levels LevelDetails(int ID);
    }
}