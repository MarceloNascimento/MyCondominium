
using Avanade.Desafio.Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avanade.Challange.MyCondominium.Infra.Data.Mappings
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

            builder.Property(x => x.DataCriacao)
                .HasColumnType("DATETIME");

            builder.Property(x => x.DataAtualizacao)
                .HasColumnType("DATETIME");

        }
    }
}
