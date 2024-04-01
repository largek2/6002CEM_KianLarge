using System;

namespace _6003CEM.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
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
        private void RemoveCart(string name)
        {
            var item = Products.FirstOrDefault(p => p.Name == name);
            if (item is not null)
            {
                Products.Remove(item);
                CalculateTotalAmount();
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
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Products.Clear();
            CalculateTotalAmount();
            
        }
    }    
}
