using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psigest.Domain.Entities;
using Psigest.Infrastructure.Data.Maps.Base;

namespace Psigest.Infrastructure.Data.Maps;
public class ClinicMap : BaseEntityMap<Clinic>
{
    public override void Configure(EntityTypeBuilder<Clinic> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Address).IsRequired().HasMaxLength(100);

    }
}
