using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.EntityConfig
{
    public class ServiceEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ServiceEntity> entityBuilder)
        {
            entityBuilder
                .ToTable("Services");

            entityBuilder
                .HasKey(x => x.Id);

            entityBuilder
                .Property(x => x.Id)
                .IsRequired();

            entityBuilder
                .Property(x => x.Price)
                .HasColumnType("DECIMAL(19,2)");
        }
    }
}