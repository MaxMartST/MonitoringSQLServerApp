using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSQLServer.Domain
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserList();
        Task<User> GetUser(int id);
        void Create(User item);
        void Update(User item);
        void Delete(int id);
        void Save();
    }
}
