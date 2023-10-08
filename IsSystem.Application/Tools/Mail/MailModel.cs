namespace IsSystem.Application.Tools.Mail
{
    public class MailModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public string SenderDisplayName { get; set; }
        public string Recipient { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
