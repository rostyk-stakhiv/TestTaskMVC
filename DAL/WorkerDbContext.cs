using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class WorkerDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public WorkerDbContext(DbContextOptions<WorkerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}