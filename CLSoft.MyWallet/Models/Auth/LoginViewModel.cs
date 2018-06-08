using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Models.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememeberMe { get; set; }
    }
}
