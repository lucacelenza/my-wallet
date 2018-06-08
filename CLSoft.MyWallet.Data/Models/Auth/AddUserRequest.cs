using System;
using System.Collections.Generic;
using System.Text;

namespace CLSoft.MyWallet.Data.Models.Auth
{
    public class AddUserRequest
    {
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}
