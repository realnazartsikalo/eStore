using eStore.DB;
using eStore.AppSystem;
using eStore.DB.Repository.Interfaces;

namespace eStore.DB.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _context;

        public OrderRepository(DbContext context)
        {
            _context = context;
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders.Where(o => o.User.Id == userId).ToList();
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            order.Id = _context.Orders.Count + 1;
            _context.Orders.Add(order);
        }
    }
}