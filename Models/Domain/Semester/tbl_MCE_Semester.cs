using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.Semester
{
    public class tbl_MCE_Semester
    {
        [Key]
        public int intSemesterID { get; set; }

        [DisplayName("Admission Batch")]
        [Required(ErrorMessage = "Enter Admission Batch")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchAdmissionBatch { get; set; }



        [DisplayName("Course")]
        [Required(ErrorMessage = "Course")]
        public Nullable<int> intCourseID { get; set; }
        public string vchCourseName { get; set; }

        [DisplayName("Branch")]
        [Required(ErrorMessage = "Select Branch")]
        public Nullable<int> intBranchID { get; set; }
        public string vchBranchName { get; set; }

        [DisplayName("Semester")]
        [Required(ErrorMessage = "Enter Semester")]
        [Range(1, 8, ErrorMessage = "Please enter valid semister (1 to 8)")]
        public Nullable<int> intSemester { get; set; }

        [DisplayName("Section")]
        [Required(ErrorMessage = "Enter Section")]
        [StringLength(50, ErrorMessage = "Only 10 character are allowed")]
        public string vchSection { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> dtmStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> dtmEndDate { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }

    }

    public class SemesterSearchPanel
    {
        public Nullable<int> intCourseID { get; set; }
        public Nullable<int> intBranchID { get; set; }
        public Nullable<int> intSemester { get; set; }
        public string vchAdmissionBatch { get; set; }
    }
}