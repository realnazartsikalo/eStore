using eStore.DB.Service.Interfaces;

namespace eStore.DB.Controller
{
    public class CartController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public void AddToCart(int userId)
        {
            Console.WriteLine("Enter Product ID to add to your cart:");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid input. Please enter a valid Product ID.");
                return;
            }

            Console.WriteLine("Enter quantity:");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 1)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
                return;
            }

            try
            {
                _cartService.AddToCart(userId, productId, quantity);
                Console.WriteLine("Product added to cart successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewCart(int userId)
        {
            try
            {
                var cart = _cartService.ViewCart(userId);
                if (cart != null && cart.Products.Count > 0)
                {
                    foreach (var item in cart.Products)
                    {
                        Console.WriteLine($"Product: {item.Key.Name}, Price: {item.Key.Price}, Quantity: {item.Value}");
                    }
                    Console.WriteLine($"Total Price: {cart.TotalPrice()}");
                }
                else
                {
                    Console.WriteLine("Your cart is empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ClearCart(int userId)
        {
            try
            {
                _cartService.ClearCart(userId);
                Console.WriteLine("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}