using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Org.Domain.Data.Model;
using Org.Domain.Data.Repository;
using Org.Domain.Services.Interfaces;

namespace Org.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(Cliente clie)
        {
            await _repository.Create(clie);
            return await _repository.SaveChanges();
        }

        public async Task<bool> Update(Cliente clie)
        {
            return await _repository.SaveChanges();
        }

        public async Task<bool> Delete(Cliente clie)
        {
            await _repository.Delete(clie);
            return await _repository.SaveChanges();
        }
    }
}