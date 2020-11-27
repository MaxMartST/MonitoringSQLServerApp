using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MIcrosoftSQLServerConnector
{
    public interface IMSQLServerService
    {
        List<EventMSSQLServer> GetNewQueryHistory();
    }
}
