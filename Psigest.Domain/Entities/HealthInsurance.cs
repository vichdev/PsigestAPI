using Psigest.Domain.Entities.Base;
using Psigest.Domain.Validation;


namespace Psigest.Domain.Entities;

public sealed class HealthInsurance(string name, string imageUrl) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string ImageUrl { get; private set; } = imageUrl;
    public ICollection<Clinic> Clinics { get; set; } = [];

    public void Update(HealthInsurance healthInsurance)
    {
        Validate(healthInsurance.Name, healthInsurance.ImageUrl);

        Name = healthInsurance.Name;
        ImageUrl = healthInsurance.ImageUrl;
    }

    private void Validate(string name, string imageUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            $"{nameof(Name)} inválido. O nome é obrigatório.");

        DomainExceptionValidation.When(name.Length < 5,
            $"{nameof(Name)} deve ter pelo menos 3 caracteres.");

        DomainExceptionValidation.When(imageUrl?.Length > 250, $"{nameof(ImageUrl)} muito longo, deve ter pelo menos 250 caracteres.");
    }
}
