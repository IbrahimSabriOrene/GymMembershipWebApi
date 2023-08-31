using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberInfo.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace MemberInfo.Infrastructure.Persistence
{
    public class MemberInfoDbContext : DbContext
    {
        public MemberInfoDbContext(DbContextOptions<MemberInfoDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MemberInfoDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        
        
    }
}