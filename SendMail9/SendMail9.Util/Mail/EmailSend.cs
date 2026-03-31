using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Extensions.Options;
using SendMail9.Util.Mail.Interfaces;

namespace SendMail9.Util.Mail;

public class EmailSend : IEmailSend
{
    private readonly EmailSettings _emailSettings;

    public EmailSend(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var mail = new MailMessage();
        mail.To.Add(new MailAddress(email));
        mail.From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName);
        mail.Subject = subject;
        mail.Body = message;
        mail.IsBodyHtml = true;

        try
        {
            using (var smtp = new SmtpClient(_emailSettings.MailServer))
            {
                smtp.Port = _emailSettings.MailPort;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);
                await smtp.SendMailAsync(mail);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task SendEmailAttachmentAsync(string email, string subject, string message, byte[] pdfBytes)
    {
        var mail = new MailMessage();
        mail.To.Add(new MailAddress(email));
        mail.From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName);
        mail.Subject = subject;
        mail.Body = message;
        mail.IsBodyHtml = true;

        if (pdfBytes != null && pdfBytes.Length > 0)
        {
            var stream = new MemoryStream(pdfBytes);
            mail.Attachments.Add(new Attachment(stream, "OrderBevestiging.pdf", MediaTypeNames.Application.Pdf));
        }

        try
        {
            using (var smtp = new SmtpClient(_emailSettings.MailServer))
            {
                smtp.Port = _emailSettings.MailPort;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);
                await smtp.SendMailAsync(mail);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
