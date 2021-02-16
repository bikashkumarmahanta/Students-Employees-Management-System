using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.Branches
{
    public class tbl_MCE_Branch
    {
        public int intBranchID { get; set; }

        [DisplayName("Branch Code")]
        [Required(ErrorMessage = "Enter Branch Code")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchBranchCode { get; set; }

        [DisplayName("Branch Name")]
        [Required(ErrorMessage = "Enter Branch Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchBranchName { get; set; }

        [DisplayName("Branch Description")]
        [Required(ErrorMessage = "Enter Branch Description")]
        [StringLength(200, ErrorMessage = "Only 200 character are allowed")]
        public string vchBranchDescription { get; set; }

        [DisplayName("Course")]
        [Required(ErrorMessage = "Course")]
        public Nullable<int> intCourseID { get; set; }
        public string vchCourseName { get; set; }


        //[DisplayName("Course Name")]
        //[Required(ErrorMessage = "Enter Course Name")]
        //[StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        //public string vchCourseName { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }

        [DisplayName("Remarks")]
        [Required(ErrorMessage = "Enter Remarks")]
        [StringLength(200, ErrorMessage = "Only 200 character are allowed")]
        public string vchRemarks { get; set; }

        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }
    }

    public class Branch_DDL
    {
        public int intBranchID { get; set; }
        public Nullable<int> intCourseID { get; set; }
        public string vchBranchName { get; set; }

    }
    public class BranchSearchPanel
    {
        public Nullable<int> intCourseID { get; set; }
        public string vchBranchDescription { get; set; }
    }
}