using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var context = new MyDbContext())
                {
                    products = context.Products.Include(p=>p.Category).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static Product FindProductById(int propId)
        {
            Product p = new Product();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Products.Include(p => p.Category).SingleOrDefault(x => x.ProductId == propId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Product>(product).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p = context.Products.SingleOrDefault(
                        c => c.ProductId == product.ProductId);
                    context.Products.Remove(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
