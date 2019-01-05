using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebApplication3.Model.SQl
{
    public class SQLProductData:IProductData
    {
        private readonly WebStoreContext _context;

        public SQLProductData(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Section> GetSections()
        {
            return _context.Section.ToList();
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.Include("Section").Include("Brand").AsQueryable();
            if ((filter.Ids!=null)&& (filter.Ids.Count > 0))
            {
                query = query.Where(c => filter.Ids.Contains(c.Id));
            }
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c => c.SectionId.Equals(filter.SectionId.Value));
            return query.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include("Section").Include("Brand").FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}