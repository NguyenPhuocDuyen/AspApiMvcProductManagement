using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<OrderDetail>().HasKey(p => new { p.OrderId, p.ProductId });

            optionsBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "KATANA" },
                new Category { CategoryId = 5, CategoryName = "FuShi" },
                new Category { CategoryId = 6, CategoryName = "MaleWe" },
                new Category { CategoryId = 7, CategoryName = "Posia" },
                new Category { CategoryId = 8, CategoryName = "CamDaka" },
                new Category { CategoryId = 9, CategoryName = "Rikiko" },
                new Category { CategoryId = 10, CategoryName = "Grains/Cereals" }
                );

            optionsBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Iphone", UnitPrice = 10, UnitsInStock = 1, CategoryId = 5, Weight = 10},
                new Product { ProductId = 2, ProductName = "Sam Sung", UnitPrice = 20, UnitsInStock = 2, CategoryId = 4, Weight = 20 },
                new Product { ProductId = 3, ProductName = "Nokia", UnitPrice = 30, UnitsInStock = 3, CategoryId = 3, Weight =30 },
                new Product { ProductId = 4, ProductName = "Huwai", UnitPrice = 40, UnitsInStock = 4, CategoryId = 2, Weight = 40 },
                new Product { ProductId = 5, ProductName = "Cuc Gach", UnitPrice = 50, UnitsInStock = 5, CategoryId = 1, Weight = 50 }
                );

            optionsBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, Email = "cus1@gmail.com", CompanyName = "ABC", City = "Can Tho", Country = "Viet Nam", Password = "cus1@gmail.com"},
                new Member { MemberId = 2, Email = "cus2@gmail.com", CompanyName = "Hung Thinh", City = "MaBu", Country = "HaWai", Password = "cus2@gmail.com" },
                new Member { MemberId = 3, Email = "cus3@gmail.com", CompanyName = "Hoang Thanh", City = "HaTi", Country = "New Tork", Password = "cus3@gmail.com" },
                new Member { MemberId = 4, Email = "cus4@gmail.com", CompanyName = "Iuke", City = "KuBa", Country = "Canada", Password = "cus4@gmail.com" },
                new Member { MemberId = 5, Email = "cus5@gmail.com", CompanyName = "AVC", City = "AVC", Country = "Japan", Password = "cus5@gmail.com" }
                );
            optionsBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, MemberId = 3},
                new Order { OrderId = 2, MemberId = 2},
                new Order { OrderId = 3, MemberId = 1},
                new Order { OrderId = 4, MemberId = 4},
                new Order { OrderId = 5, MemberId = 5}
                );
            optionsBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderId = 3, ProductId = 5, UnitPrice = 100, Quantity = 11, Discount = 10},
                new OrderDetail { OrderId = 2, ProductId = 3, UnitPrice = 99, Quantity = 22, Discount = 10},
                new OrderDetail { OrderId = 1, ProductId = 2, UnitPrice = 88, Quantity = 33, Discount = 10},
                new OrderDetail { OrderId = 2, ProductId = 4, UnitPrice = 77, Quantity = 44, Discount = 10},
                new OrderDetail { OrderId = 3, ProductId = 1, UnitPrice = 12, Quantity = 55, Discount = 10},
                new OrderDetail { OrderId = 4, ProductId = 2, UnitPrice = 53, Quantity = 44, Discount = 10},
                new OrderDetail { OrderId = 4, ProductId = 3, UnitPrice = 22, Quantity = 88, Discount = 10},
                new OrderDetail { OrderId = 5, ProductId = 4, UnitPrice = 76, Quantity = 23, Discount = 10},
                new OrderDetail { OrderId = 5, ProductId = 5, UnitPrice = 11, Quantity = 44, Discount = 10}
                );
        }
    }
}
