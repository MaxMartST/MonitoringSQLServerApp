using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public List<RoleGroup> RoleGroups { get; set; }
        public Group()
        {
            RoleGroups = new List<RoleGroup>();
            UserGroups = new List<UserGroup>();
        }
    }
}
