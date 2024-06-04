using NomadLife.Mobile.Services;
using NomadLife.Shared.Interfaces;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Refit;

namespace NomadLife.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            })
            .UseMauiCommunityToolkit();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<IHotelService, ApiHotelFetcher>()
            .AddSingleton<ICommonService, CommonService>();

        builder.Services.AddSingleton<AppState>();

        ConfigureRefit(builder.Services);

        return builder.Build();
    }

    private static void ConfigureRefit(IServiceCollection services)
    {
        var refitSettings = new RefitSettings
        {
            HttpMessageHandlerFactory = () =>
            {
#if ANDROID
                return new Xamarin.Android.Net.AndroidMessageHandler
                {
                    ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                            certificate?.Issuer == "CN-localhost"
                            || sslPolicyErrors == System.Net.Security.SslPolicyErrors.None
                };
#elif IOS
                return new NSUrlSessionHandler
                {
                    TrustOverrideForUrl = (nSUrlSessionHandler, url, secTrust) =>
                        url.StartsWith("https://localhost")
                };
#endif
                return null;
            }
        };

        services.AddRefitClient<IHotelApi>(refitSettings)
            .ConfigureHttpClient(httpClient =>
            {
                string baseUrl;

                if (DeviceInfo.DeviceType == DeviceType.Physical)
                {
                    baseUrl = "https://47vjdz1q-7014.euw.devtunnels.ms";

                }
                else
                {
                    //running on Emulator/Simulator

                    baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                        ? "https://47vjdz1q-7014.euw.devtunnels.ms"    /*"https://10.0.2.2:7215"*/
                        : "https://localhost:7215";
                }

                httpClient.BaseAddress = new Uri(baseUrl);
            });
    }
}
