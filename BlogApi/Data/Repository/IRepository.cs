using System.Collections.Generic;
using BlogApi.Data;
using BlogApi.Data.Models;

namespace BlogApi.Data.Repository
{
    public interface IRepository
    {
        Blog Get(int id);
        List<Blog> GetAll();
        int Add(Blog entity);
        DbResponse Update(BlogDTO blogDTO,string uId);
        DbResponse Delete(int id, string uId);
    }
}