using System.Collections.Generic;
using BlogApi.Data.Models;
using BlogApi.Data;

namespace BlogApi.Services
{
    public interface IBlogService
    {
        BlogDTO Get(int id);
        List<BlogDTO> GetAll();
        (BlogDTO blogDTO, DbResponse response) Add(BlogDTO entity,string uId);
        DbResponse Update(BlogDTO blogDTO, string uId);
        DbResponse Delete(int id, string uId);
    }
}