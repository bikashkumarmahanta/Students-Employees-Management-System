using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.GroupLinkAccess
{
    public class tbl_MCE_GroupLinkAccess
    {
        [Key]
        public int intGroupLinkAccessID { get; set; }
        [DisplayName("GroupLinkAccessName")]
        [Required(ErrorMessage = "GroupLinkAccessName")]
        public string vchGroupLinkAccessName { get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "Enter Role")]
        public Nullable<int> intRoleID { get; set; }
        [DisplayName("Role")]
        public string vchDescription { get; set; }

        [DisplayName("Primary Link Name")]
        [Required(ErrorMessage = "Enter PrimaryLink Name")]
        public Nullable<int> intPLinkID { get; set; }

        [DisplayName("Primary Link Name")]
        [Required(ErrorMessage = "Enter PrimaryLink Name")]
        [StringLength(300, ErrorMessage = "Only 300 character are allowed")]
        public string vchPLinkName { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        [DisplayName("Remarks")]
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }

    }
    public class GroupLinkAccessSearchPanel
    {

        public string vchGroupLinkAccessName { get; set; }
        public string vchPLinkName { get; set; }
        public string vchDescription { get; set; }

    }
}