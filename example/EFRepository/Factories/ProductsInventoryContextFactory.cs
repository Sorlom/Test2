using Microsoft.EntityFrameworkCore;
using Persistencia.EFRepository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.EFRepository.Factories
{
    public class ProductsInventoryContextFactory
    {
        public ProductsInventoryContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsInventoryContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-UFHV26S;Database=test;Trusted_Connection=True;", opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new ProductsInventoryContext(optionsBuilder.Options);
        }
    }
}
