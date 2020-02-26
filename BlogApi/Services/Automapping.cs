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
        }
    }
}