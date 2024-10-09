using ClientesApp.Application.Dtos;
using ClientesApp.Application.Interfaces.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] ClienteRequestDto request)
        {
            var response = await _clienteAppService.AddAsync(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        //[Route("editar")]
        [ProducesResponseType(typeof(ClienteResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ClienteRequestDto request)
        {
            var response = await _clienteAppService.UpdateAsync(id, request);
            return Ok(response);

        }

        [HttpDelete]
        [ProducesResponseType(typeof(ClienteResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _clienteAppService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMany([FromQuery] string nome)
        {
            var response = await _clienteAppService.GetManyAsync(nome);
            return Ok(response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _clienteAppService.GetByIdAsync(id);
            return Ok(response);
        }
    }
}
