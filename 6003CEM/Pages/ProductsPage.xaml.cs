using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6003CEM.Pages
{
    public partial class ProductsPage : ContentPage
    {
        private readonly ProductsViewModel _productsViewModel;
        public ProductsPage(ProductsViewModel productsViewModel)
        {
            InitializeComponent();
            _productsViewModel = productsViewModel;
            BindingContext = _productsViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (_productsViewModel.FromSearch)
            {
                await Task.Delay(150);
                searchBar.Focus();
            }
        }
        
        void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                _productsViewModel.SearchProductsCommand.Execute(null);
            }
        }
    }
}