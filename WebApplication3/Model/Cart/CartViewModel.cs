using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Model.Cart
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel,int> Items { get; set; }
        public int ItemsCount
        {
            get => Items?.Sum(x => x.Value) ?? 0;
        }
    }
}