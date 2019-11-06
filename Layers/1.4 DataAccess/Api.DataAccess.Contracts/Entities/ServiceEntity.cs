using System.Collections.Generic;

namespace Api.DataAccess.Contracts.Entities
{
    public class ServiceEntity
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Room2ServiceEntity> Room2Service { get; set; }
    }
}