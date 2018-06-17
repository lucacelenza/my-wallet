namespace CLSoft.MyWallet.Business.Identity.Models
{
    public class SignInRequest
    {
        public string IdentityName { get; set; }
        public bool IsPersistent { get; set; }
    }
}