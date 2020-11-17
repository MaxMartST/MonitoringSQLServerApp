using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonitoringSQLServer.Domain;

namespace MonitoringSQLServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private IStatisticsRepository _StatisticsRepository;
        public StatisticsController(IStatisticsRepository whoIsActiveRepository)
        {
            _StatisticsRepository = whoIsActiveRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var state = _StatisticsRepository.GiveServerState();

            return Ok(state);
        }
    }
}
