﻿using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.XUnitTest
{
    public class BaseTest : IDisposable
    {
        protected readonly ApplicationContext _context;

        public BaseTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options;

            _context = new ApplicationContext(options);
            _context.Database.EnsureCreated();

            ApplicationInitialize.Initialize(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
