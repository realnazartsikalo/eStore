using eStore.AppSystem;

namespace eStore.DB.Service.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(int userId);
        IEnumerable<Order> GetUserOrders(int userId);
    }
}
