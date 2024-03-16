using _6003CEM.Models;
using _6003CEM.Services;
using _6003CEM.PageModels;
using _6003CEM.Pages;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Supabase;

namespace _6003CEM;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        
        var url = AppConfig.SUPABASE_URL;
        var key = AppConfig.SUPABASE_KEY;
        builder.Services.AddSingleton(provider => new Supabase.Client(url, key));
        
        // Add PageModels
        builder.Services.AddSingleton<ProductListingPageModel>();
        builder.Services.AddTransient<AddProductPageModel>();

        // Add Views
        builder.Services.AddSingleton<ProductListingPage>();
        builder.Services.AddTransient<AddProductPage>();
        
        // Add Data Service
        builder.Services.AddSingleton<IDataService, DataService>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}