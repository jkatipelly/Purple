using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Purple.Entities
{
   
    public class OfferStatus
    {       
        public int StatusID { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}