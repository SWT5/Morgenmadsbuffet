using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Morgenmadsbuffet.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string Name { get; set; }
    }
}
