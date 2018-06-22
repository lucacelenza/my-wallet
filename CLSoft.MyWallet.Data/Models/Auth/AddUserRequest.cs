using System;

namespace CLSoft.MyWallet.Data.Models.Auth
{
    public class AddUserRequest
    {
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}