using System;
using System.Collections;
using System.Collections.Generic;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain
{
    public class Brand:NamedEntity,IOrderedEntity
    {
        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
