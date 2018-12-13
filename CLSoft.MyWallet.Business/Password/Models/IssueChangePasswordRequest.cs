namespace CLSoft.MyWallet.Business.Password.Models
{
    public class IssueChangePasswordRequest
    {
        public string EmailAddress { get; }

        public IssueChangePasswordRequest(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
