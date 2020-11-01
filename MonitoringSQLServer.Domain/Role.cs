using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoleGroup> RoleGroups { get; set; }
        public Role()
        {
            RoleGroups = new List<RoleGroup>();
        }
    }
}
