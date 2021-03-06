using Microsoft.EntityFrameworkCore;
using api_development.Models;

namespace api_development.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
    }
}
