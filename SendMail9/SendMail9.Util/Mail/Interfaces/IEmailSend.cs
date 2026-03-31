namespace SendMail9.Util.Mail.Interfaces;

public interface IEmailSend
{
    Task SendEmailAsync(string email, string subject, string message);
    
    Task SendEmailAttachmentAsync(string email, string subject, 
        string message,
        byte[] pdfBytes);
}