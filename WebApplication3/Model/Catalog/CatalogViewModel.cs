using System.Collections.Generic;

namespace WebApplication3.Model
{
    public class CatalogViewModel
    {
        public int? BrandId { get; set; }
        public int? SectionId { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }

}