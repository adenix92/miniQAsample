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
    
    public partial class SampleOrganization
    {
        public int SampleId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string OrganizationName { get; set; }
        public string Q1 { get; set; }
        public string A1 { get; set; }
        public string Q2 { get; set; }
        public string A2 { get; set; }
        public string Q3 { get; set; }
        public string A4 { get; set; }
        public string Q5 { get; set; }
        public string A5 { get; set; }
        public string Q6 { get; set; }
        public string A6 { get; set; }
        public string Q7 { get; set; }
        public string A7 { get; set; }
        public string DateRegister { get; set; }
        public Nullable<int> Active { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
    }
}