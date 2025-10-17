using System.ComponentModel.DataAnnotations;

public class ClienteCriacaoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O sobrenome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O sobrenome deve ter no máximo 50 caracteres.")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "O Cpf é obrigatório.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter exatamente 11 números.")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [MaxLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
    public string Email { get; set; }

    [MaxLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
    public string Endereco { get; set; }
}