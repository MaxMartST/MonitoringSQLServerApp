using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MonitoringSQLServer.Domain;

namespace MonitoringSQLServerApp.Controllers
{
    public class StatisticsController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public StatisticsController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public IActionResult GetActiveSession()
        {
            List<Session> specialSessions = new List<Session>();
            var allActiveSessions = _repositoryWrapper.ActiveSessions.GetServerStatistics();

            if (allActiveSessions == null)
            {
                return NotFound();
            }

            foreach (ActiveSessions ativeSession in allActiveSessions)
            {
                var mapperSession = _mapper.Map<Session>(ativeSession);

                var value = _repositoryWrapper.Session.FindByCondition(x => x.SPID == mapperSession.SPID).FirstOrDefault();
                //Session session = value;

                if (value == null)
                {
                    _repositoryWrapper.Session.Create(mapperSession);
                    _repositoryWrapper.Save();
                }

                if (SessionAnalysis(value, mapperSession))
                {
                    specialSessions.Add(mapperSession);
                }
            }

            return Ok(specialSessions);
        }

        private bool SessionAnalysis(Session sessionDb, Session sessionActive)
        {
            if (sessionDb != null && sessionDb.BlkBy == sessionActive.BlkBy)
            {
                return BlockingAnalysis(sessionDb.ElapsedMS, sessionActive.ElapsedMS);
            }

            return false;
        }

        private bool BlockingAnalysis(int timeSessionDB, int timeSessionActive)
        {
            int orderTime = timeSessionActive - timeSessionDB;
            if (orderTime > 60000)
            {
                return true;
            }

            return false;
        }
    }
}
