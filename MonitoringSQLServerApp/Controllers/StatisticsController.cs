using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonitoringSQLServer.Domain;

namespace MonitoringSQLServerApp.Controllers
{
    public class StatisticsController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;
        public StatisticsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        
        public IActionResult GetBlocking()
        {
            var serverBloking = _repositoryWrapper.Blocking.GetServerStatistics();

            return Ok(serverBloking);
        }

        public IActionResult GetActiveSession()
        {
            var activeSession = _repositoryWrapper.ActiveSessions.GetServerStatistics();

            return Ok(activeSession);
        }
    }
}
