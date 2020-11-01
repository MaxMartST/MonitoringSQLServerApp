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
        public DbSet<UserGroup> UserGroup { get; set; }
        //public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasKey(bc => new { bc.UserId, bc.GroupId });
            modelBuilder.Entity<UserGroup>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserGroups)
                .HasForeignKey(bc => bc.GroupId);
            modelBuilder.Entity<UserGroup>()
                .HasOne(bc => bc.Group)
                .WithMany(c => c.UserGroups)
                .HasForeignKey(bc => bc.GroupId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
