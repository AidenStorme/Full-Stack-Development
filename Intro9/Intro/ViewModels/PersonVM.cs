using System.ComponentModel.DataAnnotations;

namespace Intro.ViewModels
{
    public class PersonVM
    {
        [Required(ErrorMessage =
            "gelieve naam in te geven")] // Restrictions
        public string? Name { get; set; } // "variabel" met getter and setter

        [Required(ErrorMessage =
            "gelieve voornaam in te geven")]
        public string? FirstName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Range(18, 99)] // Properties / restricties van het veld
        public int Leeftijd { get; set; }

        [AllowedValues("Batman", "Catwoman", "James Bond")]
        public string? Hero { get; set; }

        [DeniedValues("Admin", "Administrator")]
        public string? Username { get; set; }
    }
}
