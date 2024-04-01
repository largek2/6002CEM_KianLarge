using System;

namespace _6003CEM.ViewModels
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public partial class ProductDetailsViewModel : ObservableObject
    {
        private readonly CartViewModel _cartViewModel;
        public ProductDetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
        }

        [ObservableProperty] 
        private Product _product;

        [RelayCommand]
        private void AddToCart()
        {
            Product.CartQuantity++;
            _cartViewModel.UpdateCartCommand.Execute(Product);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if(Product.CartQuantity > 0) 
                Product.CartQuantity--;
            _cartViewModel.UpdateCartCommand.Execute(Product);

        }
    }
}    