using System;
using System.Collections.Generic;
using System.Text;

namespace MIcrosoftSQLServerConnector
{
    public class EventMSSQLServer
    {
        public DateTime TimeStamp { get; set; }
        public string ClientHn { get; set; }
        public string Duration { get; set; }
        public string NtUserName { get; set; }
        public int DatabaseId { get; set; }
        public string DatabaseName { get; set; }
        public int CpuTime { get; set; }
        public int LogicalReads { get; set; }
        public int Writes { get; set; }
    }
}
