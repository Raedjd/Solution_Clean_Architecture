using AutoMapper;
using SolutionProject.Application.DataTransfertObject;
using SolutionProject.Application.Feature.Users.Commands.AddUser;
using SolutionProject.Application.Feature.Users.Commands.UpdateUser;
using SolutionProject.Domain.Entities;


namespace SolutionProject.Application.Common.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() {

            CreateMap<User, UserDto>();
            CreateMap<AddUserCommand, User>(); 
            CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
