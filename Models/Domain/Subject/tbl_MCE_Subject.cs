using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Models.Domain.Subject
{

    public class tbl_MCE_Subject
    {

        public int intSubjectID { get; set; }

        [DisplayName("Subject Code")]
        [Required(ErrorMessage = "Enter Subject Code")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchSubjectCode { get; set; }

        [DisplayName("Subject Name")]
        [Required(ErrorMessage = "Enter Subject Name")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchSubjectName { get; set; }

        [DisplayName("Subject Description")]
        public string vchSubjectDescription { get; set; }

        [DisplayName("Course")]
        [Required(ErrorMessage = "Course")]
        public Nullable<int> intCourseID { get; set; }
        public string vchCourseName { get; set; }

        [DisplayName("Branch")]
        [Required(ErrorMessage = "Select Branch")]
        public Nullable<int> intBranchID { get; set; }
        public string vchBranchCode { get; set; }
        public string vchBranchName { get; set; }

        [DisplayName("Semister")]
        [Required(ErrorMessage = "Enter Semister")]
        [Range(1, 8, ErrorMessage = "Please enter valid semister (1 to 8)")]
        public Nullable<int> intSemister { get; set; }

        [DisplayName("Subject Type")]
        [Required(ErrorMessage = "Select Subject Type")]
        public string vchSubjectType { get; set; }

        [DisplayName("Subject Category")]
        [Required(ErrorMessage = "Select Subject Category")]
        public string vchSubjectCategory { get; set; }

        [DisplayName("Credit")]
        [Required(ErrorMessage = "Enter Credit")]
        [Range(1, 16, ErrorMessage = "Please enter valid semister (1 to 16)")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Please enter a valid decimal number")]
        public decimal decCredit { get; set; }

        [DisplayName("Hours")]
        [Required(ErrorMessage = "Enter Number of Hours")]
        [Range(1, 200, ErrorMessage = "Please enter valid semister (1 to 200)")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Please enter a valid decimal number")]
        public Nullable<decimal> decHours { get; set; }


        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }


    }
    public class SubjectList
    {
        public int intSubjectID { get; set; }
        public string vchSubjectCode { get; set; }
        public string vchSubjectName { get; set; }

        public string vchSubjectDescription { get; set; }
        public string vchSubjectType { get; set; }
        public string vchSubjectCategory { get; set; }
        public decimal decCredit { get; set; }
        public Nullable<decimal> decHours { get; set; }

    }




}