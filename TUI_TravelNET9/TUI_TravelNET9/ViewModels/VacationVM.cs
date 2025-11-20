using TUI_TravelNET9.Domain.Entities;

namespace TUI_TravelNET9.ViewModels
{
    public class VacationVM
    {
        public string? NameHotel { get; set; }
        public int Stars { get; set; }
        public double? Score { get; set; }
        public string? Facilities { get; set; }
        public string? Photo { get; set; }
        public CountryType? Country { get; set; }
    }
}