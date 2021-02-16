using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Models.Domain.Employee
{
    public class tbl_MCE_Employee
    {

        [Key]
        public int intID { get; set; }

        [DisplayName("Employee Code")]
        [Required(ErrorMessage = "Enter Employee Code")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchEmployeeCode { get; set; }

        [DisplayName(" User Name")]
        [Required(ErrorMessage = "Enter User Name ")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchUserName { get; set; }


        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Enter Employee Name ")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchName { get; set; }

        [DisplayName("Password ")]
        [Required(ErrorMessage = "Enter Password ")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchPassword { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("Date Of Joining")]
        [Required(ErrorMessage = "Enter Date Of Joining")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> dtDOJ { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Of Ending")]
        [Required(ErrorMessage = "Enter Date Of Ending")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> dtDOE { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "Enter Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> dtDOB { get; set; }


        [DisplayName("Join Category")]
        [Required(ErrorMessage = "Enter Join Category ")]
        public Nullable<int> intJoinCategoryID { get; set; }

        [DisplayName("Course")]
        [Required(ErrorMessage = "enter Course")]
        public Nullable<int> intCourseID { get; set; }
        public string vchCourseName { get; set; }

        [DisplayName("Branch")]
        [Required(ErrorMessage = "Select Branch")]
        public Nullable<int> intBranchID { get; set; }
        public string vchBranchName { get; set; }

        [DisplayName("Designation")]
        [Required(ErrorMessage = "Select Designation")]
        public Nullable<int> intDesignationID { get; set; }
        public string vchDesignation { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "select Role")]
        public Nullable<int> intRoleID { get; set; }

        [DisplayName("Level")]
        [Required(ErrorMessage = "select Level")]
        public Nullable<int> intLevelID { get; set; }

        [DisplayName("Reporting Authority")]
        [Required(ErrorMessage = " enter RAID")]
        public Nullable<int> intRAID { get; set; }

        [DisplayName(" Gender")]
        [Required(ErrorMessage = "select Gender")]
        public string vchGender { get; set; }

        public Nullable<bool> bitMaritalStatus { get; set; }

        [DisplayName(" BloodGroup")]
        [Required(ErrorMessage = "select Blood Group")]
        public string vchBloodGroup { get; set; }

        [DisplayName(" Religion")]
        [Required(ErrorMessage = "enter Religion")]
        public string vchReligion { get; set; }

        [DisplayName(" CasteCategory")]
        [Required(ErrorMessage = "enter Caste Category")]
        public string vchCasteCategory { get; set; }

        [DisplayName(" Father Name")]
        [Required(ErrorMessage = "enter Father Name")]
        public string vchFatherName { get; set; }


        [DisplayName(" Mother Name")]
        [Required(ErrorMessage = "enter Mother Name")]
        public string vchMotherName { get; set; }


        [DisplayName(" Guardian Name")]
        [Required(ErrorMessage = "enter Guardian Name")]
        public string vchGuardianName { get; set; }


        [DisplayName(" GuardianContactNo")]
        [Required(ErrorMessage = "enter GuardianContactNo")]
        public string vchGuardianContactNo { get; set; }


        [DisplayName(" MobileNo")]
        [Required(ErrorMessage = "enter MobileNo")]
        public string vchEmployeeMobileNo { get; set; }

        [DisplayName(" Parent MobileNo")]
        [Required(ErrorMessage = "enter Parent MobileNo")]
        public string vchParentMobileNo { get; set; }

        [DisplayName(" AdhhaarNo")]
        [Required(ErrorMessage = "enter AdhhaarNo")]
        public string vchAdhhaarNo { get; set; }

        [DisplayName(" Email")]
        [Required(ErrorMessage = "enter Email")]
        public string vchEmployeeEmailAddress { get; set; }

        [DisplayName(" Parent Email")]
        [Required(ErrorMessage = "enter Parent Email")]
        public string vchParentEmailAddress { get; set; }

        [DisplayName("  Present Address")]
        [Required(ErrorMessage = "enter Present Address")]
        public string vchPresentAddress { get; set; }

        [DisplayName(" Permanent Address")]
        [Required(ErrorMessage = "enter Permanent Address")]
        public string vchPermanentAddress { get; set; }

        [DisplayName(" vchCountry ")]
        [Required(ErrorMessage = "enter vchCountry ")]
        public string vchCountry { get; set; }

        [DisplayName("CountryCodeForMobileNo")]
        [Required(ErrorMessage = "enter CountryCodeForMobileNo")]
        public string vchCountryCodeForMobileNo { get; set; }

        [DisplayName(" State")]
        [Required(ErrorMessage = "enter State")]
        public string vchState { get; set; }

        [DisplayName("District")]
        [Required(ErrorMessage = "enter District")]
        public string vchDistrict { get; set; }

        [DisplayName("PinCode")]
        [Required(ErrorMessage = "enter PinCode")]
        public string vchPinCode { get; set; }

        [DisplayName("Highest Qualification")]
        [Required(ErrorMessage = "enter HighestQualification")]
        public string vchHighestQualification { get; set; }

        [DisplayName("Experience As Joining Date")]
        [Required(ErrorMessage = "Enter ExperienceAsJoiningDate")]
        public decimal decExperienceAsJoiningDate { get; set; }

        public string vchUserImage { get; set; }
        public Nullable<bool> bitApproval { get; set; }


        [DisplayName("Approved By")]
        [Required(ErrorMessage = " enter ApprovalByID")]
        public Nullable<int> intApprovalByID { get; set; }
        public Nullable<DateTime> dtmApprovalDate { get; set; }
        public Nullable<int> intLogInFlag { get; set; }
        public Nullable<int> intFirstTimeLogin { get; set; }


        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        [DisplayName("Remarks")]
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }
    }
    public class Employee_DDL
    {
        public int intID { get; set; }
        public string vchName { get; set; }
    }
}