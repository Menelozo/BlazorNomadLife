using NomadLife.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NomadLife.Web.Data;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationHotels> LocationHotels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationHotels>().HasKey(gb => new { gb.LocationId, gb.HotelId });
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>()
            .HasData([
                 new Location { Id = 1, Name = "United States", Slug = "united-states", IsTop = true },
         new Location { Id = 2, Name = "France", Slug = "france", IsTop = true },
         new Location { Id = 3, Name = "Italy", Slug = "italy", IsTop = true },
         new Location { Id = 4, Name = "Spain", Slug = "spain", IsTop = false },
         new Location { Id = 5, Name = "United Kingdom", Slug = "united-kingdom", IsTop = true },
         new Location { Id = 6, Name = "Mexico", Slug = "mexico", IsTop = false },
         new Location { Id = 7, Name = "Germany", Slug = "germany", IsTop = false },
         new Location { Id = 8, Name = "Thailand", Slug = "thailand", IsTop = false },
         new Location { Id = 9, Name = "China", Slug = "china", IsTop = false },
         new Location { Id = 10, Name = "Japan", Slug = "japan", IsTop = true },
         new Location { Id = 11, Name = "Turkey", Slug = "turkey", IsTop = false },
         new Location { Id = 12, Name = "Greece", Slug = "greece", IsTop = false },
         new Location { Id = 13, Name = "Canada", Slug = "canada", IsTop = false },
         new Location { Id = 14, Name = "Australia", Slug = "australia", IsTop = false },
         new Location { Id = 15, Name = "Brazil", Slug = "brazil", IsTop = false },
         new Location { Id = 16, Name = "Argentina", Slug = "argentina", IsTop = false },
         new Location { Id = 17, Name = "South Korea", Slug = "south-korea", IsTop = false },
         new Location { Id = 18, Name = "Egypt", Slug = "egypt", IsTop = false },
         new Location { Id = 19, Name = "South Africa", Slug = "south-africa", IsTop = false },
         new Location { Id = 20, Name = "India", Slug = "india", IsTop = true },
         new Location { Id = 21, Name = "Russia", Slug = "russia", IsTop = false },
         new Location { Id = 22, Name = "Indonesia", Slug = "indonesia", IsTop = false },
         new Location { Id = 23, Name = "Vietnam", Slug = "vietnam", IsTop = false },
         new Location { Id = 24, Name = "Netherlands", Slug = "netherlands", IsTop = false },
         new Location { Id = 25, Name = "Malaysia", Slug = "malaysia", IsTop = false },
         new Location { Id = 26, Name = "Switzerland", Slug = "switzerland", IsTop = false },
         new Location { Id = 27, Name = "Portugal", Slug = "portugal", IsTop = true },
         new Location { Id = 28, Name = "New Zealand", Slug = "new-zealand", IsTop = false },
         new Location { Id = 29, Name = "Austria", Slug = "austria", IsTop = false },
         new Location { Id = 30, Name = "Sweden", Slug = "sweden", IsTop = false },
         new Location { Id = 31, Name = "Norway", Slug = "norway", IsTop = false },
         new Location { Id = 32, Name = "Denmark", Slug = "denmark", IsTop = false },
         new Location { Id = 33, Name = "Finland", Slug = "finland", IsTop = false },
         new Location { Id = 34, Name = "Belgium", Slug = "belgium", IsTop = false },
         new Location { Id = 35, Name = "Ireland", Slug = "ireland", IsTop = false },
         new Location { Id = 36, Name = "Scotland", Slug = "scotland", IsTop = false },
         new Location { Id = 37, Name = "Iceland", Slug = "iceland", IsTop = false },
         new Location { Id = 38, Name = "Croatia", Slug = "croatia", IsTop = false },
         new Location { Id = 39, Name = "Czech Republic", Slug = "czech-republic", IsTop = false },
         new Location { Id = 40, Name = "Hungary", Slug = "hungary", IsTop = false },
         new Location { Id = 41, Name = "Poland", Slug = "poland", IsTop = false },
         new Location { Id = 42, Name = "Israel", Slug = "israel", IsTop = false },
         new Location { Id = 43, Name = "Chile", Slug = "chile", IsTop = false },
         new Location { Id = 44, Name = "Peru", Slug = "peru", IsTop = false },
         new Location { Id = 45, Name = "Colombia", Slug = "colombia", IsTop = false },
         new Location { Id = 46, Name = "Singapore", Slug = "singapore", IsTop = true },
         new Location { Id = 47, Name = "Philippines", Slug = "philippines", IsTop = false },
         new Location { Id = 48, Name = "Morocco", Slug = "morocco", IsTop = false },
         new Location { Id = 49, Name = "United Arab Emirates", Slug = "uae", IsTop = false },
         new Location { Id = 50, Name = "Saudi Arabia", Slug = "saudi-arabia", IsTop = false },
         new Location { Id = 51, Name = "Qatar", Slug = "qatar", IsTop = false },
         new Location { Id = 52, Name = "Kuwait", Slug = "kuwait", IsTop = false },
         new Location { Id = 53, Name = "Jordan", Slug = "jordan", IsTop = false },
         new Location { Id = 54, Name = "Lebanon", Slug = "lebanon", IsTop = false },
         new Location { Id = 55, Name = "Nepal", Slug = "nepal", IsTop = false },
         new Location { Id = 56, Name = "Sri Lanka", Slug = "sri-lanka", IsTop = false },
         new Location { Id = 57, Name = "Bangladesh", Slug = "bangladesh", IsTop = false },
         new Location { Id = 58, Name = "Pakistan", Slug = "pakistan", IsTop = false },
         new Location { Id = 59, Name = "Myanmar", Slug = "myanmar", IsTop = false },
         new Location { Id = 60, Name = "Laos", Slug = "laos", IsTop = false },
         new Location { Id = 61, Name = "Cambodia", Slug = "cambodia", IsTop = false },
         new Location { Id = 62, Name = "Mongolia", Slug = "mongolia", IsTop = false },
         new Location { Id = 63, Name = "Kazakhstan", Slug = "kazakhstan", IsTop = false },
         new Location { Id = 64, Name = "Uzbekistan", Slug = "uzbekistan", IsTop = false },
         new Location { Id = 65, Name = "Romania", Slug = "romania", IsTop = false },
         new Location { Id = 66, Name = "Bulgaria", Slug = "bulgaria", IsTop = false },
         new Location { Id = 67, Name = "Ukraine", Slug = "ukraine", IsTop = false },
         new Location { Id = 68, Name = "Belarus", Slug = "belarus", IsTop = false },
         new Location { Id = 69, Name = "Estonia", Slug = "estonia", IsTop = false },
         new Location { Id = 70, Name = "Latvia", Slug = "latvia", IsTop = false },
         new Location { Id = 71, Name = "Lithuania", Slug = "lithuania", IsTop = false },
         new Location { Id = 72, Name = "Slovenia", Slug = "slovenia", IsTop = false },
         new Location { Id = 73, Name = "Slovakia", Slug = "slovakia", IsTop = false },
         new Location { Id = 74, Name = "Serbia", Slug = "serbia", IsTop = false },
                        ]);

        modelBuilder.Entity<Author>()
            .HasData([
                  new Author { Id = 1, Name = "Paweł Syrowy", Slug = "pawel-syrowy" }
                ]);

        const string ImageBaseUrl = "https://raw.github.com/PawelSyrowy/NomadLifeImages/main";


        modelBuilder.Entity<Hotel>()
            .HasData([
                 new Hotel { Id = 1, Title = "Ocean Breeze Hotel", AuthorId = 1, Description = "A serene retreat located on the shores of a pristine beach, offering breathtaking ocean views and luxurious amenities.", Type = "Hotel", NumStars = 5, Image = $"{ImageBaseUrl}/hotel1.jpg", BuyLink = null },
         new Hotel { Id = 2, Title = "Mountain View Hostel", AuthorId = 1, Description = "A cozy and affordable hostel nestled in the heart of the mountains, perfect for backpackers and nature lovers.", Type = "Hostel", NumStars = 3, Image = $"{ImageBaseUrl}/hotel2.jpg", BuyLink = null },
         new Hotel { Id = 3, Title = "City Central Apartment", AuthorId = 1, Description = "A modern and stylish apartment located in the bustling city center, ideal for business travelers and tourists.", Type = "Apartment", NumStars = 4, Image = $"{ImageBaseUrl}/hotel3.jpg", BuyLink = null },
         new Hotel { Id = 4, Title = "Riverside Inn", AuthorId = 1, Description = "A charming inn situated by the river, offering a peaceful and relaxing atmosphere with scenic views.", Type = "Hotel", NumStars = 4, Image = $"{ImageBaseUrl}/hotel4.jpg", BuyLink = null },
         new Hotel { Id = 5, Title = "Desert Oasis Resort", AuthorId = 1, Description = "An exotic resort located in the middle of the desert, providing luxurious accommodations and unique experiences.", Type = "Resort", NumStars = 5, Image = $"{ImageBaseUrl}/hotel5.jpg", BuyLink = null },
         new Hotel { Id = 6, Title = "Historic Downtown Bed & Breakfast", AuthorId = 1, Description = "A quaint bed and breakfast in a historic downtown area, featuring cozy rooms and homemade breakfast.", Type = "Bed & Breakfast", NumStars = 3, Image = $"{ImageBaseUrl}/hotel6.jpg", BuyLink = null },
         new Hotel { Id = 7, Title = "Lakeside Lodge", AuthorId = 1, Description = "A rustic lodge located by the lake, offering a perfect getaway for fishing, boating, and relaxation.", Type = "Lodge", NumStars = 4, Image = $"{ImageBaseUrl}/hotel7.jpg", BuyLink = null },
         new Hotel { Id = 8, Title = "Urban Chic Boutique Hotel", AuthorId = 1, Description = "A trendy boutique hotel in the heart of the city, known for its stylish design and personalized service.", Type = "Boutique Hotel", NumStars = 5, Image = $"{ImageBaseUrl}/hotel8.jpg", BuyLink = null },
         new Hotel { Id = 9, Title = "Eco-Friendly Retreat", AuthorId = 1, Description = "An environmentally friendly retreat offering sustainable accommodations and activities in nature.", Type = "Retreat", NumStars = 4, Image = $"{ImageBaseUrl}/hotel9.jpg", BuyLink = null },
         new Hotel { Id = 10, Title = "Countryside Guesthouse", AuthorId = 1, Description = "A welcoming guesthouse located in the tranquil countryside, perfect for a peaceful escape from the city.", Type = "Guesthouse", NumStars = 3, Image = $"{ImageBaseUrl}/hotel10.jpg", BuyLink = null }
            ]);


        modelBuilder.Entity<LocationHotels>()
            .HasData(new[]
            {
        new LocationHotels { LocationId = 15, HotelId = 1 }, // Ocean Breeze Hotel in Brazil
        new LocationHotels { LocationId = 26, HotelId = 2 }, // Mountain View Hostel in Switzerland
        new LocationHotels { LocationId = 7, HotelId = 3 }, // City Central Apartment in Germany
        new LocationHotels { LocationId = 2, HotelId = 4 }, // Riverside Inn in France
        new LocationHotels { LocationId = 48, HotelId = 5 }, // Desert Oasis Resort in Morocco
        new LocationHotels { LocationId = 1, HotelId = 6 }, // Historic Downtown Bed & Breakfast in United States
        new LocationHotels { LocationId = 13, HotelId = 7 }, // Lakeside Lodge in Canada
        new LocationHotels { LocationId = 10, HotelId = 8 }, // Urban Chic Boutique Hotel in Japan
        new LocationHotels { LocationId = 28, HotelId = 9 }, // Eco-Friendly Retreat in New Zealand
        new LocationHotels { LocationId = 14, HotelId = 10 } // Countryside Guesthouse in Australia
            });



    }
}
