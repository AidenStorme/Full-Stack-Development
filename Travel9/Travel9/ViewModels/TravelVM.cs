using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Travel9.ViewModels
{
    public class TravelVM
    {
        [Display(Name = "Departure *")]
        public string? DepartureCode { get; set; }

        [Display(Name = "Arrival *")]
        public string? ArrivalCode { get; set; }
        public List<SelectListItem>? CountryList { get; set; }

        [Display(Name = "Departure date *")]
        [Required(ErrorMessage = "vertrekdatum moet ingegeven worden")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Return date *")]
        [Required(ErrorMessage = "einddatum moet ingegeven worden")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

    }

    public class TravelDatePickerVM
    {
        [Display(Name = "Departure *")]
        public string? DepartureCode { get; set; }

        [Display(Name = "Arrival *")]
        public string? ArrivalCode { get; set; }
        public List<SelectListItem>? CountryList { get; set; }

        [Display(Name = "Departure date *")]
        [Required(ErrorMessage = "vertrekdatum moet ingegeven worden")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Return date *")]
        [Required(ErrorMessage = "einddatum moet ingegeven worden")]
        public DateTime? EndDate { get; set; }

    }
}