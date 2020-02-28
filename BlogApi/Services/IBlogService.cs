using System.Collections.Generic;
using BlogApi.Data.Models;

namespace BlogApi.Services
{
    public interface IBlogService
    {
        BlogDTO Get(int id);
        List<BlogDTO> GetAll();
        BlogDTO Add(BlogDTO entity);
        int Update(BlogDTO blogDTO);
        bool Delete(int id);

    }
}