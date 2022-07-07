
using Avanade.Challenge.MyCondominium.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avanade.Challenge.MyCondominium.Infra.Data.Mappings
{
    public class ApartmentMap : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartment");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.Block)
                .HasColumnType("INT");

            builder.Property(x => x.Created)
                .HasColumnType("DATETIME");

            builder.Property(x => x.LastUpdated)
                .HasColumnType("DATETIME");

        }
    }
}
