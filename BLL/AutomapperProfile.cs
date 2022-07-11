using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Worker, WorkerModel>()
                .ForMember(p => p.Id, c => c.MapFrom(worker => worker.Id))
                .ForMember(p => p.Name, c => c.MapFrom(worker => worker.Name))
                .ForMember(p => p.DateOfBirth, c => c.MapFrom(worker => worker.DateOfBirth))
                .ForMember(p => p.Married, c => c.MapFrom(worker => worker.Married))
                .ForMember(p => p.Phone, c => c.MapFrom(worker => worker.Phone))
                .ForMember(p => p.Salary, c => c.MapFrom(worker => worker.Salary))
                .ReverseMap();
        }
    }
}