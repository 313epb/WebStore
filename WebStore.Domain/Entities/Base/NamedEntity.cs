using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    public class NamedEntity:BaseEntity, INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}