using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interfaces.Presentacion.Entities
{
    public class Factory
    {
        public long FactoryId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
