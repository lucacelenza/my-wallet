using System;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? PasswordChangedOn { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; set; }
    }
}