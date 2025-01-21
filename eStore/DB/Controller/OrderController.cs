using eStore.DB.Service.Interfaces;

namespace eStore.DB.Controller
{
    public class OrderController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void CreateOrder(int userId)
        {
            try
            {
                _orderService.CreateOrder(userId);
                Console.WriteLine("Order created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewOrderHistory(int userId)
        {
            try
            {
                var orders = _orderService.GetUserOrders(userId);
                if (orders != null && orders.Any())
                {
                    Console.WriteLine("Order History:");
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Order ID: {order.Id}, Date: {order.OrderDate}");
                        Console.WriteLine("Products:");
                        foreach (var productId in order.Products.Keys)
                        {
                            Console.WriteLine($"Product ID: {productId}, Quantity: {order.Products[productId]}");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No order history available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}