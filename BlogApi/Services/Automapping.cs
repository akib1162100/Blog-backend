using AutoMapper;
using BlogApi.Models;
namespace BlogApi.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BlogDTO, Blog>();
        }
    }
}