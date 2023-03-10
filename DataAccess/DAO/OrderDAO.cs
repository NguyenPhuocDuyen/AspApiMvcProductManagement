using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new MyDbContext())
                {
                    orders = context.Orders.Include(o => o.Member).Include(o => o.OrderDetails).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public static Order FindOrderById(int orderId)
        {
            Order p = new Order();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Orders.Include(o => o.Member).SingleOrDefault(x => x.OrderId == orderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static void SaveOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Order>(order).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p = context.Orders.SingleOrDefault(
                        c => c.OrderId == order.OrderId);
                    context.Orders.Remove(p);
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
