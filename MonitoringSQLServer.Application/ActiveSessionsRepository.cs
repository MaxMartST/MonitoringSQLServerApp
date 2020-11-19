using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitoringSQLServer.Application
{
    public class ActiveSessionsRepository : IActiveSessionsRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ActiveSessionsRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [Obsolete]
        public IEnumerable<ActiveSessions> GetServerStatistics()
        {
            var data = _applicationContext.ActiveSessions
                .FromSqlRaw("SELECT " +
                    "CAST(er.session_id AS int) AS SPID, " +
                    "CAST(er.blocking_session_id AS int) AS BlkBy, " +
                    "er.total_elapsed_time AS ElapsedMS, " +
                    "er.cpu_time AS CPU, " +
                    "er.logical_reads + er.reads AS IOReads, " +
                    "er.writes AS IOWrites " +
                        "FROM sys.dm_exec_requests er " +
                            "LEFT JOIN sys.dm_exec_sessions ses ON ses.session_id = er.session_id " +
                            "LEFT JOIN sys.dm_exec_connections con ON con.session_id = ses.session_id " +
                                "CROSS APPLY sys.dm_exec_sql_text(er.sql_handle) as qt " +
                                "OUTER APPLY(SELECT execution_count = MAX(cp.usecounts) FROM sys.dm_exec_cached_plans cp WHERE cp.plan_handle = er.plan_handle) AS ec ")
                .ToList();

            return data;
        }
    }
}
