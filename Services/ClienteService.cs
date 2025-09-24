
using Microsoft.EntityFrameworkCore;

public class ClientesService : IClienteInterface
{

    private readonly AppDbContext _context;

    public ClientesService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var clientes = await _context.Clientes.ToListAsync();

            resposta.Dados = clientes;
            resposta.Mensagem = "Todos os clientes foram coletados!";

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    public async Task<ResponseModel<ClienteModel>> BuscarClientePorId(int idCliente)
    {
        ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
        try
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == idCliente);

            if (cliente == null)
            {
                resposta.Mensagem = "Nenhum cliente localizado!";
                return resposta;
            }

            resposta.Dados = cliente;
            resposta.Mensagem = "Cliente Localizado!";

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var cliente = new ClienteModel()
            {
                Nome = clienteCriacaoDto.Nome,
                Sobrenome = clienteCriacaoDto.Sobrenome,
                Cpf = clienteCriacaoDto.Cpf,
                Email = clienteCriacaoDto.Email,
                Endereco = clienteCriacaoDto.Endereco
            };

            _context.Add(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes.ToListAsync();
            resposta.Mensagem = "Cliente criado com sucesso!";

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }



    public async Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == clienteEdicaoDto.Id);

            if (cliente == null)
            {
                resposta.Mensagem = "Nenhum cliente localizado";
                return resposta;
            }

            cliente.Nome = clienteEdicaoDto.Nome;
            cliente.Sobrenome = clienteEdicaoDto.Sobrenome;
            cliente.Endereco = clienteEdicaoDto.Endereco;
            cliente.Email = clienteEdicaoDto.Email;

            _context.Update(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes.ToListAsync();
            resposta.Mensagem = "Cliente editado com sucesso!";

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<ClienteModel>>> ExcluirCliente(int idCliente)
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();

        try
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == idCliente);

            if (cliente == null)
            {
                resposta.Mensagem = "Nenhum cliente localizado!";
                return resposta;
            }

            _context.Remove(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes.ToListAsync();
            resposta.Mensagem = "Removido com Sucesso!";

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}