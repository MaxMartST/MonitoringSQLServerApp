using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;

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
            modelBuilder.Entity<Group>()
                .HasMany(p => p.Users)
                .WithMany(p => p.Groups)
                .UsingEntity<UserGroup>(
                    j => j
                        .HasOne(pt => pt.User)
                        .WithMany(t => t.UserGroups)
                        .HasForeignKey(pt => pt.UserId),
                    j => j
                        .HasOne(pt => pt.Group)
                        .WithMany(p => p.UserGroups)
                        .HasForeignKey(pt => pt.GroupId),
                    j =>
                    {
                        j.HasKey(t => new { t.GroupId, t.UserId });
                    });
        }
    }
}
