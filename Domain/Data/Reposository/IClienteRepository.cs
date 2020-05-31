using System.Collections.Generic;
using System.Threading.Tasks;
using Org.Domain.Data.Model;

namespace Org.Domain.Data.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> Get(int id);
        Task<IEnumerable<Cliente>> GetAll(); 
        Task Create(Cliente clie);
        //void Update(Cliente clie);
        Task Delete(Cliente clie);
        Task<bool> SaveChanges();
    }
}