namespace NomadLife.Shared.Dtos;

public record HotelDetailsDto(int Id, string Title, string Image,
                            AuthorDto Author, int NumStars, string Type, 
                            string Description, LocationDto[] Locations, string? BuyLink)
{
public string HotelLink => string.IsNullOrWhiteSpace(BuyLink)
    ? $"https://www.bing.com/search?q={Title.Replace(" ", "+")}+by+{Author.Name.Replace(" ", "+")}"
    : BuyLink;
}


