using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ayubaweb.Models
{
    public class SignIn
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is Required")]
        [Display(Name ="Username")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is Required")]
        public string Passwords { get; set; }
    }
}