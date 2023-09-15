using MongoDB.Bson.Serialization.Attributes;

namespace TaskManager.Domain.Entities
{
    [BsonIgnoreExtraElements(Inherited = true)]
    public class EntityBase
    {
        [BsonId]
        public string ItemId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string[] Tags { get; set; }
    }
}
