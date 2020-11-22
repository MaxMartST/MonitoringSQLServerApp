using MonitoringSQLServer.Domain;
using MonitoringSQLServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Application
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _applicationContext;
        private IUserRepository _user;
        private IGroupRepository _group;
        private IRoleRepository _role;
        private ISessionRepository _session;
        private IBlockingRepository _blocking;
        private IActiveSessionsRepository _activeSessions;

        public RepositoryWrapper(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_applicationContext);
                }

                return _user;
            }
        }
        public IGroupRepository Group
        {
            get
            {
                if (_group == null)
                {
                    _group = new GroupRepository(_applicationContext);
                }

                return _group;
            }
        }
        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_applicationContext);
                }

                return _role;
            }
        }
        public ISessionRepository Session
        {
            get
            {
                if (_session == null)
                {
                    _session = new SessionRepository(_applicationContext);
                }

                return _session;
            }
        }
        public IBlockingRepository Blocking
        {
            get
            {
                if (_blocking == null)
                {
                    _blocking = new BlockingRepository(_applicationContext);
                }

                return _blocking;
            }
        }
        public IActiveSessionsRepository ActiveSessions
        {
            get
            {
                if (_activeSessions == null)
                {
                    _activeSessions = new ActiveSessionsRepository(_applicationContext);
                }

                return _activeSessions;
            }
        }
        public void Save()
        {
            _applicationContext.SaveChanges();
        }
    }
}
