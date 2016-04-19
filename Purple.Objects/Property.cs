using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Purple.Models
{
    public class Property
    {
        public int PropertyID { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Is { get; set; }
    }
}