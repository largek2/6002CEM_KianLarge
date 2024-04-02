using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6003CEM.Pages
{
    public partial class ProductDetailsPage : ContentPage
    {
        private readonly ProductDetailsViewModel _productDetailsViewModel;
        public ProductDetailsPage(ProductDetailsViewModel productDetailsViewModel)
        {
            _productDetailsViewModel = productDetailsViewModel;
            InitializeComponent();
            BindingContext = _productDetailsViewModel;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage", animate: true);
        }
    }
}
