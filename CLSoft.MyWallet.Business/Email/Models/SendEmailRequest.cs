namespace CLSoft.MyWallet.Business.Email.Models
{
    public class SendEmailRequest
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string Template { get; set; }
        public object Model { get; set; }
    }
}
