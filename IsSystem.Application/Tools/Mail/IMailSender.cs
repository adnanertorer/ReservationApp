namespace IsSystem.Application.Tools.Mail
{
    public interface IMailSender
    {
        bool SendMail(MailModel mailModel);
    }
}
