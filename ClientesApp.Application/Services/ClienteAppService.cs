using AutoMapper;
using ClientesApp.Application.Dtos;
using ClientesApp.Application.Interfaces;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Services;

namespace ClientesApp.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteDomainService _clienteDomainService;

        public ClienteAppService(IMapper mapper, IClienteDomainService clienteDomainService)
        {
            _mapper = mapper;
            _clienteDomainService = clienteDomainService;
        }

        public async Task<ClienteResponseDto> AddAsync(ClienteRequestDto request)
        {
            var cliente = _mapper.Map<Cliente>(request);
            cliente.Id = Guid.NewGuid();

            var result = await _clienteDomainService.AddAsync(cliente);
            return _mapper.Map<ClienteResponseDto>(result);

        }

        public async Task<ClienteResponseDto> UpdateAsync(Guid id, ClienteRequestDto request)
        {
            var cliente = _mapper.Map<Cliente>(request);
            cliente.Id = id;

            var result = await _clienteDomainService.UpdateAsync(cliente);
            return _mapper.Map<ClienteResponseDto>(result);
        }

        public async Task<ClienteResponseDto> DeleteAsync(Guid id)
        {
            var result = await _clienteDomainService.DeleteAsync(id);
            return _mapper.Map<ClienteResponseDto>(result);
        }

        public async Task<List<ClienteResponseDto>> GetManyAsync(string nome)
        {
            var result = await _clienteDomainService.GetManyAsync(nome);
            return _mapper.Map<List<ClienteResponseDto>>(result);
        }

        public async Task<ClienteResponseDto?> GetByIdAsync(Guid id)
        {
            var result = await _clienteDomainService.GetByIdAsync(id);
            return _mapper.Map<ClienteResponseDto>(result);
        }

        public void Dispose()
        {
            _clienteDomainService.Dispose();
        }
    }
}
