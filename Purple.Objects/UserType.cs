using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Purple.Models
{   [Table("tblUserTypes")]
    public class UserType
    {   [Key]
        public int UserTypeID { get; set; }
        public string Description { get; set; }
    }
}