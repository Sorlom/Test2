using Interfaces.Presentacion.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Presentacion
{
    public interface IFactoryCommand
    {
        bool CreateFactory(Factory factory);
    }
}
