using System.Collections.Generic;
using BlogApi.Data.Models;
using BlogApi.Data;

namespace BlogApi.Services
{
    public interface IBlogService
    {
        BlogDTO Get(int id);
        List<BlogDTO> GetAll();
        BlogDTO Add(BlogDTO entity,string userId);
        DbResponse Update(BlogDTO blogDTO, string userId);
        DbResponse Delete(int id, string userId);

    }
}