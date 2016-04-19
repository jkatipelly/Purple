using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Purple.Models
{   [Table("tblOfferStatuses")]
    public class OfferStatus
    {   [Key]
        public int StatusID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}