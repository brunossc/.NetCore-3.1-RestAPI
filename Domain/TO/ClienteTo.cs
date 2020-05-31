using Org.Domain.Data.Model;

namespace Org.Domain.TO
{
    public class ClienteTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public int AgenciaId { get; set; }
    }
}