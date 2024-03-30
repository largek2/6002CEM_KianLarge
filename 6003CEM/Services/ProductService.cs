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
                Price = 3.99
            },
            new Product
            {
                Name = "Burrito",
                Image = "burrito",
                Price = 4.49
            },
            new Product
            {
                Name = "Quesadilla",
                Image = "ques",
                Price = 4.29
            }, 
            new Product
            {
                Name = "Supreme Rice Bowl",
                Image = "ricebowl",
                Price = 4.09
            },
            new Product
            {
                Name = "Supreme Veggie Bowl",
                Image = "rice_veggie",
                Price = 3.79
            },
            new Product
            {
                Name = "Loaded Nachos",
                Image = "nachos",
                Price = 3.99
            },
            new Product
            {
                Name = "Fajitas",
                Image = "fajita",
                Price = 4.09
            },
            new Product
            {
                Name = "Churros ",
                Image = "churros",
                Price = 2.99
            },
            new Product
            {
                Name = "Coca Cola",
                Image = "coke",
                Price = 1.99
            }, 
            new Product
            {
                Name = "Water",
                Image = "water",
                Price = 1.79
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