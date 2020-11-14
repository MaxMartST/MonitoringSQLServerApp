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
    public class WhoIsActiveRepository : IWhoIsActiveRepository
    {
        private readonly ApplicationContext _applicationContext;
        public WhoIsActiveRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IEnumerable<WhoIsActive> GiveServerState()
        {
            var date = new List<WhoIsActive>();
            using (var command = _applicationContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC sp_WhoIsActive @show_sleeping_spids = 2, @show_system_spids = 1, @show_own_spid = 1, @get_additional_info = 1";
                _applicationContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var wia = new WhoIsActive();

                        wia.CPU = result["CPU"].ToString();

                        date.Add(wia);
                    }
                }
            }

            return date;
        }
    }
}
