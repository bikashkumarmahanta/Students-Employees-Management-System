using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMCE.Models.Domain.PrimaryLink
{

    public class tbl_MCE_PrimaryLink
    {
        [Key]
        public int intPLinkID { get; set; }

        [DisplayName("Primary Link Name")]
        [Required(ErrorMessage = "Enter PrimaryLink Name")]
        [StringLength(300, ErrorMessage = "Only 300 character are allowed")]
        public string vchPLinkName { get; set; }

        [DisplayName("Global Link Name")]
        [Required(ErrorMessage = "GlobalLink Name")]
        public Nullable<int> intGLinkID { get; set; }

        [DisplayName("Global Link Name")]
        public string vchGLinkName { get; set; }

        [DisplayName("Function Name")]
        [Required(ErrorMessage = "Enter Function Name")]
        public Nullable<int> intFunctionID { get; set; }

        [DisplayName("Function Name")]
        public string vchFunctionName { get; set; }



        [DisplayName("SL No")]
        [Required(ErrorMessage = "Enter SL No")]
        public int intSlNo { get; set; }

        [DisplayName("ExternalUrl")]
        public string vchExternalURL { get; set; }

        [DisplayName("LinkType")]
        public Nullable<bool> bitLinkType { get; set; }

        [DisplayName("ShowOnHomePage")]
        public Nullable<bool> bitShowOnHomePage { get; set; }

        [DisplayName("AccessID")]
        public Nullable<int> intAccessID { get; set; }

        [DisplayName("Access")]
        public Nullable<int> intAccess { get; set; }

        [DisplayName("UserID")]
        public Nullable<int> intUserID { get; set; }

        [DisplayName("Action1")]
        public string vchAction1 { get; set; }

        [DisplayName("Icon")]
        public string vchIcon { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }
        [DisplayName("Remarks")]
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }


    }
    public class PrimaryLinkSearchPanel
    {

        public string vchGLinkName { get; set; }
        public string vchPLinkName { get; set; }
        public string vchFunctionName { get; set; }

    }

}