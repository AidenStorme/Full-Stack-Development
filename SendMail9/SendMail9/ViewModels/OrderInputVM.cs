using System.ComponentModel.DataAnnotations;

namespace SendMail9.ViewModels;

public class OrderInputVM
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}