using Interfaces.Persistencia;
using Interfaces.Presentacion;
using Interfaces.Presentacion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion
{
    public class FactoryCommand : IFactoryCommand
    {
        private IFactoryContext factoryContext;

        public FactoryCommand(IFactoryContext factoryContext)
        {
            this.factoryContext = factoryContext;
        }

        public bool CreateFactory(Factory factory)
        {
            try
            {
                Dominio.Factory domainFactory = new Dominio.Factory(factory.Phone, factory.Address);

                factoryContext.CreateFactory(domainFactory);

                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }


    }
}
