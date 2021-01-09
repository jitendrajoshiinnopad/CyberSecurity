using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CyberSecurity.Models.ViewModels
{
    public class UserViewModels
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool Remember { get; set; } = false;
    }
}
