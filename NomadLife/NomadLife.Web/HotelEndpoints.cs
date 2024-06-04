using NomadLife.Shared.Interfaces;

namespace NomadLife.Web;

public static class HotelEndpoints
{
    public static IEndpointRouteBuilder MapHotelEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/hotels/{hotelId:int}",
            async (int hotelId, IHotelService hotelService) =>
                TypedResults.Ok(await hotelService.GetHotelAsync(hotelId))
        );
        app.MapGet("/api/hotels",
            async (IHotelService hotelService, int pageNo, int pageSize, string? locationSlug = null) =>
                TypedResults.Ok(await hotelService.GetHotelsAsync(pageNo, pageSize, locationSlug))
        );
        app.MapGet("/api/authors/{authorSlug}/hotels",
            async (IHotelService hotelService, int pageNo, int pageSize, string authorSlug) =>
                TypedResults.Ok(await hotelService.GetHotelsByAuthorAsync(pageNo, pageSize, authorSlug))
        );
        app.MapGet("/api/locations",
            async (IHotelService hotelService, bool topOnly) =>
                TypedResults.Ok(await hotelService.GetLocationsAsync(topOnly))
        );
        app.MapGet("/api/hotels/popular",
            async (IHotelService hotelService, int count, string? locationSlug = null) =>
                TypedResults.Ok(await hotelService.GetPopularHotelsAsync(count, locationSlug))
        );
        app.MapGet("/api/hotels/{hotelId:int}/similar",
            async (int hotelId, int count, IHotelService hotelService) =>
                TypedResults.Ok(await hotelService.GetSimilarHotelsAsync(hotelId, count))
        );
        return app;
    }
}
