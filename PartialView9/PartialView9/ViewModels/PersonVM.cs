using PartialView.Domain.Entities;

namespace PartialView9.ViewModels
{
    public class PersonVM
    {
        public string? Voornaam { get; set; }
        public string? Naam { get; set; }
        public DateTime EnrollDate { get; set; }
        public string? ImagePath { get; set; }
    }
}
