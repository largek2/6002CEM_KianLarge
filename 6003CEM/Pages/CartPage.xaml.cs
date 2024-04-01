using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6003CEM.Pages;

public partial class CartPage : ContentPage
{
    private readonly CartViewModel _cartViewModel;
    public CartPage(CartViewModel cartViewModel)
    {
        _cartViewModel = cartViewModel;
        InitializeComponent();
        BindingContext = _cartViewModel;
    }
}