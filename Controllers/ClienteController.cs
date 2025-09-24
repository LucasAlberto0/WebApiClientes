using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteInterface _clienteInterface;

    public ClienteController(IClienteInterface clienteInterface)
    {
        _clienteInterface = clienteInterface;
    }

    [HttpGet("ListarClientes")]
    public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
    {
        var clientes = await _clienteInterface.ListarClientes();
        return Ok(clientes);
    }

    [HttpGet("BuscarClientePorId/{idCliente}")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClintePorId(int idCliente)
    {
        var clientes = await _clienteInterface.BuscarClientePorId(idCliente);
        return Ok(clientes);
    }

    [HttpPost("CriarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
    {
        var clientes = await _clienteInterface.CriarCliente(clienteCriacaoDto);
        return Ok(clientes);
    }

    [HttpPut("EditarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
    {
        var clientes = await _clienteInterface.EditarCliente(clienteEdicaoDto);
        return Ok(clientes);
    }
        
    [HttpDelete("ExcluirCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> ExcluirCliente(int idCliente)
    {
        var clientes = await _clienteInterface.ExcluirCliente(idCliente);
        return Ok(clientes);
    }
    }