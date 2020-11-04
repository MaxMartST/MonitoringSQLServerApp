using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitoringSQLServer.Infrastructure
{
    public class ApplicationInitialize
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Users.Any())
            {
                Seed(context);
            }
        }

        private static void Seed(ApplicationContext context)
        {
            var listUser = new List<User>
            {
                new User { Name = "Jerry" },
                new User { Name = "Summer" },
                new User { Name = "Morty" },
                new User { Name = "Rick" },
                new User { Name = "Beth" }
            };

            foreach (User user in listUser)
            {
                context.Users.Add(user);
                context.SaveChanges();
                context.Entry(user).State = EntityState.Detached;
            }
        }
    }
}
