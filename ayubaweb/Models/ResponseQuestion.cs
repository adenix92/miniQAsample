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
    
    public partial class ResponseQuestion
    {
        public int RId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> QId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string DateAnswer { get; set; }
        public Nullable<int> Active { get; set; }
    
        public virtual QuestionTitle QuestionTitle { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}