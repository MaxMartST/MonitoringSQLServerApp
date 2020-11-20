using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class ActiveSessions
    {
        public int SPID { get; set; }
        public int BlkBy { get; set; }
        public int ElapsedMS { get; set; }
        public int CPU { get; set; }
        public long IOReads { get; set; }
        public long IOWrites { get; set; }
        public int Executions { get; set; }
        public string CommandType { get; set; }
        public string SQLStatement { get; set; }
        public string Status { get; set; }
        public string Login { get; set; }
        public string HostName { get; set; }
        public string DBName { get; set; }
        public string LastWaitType { get; set; }
        public DateTime StartTime { get; set; }
        public string Protocol { get; set; }
        public string TransactionIsolation { get; set; }
        public int ConnectionWrites { get; set; }
        public int ConnectionReads { get; set; }
        public string ClientAddress { get; set; }
        public string Authentication { get; set; }
    }
}
