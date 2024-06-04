using NomadLife.Shared.Dtos;
using NomadLife.Shared.Interfaces;

namespace NomadLife.Mobile.Services;

public class ApiHotelFetcher : IHotelService
{
    private readonly IHotelApi _hotelApi;
    public ApiHotelFetcher(IHotelApi hotelApi)
    {
        _hotelApi = hotelApi;
    }
    public async Task<HotelDetailsDto> GetHotelAsync(int hotelId)
    {
        return await _hotelApi.GetHotelAsync(hotelId);
    }

    public async Task<PagedResult<HotelListDto>> GetHotelsAsync(int pageNo, int pageSize, string? locationSlug = null)
    {
        return await _hotelApi.GetHotelsAsync(pageNo, pageSize, locationSlug);
    }

    public async Task<PagedResult<HotelListDto>> GetHotelsByAuthorAsync(int pageNo, int pageSize, string authorSlug)
    {
        return await _hotelApi.GetHotelsByAuthorAsync(pageNo, pageSize, authorSlug);
    }

    public async Task<LocationDto[]> GetLocationsAsync(bool topOnly)
    {
        return await _hotelApi.GetLocationsAsync(topOnly);
    }

    public async Task<HotelListDto[]> GetPopularHotelsAsync(int count, string? locationSlug = null)
    {
        return await _hotelApi.GetPopularHotelsAsync(count, locationSlug);
    }

    public async Task<HotelListDto[]> GetSimilarHotelsAsync(int hotelId, int count)
    {
        return await _hotelApi.GetSimilarHotelsAsync(hotelId, count);
    }
}
