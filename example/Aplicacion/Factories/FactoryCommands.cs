using Interfaces.Presentacion;
using Persistencia.EFRepository.Contexts;
using System;

namespace Aplicacion.Factories
{
    public class FactoryCommands
    {
        public IFactoryCommand CreateFactoryCommand(string databaseName)
        {
            switch (databaseName)
            {
                case "EFCore":
                    var factoryContext = new FactoryContext();
                    var factoryCommand = new FactoryCommand(factoryContext);

                    return factoryCommand;
                default:
                    throw new Exception("Error: Database engine not set in configuration file.");
            }
        }
    }
}
