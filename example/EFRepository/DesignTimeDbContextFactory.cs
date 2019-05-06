using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistencia.EFRepository.Entities;

namespace Persistencia.EFRepository
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProductsInventoryContext>
    {
        public ProductsInventoryContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProductsInventoryContext>();
            builder.UseSqlServer(@"Server=DESKTOP-UFHV26S;Database=test;Trusted_Connection=True;");

            return new ProductsInventoryContext(builder.Options);
        }
    }
}
