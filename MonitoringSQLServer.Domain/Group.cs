using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public Group()
        {
            Users = new List<User>();
        }
    }
}
