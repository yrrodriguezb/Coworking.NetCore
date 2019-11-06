using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.EntityConfig
{
    public class UserEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder
                .ToTable("Users");

            entityBuilder
                .HasKey(x => x.Id);

            entityBuilder
                .Property(x => x.Id)
                .IsRequired();
        }
    }
}