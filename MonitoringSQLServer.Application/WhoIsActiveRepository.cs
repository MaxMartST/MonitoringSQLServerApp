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
        public IEnumerable<User> GiveServerState()
        {
            return _applicationContext.Users
                .FromSqlRaw<User>("EXECUTE get_all_users")
                .ToList();
        }
    }
}
