using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonitoringSQLServer.Domain;

namespace MonitoringSQLServer.Infrastructure
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public DbSet<OrderItem> OrderItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating( builder );
            
            builder.ApplyConfiguration( new GroupMap() );

            // Imagine a ton more customizations
        }
    }
}
