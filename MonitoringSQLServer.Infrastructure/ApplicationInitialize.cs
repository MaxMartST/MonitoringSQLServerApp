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
                new User { 
                    FirstName = "Jerry",
                    LastName = "First",
                    Email = "Jerry-First@gmail.com"
                },
                new User { 
                    FirstName = "Adam", 
                    LastName = "Smit",
                    Email = "Adam-Smit@gmail.com"
                },
                new User { 
                    FirstName = "Morty",
                    LastName = "Willems",
                    Email = "Morty-Willems@gmail.com"
                },
                new User { 
                    LastName = "Rick",
                    FirstName = "Graims",
                    Email = "Rick-Graims@gmail.com"
                },
                new User { 
                    LastName = "Beth",
                    FirstName = "Aflic",
                    Email = "Beth-Aflic@gmail.com"
                }
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
