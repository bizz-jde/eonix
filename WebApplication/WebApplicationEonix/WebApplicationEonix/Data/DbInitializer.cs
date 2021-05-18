using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEonix.Models;

namespace WebApplicationEonix.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EonixContext context)
        {
            context.Database.EnsureCreated();


            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Id=  Guid.NewGuid(),FirstName="Julien",LastName="Desterbecq"},
                new User{Id=  Guid.NewGuid(),FirstName="Arnold",LastName="Schwarzenegger"},
                new User{Id=  Guid.NewGuid(),FirstName="Bruce",LastName="Willis"},
                new User{Id=  Guid.NewGuid(),FirstName="Sylvester",LastName="Stallone"}
            };

            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();
        }
    }
}
