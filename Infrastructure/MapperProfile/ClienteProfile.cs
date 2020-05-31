using System.Collections.Generic;
using AutoMapper;
using Org.Domain.Data.Model;
using Org.Domain.TO;

namespace Org.Infrestructure.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // DTO to Entity
            CreateMap<ClienteCreateTO, Cliente>();
            CreateMap<ClienteTO,Cliente>();

            //Entity to DTO
            CreateMap<Cliente, ClienteCreateTO>();
            CreateMap<Cliente, ClienteTO>();            
        }
    }
}