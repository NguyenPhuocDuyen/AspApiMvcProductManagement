using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository
    {
        void SaveOrderDetail(OrderDetail orderDetail);
        OrderDetail GetOrderDetailById(int propId, int orderId);
        void DeleteOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);

        List<OrderDetail> GetOrderDetails();
    }
}
