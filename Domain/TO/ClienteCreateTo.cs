using System;
using System.ComponentModel.DataAnnotations;

namespace Org.Domain.Data.Model
{
    public class ClienteCreateTO
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public int AgenciaId { get; set; }
    }
}