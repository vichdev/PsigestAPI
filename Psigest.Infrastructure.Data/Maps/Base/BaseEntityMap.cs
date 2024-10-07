using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Psigest.Domain.Entities.Base;

namespace Psigest.Infrastructure.Data.Maps.Base;
public class BaseEntityMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TDomain> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnName("Id")
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}
