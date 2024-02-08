using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayubaweb.Models
{
    public class Userprofile_class
    {
        public int UserId { get; set; }
        [Display(Name ="FullName")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        
        public string Email { get; set; }
        [Display(Name ="Country")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Country Required",AllowEmptyStrings =false)]
        public string Country { get; set; }
        [Display(Name ="Job Title")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Job Title Require",AllowEmptyStrings =false)]
        public string JobTitle { get; set; }
        [Display(Name = "Current address of your organization")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Address Require",AllowEmptyStrings =false)]
        public string CurrentAddressOrganization { get; set; }
        [Display(Name = "Area of specialization")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Area of Specialization Require",AllowEmptyStrings =false)]
        public string AreaSpecialization { get; set; }
        
     
        public int WorkingExperience { get; set; }
    
        public string Question1 { get; set; }
        public string Answer1 { get; set; }
        
        public string Question2 { get; set; }
        public string Answer2 { get; set; }
        public string DateRegister { get; set; }
        public int Active { get; set; }

       
        public virtual ICollection<ResponseQuestion> ResponseQuestions { get; set; }
        public virtual ICollection<SampleOrganization> SampleOrganizations { get; set; }
    }
}