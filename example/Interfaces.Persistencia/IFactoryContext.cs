using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Persistencia
{
    public interface IFactoryContext
    {
        bool CreateFactory(Factory address);
    }
}
