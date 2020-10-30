using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
        public Role()
        {
            Roles = new List<Role>();
        }
    }
}
