using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entities;

namespace Services
{
    public interface IOrdersServices
    {
        Task<List<OrderDto>> GetOrders();
        Task AddOrder(OrderDto orderDto);

    }
}
