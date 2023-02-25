using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var orderdetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyDbContext())
                {
                    orderdetails = context.OrderDetails.Include(od => od.Order).Include(od=>od.Product).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderdetails;
        }

        public static OrderDetail FindOrderDetailById(int propId, int orderId)
        {
            OrderDetail p = new OrderDetail();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.OrderDetails.Include(od => od.Order).Include(od => od.Product).SingleOrDefault(x => x.ProductId == propId && x.OrderId == orderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public static void SaveOrderDetail(OrderDetail orderdetail)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.OrderDetails.Add(orderdetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateOrderDetail(OrderDetail orderdetail)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<OrderDetail>(orderdetail).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrderDetail(OrderDetail orderdetail)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p = context.OrderDetails.SingleOrDefault(
                        c => c.ProductId == orderdetail.ProductId
                        && c.OrderId == orderdetail.OrderId);
                    context.OrderDetails.Remove(p);
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
