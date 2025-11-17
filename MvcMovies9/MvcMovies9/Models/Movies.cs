using System.ComponentModel.DataAnnotations;
namespace MvcMovies9.Models;
public class Movie
{
    // Alle velden die gebruikt zullen worden in de view
    public int Id { get; set; }
    [Required, StringLength(60)] // Restrictions
    public string Title { get; set; } = string.Empty;
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateOnly? ReleaseDate { get; set; }
    [Required, StringLength(30)]
    public string Genre { get; set; } = string.Empty;
    [Range(0, 100)]
    public decimal Price { get; set; }
    [Range(0,10)]
    public int Rating { get; set; }
}