﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSQLServer.Domain
{
    public interface IWhoIsActiveRepository
    {
        IEnumerable<User> GiveServerState();
    }
}
