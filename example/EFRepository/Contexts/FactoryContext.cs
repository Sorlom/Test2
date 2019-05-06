using Interfaces.Persistencia;
using Persistencia.EFRepository.Entities;
using Persistencia.EFRepository.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.EFRepository.Contexts
{
    public class FactoryContext : IFactoryContext
    {

        public bool CreateFactory(Dominio.Factory factory)
        {
            try
            {
                Factory entityFactory = new Factory();

                entityFactory.Phone = factory.Phone;
                entityFactory.Address = factory.Address;

                using (var context = new ProductsInventoryContextFactory().CreateDbContext())
                {
                    context.Add(entityFactory);
                    context.SaveChanges();
                }

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
