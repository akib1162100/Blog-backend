using System.Collections.Generic;
using BlogApi.Data.Models;

namespace BlogApi.Services
{
    public interface IBlogService
    {
        BlogDTO Get(int id);
        List<BlogDTO> GetAll();
        // bool Add(EntityType entity);
        Blog Update(Blog blog);
        Blog Delete(int id);

    }
}