using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.EntityConfig
{
    public class RoomEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<RoomEntity> entityBuilder)
        {
            entityBuilder
                .ToTable("Rooms");

            entityBuilder
                .HasKey(x => x.Id);

            entityBuilder
                .Property(x => x.Id)
                .IsRequired();
        }
    }
}