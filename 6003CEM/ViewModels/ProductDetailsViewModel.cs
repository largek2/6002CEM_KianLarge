using System;

namespace _6003CEM.ViewModels
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public partial class ProductDetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public ProductDetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartRemoved += OnCartRemoved;
            _cartViewModel.CartUpdated += OnCartUpdated;
        }

        private void OnCartCleared(object? _, EventArgs e) => Product.CartQuantity = 0;

        private void OnCartRemoved(object? _, Product p) => OnCartChanged(p, 0);
        
        private void OnCartUpdated(object? _, Product p) => OnCartChanged(p, p.CartQuantity);
        
        private void OnCartChanged(Product p, int quantity)
        {
            if (p.Name == Product.Name)
            {
                Product.CartQuantity = quantity;
            }
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

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartRemoved -= OnCartRemoved;
            _cartViewModel.CartUpdated -= OnCartUpdated;
        }
    }
}    