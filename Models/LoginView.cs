using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class LoginView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
    }
}
