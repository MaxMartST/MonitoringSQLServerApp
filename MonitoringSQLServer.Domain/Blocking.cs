using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class Blocking
    {
        public string DBName { get; set; }
        public int RequestSessionId { get; set; }
        public int BlockingSessionId { get; set; }
        public string BlockedObjectName { get; set; }
        public string ResourceType { get; set; }
        public string RequestingText { get; set; }
        public string BlockingTest { get; set; }
        public string RequestMode { get; set; }


        //public short session_id { get; set; }
        //public string host_name { get; set; }
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
