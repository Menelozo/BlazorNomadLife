using NomadLife.Shared.Dtos;
using Refit;

namespace NomadLife.Mobile.Services;

public interface IHotelApi
{
    [Get("/api/hotels/{hotelId}")]
    Task<HotelDetailsDto> GetHotelAsync(int hotelId);

    [Get("/api/hotels")]
    Task<PagedResult<HotelListDto>> GetHotelsAsync(int pageNo, int pageSize, string? locationSlug = null);

    [Get("/api/authors/{authorSlug}/hotels")] 
    Task<PagedResult<HotelListDto>> GetHotelsByAuthorAsync(int pageNo, int pageSize, string authorSlug);

    [Get("/api/locations")] 
    Task<LocationDto[]> GetLocationsAsync(bool topOnly);

    [Get("/api/hotels/popular")] 
    Task<HotelListDto[]> GetPopularHotelsAsync(int count, string? locationSlug = null);

    [Get("/api/hotels/{hotelId}/similar")] 
    Task<HotelListDto[]> GetSimilarHotelsAsync(int hotelId, int count);
}
