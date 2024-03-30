using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _6003CEM.Models
{
    public partial class Product : ObservableObject
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        [ObservableProperty, 
         NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => CartQuantity * Price;

        public Product Clone() => MemberwiseClone() as Product;
    } 
}