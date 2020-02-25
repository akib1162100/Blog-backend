using System.Collections.Generic;

namespace BlogApi.Services
{
    public interface IDbService<IdType, EntityType>
    {
        EntityType Get(IdType id);
        List<EntityType> GetAll();
        // EntityType Add(EntityType entity);
        EntityType Update(EntityType entity);
        EntityType Delete(IdType id);
    }
}