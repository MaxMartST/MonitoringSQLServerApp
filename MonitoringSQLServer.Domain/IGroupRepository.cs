using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSQLServer.Domain
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetGroupList();
        Task<Group> GetGroup(int id);
        void Create(Group item);
        void Update(Group item);
        void Delete(int id);
        void Save();
    }
}
