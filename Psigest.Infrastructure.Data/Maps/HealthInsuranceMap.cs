using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psigest.Domain.Entities;
using Psigest.Infrastructure.Data.Maps.Base;

namespace Psigest.Infrastructure.Data.Maps;
public class HealthInsuranceMap : BaseEntityMap<HealthInsurance>
{
    public override void Configure(EntityTypeBuilder<HealthInsurance> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);

        builder.HasOne(b => b.Clinic).WithMany(b => b.HealthInsurances).HasForeignKey(b => b.ClinicId);
    }
}
