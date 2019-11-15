using System.Collections.Generic;
using Api.DataAccess.Contracts.Entities;

namespace Coworking.Application.UnitTest.Stubs
{
    public class AdminStub
    {
        public static AdminEntity admin_1 = new AdminEntity () 
        {
            Email = "admin@admin.com",
            Id = 1,
            Name = "Admin.Coworking",
            Phone = "1564564646"
        };

         public static AdminEntity admin_2 = new AdminEntity () 
        {
            Email = "diego.rodriguez@coworking.com.co",
            Id = 2,
            Name = "diego Rodriguez",
            Phone = "456465464"
        };

        public static List<AdminEntity> listAdmin = new List<AdminEntity>(
            new AdminEntity[] { admin_1, admin_2 }
        );
    }
}