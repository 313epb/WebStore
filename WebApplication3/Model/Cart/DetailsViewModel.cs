using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Model.Order;

namespace WebApplication3.Model.Cart
{
    public class DetailsViewModel
    {
        public CartViewModel CartViewModel { get; set; }

        public  OrderViewModel OrderViewModel { get; set; }
    }
}
