using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using _6003CEM.Services;
using _6003CEM.Pages;
using _6003CEM.ViewModels;

namespace _6003CEM;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#else
        builder.Logging.AddConsole();
#endif
        AddProductServices(builder.Services);
        return builder.Build();
    }

    private static IServiceCollection AddProductServices(IServiceCollection services)
    {
        services.AddSingleton<ProductService>(provider =>
        {
            var logger = provider.GetRequiredService<ILogger<ProductService>>();
            var productService = new ProductService(logger);
            return productService;
        });
        services.AddSingletonWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
        services.AddTransientWithShellRoute<ProductsPage, ProductsViewModel>(nameof(ProductsPage));
        return services;
    }
}