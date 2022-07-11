using BLL.Models;

namespace TestTaskMVC.Models
{
    public class WorkersViewModel
    {
        public IEnumerable<WorkerModel> Workers { get; set; }
        public WorkersViewModel(IEnumerable<WorkerModel> workers)
        {
            Workers = workers;  
        }
        
    }
}
