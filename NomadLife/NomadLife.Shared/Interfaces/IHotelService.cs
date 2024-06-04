using NomadLife.Shared.Dtos;

namespace NomadLife.Shared.Interfaces;

public interface IHotelService
{
    Task<HotelDetailsDto> GetHotelAsync(int hotelId);
    Task<PagedResult<HotelListDto>> GetHotelsAsync(int pageNo, int pageSize, string? locationSlug = null);
    Task<PagedResult<HotelListDto>> GetHotelsByAuthorAsync(int pageNo, int pageSize, string authorSlug);
    Task<LocationDto[]> GetLocationsAsync(bool topOnly);
    Task<HotelListDto[]> GetPopularHotelsAsync(int count, string? locationSlug = null);
    Task<HotelListDto[]> GetSimilarHotelsAsync(int hotelId, int count);
}
