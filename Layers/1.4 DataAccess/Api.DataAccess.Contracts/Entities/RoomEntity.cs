using System.Collections.Generic;

namespace Api.DataAccess.Contracts.Entities
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Office2RoomsEntity> Office2Room { get; set; }
        public virtual ICollection<Room2ServiceEntity> Room2Service { get; set; }

    }
}