using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebImoveis.Domain.Entities;

namespace WebImoveis.Data.EntitiesMapping
{
    public class PropertyMap : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");

            builder.HasKey(p => p.PropertyId);

            builder.Property(p => p.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("VARCHAR(120)").IsRequired();
            builder.Property(p => p.Price).HasColumnType("DECIMAL(20,2)").IsRequired();
        }
    }
}
