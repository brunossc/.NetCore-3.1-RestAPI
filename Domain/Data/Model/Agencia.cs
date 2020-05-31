using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Domain.Data.Model
{
    public class Agencia
    { 
         [Key]
        public int Id { get; set; }

        [Required()]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        public virtual IEnumerable<Cliente> Clientes { get; set; }
    }
}