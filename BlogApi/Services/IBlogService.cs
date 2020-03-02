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
        DbResponse Update(BlogDTO blogDTO);
        DbResponse Delete(int id);

    }
}