using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMCE.Models.Domain.Function
{
    public class tbl_MCE_Function
    {

        [Key]
        public int intFunctionID { get; set; }

        [DisplayName("Function Name")]
        [Required(ErrorMessage = "Enter Function Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchFunctionName { get; set; }

        [DisplayName("File  Name")]
        [Required(ErrorMessage = "Enter File Name")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchFileName { get; set; }

        [DisplayName("Function Description")]
        [Required(ErrorMessage = "Enter Function Description")]
        [StringLength(100, ErrorMessage = "Only 100 character are allowed")]
        public string vchDescription { get; set; }

        [DisplayName("Function Action1")]
        public string vchAction1 { get; set; }

        [DisplayName("Function Action2")]
        public string vchAction2 { get; set; }

        [DisplayName("Function Action3")]
        public string vchAction3 { get; set; }

        public Nullable<bool> bitStatus { get; set; }
        public Nullable<bool> bitDeletedFlag { get; set; }

        [DisplayName("Function Remark")]
        public string vchRemarks { get; set; }
        public Nullable<int> intCreatedBy { get; set; }
        public Nullable<System.DateTime> dtmCreatedOn { get; set; }
        public Nullable<int> intUpdatedBy { get; set; }
        public Nullable<System.DateTime> dtmUpdatedOn { get; set; }

    }
    public class Function_DDL
    {
        public int intFunctionID { get; set; }
        public string vchFunctionName { get; set; }
    }
    public class FunctionSearchPanel
    {
        public string vchFunctionName { get; set; }
        public string vchDescription { get; set; }
    }
}