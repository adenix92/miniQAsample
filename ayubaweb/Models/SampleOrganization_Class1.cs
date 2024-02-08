using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayubaweb.Models
{
    public class SampleOrganization_Class1
    {
         public int SampleId { get; set; }
        public Nullable<int> UserId { get; set; }
        [Display(Name = "Name of Organization (Optional)")]
        [DataType(DataType.Text)]
        public string OrganizationName { get; set; }
        [Display(Name = "What is the primary business of your organization?")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Question 1 Require",AllowEmptyStrings =false)]
        public string Q1 { get; set; }
        public string A1 { get; set; }
        [Display(Name = "Please specify the size of your organization")]
        [DataType(DataType.Text)]
        public string Q2 { get; set; }
        public string A2 { get; set; }
        [Display(Name = "How many employees does your organization have")]
        [DataType(DataType.Text)]
        public string Q3 { get; set; }
        public string A4 { get; set; }

        [Display(Name = "What is the nature of your organization")]
        [DataType(DataType.Text)]
        public string Q5 { get; set; }
        public string A5 { get; set; }
        [Display(Name = "Do you have challenges using any applications or systems that uses the internet to operate?")]
        [DataType(DataType.Text)]
        public string Q6 { get; set; }
        public string A6 { get; set; }
        [Display(Name = "Has your organization ever participated in decision on prioritizing challenges that hinders adoption of IoT technologies?")]
        [DataType(DataType.Text)]
        public string Q7 { get; set; }
        public string A7 { get; set; }
        public string DateRegister { get; set; }
        public Nullable<int> Active { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
    }
}