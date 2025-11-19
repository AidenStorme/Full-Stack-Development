namespace TUI_TravelNET9.Domain.Entities;

public class Hotel
{
    public enum CountryType
    {
        Coast,
        Wallonia
    }
    public class Vacation
    {
        public int Id { get; set; }
        public string? NameHotel { get; set; }
        public string? City { get; set; }
        public int Stars { get; set; }
        public double Score { get; set; }
        public string? Benefit { get; set; }
        public string? Photo { get; set; }
        public CountryType Country { get; set; }
    }
}