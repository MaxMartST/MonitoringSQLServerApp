using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;
//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.Desig
//Microsoft.EntityFrameworkCore.SqlServe
//Microsoft.EntityFrameworkCore.Tools

namespace MonitoringSQLServer.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base(GetOptions("MonitoringSQLServerDB"))
        { }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        //public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasOne(r => r.User)
                .WithMany(t => t.UserGroups)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(r => r.Group)
                .WithMany(t => t.UserGroups)
                .HasForeignKey(p => p.GroupId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
