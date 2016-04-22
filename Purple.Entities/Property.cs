using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Purple.Entities
{
    
    public class Property
    {       
        public int PropertyID { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "IsSold is required")]
        public bool IsSold { get; set; }      
    }
}