using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLay.IdentityModels
{
   public class ApplicationUser :IdentityUser
    {
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
