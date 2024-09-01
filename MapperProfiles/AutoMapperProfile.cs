using AutoMapper;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;

namespace JobSearchAppBackend.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();

        }
    }
}
