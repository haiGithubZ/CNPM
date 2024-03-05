using AutoMapper;
using System.Linq;
using Jhipster.Domain;
using SportSvc.Application.Commands.ShoppingCartss;
using SportSvc.Domain.Entities;
using Jhipster.Dto;

namespace Jhipster.Configuration.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, Dto.UserDto>()
                .ForMember(userDto => userDto.Roles, opt => opt.MapFrom(user => user.UserRoles.Select(iur => iur.Role.Name).ToHashSet()))
            .ReverseMap()
                .ForPath(user => user.UserRoles, opt => opt.MapFrom(userDto => userDto.Roles.Select(role => new UserRole { Role = new Role { Name = role }, UserId = userDto.Id }).ToHashSet()))
            .ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            //CreateMap<User, UserDto>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
        }
    }
}
