using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.EntityConfig
{
    public class OfficeEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<OfficeEntity> entityBuilder)
        {
            entityBuilder
                .ToTable("Officess");

            entityBuilder
                .HasKey(x => x.Id);

            entityBuilder
                .Property(x => x.Id)
                .IsRequired();

            entityBuilder
                .HasOne(x => x.Booking)
                .WithOne(x => x.Office);

            entityBuilder
                .Property(x => x.PriceWorkSpaceDaily)
                .HasColumnType("DECIMAL(19,2)");

            entityBuilder
                .Property(x => x.PriceWorkSpaceMonthly)
                .HasColumnType("DECIMAL(19,2)");
        }
    }
}