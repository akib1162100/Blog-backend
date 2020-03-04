using AutoMapper;
using BlogApi.Data.Models;
namespace BlogApi.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BlogDTO, Blog>();
            CreateMap<Blog, BlogDTO>();
            CreateMap<UserRegistrationDTO,User>();
            CreateMap<UserDTO,User>();
            CreateMap<User,UserDTO>();
            CreateMap<User,UserRegistrationDTO>();
        }
    }
}