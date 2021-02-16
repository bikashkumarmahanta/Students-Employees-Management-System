using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.Student
{
    public class tbl_MCE_Student
    {
        public int intID { get; set; }
        public string vchRegistrationNo { get; set; }
        public string vchRollNo { get; set; }
        public string vchName { get; set; }
        public string vchUserName { get; set; }
        public string vchPassword { get; set; }
        public string vchSecurityQuestion { get; set; }
        public string vchSecrityQuestionAnswer { get; set; }
        public int intLogInFlag { get; set; }
        public int intFirstTimeLogin { get; set; }
        public int intRoleID { get; set; }
        public int intLevelID { get; set; }
        public int intRAID { get; set; }
        public Nullable<DateTime> dtmDOJ { get; set; }
        public Nullable<DateTime> dtmDOE { get; set; }
        public string vchAdmissionBatch { get; set; }
        public int intCourseID { get; set; }
        public string vchCourseName { get; set; }
        public int intBranchID { get; set; }
        public string vchBranchName { get; set; }
        public int intSemister { get; set; }
        public string vchSection { get; set; }
        public int intJoinCategoryID { get; set; }
        public Nullable<DateTime> dtmDOB { get; set; }
        public string vchGender { get; set; }
        public Nullable<bool> bitMaritalStatus { get; set; }
        public string vchBloodGroup { get; set; }
        public string vchReligon { get; set; }
        public string vchCasteCategory { get; set; }
        public string vchFathersName { get; set; }
        public string vchMothersName { get; set; }
        public string vchGuardianName { get; set; }
        public string vchGuardianContactNo { get; set; }
        public string vchStudentMobileNo { get; set; }
        public string vchParentMobileNo { get; set; }
        public string vchAdhhaarNo { get; set; }
        public string vchStudentEmailAddress { get; set; }
        public string vchParentEmailAddress { get; set; }
        public string vchPresentAddress { get; set; }
        public string vchPermanentAddress { get; set; }
        public string vchCountry { get; set; }
        public string vchCountryCodeForMobileNo { get; set; }
        public string vchState { get; set; }
        public string vchDistrict { get; set; }
        public string vchPinCode { get; set; }
        public Nullable<bool> bitStayingAtHostel { get; set; }
        public string vchHostelName { get; set; }
        public string vchBlockNo { get; set; }
        public int intRoomNo { get; set; }
        public int intBedNo { get; set; }
        public string vchHostelLocation { get; set; }
        public string vchUserImage { get; set; }
        public int intApproval { get; set; }
        public int intApprovalByID { get; set; }
        public Nullable<bool> dtApprovalDate { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }
    }
    public class tbl_MCE_Student_Basic
    {
        [DisplayName("Student Name")]
        [Required(ErrorMessage = "Enter Function Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchName { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "Enter User Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchUserName { get; set; }
        [DisplayName("Password")]
        public string vchPassword { get; set; }
        [DisplayName("AdmissionBatch")]
        public string vchAdmissionBatch { get; set; }
        [DisplayName("CourseID")]
        public int intCourseID { get; set; }
        [DisplayName("CourseName")]
        public string vchCourseName { get; set; }
        [DisplayName("BranchID")]
        public int intBranchID { get; set; }
        [DisplayName("BranchName")]
        public string vchBranchName { get; set; }
        [DisplayName("Semister")]
        public int intSemister { get; set; }
        [DisplayName("JoinCategory Type")]
        public int intJoinCategoryID { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("DOB")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dtmDOB { get; set; }
        [DisplayName("Gender")]
        public string vchGender { get; set; }
        [DisplayName("Remarks")]
        public string vchRemarks { get; set; }
        public int intRoleID { get; set; }
        public int intLevelID { get; set; }
    }
}