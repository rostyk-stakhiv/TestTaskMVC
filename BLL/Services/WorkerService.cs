using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validations;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _repository;
        private readonly IMapper _mapper;
        public WorkerService(IWorkerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(WorkerModel model)
        {
            var worker = _mapper.Map<Worker>(model);
            Validation.ValidateWorker(worker);
            await _repository.AddAsync(worker);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _repository.DeleteByIdAsync(modelId);
        }

        public IEnumerable<WorkerModel> GetAll()
        {
            return _mapper.Map<List<WorkerModel>>(_repository.GetAll());
        }

        public async Task<WorkerModel> GetByIdAsync(int id)
        {
            var worker = await _repository.GetByIdAsync(id);
            return _mapper.Map<WorkerModel>(worker);
        }

        public async Task ReadFromCSV(Stream file)
        {
            using var reader = new StreamReader(file);

            var str = reader.ReadLine();
            while (str != null)
            {
                var fields = str.Split(",");
                var model = new WorkerModel()
                {
                    Name = fields[0],
                    DateOfBirth = Convert.ToDateTime(fields[1]),
                    Married = Convert.ToBoolean(fields[2]),
                    Phone = fields[3],
                    Salary = Convert.ToDecimal(fields[4])
                };
                try
                {
                    await AddAsync(model);
                }
                catch
                {
                    continue;
                }
                str = reader.ReadLine();
            }

        }

        public async Task UpdateAsync(WorkerModel model)
        {
            var worker = _mapper.Map<Worker>(model);
            Validation.ValidateWorker(worker);
            await _repository.UpdateAsync(worker);
        }
    }
}
