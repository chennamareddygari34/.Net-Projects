using AutoMapper;
using CompanyApplication.Models;
using CompanyWebApiApp.Models.DTOs;

namespace CompanyWebApiApp.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
        }
    }
}
