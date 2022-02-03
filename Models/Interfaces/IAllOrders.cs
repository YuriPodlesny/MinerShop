using System.Collections.Generic;
using MinerShop.Models.Orders;

namespace MinerShop.Models
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);

        public IEnumerable<OrderDetail> GetOrderDetailJoinProductByOrderId(int orderId);
    }
}