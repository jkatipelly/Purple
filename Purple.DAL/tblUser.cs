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
    
    public partial class tblUser
    {
        public tblUser()
        {
            this.tblOffers = new HashSet<tblOffer>();
            this.tblOffers1 = new HashSet<tblOffer>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeID { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<tblOffer> tblOffers { get; set; }
        public virtual ICollection<tblOffer> tblOffers1 { get; set; }
        public virtual tblUserType tblUserType { get; set; }
    }
}
