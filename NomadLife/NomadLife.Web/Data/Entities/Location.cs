using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NomadLife.Web.Data.Entities;

public class Location
{
    [Key]
    public short Id { get; set; }

    [Required,MaxLength(50),Unicode(false)]
    public string Name { get; set; }

    [Required, MaxLength(75), Unicode(false)]
    public string Slug { get; set; }

    public bool IsTop { get; set; }

    public virtual ICollection<LocationHotels> LocationHotels { get; set; } = new List<LocationHotels>();
}
