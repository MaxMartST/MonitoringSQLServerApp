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

        public RepositoryWrapper(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
