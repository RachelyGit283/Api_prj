using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class OrdersData : IOrdersData
    {
        StoreDB215085283Context _StoreDB215085283Context;

        public OrdersData(StoreDB215085283Context storeDB215085283Context)
        {
            _StoreDB215085283Context = storeDB215085283Context;
        }

        public async Task<List<Order>> GetOrders()
        {
            try
            {
                return await _StoreDB215085283Context.Orders.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new CustomApiException(500, "Error reading orders from DB " + ex.Message);
            }
        }

        public async Task AddOrder(Order order)
        {
            try
            {
                await _StoreDB215085283Context.Orders.AddAsync(order);
                await _StoreDB215085283Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomApiException(500, "Error writing order to DB: " + ex.Message);
            }
        }

    }
}
