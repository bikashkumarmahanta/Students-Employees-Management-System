﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMCE.Models.Repository.Subject;
using MyMCE.Models.Domain.Subject;

namespace MyMCE.Models.IRepository.Subject
{
    interface ISubject
    {
        //Add new Subject
        string AddSubject(tbl_MCE_Subject MCE_Subject);

        //Update Subject
        string EditSubject(tbl_MCE_Subject MCE_Subject);

        //Update Subject
        string DeleteSubject(tbl_MCE_Subject MCE_Subject);

        //To get All Subject List for View
        IEnumerable<tbl_MCE_Subject> SubjectList();

        //To get subject details of specific subject
        tbl_MCE_Subject SubjectDetails(int ID);
    }
}