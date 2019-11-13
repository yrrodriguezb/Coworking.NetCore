using System;

namespace Coworking.Api.Bussiness.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
    }
}