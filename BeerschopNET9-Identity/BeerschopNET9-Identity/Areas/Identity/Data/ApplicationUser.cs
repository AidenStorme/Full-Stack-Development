using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeerschopNET9_Identity.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Range(1900, 2100)]
        public int? BirthYear { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        [StringLength(4)]
        public string? PostalCode { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
    }
}
