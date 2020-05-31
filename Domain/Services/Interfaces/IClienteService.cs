using System.Threading.Tasks;
using Org.Domain.Data.Model;

namespace Org.Domain.Services.Interfaces
{
    public interface IClienteService
    {
        Task<bool> Create(Cliente clie);
        Task<bool> Update(Cliente clie);
        Task<bool> Delete(Cliente clie);
    }
}