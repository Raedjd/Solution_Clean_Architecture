using AutoMapper;
using SolutionProject.Application.DataTransfertObject;
using SolutionProject.Domain.Entities;


namespace SolutionProject.Application.Common.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() {

            CreateMap<User, UserDto>();
        }
    }
}
