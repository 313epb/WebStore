using System;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Base;

namespace WebStore.DAL
{
    public class WebStoreContext:IdentityDbContext<User>
    {
        public  WebStoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Section { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
