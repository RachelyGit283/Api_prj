
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
