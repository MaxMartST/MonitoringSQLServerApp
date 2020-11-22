using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IGroupRepository Group { get; }
        IRoleRepository Role { get; }
        ISessionRepository Session { get; }
        IActiveSessionsRepository ActiveSessions { get; }
        IBlockingRepository Blocking { get; }

        void Save();
    }
}
