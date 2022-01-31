using DBApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.DAL
{
    public class DBApiContext:DbContext    {
        public DBApiContext(DbContextOptions<DBApiContext> options) : base(options)
        {

        }
        public DbSet<Response> MaxAmountCode { get; set; }
        public DbSet<Order> OrderData { get; set; }
        public DbSet<Agent> AgentData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Response>().HasNoKey().ToView(null);
            modelBuilder.Entity<Order>().HasNoKey().ToView(null);
            modelBuilder.Entity<Agent>().HasNoKey().ToView(null);
        }
    }
}
