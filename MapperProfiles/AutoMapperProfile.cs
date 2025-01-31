using AutoMapper;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;

namespace JobSearchAppBackend.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<JobListing, JobListingDTO>().ReverseMap();
            CreateMap<JobListing, JobListingCreateDTO>().ReverseMap();

        }
    }
}
