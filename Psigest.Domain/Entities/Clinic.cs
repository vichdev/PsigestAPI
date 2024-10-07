using Psigest.Domain.Entities.Base;
using Psigest.Domain.Validation;


namespace Psigest.Domain.Entities;

public sealed class Clinic(string name, string address) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Address { get; private set; } = address;
    public ICollection<HealthInsurance> HealthInsurances { get; set; } = [];

    public void Update(string name, string address)
    {
        Validate(name, address);

        Name = name;
        Address = address;

    }

    private void Validate(string name, string address)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            $"{nameof(Name)} inválido. O nome é obrigatório.");

        DomainExceptionValidation.When(name.Length < 5,
            $"{nameof(Name)} deve ter pelo menos 3 caracteres.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(address),
            $"{nameof(Address)} inválido. O endereço é obrigatório.");

        DomainExceptionValidation.When(address.Length < 10,
            $"{nameof(Address)} deve ter pelo menos 5 caracteres.");
    }
}
