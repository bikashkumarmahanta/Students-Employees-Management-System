using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.Role
{
    public class tbl_MCE_Role
    {
        public int intRoleID { get; set; }

        [DisplayName("Role Name")]
        [Required(ErrorMessage = "Enter Role Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchRoleName { get; set; }

        [DisplayName("Role Description")]
        [Required(ErrorMessage = "Enter Role Description")]
        [StringLength(500, ErrorMessage = "Only 500 character are allowed")]
        public string vchDescription { get; set; }




        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }

        [DisplayName("Role Remark")]
        [Required(ErrorMessage = "Enter Remark")]
        [StringLength(500, ErrorMessage = "Only 500 character are allowed")]
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }
    }
}