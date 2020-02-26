using System.Collections.Generic;

namespace BlogApi.Services
{
    public interface IPostService<IdType, EntityType>
    {
        EntityType Get(IdType id);
        List<EntityType> GetAll();
        // bool Add(EntityType entity);
        EntityType Update(EntityType entity);
        EntityType Delete(IdType id);

    }
}