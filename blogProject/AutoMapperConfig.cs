using AutoMapper;
using blogProject.Entities;
using blogProject.Models;


namespace blogProject
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User,UserViewModel>().ReverseMap();
            CreateMap<User, CreateUserViewModel>().ReverseMap();
            CreateMap<User, EditUserViewModel>().ReverseMap();
        }
    }
}
