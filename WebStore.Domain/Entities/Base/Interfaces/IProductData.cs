using System.Collections;
using System.Collections.Generic;

namespace WebStore.Domain.Entities.Base.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
        Product GetProductById(int id);
    }
}