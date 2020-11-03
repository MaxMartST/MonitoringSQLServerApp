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
            if (context.Users.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(ApplicationContext context)
        {
            var customers = new[]
            {
                new User { Name = "Jerry" },
                new User { Name = "Summer" },
                new User { Name = "Morty" },
                new User { Name = "Rick" },
                new User { Name = "Beth" }
            };

            context.Users.AddRange(customers);
            context.SaveChanges();
        }
    }
}
