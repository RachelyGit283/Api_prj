using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities
;
namespace Repositories
{
    public interface IOrdersData
    {
        Task<List<Order>> GetOrders();

        Task AddOrder(Order order);
    }
}
