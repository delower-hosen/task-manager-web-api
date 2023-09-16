using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Services
{
    public static class EntityInfoService
    {
        public static EntityBase AddBasicEntityInfo(this EntityBase entity)
        {
            entity.ItemId ??= Guid.NewGuid().ToString();
            entity.CreateDate = DateTime.UtcNow;
            entity.LastUpdateDate = DateTime.UtcNow;
            entity.Tags ??= Array.Empty<string>();
            return entity;
        }
    }
}
