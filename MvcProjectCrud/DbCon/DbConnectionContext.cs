using Microsoft.EntityFrameworkCore;
using MvcProjectCrud.Models;

namespace MvcProjectCrud.DbCon
{
    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext(DbContextOptions<DbConnectionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
           .HasKey(e => e.IdNumber);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
