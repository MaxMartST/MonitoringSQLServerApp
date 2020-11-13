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
    public class WhoIsActiveController : Controller
    {
        private IWhoIsActiveRepository _whoIsActiveRepository;
        public WhoIsActiveController(IWhoIsActiveRepository whoIsActiveRepository)
        {
            _whoIsActiveRepository = whoIsActiveRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var state = _whoIsActiveRepository.GiveServerState();

            return Ok(state);
        }
    }
}
