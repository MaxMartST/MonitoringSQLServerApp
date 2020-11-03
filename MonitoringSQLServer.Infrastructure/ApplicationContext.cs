using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;

namespace MonitoringSQLServer.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<RoleGroup> RoleGroup { get; set; }

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

            modelBuilder.Entity<RoleGroup>()
                .HasKey(bc => new { bc.RoleId, bc.GroupId });
            modelBuilder.Entity<RoleGroup>()
                .HasOne(bc => bc.Role)
                .WithMany(b => b.RoleGroups)
                .HasForeignKey(bc => bc.RoleId);
            modelBuilder.Entity<UserGroup>()
                .HasOne(bc => bc.Group)
                .WithMany(c => c.UserGroups)
                .HasForeignKey(bc => bc.GroupId);
        }
    }
}
