namespace IsSystem.Application.Tools.Mail
{
    public interface IMailSender
    {
        void SendMail(MailModel mailModel);
    }
}
