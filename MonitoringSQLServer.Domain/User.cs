using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public User()
        {
            UserGroups = new List<UserGroup>();
        }
    }
}
