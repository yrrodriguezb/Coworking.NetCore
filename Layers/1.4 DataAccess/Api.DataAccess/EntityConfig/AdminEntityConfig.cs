using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.EntityConfig
{
    public class AdminEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<AdminEntity> entityBuilder)
        {
            entityBuilder
                .ToTable("Admins");

            entityBuilder
                .HasKey(x => x.Id);

            entityBuilder
                .Property(x => x.Id)
                .IsRequired();
        }
    }
}