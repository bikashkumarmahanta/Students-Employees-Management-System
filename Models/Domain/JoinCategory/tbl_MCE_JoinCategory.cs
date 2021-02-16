using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.JoinCategory
{
    public class tbl_MCE_JoinCategory
    {
        [Key]
        public int intJoinCategoryID { get; set; }


        [DisplayName("Level")]
        [Required(ErrorMessage = "Level")]
        public Nullable<int> intLevelID { get; set; }
        public string vchLevelName { get; set; }

        [DisplayName("Join Category type")]
        [Required(ErrorMessage = "Enter category type")]
        [StringLength(50, ErrorMessage = "Only 50 character are allowed")]
        public string vchJoinCategoryType { get; set; }

        [DisplayName("Join Description")]
        public string vchDescription { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        [DisplayName("Remark")]
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }



    }
    public class JoinCategorySearchPanel
    {
        public Nullable<int> intLevelID { get; set; }
        public string vchJoinCategoryType { get; set; }
    }
}