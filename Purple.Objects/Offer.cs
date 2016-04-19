using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Purple.Models
{   [Table("tblOffers")]
    public class Offer
    {
        [Key]
        public int OfferID { get; set; }
        public int Property { get; set; }
        public int Buyer { get; set; }
        public int Seller { get; set; }
        public int Status { get; set; }
    }
}