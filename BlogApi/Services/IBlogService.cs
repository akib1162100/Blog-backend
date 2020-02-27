using System.Collections.Generic;
using BlogApi.Data.Models;

namespace BlogApi.Services
{
    public interface IBlogService
    {
        BlogDTO Get(int id);
        List<BlogDTO> GetAll();
        BlogDTO Add(BlogDTO entity);
        Blog Update(Blog blog);
        // Blog Delete(int id);

    }
}