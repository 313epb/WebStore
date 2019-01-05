using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Model.Cart
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public int ItemsCount
        {
            get => Items?.Sum(x => x.Quantity) ?? 0;
        }
    }
}