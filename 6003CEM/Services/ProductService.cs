using System;
using System.Collections.Generic;
using _6003CEM.Models;
using Microsoft.Extensions.Logging;

namespace _6003CEM.Services
{
    public class ProductService
    {
        private readonly static IEnumerable<Product> _products = new 
            List<Product>
        {
            new Product
            {
                Name = "Taco",
                Image = "taco",
                Price = 3.99,
                Description = "Tortilla filled with chicken, Cheddar, pico de galo, cheese, and lettuce. Tacos consist of a mix of hot and cold ingredients, the final food temperature will depend on this mix. All tacos are 6 inch."
            },
            new Product
            {
                Name = "Burrito",
                Image = "burrito",
                Price = 4.49,
                Description = "12 inch flour tortilla layered with Mexican rice, beans, pico de gallo with melted cheese, lettuce, sour cream, guacamole, and salsa."
            },
            new Product
            {
                Name = "Quesadilla",
                Image = "ques",
                Price = 4.29,
                Description = "Melted Cheeses in a Grilled Flour Tortilla, served with Guacamole, Sour Cream & Tortilla Chips."
            }, 
            new Product
            {
                Name = "Supreme Rice Bowl",
                Image = "ricebowl",
                Price = 4.09,
                Description = "A steak filled bowl with Mexican rice, beans, lettuce, pico de galo, guacamole, and sour cream, salsa."
            },
            new Product
            {
                Name = "Supreme Veggie Bowl",
                Image = "rice_veggie",
                Price = 3.79,
                Description = "A bowl filled with Mexican rice, beans, lettuce, pico de galo, guacamole, and sour cream, salsa."
            },
            new Product
            {
                Name = "Loaded Nachos",
                Image = "nachos",
                Price = 3.99,
                Description = "Contains Cheese with Guacamole and Sour cream Dip."
            },
            new Product
            {
                Name = "Fajitas",
                Image = "fajita",
                Price = 6.09,
                Description = "Warm soft flour tortillas, refried beans, Mexican red rice and salsas, Fajitas de Pollo Asado."
            },
            new Product
            {
                Name = "Churros",
                Image = "churros",
                Price = 2.99,
                Description = "Crunchy dough swirls covered with cinnamon sugar, served with Chocolate sauce."
            },
            new Product
            {
                Name = "Coca Cola",
                Image = "coke",
                Price = 1.99,
                Description = "500ML Bottle."
            }, 
            new Product
            {
                Name = "Water",
                Image = "water",
                Price = 1.79,
                Description = "500ML Bottle."
            }
        };

        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
            LogProducts();
        }

        private void LogProducts()
        {
            _logger.LogInformation("Initial Products:");
            foreach (var product in _products)
            {
                _logger.LogInformation($"- Name: {product.Name}, Price: {product.Price}, Image: {product.Image}");
            }
        }

        public IEnumerable<Product> GetAllProducts() => _products;

        public IEnumerable<Product> GetPopularProducts(int count = 4) =>
            _products.OrderBy(p => Guid.NewGuid())
                .Take(count);

        public IEnumerable<Product> SearchProducts(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
                ? _products
                : _products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}