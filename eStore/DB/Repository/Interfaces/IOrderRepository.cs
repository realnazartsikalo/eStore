using eStore.AppSystem;

namespace eStore.DB.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrderById(int orderId);
        IEnumerable<Order> GetOrdersByUserId(int userId);
        void AddOrder(Order order);
    }
}