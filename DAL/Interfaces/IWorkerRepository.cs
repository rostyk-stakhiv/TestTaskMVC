using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IWorkerRepository
    {
        IQueryable<Worker> GetAll();

        Task<Worker> GetByIdAsync(int id);
        
        Task AddAsync(Worker entity);
        
        Task UpdateAsync(Worker entity);

        Task DeleteByIdAsync(int id);
    }
}