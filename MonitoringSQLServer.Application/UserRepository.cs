using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Application
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
        { 
        }
    }
}
