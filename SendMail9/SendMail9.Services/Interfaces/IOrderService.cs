using SendMail9.Domain;

namespace SendMail9.Services.Interfaces;

public interface IOrderService
{
    Task SendOrderConfirmationAsync(string email);
    Task SendOrderConfirmationAsync(Order order);
}
