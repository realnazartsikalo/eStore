using eStore.AppSystem;
using eStore.DB.Repository.Interfaces;
using eStore.DB.Service.Interfaces;

namespace eStore.DB.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public void CreateOrder(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            if (!user.Cart.Products.Any())
            {
                throw new InvalidOperationException("Your cart is empty.");
            }
            
            if(user.Balance < user.Cart.TotalPrice())
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            var order = new Order
            {
                User = user,
                OrderDate = DateTime.Now,
                Products = new Dictionary<int, int>(user.Cart.Products.ToDictionary(p => p.Key.Id, p => p.Value))
            };

            _orderRepository.AddOrder(order);
            user.Balance -= user.Cart.TotalPrice();
            user.Cart.ClearCart();
        }

        public IEnumerable<Order> GetUserOrders(int userId)
        {
            return _orderRepository.GetOrdersByUserId(userId);
        }
    }
}