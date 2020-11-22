using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, ActiveSessions>()
                .ReverseMap();
        }
    }
}
