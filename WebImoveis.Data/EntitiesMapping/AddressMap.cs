using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebImoveis.Domain.Entities;

namespace WebImoveis.Data.EntitiesMapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(a => a.AddressId);

            builder.Property(a => a.Cep).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(a => a.Street).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(a => a.Neighborhood).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(a => a.Town).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(a => a.Uf).HasColumnType("CHAR(2)").IsRequired();

            builder
                .HasMany<Property>(a => a.Properties)
                .WithOne(p => p.Address)
                .HasForeignKey(p => p.AddressId);
        }
    }
}
