using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        protected readonly WorkerDbContext _context;
        private readonly DbSet<Worker> _enteties;
        public WorkerRepository(WorkerDbContext context)
        {
            _context = context;
            _enteties = context.Set<Worker>();
        }
        public async Task AddAsync(Worker entity)
        {
            await _enteties.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _enteties.SingleOrDefaultAsync(s => s.Id == id);
            _enteties.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Worker> GetAll()
        {
            return _enteties;
        }

        public async Task<Worker> GetByIdAsync(int id)
        {
            var entity = await _enteties.SingleOrDefaultAsync(s => s.Id == id); 

            return entity;
        }

        public async Task UpdateAsync(Worker entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
