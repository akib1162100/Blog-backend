using System.Collections.Generic;
using BlogApi.Data.Models;
using BlogApi.Data;

namespace BlogApi.Services
{
    public interface IBlogService
    {
        BlogDTO Get(int id);
        List<BlogDTO> GetAll();
        BlogDTO Add(BlogDTO entity);
        MessageEnum Update(BlogDTO blogDTO);
        MessageEnum Delete(int id);

    }
}