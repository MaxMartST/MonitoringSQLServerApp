using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Application
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext applicationContext) : base(applicationContext)
        { 
        }
    }
}
