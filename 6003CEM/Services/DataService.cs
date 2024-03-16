using _6003CEM.Models;
using Supabase;

namespace _6003CEM.Services;

public class DataService : IDataService
{
    private readonly Client _supabaseClient;

    public DataService(Supabase.Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var response = await _supabaseClient.From<Product>().Get();
        return response.Models.OrderBy(p => p.Id);
    }

    public async Task CreateProduct(Product product)
    {
        await _supabaseClient.From<Product>().Insert(product);
    }

    public async Task DeleteProduct(int id)
    {
        await _supabaseClient.From<Product>()
            .Where(p => p.Id == id).Delete();
    }

    public async Task UpdateProduct(Product product)
    {
        await _supabaseClient.From<Product>().Where(b => b.Id == product.Id)
            .Set(p => p.Title, product.Title)
            .Set(p => p.Price, product.Title)
            .Set(p => p.Image, product.Image)
            .Update();

    }
}