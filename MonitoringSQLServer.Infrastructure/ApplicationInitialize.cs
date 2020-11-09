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
                    //RegistrationDate = new DateTime(2020, 10, 19),
                    Email = "Jerry-First@gmail.com"
                },
                new User { 
                    FirstName = "Adam", 
                    LastName = "Smit",
                    //RegistrationDate = new DateTime(2020, 11, 09),
                    Email = "Adam-Smit@gmail.com"
                },
                new User { 
                    FirstName = "Morty",
                    LastName = "Willems",
                    //RegistrationDate = new DateTime(2020, 10, 01),
                    Email = "Morty-Willems@gmail.com"
                },
                new User { 
                    LastName = "Rick",
                    FirstName = "Graims",
                    //RegistrationDate = new DateTime(2020, 10, 19),
                    Email = "Rick-Graims@gmail.com"
                },
                new User { 
                    LastName = "Beth",
                    FirstName = "Aflic",
                    //RegistrationDate = new DateTime(2020, 09, 01),
                    Email = "Beth-Aflic@gmail.com"
                }
            };

            foreach (User user in listUser)
            {
                user.RegDate = new DateTime(2020, 11, 09);
                context.Users.Add(user);
                context.SaveChanges();
                context.Entry(user).State = EntityState.Detached;
            }
        }
    }
}
