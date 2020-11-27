using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MIcrosoftSQLServerConnector
{
    public class MSQLServerServiceRepository : BaseDataAccess, IMSQLServerService
    {
        public MSQLServerServiceRepository(string connectionString) : base(connectionString)
        { 
        }

        public List<EventMSSQLServer> GetNewQueryHistory()
        {
            List<DbParameter> parameterList = new List<DbParameter>();
            List<EventMSSQLServer> EventMSSQLServers = new List<EventMSSQLServer>();
            EventMSSQLServer EventMSSQLServerItem = null;

            using (DbDataReader dataReader = base.GetDataReader("Test_GetAll", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        EventMSSQLServerItem = new EventMSSQLServer();

                        EventMSSQLServerItem.TimeStamp = (DateTime)dataReader["TimeStamp"];
                        EventMSSQLServerItem.ClientHn = (string)dataReader["ClientHn"];
                        EventMSSQLServerItem.Duration = (string)dataReader["Duration"];
                        EventMSSQLServerItem.NtUserName = (string)dataReader["NtUserName"];
                        EventMSSQLServerItem.DatabaseId = (int)dataReader["DatabaseId"];
                        EventMSSQLServerItem.DatabaseName = (string)dataReader["DatabaseName"];
                        EventMSSQLServerItem.CpuTime = (int)dataReader["CpuTime"];
                        EventMSSQLServerItem.LogicalReads = (int)dataReader["LogicalReads"];
                        EventMSSQLServerItem.Writes = (int)dataReader["Writes"];

                        EventMSSQLServers.Add(EventMSSQLServerItem);
                    }
                }
            }
            return EventMSSQLServers;
        }
    }
}
