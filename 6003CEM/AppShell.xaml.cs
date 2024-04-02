using _6003CEM.Pages;

namespace _6003CEM;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
    }


    private async void Signout_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Alert", "You have just signed out", "Okay");
    }
}