using System.ComponentModel.DataAnnotations.Schema;

namespace NomadLife.Web.Data.Entities;

public class LocationHotels
{
    public short LocationId { get; set; }

    public int HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public virtual Hotel Hotel { get; set; }

    [ForeignKey(nameof(LocationId))]
    public virtual Location Location { get; set; }

}
