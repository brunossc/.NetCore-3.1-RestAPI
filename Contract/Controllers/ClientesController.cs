using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Org.Domain.Data.Model;
using Org.Domain.Data.Repository;
using Org.Domain.Services.Interfaces;
using Org.Domain.TO;

namespace Org.Contract.Controllers
{
    [ApiController]
    [Route("api/Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _serviceCliente;
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService service, IClienteRepository repository, IMapper mapper)
        {
            _serviceCliente = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "Obter")]
        [Route("Obter/{id}")]
        public async Task<ActionResult> Obter(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var content = await _repository.Get(id);

            if (content == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClienteTO>(content));
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> Obter()
        {
            var content = await _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Cliente>, IList<ClienteTO>>(content));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(ClienteCreateTO clie)
        {
            if (clie == null)
            {
                throw new ArgumentNullException(nameof(clie));
            }

            var Cliente = _mapper.Map<Cliente>(clie);
            var result = await _serviceCliente.Create(Cliente);
            var ClienteTO = _mapper.Map<ClienteTO>(Cliente);

            return CreatedAtAction(nameof(Obter), new { id = ClienteTO.Id}, ClienteTO);
        }

        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult> Update(int id, ClienteCreateTO clie)
        {
            var cliente = await _repository.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(await _serviceCliente.Update(_mapper.Map(clie, cliente)));
        }

        [HttpPatch("{id}")]
        [Route("PartialUpdate/{id}")]
        public async Task<ActionResult> PartialUpdate(int id, JsonPatchDocument<ClienteCreateTO> clie)
        {
            var cliente = await _repository.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            var patchModel = _mapper.Map<ClienteCreateTO>(cliente);
            clie.ApplyTo(patchModel, ModelState);

            if (!TryValidateModel(patchModel))
            {
                return ValidationProblem(ModelState);
            }
            
            return Ok(await _serviceCliente.Update(_mapper.Map(patchModel,cliente)));            
        }

        [HttpDelete("{id}")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _repository.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(await _serviceCliente.Delete(cliente));
        }


    }
}