using _6003CEM.Models;
using _6003CEM.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _6003CEM.PageModels;

[QueryProperty(nameof(Product), "ProductObject")]
public partial class UpdateProductPageModel : ObservableObject
{
    private readonly IDataService _dataService;

    [ObservableProperty] private Product _product;
    
    public UpdateProductPageModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    private async Task UpdateProduct()
    {
        if (!string.IsNullOrEmpty(Product.Title))
        {
            await _dataService.UpdateProduct(Product);

            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "No title!", "Okay");
        }
    }
}