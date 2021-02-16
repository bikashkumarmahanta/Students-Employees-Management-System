using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Models.Domain.Course
{
    //[Bind(Exclude = "intCourseID")]
    public class tbl_MCE_Course
    {
        [Key]
        public int intCourseID { get; set; }

        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Enter Course Name")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchCourseName { get; set; }

        [DisplayName("Course Description")]
        [Required(ErrorMessage = "Enter Course Description")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchCourseDescription { get; set; }

        [DisplayName("No Of Years ")]
        [Required(ErrorMessage = "Enter No Of Years ")]
        [Range(1, 6, ErrorMessage = "Please enter valid No Of Years (1 to 6)")]
        public Nullable<int> intNoOfYears { get; set; }

        [DisplayName("No Of Semesters")]
        [Required(ErrorMessage = "Enter No Of Semesters")]
        [Range(1, 12, ErrorMessage = "Please enter valid No Of Semesters (1 to 12)")]
        public Nullable<int> intNoOfSemesters { get; set; }

        [DisplayName("Semester Duration")]
        [Required(ErrorMessage = "Enter Semester Duration")]
        [Range(1, 200, ErrorMessage = "Please enter valid Semester Duration (1 to 200)")]
        public Nullable<int> intSemesterDuration { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Enter Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dtmStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        [Required(ErrorMessage = "Enter End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dtmEndDate { get; set; }


        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }
    }
    public class Course_DDL
    {
        public int intCourseID { get; set; }
        public string vchCourseName { get; set; }
    }
}