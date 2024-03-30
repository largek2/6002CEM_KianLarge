using System;
using System.Collections.ObjectModel;
using _6003CEM.Services;
using _6003CEM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _6003CEM.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class ProductsViewModel : ObservableObject
    {
        
        private readonly ProductService _productService;
        public ProductsViewModel(ProductService productService)
        {
            _productService = productService;
            Products = new(_productService.GetAllProducts());
        }
        
        public ObservableCollection<Product> Products { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchProducts(string searchTerm)
        {
            Products.Clear();
            Searching = true;
            //var products = _productService.SearchProducts(searchTerm);
            foreach (var product in _productService.SearchProducts(searchTerm))
            {
                Products.Add(product);
            }
            Searching = false;
        }
    }    
}
