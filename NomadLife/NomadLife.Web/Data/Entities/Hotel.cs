using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadLife.Web.Data.Entities;

public class Hotel
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Title { get; set; }

    public int AuthorId { get; set; }

    [Required]
    public string Description { get; set; }

    [Required, MaxLength(30), Unicode(false)]
    public string Type {  get; set; }

    [Range(1,int.MaxValue)]
    public int NumStars { get; set; }

    [Required, MaxLength(180), Unicode(false)]
    public string Image { get; set; }

    [MaxLength(250)]
    public string? BuyLink { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public virtual Author Author { get; set; }

    public virtual ICollection<LocationHotels> HotelLocations { get; set; } = new List<LocationHotels>();
}
