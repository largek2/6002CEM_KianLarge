
using _6003CEM.Models;

namespace _6003CEM.Services;

public interface IDataService
{
    Task<IEnumerable<Product>> GetProducts();
    Task CreateProduct(Product product);
    Task DeleteProduct(int id);
    Task UpdateProduct(Product product);

} 