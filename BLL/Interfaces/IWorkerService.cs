using BLL.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IWorkerService
    {
        IEnumerable<WorkerModel> GetAll();

        Task<WorkerModel> GetByIdAsync(int id);

        Task AddAsync(WorkerModel model);

        Task UpdateAsync(WorkerModel model);

        Task ReadFromCSV(Stream file);
        Task DeleteByIdAsync(int modelId);
    }
}
