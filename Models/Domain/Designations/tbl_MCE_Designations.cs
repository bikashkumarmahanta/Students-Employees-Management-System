using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Models.Domain.Designations
{
    public class tbl_MCE_Designations
    {

        [DisplayName("Designation ID")]
        public int intDesignationID { get; set; }

        [DisplayName("Designation Name")]
        [Required(ErrorMessage = "Enter Designation")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchDesignation { get; set; }

        [DisplayName("Designation Description")]
        [Required(ErrorMessage = "Enter Designation Description")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchDesignationDescription { get; set; }

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

    public class DesignationList
    {
        public int intDesignationID { get; set; }

        public string vchDesignation { get; set; }

        public string vchDesignationDescription { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }
    }
}