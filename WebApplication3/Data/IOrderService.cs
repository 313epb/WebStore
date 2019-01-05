using System.Collections.Generic;
using WebApplication3.Model.Cart;
using WebApplication3.Model.Order;
using WebStore.Domain.Entities;

namespace WebApplication3.Data
{
    public interface IOrderService
    {
        IEnumerable<Order> GetUSerOrders(string userName);
        Order GetOrderById(int id);
        Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName);
    }
}