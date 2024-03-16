using _6003CEM.Models;
using _6003CEM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _6003CEM.PageModels;

public partial class AddProductPageModel : ObservableObject
{
    private readonly IDataService _dataService;

    [ObservableProperty] private string _productTitle;
    [ObservableProperty] private double _productPrice;
    [ObservableProperty] private string _productImage;

    public AddProductPageModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    private async Task AddProduct()
    {
        try
        {
            if (!string.IsNullOrEmpty(ProductTitle))
            {
                Product product = new()
                {
                    Title = ProductTitle,
                    Price = ProductPrice,
                    Image = ProductImage
                };
                await _dataService.CreateProduct(product);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No title", "Okay");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Okay");
        }
    }
}