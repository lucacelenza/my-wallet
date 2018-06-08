using System;

namespace CLSoft.MyWallet.Data.EntityFramework.Entities
{
    public class ForgotPasswordToken
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}