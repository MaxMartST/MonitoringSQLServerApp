using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class Blocking
    {
        public int Id { get; set; }
        public string DBName { get; set; }
        public int RequestSessionId { get; set; }
        public int BlockingSessionId { get; set; }
        public string BlockedObjectName { get; set; }
        public string ResourceType { get; set; }
        public string RequestingText { get; set; }
        public string BlockingTest { get; set; }
        public string RequestMode { get; set; }
    }
}
