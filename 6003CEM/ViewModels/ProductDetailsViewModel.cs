using System;

namespace _6003CEM.ViewModels
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public partial class ProductDetailsViewModel : ObservableObject
    {
        public ProductDetailsViewModel()
        {
            
        }

        [ObservableProperty] 
        private Product _product;
    }
}    