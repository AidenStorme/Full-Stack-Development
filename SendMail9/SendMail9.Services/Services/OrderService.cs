using SendMail9.Services.Interfaces;
using SendMail9.Util.Mail.Interfaces;
using SendMail9.Domain;
using System.Text;
using SendMail9.Util.PDF.Interfaces;

namespace SendMail9.Services.Services;

public class OrderService : IOrderService
{
    private readonly IEmailSend _emailSend;
    private readonly ICreatePDF _createPDF;

    public OrderService(IEmailSend emailSend, ICreatePDF createPDF)
    {
        _emailSend = emailSend;
        _createPDF = createPDF;
    }

    public async Task SendOrderConfirmationAsync(string email)
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            await _emailSend.SendEmailAsync(
                email,
                "Orderbevestiging",
                "Bedankt voor uw bestelling.");
        }
    }

    public async Task SendOrderConfirmationAsync(Order order)
    {
        if (!string.IsNullOrWhiteSpace(order.CustomerEmail))
        {
            // Generate PDF
            var pdfBytes = _createPDF.CreatePDFDocument(order.Products);
            
            // Build email body
            var emailBody = BuildOrderEmailBody(order);
            
            // Send email with PDF attachment
            await _emailSend.SendEmailAttachmentAsync(
                order.CustomerEmail,
                $"Orderbevestiging - Order #{order.Id}",
                emailBody,
                pdfBytes);
        }
    }

    private string BuildOrderEmailBody(Order order)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<html><body>");
        sb.AppendLine($"<h2>Beste {order.CustomerName},</h2>");
        sb.AppendLine("<p>Bedankt voor uw bestelling!</p>");
        sb.AppendLine($"<p><strong>Order Nummer:</strong> {order.Id}</p>");
        sb.AppendLine($"<p><strong>Datum:</strong> {order.OrderDate:dd/MM/yyyy HH:mm}</p>");
        
        if (order.Products != null && order.Products.Any())
        {
            sb.AppendLine("<h3>Bestelde Producten:</h3>");
            sb.AppendLine("<table border='1' cellpadding='10' style='border-collapse: collapse;'>");
            sb.AppendLine("<tr style='background-color: #f2f2f2;'>");
            sb.AppendLine("<th>Product</th><th>Aantal</th><th>Prijs</th><th>Totaal</th>");
            sb.AppendLine("</tr>");
            
            decimal grandTotal = 0;
            foreach (var product in order.Products)
            {
                var total = product.Quantity * product.Price;
                grandTotal += total;
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{product.Name}</td>");
                sb.AppendLine($"<td>{product.Quantity}</td>");
                sb.AppendLine($"<td>€{product.Price:F2}</td>");
                sb.AppendLine($"<td>€{total:F2}</td>");
                sb.AppendLine("</tr>");
            }
            
            sb.AppendLine("<tr style='background-color: #f2f2f2; font-weight: bold;'>");
            sb.AppendLine($"<td colspan='3' align='right'>Totaalbedrag:</td>");
            sb.AppendLine($"<td>€{grandTotal:F2}</td>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</table>");
        }
        
        sb.AppendLine("<br/><p>Met vriendelijke groeten,<br/>Het Beerstore Team</p>");
        sb.AppendLine("</body></html>");
        
        return sb.ToString();
    }
}
