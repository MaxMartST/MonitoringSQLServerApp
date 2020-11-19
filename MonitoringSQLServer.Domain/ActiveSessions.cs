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
        //public string program_name { get; set; }
        //public short database_id { get; set; }
        //public string client_interface_name { get; set; }
        //public string login_name { get; set; }
        //public long reads { get; set; }
        //public long writes { get; set; }
        //public int user_id { get; set; }
        //public string wait_type { get; set; }
        //public int wait_time { get; set; }
        //public string last_wait_type { get; set; }
        //public string wait_resource { get; set; }
        //public short blocking_session_id { get; set; }
        //public string text { get; set; }
        //public string query_plan { get; set; }
    }
}
