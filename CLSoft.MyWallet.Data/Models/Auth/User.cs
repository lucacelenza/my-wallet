namespace CLSoft.MyWallet.Data.Models.Auth
{
    public class User
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
    }
}