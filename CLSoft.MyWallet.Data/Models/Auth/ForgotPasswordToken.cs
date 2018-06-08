using System;

namespace CLSoft.MyWallet.Data.Models.Auth
{
    public class ForgotPasswordToken
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}