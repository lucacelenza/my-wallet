using System;

namespace CLSoft.MyWallet.Data.EntityFramework.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? PasswordChangedOn { get; set; }
    }
}