
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avanade.Challenge.MyCondominium.Infra.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.isResident)
                .HasColumnType("BIT");

            builder.Property(x => x.CondominiumFee)
                .HasColumnType("DECIMAL(7,2)");

            builder.Property(x => x.DataAtualizacao)
                .HasColumnType("DATETIME");
        }
    }
}
