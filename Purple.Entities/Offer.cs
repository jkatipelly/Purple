using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Purple.Entities
{  
    public class Offer
    {   
        public int OfferID { get; set; }     
        public int Property { get; set; }
        public int Buyer { get; set; }
        public int Seller { get; set; }
        public int Status { get; set; }
    }
}