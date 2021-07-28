using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDataLayer.Models
{
   public class ApplicationUser:IdentityUser
    {
        public int Rating { get; set; }
        public string ProfileImage { get; set; }
        public DateTime AccountCreated { get; set; }
        public bool IsActive { get; set; }


    }
}
