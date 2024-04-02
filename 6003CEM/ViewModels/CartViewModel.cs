using System;
using CommunityToolkit.Maui.Core;

namespace _6003CEM.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<Product> CartRemoved;
        public event EventHandler<Product> CartUpdated;
        public event EventHandler CartCleared; 
        public ObservableCollection<Product> Products { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void CalculateTotalAmount() 
            => TotalAmount = Products.Sum(p => p.Amount);
        
        [RelayCommand]
        private void UpdateCart(Product product)
        {
            var item = Products.FirstOrDefault(p => p.Name == product.Name);
            if (item is not null)
            {
                item.CartQuantity = product.CartQuantity;
            }
            else
            {
                Products.Add(product.Clone());
            }
            CalculateTotalAmount();
        }

        [RelayCommand]
        private async void RemoveCart(string name)
        {
            var item = Products.FirstOrDefault(p => p.Name == name);
            if (item is not null)
            {
                Products.Remove(item);
                CalculateTotalAmount();
                
                CartRemoved?.Invoke(this, item);

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.Crimson,
                    TextColor = Colors.White,
                    ActionButtonTextColor = Colors.White
                };
                var snackbar = Snackbar.Make($"{item.Name} removed from the cart",
                () =>
                {
                    Products.Add(item);
                    CalculateTotalAmount();
                    CartUpdated?.Invoke(this, item);
                }, "Undo", TimeSpan.FromSeconds(3), snackbarOptions);

                await snackbar.Show();
            }
        }

        [RelayCommand]
        private async Task ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm Clear Cart?", "Are you sure you want to clear the cart?",
                    "Yes", "No"))
            {
                Products.Clear();
                CalculateTotalAmount();
                CartCleared?.Invoke(this, EventArgs.Empty);
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Products.Clear();
            CartCleared?.Invoke(this, EventArgs.Empty);
            CalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage));
        }
    }    
}
