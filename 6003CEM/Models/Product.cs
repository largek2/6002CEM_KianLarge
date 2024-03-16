using Postgrest.Attributes;
using Postgrest.Models;

namespace _6003CEM.Models;

[Table ("products")]
public class Product : BaseModel
{
    [PrimaryKey ("id", false)]
    public int Id { get; set; }
    
    [Column("name")]
    public string Title { get; set; }
    
    [Column("price")]
    public double Price { get; set; }
    
    [Column("image_url")]
    public string Image { get; set; }
}