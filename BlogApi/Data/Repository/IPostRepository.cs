using System.Collections.Generic;
using BlogApi.Data;
using BlogApi.Data.Models;

namespace BlogApi.Data.Repository
{
    public interface IPostRepository<IdType, EntityType>
    {
        EntityType Get(IdType id);
        List<EntityType> GetAll();
        int Add(EntityType entity);
        DbResponse Update(BlogDTO  blogDTO);
        DbResponse Delete(IdType id,string userId);
    }
}