using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Purple.Entities
{
    
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyID { get; set; }

        [Required(ErrorMessage = "*")]
        public string Description { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "*")]
        public bool IsSold { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}