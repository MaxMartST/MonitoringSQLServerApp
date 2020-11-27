using System;

namespace MIcrosoftSQLServerConnector
{
    public class MSQLServerServiceRepository : BaseDataAccess, IMSQLServerService
    {
        public MSQLServerServiceRepository(string connectionString) : base(connectionString)
        { 
        }

    }
}
