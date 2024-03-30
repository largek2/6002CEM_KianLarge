using System;
using System.Collections.ObjectModel;
using _6003CEM.Services;
using _6003CEM.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _6003CEM.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly ProductService _productService;
        public HomeViewModel(ProductService productService)
        {
            _productService = productService;
            Products = new(_productService.GetPopularProducts());
        }
        public ObservableCollection<Product> Products { get; set; }

        [RelayCommand]
        private async Task GoToProductsPage(bool fromSearch = false)
        {
            var arguments = new Dictionary<string, object>
            {
                [nameof(ProductsViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(ProductsPage), animate: true, arguments);
        }
    }
}