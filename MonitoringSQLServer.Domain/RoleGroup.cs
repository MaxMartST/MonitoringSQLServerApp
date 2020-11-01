using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class RoleGroup
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
