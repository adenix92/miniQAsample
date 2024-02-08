using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayubaweb.Models
{
    public class QuestionAndAnswer
    {
        public int RId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> QId { get; set; }

       
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Question 1 require")]
        public string A1 { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Question 2 Require")]
        public string A2 { get; set; }

        [Required(ErrorMessage = "Question 3 Require")]
        [DataType(DataType.Text)]
        public string A3 { get; set; }

        [Required(ErrorMessage = "Question 4 Require")]
        [DataType(DataType.Text)]
        public string A4 { get; set; }

        [Required(ErrorMessage = "Question 5 Require")]
        [DataType(DataType.Text)]
        public string A5 { get; set; }

        public string DateAnswer { get; set; }
        public Nullable<int> Active { get; set; }

        [DataType(DataType.Text)]
        public string QuestionTitle { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}