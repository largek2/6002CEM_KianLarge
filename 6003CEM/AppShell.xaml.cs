using _6003CEM.Pages;

namespace _6003CEM;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private readonly static Type[] _routablePageTypes =
    [
        typeof(SigninPage),
        typeof(RegisterPage),
        typeof(OrderDescriptionPage),
    ];

    private void RegisterRoutes()
    {
        foreach (var pageType in _routablePageTypes)
        {
            Routing.RegisterRoute(pageType.Name, pageType);
        }
    }
}