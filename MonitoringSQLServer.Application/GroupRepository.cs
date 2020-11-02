using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Application
{
    public class GroupRepository : RepositoryBase<Group> , IGroupRepository
    {
        public GroupRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
