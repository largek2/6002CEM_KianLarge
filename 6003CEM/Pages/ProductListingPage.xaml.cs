using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6003CEM.PageModels;

namespace _6003CEM.Pages;

public partial class ProductListingPage : ContentPage
{
    public ProductListingPage(ProductListingPageModel productListingPageModel)
    {
        InitializeComponent();
        BindingContext = productListingPageModel;
    }
}