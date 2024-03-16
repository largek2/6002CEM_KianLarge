using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6003CEM.PageModels;

namespace _6003CEM.Pages;

public partial class AddProductPage : ContentPage
{
    public AddProductPage(AddProductPageModel addProductPageModel)
    {
        InitializeComponent();
        BindingContext = addProductPageModel;
    }
}