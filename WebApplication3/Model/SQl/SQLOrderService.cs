using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Model.Cart;
using WebApplication3.Model.Order;
using WebStore.DAL;
using WebStore.Domain.Entities;

namespace WebApplication3.Model.SQl
{
    public class SqlOrderService:IOrderService
    {
        private readonly WebStoreContext _context;
        private readonly UserManager<User> _userManager;

        public SqlOrderService(WebStoreContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<WebStore.Domain.Entities.Order> GetUSerOrders(string userName)
        {
            return _context.Orders.Include("User").Include("OrderItems").Where(o => o.User.UserName.Equals(userName))
                .ToList();
        }

        public WebStore.Domain.Entities.Order GetOrderById(int id)
        {
            return _context.Orders.Include("OrderItems").FirstOrDefault(o => o.Id.Equals(id));
        }

        public WebStore.Domain.Entities.Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName)
        {
            User user = null;
            if (userName != null)
                user = _userManager.FindByNameAsync(userName).Result;
            using (var transaction = _context.Database.BeginTransaction())
            {
                var order = new WebStore.Domain.Entities.Order()
                {
                    Address = orderModel.Address,
                    Name = orderModel.Name,
                    User = user,
                    Phone = orderModel.Phone,
                    Date = DateTime.Now
                };
                _context.Orders.Add(order);


                foreach (var item in transformCart.Items)
                {
                    var productVm = item.Key;
                    var product = _context.Products.FirstOrDefault(p => p.Id.Equals(productVm.Id));
                    if (product == null)
                        throw new InvalidOperationException("Продукт не найден");
                    var orderItem = new OrderItem()
                    {
                        Order = order,
                        Price = product.Price,
                        Quantity = item.Value,
                        Product = product
                    };
                    _context.OrderItems.Add(orderItem);
                }

                _context.SaveChanges();
                transaction.Commit();
                return order;
            }
        }
    }
}