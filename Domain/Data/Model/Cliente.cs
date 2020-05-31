using System;
using System.ComponentModel.DataAnnotations;

namespace Org.Domain.Data.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public int AgenciaId { get; set; }
        
        public virtual Agencia Agencia { get; set; }
    }
}