//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Purple.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUserType
    {
        public tblUserType()
        {
            this.tblUsers = new HashSet<tblUser>();
        }
    
        public int UserTypeID { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<tblUser> tblUsers { get; set; }
    }
}
