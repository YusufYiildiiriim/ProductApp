using Microsoft.EntityFrameworkCore;
using ProductApp.Model;

namespace ProductApp.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options): base (options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

    }
}
