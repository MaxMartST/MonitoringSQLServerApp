using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSQLServer.Application
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationContext _applicationContext;
        public StatisticsRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [Obsolete]
        public IEnumerable<Statistics> GiveServerState()
        {
            var date = _applicationContext.Statistics
                .FromSqlRaw("SELECT " +
                    "S.session_id, S.host_name, S.program_name, S.database_id, S.client_interface_name, S.login_name, S.reads, S.writes, " +
                    "R.user_id, R.wait_type, R.wait_time, R.last_wait_type, R.wait_resource, R.blocking_session_id, " +
                    "T.text, P.query_plan " +
                        "FROM sys.dm_exec_requests R " +
                        "JOIN sys.dm_exec_sessions S on S.session_id=R.session_id " +
                        "CROSS APPLY sys.dm_exec_sql_text(sql_handle) AS T " +
                        "CROSS APPLY sys.dm_exec_query_plan(plan_handle) As P")
                .ToList(); 

            return date;
        }
    }
}
