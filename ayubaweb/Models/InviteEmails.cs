using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ayubaweb.Models
{
    public class InviteEmails
    {
        public int EmailId { get; set; }
        
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email Require",AllowEmptyStrings =false)]
        public string Email { get; set; }

        public string DateRegister { get; set; }
        public Nullable<int> Active { get; set; }

    }

    public class EmailRecords
    {
        public int EmailId { get; set; }

        public string Email { get; set; }

        public string DateRegister { get; set; }
        public Nullable<int> Active { get; set; }
    }
}