using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Purple.Entities
{   
    public class User
    {
       
        public int UserID { get; set; }

        [Required(ErrorMessage = "FirstName is requied")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is requied")]
        public string LastName { get; set; }
                
        public int UserType { get; set; }       

        [Required(ErrorMessage = "Email is requied")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

    }
}