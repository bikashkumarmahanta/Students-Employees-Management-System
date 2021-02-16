using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.GlobalLink
{
    public class tbl_MCE_GlobalLink
    {

        public int intGLinkID { get; set; }

        [DisplayName("Global Link Name")]
        [Required(ErrorMessage = "Enter Global Link Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchGLinkName { get; set; }

        [DisplayName("Sorted Number")]
        [Required(ErrorMessage = "Enter Sorted Number")]
        public int intSortNum { get; set; }

        [DisplayName("Home Page")]
        [Required(ErrorMessage = "Enter Home Page")]
        public bool bitHomePage { get; set; }

        [DisplayName("Icon")]
        [Required(ErrorMessage = "Enter Icon")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchIcon { get; set; }



        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        [DisplayName("Remark")]
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }

    }

    public class GlobalLinkSearchPanel
    {
        public int intGLinkID { get; set; }
        public string vchGLinkName { get; set; }
        public int intSortNum { get; set; }
    }
}