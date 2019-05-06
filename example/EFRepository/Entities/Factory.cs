using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistencia.EFRepository.Entities
{
    public class Factory
    {
        [Key]
        public long FactoryId { get; set; }

        [MaxLength(50), Required]
        public string Phone { get; set; }

        [MaxLength(300), Required]
        public string Address { get; set; }
    }
}
