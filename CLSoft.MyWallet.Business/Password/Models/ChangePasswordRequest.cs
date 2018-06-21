namespace CLSoft.MyWallet.Business.Password.Models
{
    public class ChangePasswordRequest
    {
        public string NewPassword { get; }
        public string Token { get; }

        public ChangePasswordRequest(string newPassword, string token)
        {
            NewPassword = newPassword;
            Token = token;
        }
    }
}