using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Models.Domain.Levels
{
    public class tbl_MCE_Levels
    {
        [DisplayName("Level ID")]
        public int intLevelID { get; set; }

        [DisplayName("Level Name")]
        [Required(ErrorMessage = "Enter Level Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchLevelName { get; set; }


        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }

        [DisplayName("Remarks")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchRemarks { get; set; }

        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }
    }
}