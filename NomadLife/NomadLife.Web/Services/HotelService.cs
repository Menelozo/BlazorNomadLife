using NomadLife.Shared.Dtos;
using NomadLife.Shared.Interfaces;
using NomadLife.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace NomadLife.Web.Services;

public class HotelService : IHotelService
{
    private readonly IDbContextFactory<HotelContext> _dbContextFactory;

    public HotelService(IDbContextFactory<HotelContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<LocationDto[]> GetLocationsAsync(bool topOnly)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var query = context.Locations.AsQueryable();
        if (topOnly)
        {
            query = query.Where(g => g.IsTop);
        }
        var locations = await query.Select(g => new LocationDto(g.Name, g.Slug)).ToArrayAsync();

        return locations;
    }

    public async Task<PagedResult<HotelListDto>> GetHotelsAsync(int pageNo, int pageSize, string? locationSlug = null)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var query = context.Hotels.AsQueryable();

        if (!string.IsNullOrWhiteSpace(locationSlug))
        {
            query = context.Locations
                .Where(g => g.Slug == locationSlug)
                .SelectMany(g => g.LocationHotels)
                .Select(gb => gb.Hotel);
        }

        var totalCount = await query.CountAsync();

        var hotels = await query
            .OrderByDescending(b => b.Id)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new HotelListDto(b.Id, b.Title, b.Image, new AuthorDto(b.Author.Name, b.Author.Slug)))
            .ToArrayAsync();

        return new PagedResult<HotelListDto>(hotels, totalCount);
    }

    public async Task<HotelListDto[]> GetPopularHotelsAsync(int count, string? locationSlug = null)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var query = context.Hotels.AsQueryable();

        if (!string.IsNullOrWhiteSpace(locationSlug))
        {
            query = context.Locations
                .Where(g => g.Slug == locationSlug)
                .SelectMany(g => g.LocationHotels)
                .Select(gb => gb.Hotel);
        }

        var hotels = await query
            .Select(b => new HotelListDto(b.Id, b.Title, b.Image, new AuthorDto(b.Author.Name, b.Author.Slug)))
            .OrderBy(b => Guid.NewGuid())
            .Take(count)
            .ToArrayAsync();

        if (hotels.Length < count)
        {
            //We dont have {count} hotels in this Location //in this case, we will get random hotels from other locations
            var alreadyFetchedHotelIds = hotels.Select(b => b.Id);
            var additionalHotels = await context.Hotels
                .Where(b => !alreadyFetchedHotelIds.Contains(b.Id))
                .Select(b => new HotelListDto(b.Id, b.Title, b.Image, new AuthorDto(b.Author.Name, b.Author.Slug)))
                .OrderBy(b => Guid.NewGuid())
                .Take(count - hotels.Length)
                .ToArrayAsync();

            hotels = [.. hotels, .. additionalHotels];
        }
        return hotels;
    }

    public async Task<HotelDetailsDto> GetHotelAsync(int hotelId)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var hotel = await context.Hotels
            .Where(b => b.Id == hotelId)
            .Select(b => new HotelDetailsDto
                        (b.Id, b.Title, b.Image,
                            new AuthorDto(b.Author.Name, b.Author.Slug),
                        b.NumStars, b.Type, b.Description,
                            b.HotelLocations.Select(bg => new LocationDto(bg.Location.Name, bg.Location.Slug)).ToArray(),
                        b.BuyLink
                        ))
            .FirstOrDefaultAsync();

        return hotel;
    }

    public async Task<HotelListDto[]> GetSimilarHotelsAsync(int hotelId, int count)
    {
        using var context = _dbContextFactory.CreateDbContext();

        var similarHotels = await context.LocationHotels
            .Where(gb => gb.HotelId == hotelId)
            .SelectMany(gb => gb.Location.LocationHotels)
            .Select(gb => gb.Hotel)
            .Where(b => b.Id != hotelId)  //skip this current hotel from the similar hotels section
            .Select(b => new HotelListDto(b.Id, b.Title, b.Image, new AuthorDto(b.Author.Name, b.Author.Slug)))
            .OrderBy(b => Guid.NewGuid()) //randomize
            .Take(count)
            .ToArrayAsync();

        return similarHotels;
    }

    public async Task<PagedResult<HotelListDto>> GetHotelsByAuthorAsync(int pageNo, int pageSize, string authorSlug)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var query = context.Hotels.Where(b => b.Author.Slug == authorSlug);
        var totalCount = await query.CountAsync();
        var hotels = await query
            .OrderByDescending(b => b.Id)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new HotelListDto(b.Id, b.Title, b.Image, new AuthorDto(b.Author.Name, b.Author.Slug)))
            .ToArrayAsync();

        return new PagedResult<HotelListDto>(hotels, totalCount);
    }
}
