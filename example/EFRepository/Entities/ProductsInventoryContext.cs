using Microsoft.EntityFrameworkCore;

namespace Persistencia.EFRepository.Entities
{
    public class ProductsInventoryContext : DbContext
    {
        public ProductsInventoryContext(DbContextOptions<ProductsInventoryContext> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-UFHV26S;Database=test;Trusted_Connection=True;");
            }
        }

        public DbSet<Factory> factories { get; set; }
    }
}
