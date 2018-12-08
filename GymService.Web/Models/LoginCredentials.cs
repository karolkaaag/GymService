using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymService.Web.Models
{
    public class LoginCredentials
    {
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
