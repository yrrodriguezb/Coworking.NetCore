using System;

namespace Coworking.API.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
    }
}