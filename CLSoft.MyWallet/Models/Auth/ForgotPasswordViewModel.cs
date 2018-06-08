using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Models.Auth
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}
