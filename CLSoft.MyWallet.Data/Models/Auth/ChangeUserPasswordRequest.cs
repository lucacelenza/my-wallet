using System;

namespace CLSoft.MyWallet.Data.Models.Auth
{
    public class ChangeUserPasswordRequest
    {
        public long UserId { get; set; }
        public string NewHashedPassword { get; set; }
        public DateTime ChangedOn { get; set; }
    }
}