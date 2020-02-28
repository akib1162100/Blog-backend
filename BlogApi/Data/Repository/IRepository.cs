using System.Collections.Generic;

namespace BlogApi.Data.Repository
{
    public interface IRepository<IdType, EntityType>
    {
        EntityType Get(IdType id);
        List<EntityType> GetAll();
        int Add(EntityType entity);
        bool Update(IdType id);
        EntityType Delete(IdType id);
    }
}