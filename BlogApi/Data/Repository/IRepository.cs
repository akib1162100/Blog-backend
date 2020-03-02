using System.Collections.Generic;
using BlogApi.Data;
namespace BlogApi.Data.Repository
{
    public interface IRepository<IdType, EntityType>
    {
        EntityType Get(IdType id);
        List<EntityType> GetAll();
        int Add(EntityType entity);
        DbResponse Update(IdType id);
        DbResponse Delete(IdType id);
    }
}