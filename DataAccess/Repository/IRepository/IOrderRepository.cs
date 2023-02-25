using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IOrderRepository
    {
        void SaveOrder(Order order);
        Order GetOrderById(int id);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);

        List<Order> GetOrders();
    }
}
