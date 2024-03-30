using _6003CEM.Pages;

namespace _6003CEM;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private readonly static Type[] RoutablePageTypes =
    [
        typeof(SigninPage),
        typeof(RegisterPage),
    ];

    private void RegisterRoutes()
    {
        foreach (var pageType in RoutablePageTypes)
        {
            Routing.RegisterRoute(pageType.Name, pageType);
        }
    }

    private async void Signout_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Alert", "You have just signed out", "Okay");
        
    }
}