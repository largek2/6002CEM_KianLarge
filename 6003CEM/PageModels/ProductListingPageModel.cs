using _6003CEM.Models;
using _6003CEM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace _6003CEM.PageModels;

public partial class ProductListingPageModel : ObservableObject
{
    private readonly IDataService _dataService;

    public ObservableCollection<Product> Products { get; set; } = new();
    
    public ProductListingPageModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    public async Task GetProducts()
    {
        Products.Clear();

        try
        {
            var products = await _dataService.GetProducts();

            if (products.Any())
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }

    [RelayCommand]
    private async Task AddProduct() => await Shell.Current.GoToAsync("AddProductPage");

    [RelayCommand]
    private async Task DeleteProduct(Product product)
    {
        var result = await Shell.Current.DisplayAlert("Delete", $"Are you sure you want to delete \"{product.Title}\"?", "Yes", "No");

        if (result is true)
        {
            try
            {
                await _dataService.DeleteProduct(product.Id);
                await GetProducts();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
            }
        }
    }

    [RelayCommand]
    private async Task UpdateProduct(Product product) => await Shell.Current.GoToAsync("UpdateProductPage",
        new Dictionary<string, object>
        {
            { "ProductObject", product }
        });
}