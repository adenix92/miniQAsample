//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ayubaweb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserProfile()
        {
            this.ResponseQuestions = new HashSet<ResponseQuestion>();
            this.SampleOrganizations = new HashSet<SampleOrganization>();
        }
    
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string JobTitle { get; set; }
        public string CurrentAddressOrganization { get; set; }
        public string AreaSpecialization { get; set; }
        public Nullable<int> WorkingExperience { get; set; }
        public string Question1 { get; set; }
        public string Answer1 { get; set; }
        public string Question2 { get; set; }
        public string Answer2 { get; set; }
        public string DateRegister { get; set; }
        public Nullable<int> Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResponseQuestion> ResponseQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SampleOrganization> SampleOrganizations { get; set; }
    }
}
