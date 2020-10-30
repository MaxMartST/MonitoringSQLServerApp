using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSQLServer.Domain
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRoleList();
        Task<Role> GetRole(int id);
        void Create(Role item);
        void Update(Role item);
        void Delete(int id);
        void Save();
    }
}
