using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.API
{
    public class RegisterUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set;  }
        public string Phone { get; set; }

        //TODO: remove this and keep roles from being able to be set on constrution
        public List<string> Roles { get; set; }
    }
}
