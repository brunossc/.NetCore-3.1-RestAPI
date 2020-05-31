using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Org.Domain.Data.Model;
using Org.Domain.Data.Repository;

namespace Org.Infrestructure.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSet<Cliente> _repository;
        private readonly SqlDBConttext _context;

        public ClienteRepository(SqlDBConttext context)
        {
            _repository = context.Clientes;
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _repository.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _repository.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(Cliente clie)
        {
            await _repository.AddAsync(clie);
        }

        public async Task Delete(Cliente clie)
        {
           await Task.Run(()=> {
               _repository.Remove(clie);
           });            
        }

        public async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();
            return (result >= 0 );
        }

       
    }
}