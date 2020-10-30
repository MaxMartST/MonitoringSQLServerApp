using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class UserGroup
    {
        public DateTime PublicDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
