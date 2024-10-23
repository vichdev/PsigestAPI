using System.ComponentModel.DataAnnotations;

namespace Psigest.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "A senha é obrigatória")]
    [StringLength(20, ErrorMessage = "A senha deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
    public string ReturnUrl { get; set; } = "";
}
