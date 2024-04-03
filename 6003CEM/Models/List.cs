using SQLite;

namespace _6003CEM.Models
{
    [SQLite.Table("list")]
    public class List
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("customer_name")]
        public string? CustomerName { get; set; }
        
        [Column("order_list")]
        public string? OrderList { get; set; }
    }
}
