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
            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserRegisterDTO>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, AuthorDTO>();
            CreateMap<AuthorDTO,User>();
        }
    }
}