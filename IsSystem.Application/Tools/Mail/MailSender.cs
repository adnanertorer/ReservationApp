using System.Net;
using System.Net.Mail;

namespace IsSystem.Application.Tools.Mail
{
    public class MailSender : IMailSender
    {
        public void SendMail(MailModel mailModel)
        {
            try
            {
                SmtpClient smtpClient = new()
                {
                    UseDefaultCredentials = false,
                    EnableSsl = mailModel.EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(mailModel.Username, mailModel.Password),
                    Host = mailModel.SmtpHost,
                    Port = mailModel.SmtpPort
                };

                MailAddress from = new(mailModel.Sender, mailModel.SenderDisplayName);
                MailAddress to = new(mailModel.Recipient);
                MailMessage mail = new(from, to)
                {
                    Subject = mailModel.Subject,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                    Body = mailModel.Body,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    IsBodyHtml = mailModel.IsBodyHtml
                };

                smtpClient.Send(mail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
