using System.ComponentModel.DataAnnotations;

namespace Psigest.Application.DTO;

public class ClinicDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome � obrigat�rio")]
    [MinLength(3, ErrorMessage = "O nome precisa ter no minimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O nome n�o pode ser maior que 100 caracteres")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "O endere�o � obrigat�rio")]
    [MinLength(3, ErrorMessage = "O endere�o precisa ter no minimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O endere�o n�o pode ser maior que 100 caracteres")]
    public string Address { get; set; } = "";

    public IEnumerable<HealthInsuranceDto>? HealthInsurances { get; set; }
}