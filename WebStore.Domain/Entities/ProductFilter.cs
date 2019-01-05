using System.Collections.Generic;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    public class ProductFilter
    {
        /// <summary>
        /// Секция, к которой принадлежит товар
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

        public List<int> Ids { get; set; }
    }

}