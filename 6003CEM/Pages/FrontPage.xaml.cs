using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6003CEM.Pages;

public partial class FrontPage : ContentPage
{
    public FrontPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
