using System.Collections.Generic;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebApplication3.Model
{
    public class SectionViewModel:INamedEntity,IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public SectionViewModel()
        {
            ChildSections= new List<SectionViewModel>();
        }

        public List<SectionViewModel> ChildSections { get; set; }
        public SectionViewModel ParentSection { get; set; }

    }

}