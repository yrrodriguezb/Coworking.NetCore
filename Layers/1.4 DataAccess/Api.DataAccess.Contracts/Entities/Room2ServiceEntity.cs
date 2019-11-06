namespace Api.DataAccess.Contracts.Entities
{
    public class Room2ServiceEntity
    {
        public int IdRoom { get; set; }   
        public int IdService { get; set; }
        public virtual RoomEntity Room { get; set; }
        public virtual ServiceEntity Service { get; set; }

    }
}