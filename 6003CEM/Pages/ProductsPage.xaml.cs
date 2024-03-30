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
    }
}